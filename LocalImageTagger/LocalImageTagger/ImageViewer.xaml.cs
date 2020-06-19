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
        }

        protected int imageSelector = 0;
        void File_Open_Click(object sender, RoutedEventArgs e)
        {
            if (imageSelector == 0)
            {
                //Built from a few tutorials, so mixed style and naming for now, since this is all temporary anyway
                OpenFileDialog dlg = new OpenFileDialog
                {
                    InitialDirectory = "c:\\",
                    Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All Files (*.*)|*.*",
                    RestoreDirectory = true
                };

                if (dlg.ShowDialog() == true)
                {
                    string selectedFileName = dlg.FileName;
                    BitmapImage bitmap = new BitmapImage(); //Directly typing it is one option, or use var.
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(selectedFileName);
                    bitmap.EndInit();
                    largeImage.Source = bitmap;
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
    }
}
