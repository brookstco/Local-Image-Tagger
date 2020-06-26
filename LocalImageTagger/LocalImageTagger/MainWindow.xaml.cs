﻿using System;
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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Test_Button_Click(object sender, RoutedEventArgs e)
        {
            ImageViewer popUp = new ImageViewer();
            popUp.Show();
        }

        private void Tag_Button_Click(object sender, RoutedEventArgs e)
        {
            NewTagWindow popUp = new NewTagWindow();
            popUp.Show();
        }
    }
}
