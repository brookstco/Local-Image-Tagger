using LocalImageTagger.ViewModels;
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
            //TODO: I can use this same view for both add and edit. Pass in viewmodel to allow for either? Also needs more of the data to be bound anyway, but def for this.
            DataContext = new NewTagWindowViewModel();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
