using System;
using System.IO;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace LocalImageTagger.ViewModels
{
    public class ImageDisplayViewModel : BaseViewModel
    {
        public int Stretch { get; set; }

        public BitmapImage Image { get; set; }

        public Uri ImageUri { get; set; } 

        public ImageDisplayViewModel()
        {
            Image = new BitmapImage(new Uri(Path.Join("C:", "Users", "Colin", "Pictures", "cat.png")));
            ImageUri = new Uri(Path.Join("C:", "Users", "Colin", "Pictures", "cat.png"));
            Stretch = 2; //"None";
        }

        public void swapSize()
        {
            if(Stretch == 0)
            {
                Stretch = 2;
            }
            else
            {
                Stretch = 0;
            }
        }
    }
}
