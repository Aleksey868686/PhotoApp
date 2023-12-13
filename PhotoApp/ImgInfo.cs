using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoApp
{
    public class ImgInfo
    {
        public static string CameraFolder { get; }
        public ObservableCollection<Image> Images;

        static ImgInfo()
        {
            if (DeviceInfo.Platform == DevicePlatform.Android)
            {
                CameraFolder = "/storage/emulated/0/DCIM/Camera/";
            }
            else
            {
                throw new Exception("Unsupported Platform");
            }
        }

        public ImgInfo()
        {
            Images = new();
        }

        public ObservableCollection<Image> GetAllImages()
        {
            Images.Clear();
            string[] fileNames = Directory.GetFiles(CameraFolder);

            foreach (string f in fileNames)
            {
                FileInfo file = new FileInfo(f);
                string sName = file.Name;
                DateTime creationDate = file.CreationTime;

                Image item = new(f, sName, creationDate);

                Images.Add(item);
            }
            return Images;
        }
    }

    public class Image
    {
        public ImageSource Source { get; set; }
        public string ShortName { get; set; }
        public string CreationDate { get; set; }

        public Image(ImageSource src, string sName, DateTime creationDate)
        {
            Source = src;
            ShortName = sName;
            CreationDate = creationDate.ToString();
        }
    }
}
