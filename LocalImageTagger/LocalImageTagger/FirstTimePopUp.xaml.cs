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
using System.Diagnostics;
using System.Windows.Navigation;

namespace LocalImageTagger
{
    /// <summary>
    /// Interaction logic for FirstTimePopUp.xaml
    /// </summary>
    public partial class FirstTimePopUp : Window
    {
        public FirstTimePopUp()
        {
            InitializeComponent();
        }
        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            //TODO: Broken Hyperlinks 
            //Apparently this breaks because this is a .core type project. Not sure important, so will be ignored for now.
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Popup's checkbox for settings
            //Deal with the checkbox here. Changes app setting for the popup next time
            this.Close();
        }
    }
}
