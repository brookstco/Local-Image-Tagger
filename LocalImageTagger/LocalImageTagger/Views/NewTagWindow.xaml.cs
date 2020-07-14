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
using System.Windows.Shapes;

namespace LocalImageTagger
{
    /// <summary>
    /// Interaction logic for NewTagWindow.xaml
    /// </summary>
    public partial class NewTagWindow : Window
    {
        public NewTagWindow()
        {
            InitializeComponent();
            //IDEA: Load thumbnails through multi-threading, so each can be seen and interacted with even as they load. Howver, UI can not be interacted with from a thread, so it may not be a btter option.
            //(Possibly each thumbnail as a seperate thread? This would allow smaller images to load faster as well. Additionally, lets it prioritize images in various ways, and have the number be dynamic, maybe)
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
