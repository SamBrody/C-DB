﻿using CSharpDB.Model;
using CSharpProjCore.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CSharpProjCore.View
{
    /// <summary>
    /// Interaction logic for TestingWin.xaml
    /// </summary>
    public partial class TestingWin : Window
    {
        bool CheckButtonClick = false;
        public TestingWin(string username, int test)
        {
            InitializeComponent();
            this.DataContext = new TestingViewModel();
            textboxUN.Text = username;
            textboxID.Text = test.ToString();
        }

        private void buttonCloseWindow_Click(object sender, RoutedEventArgs e)
        {
            CheckButtonClick = true;
            MainWindow mainWindow = new MainWindow(textboxUN.Text);
            mainWindow.Show();
            this.Close();
        }

        private void pgae_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void pgae_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(CheckButtonClick!=true)
            {
                MainWindow mainWindow = new MainWindow(textboxUN.Text);
                mainWindow.Show();
            }  
        }
    }
}
