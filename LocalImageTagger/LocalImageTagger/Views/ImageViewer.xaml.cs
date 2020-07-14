using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using Microsoft.Win32;
using LocalImageTagger.ViewModels;

namespace LocalImageTagger
{
    /// <summary>
    /// Interaction logic for ImageViewer.xaml
    /// </summary>
    public partial class ImageViewer : Window
    {
        public ImageViewer()
        {
            InitializeComponent();
            
            DataContext = new ImageViewerViewModel();
        }

        //TODO: Have the size of the popped out video player adjust based on video versus photo, but go back to the old user size if a pi is opened back up afterwards
        //IDEA: Multi-thread loading higher-resolutions, so a smaller preview can be seen immediately, and the full image will load at its own pace, for large images at least.
        
        /*
        protected int imageSelector = 0;
        protected bool fullSize = false;
        void File_Open_Click(object sender, RoutedEventArgs e)
        {
            if (imageSelector == 0)
            {
                //Built from a few tutorials, so mixed style and naming for now, since this is all temporary anyway
                OpenFileDialog dlg = new OpenFileDialog
                {
                    InitialDirectory = "c:\\",
                    Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|Video files (*.mp4)|*.mp4|All Files (*.*)|*.*",
                    RestoreDirectory = true
                };

                if (dlg.ShowDialog() == true)
                {
                    string selectedFileName = dlg.FileName;
                    string selectedFileExt = System.IO.Path.GetExtension(selectedFileName);

                    //Use an image player if an image, and a media player if it is a video
                    if (selectedFileExt == ".png" || selectedFileExt == ".jpg" || selectedFileExt == ".jpeg")
                    {
                        videoPlayer.Source = null;
                        BitmapImage bitmap = new BitmapImage(); //Directly typing it is one option, or use var.
                        bitmap.BeginInit();
                        bitmap.UriSource = new Uri(selectedFileName);
                        bitmap.EndInit();
                        largeImage.Source = bitmap;
                    }
                    else if (selectedFileExt == ".mp4")
                    {
                        largeImage.Source = null;

                        videoPlayer.Source = new Uri(selectedFileName);
                        videoPlayer.Play(); //just autoplays since this is just a test
                    }
                }
            }
            else if(imageSelector == 1)
            {
                var path = Path.Join("C:", "IMAGETESTFOLDER", "cake.png"); //creates a path from strings   ///Environment.CurrentDirectory  --var works as dynamic typing, and is perfectly okay. Style thing
                var uri = new Uri(path); //Makes that path usable for the system
                var bitmap = new BitmapImage(uri); //creates an image file of that path
                largeImage.Source = bitmap; //tells the image to be the loaded image
                imageSelector++;
            }
            else
            {
                
                var path = Path.Join("C:", "IMAGETESTFOLDER", "IMG_20180727_093146327.jpg"); //creates a path from strings   ///Environment.CurrentDirectory
                var uri = new Uri(path); //Makes that path usable for the system
                var bitmap = new BitmapImage(uri); //creates an image file of that path
                largeImage.Source = bitmap; //tells the image to be the loaded image
                imageSelector--;
            }
        }

        private void BtnSizeSwap_Click(object sender, RoutedEventArgs e)
        {
            fullSize = !fullSize;
            if (fullSize)
            {
                largeImage.Stretch = Stretch.None;
            }
            else
            {
                largeImage.Stretch = Stretch.Uniform;
            }
        }*/
    }
}
