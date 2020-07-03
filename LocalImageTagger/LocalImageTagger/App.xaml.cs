﻿using System;
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
    public enum tagType : short
    {
        Unknown = 0,
        Standard,
        Alias
    }

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //TODO: Make this only have 1 instance up at a time. If it is already open, bring it to the front.
        private void Application_Startup(object sender, StartupEventArgs e)
        {

            MainWindow window = new MainWindow();
            //Test window = new Test();
            if (e.Args.Length >= 1)
            {
                //TODO: Command Line Searches
                //This will enable searching and other effects from the command line by adding the search terms as parameters on bootup
                //Open immediately in new tab if ones are saved from before?
            }
            window.Show();

            #region Globalization
            /*Globalization controls. Unneeded for now.
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US"); //Sets thread default culture- Use if I multithread
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en-US");

            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US"); //Sets number display culture
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US"); //Sets language deafult
            */
            #endregion

            #region First-Time pop-up
            //TODO: Open popup based on settings
            //Show a popup on the first time opening the program, or if the setting is toggled.
            //If firstTimeOpen setting is true
            FirstTimePopUp popup = new FirstTimePopUp
            {
                Owner = window //The popup will load in the center of the main window of the window
            };
            popup.Show();
            #endregion

        }
    }
}
