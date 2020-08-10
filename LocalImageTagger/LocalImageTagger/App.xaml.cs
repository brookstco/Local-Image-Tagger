using LocalImageTagger.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace LocalImageTagger
{

    //TODO: Put this stuff where it belongs
    //This will be stored in a smallint field in the database


    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //TODO: Make this only have 1 instance up at a time. If it is already open, bring it to the front.
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            MainWindowViewModel mainVM = new MainWindowViewModel();
            //Link the view and VM
            mainWindow.DataContext = mainVM;

            mainWindow.Show();

            #region First-Time pop-up
            //Show a popup on the first time opening the program, or if the setting is toggled.

            //Have to Specify LIT since properties also belongs to app
            if (LocalImageTagger.Properties.Settings.Default.FirstTime == true || LocalImageTagger.Properties.Settings.Default.FirstTimePopUpDisplays == true)
            {
                FirstTimePopUp popup = new FirstTimePopUp
                {
                    Owner = mainWindow //The popup will load in the center of the main window of the window
                };
                popup.Show();

            }
            #endregion

            if (LocalImageTagger.Properties.Settings.Default.FirstTime == true)
            {
                LocalImageTagger.Properties.Settings.Default.FirstTime = false;
                LocalImageTagger.Properties.Settings.Default.Save();
            }

        }
    }
}
