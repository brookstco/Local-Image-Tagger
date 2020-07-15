
using System.Windows;
using System.Diagnostics;
using System.Windows.Navigation;
using LocalImageTagger.ViewModels;

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
            DataContext = new FirstTimePopUpViewModel();
        }
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            //Without the UseShellExecute, this breaks.
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri) { UseShellExecute = true });
            e.Handled = true;
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Popup's checkbox for settings
            //Deal with the checkbox here. Changes app setting for the popup next time
            this.Close();
        }
    }
}
