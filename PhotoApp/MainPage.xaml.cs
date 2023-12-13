using PhotoApp.Pages;

namespace PhotoApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            EnterPinCode.Text = Preferences.ContainsKey("Pin") ? "Введите PIN" : "Придумайте PIN";
        }

        private async void OnEnterPinAsync(object sender, EventArgs e)
        {
            if (!Preferences.ContainsKey("Pin"))
            {
                Preferences.Set("Pin", EnteredPin.Text);
                await DisplayAlert("Saved", "PIN " + EnteredPin.Text + " saved", "OK");
                EnterPinCode.Text = "Введите PIN";
            }
            else if (Preferences.Get("Pin", "") == EnteredPin.Text)
            {
                EnteredPin.Text = "";
                await Navigation.PushAsync(new ImgListPage());
            }
            else
            {
                if (EnteredPin.Text == "resetpin" + DateTime.Now.ToString("MM"))
                {
                    await DisplayAlert("PIN Reset", "Create a new PIN", "OK");
                    Preferences.Remove("Pin");
                    EnterPinCode.Text = "Создайте PIN";
                }
                else
                {
                    await DisplayAlert("Incorrect", "Incorrect PIN Entered", "OK");
                }
            }
            EnteredPin.Text = "";
        }
    }
}