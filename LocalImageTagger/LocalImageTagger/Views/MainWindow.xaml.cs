using LocalImageTagger.ViewModels;
using LocalImageTagger.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LocalImageTagger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //IDEA: Load thumbnails through multi-threading, so each can be seen and interacted with even as they load. Howver, UI can not be interacted with from a thread, so it may not be a btter option.
        //(Possibly each thumbnail as a seperate thread? This would allow smaller images to load faster as well. Additionally, lets it prioritize images in various ways, and have the number be dynamic, maybe)

        public MainWindow()
        {
            InitializeComponent();

            //TODO: When closing, prompt about closing, and have a checkbox for not having that warning anymore
        }

        private void Test_Button_Click(object sender, RoutedEventArgs e)
        {
            ImageViewer popUp = new ImageViewer();
            popUp.Show();
        }

        private void Tag_Button_Click(object sender, RoutedEventArgs e)
        {
            NewTagWindow dialog = new NewTagWindow
            {
                Owner = this //Make this window the owner of the popup, so that it will show in the center.
            };
            dialog.Show();
        }
        private void Dir_Button_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new NewFileLocationWindow
            {
                Owner = this //Make this window the owner of the popup, so that it will show in the center.
            };
            dialog.Show();
        }
        private void Cat_Button_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new NewCategoryWindow
            {
                Owner = this //Make this window the owner of the popup, so that it will show in the center.
            };
            dialog.Show();
        }
    }
}
