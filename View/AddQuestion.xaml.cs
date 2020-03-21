﻿using CSharpProjCore.ViewModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CSharpProjCore.View
{
    /// <summary>
    /// Interaction logic for AddQuestion.xaml
    /// </summary>
    public partial class AddQuestion : Page
    {
        public AddQuestion()
        {
            InitializeComponent();
            this.DataContext = new AddQuestionViewModel();
        }

        private void buttonGototheme_Click(object sender, RoutedEventArgs e)
        {
            ThemeListWin themeListWin = new ThemeListWin();
            themeListWin.Show();
        }

        private void buttonGototest_Click(object sender, RoutedEventArgs e)
        {
            TestListWin testListWin = new TestListWin();
            testListWin.Show();
        }
    }
}