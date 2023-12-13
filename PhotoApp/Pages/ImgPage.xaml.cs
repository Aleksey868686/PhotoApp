namespace PhotoApp.Pages;

public partial class ImgPage : ContentPage
{
    Image ItemToDisplay { get; set; }
    public ImgPage()
	{
		InitializeComponent();
	}

    public ImgPage(Image selected)
    {
        InitializeComponent();
        img.Source = selected.Source.ToString().Substring(6);
        path.Text = selected.Source.ToString().Substring(6);
        dt.Text = String.Concat("Image created: ", selected.CreationDate.ToString());
    }
}