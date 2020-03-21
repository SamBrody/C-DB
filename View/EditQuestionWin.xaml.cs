using CSharpDB.Context;
using CSharpDB.Model;
using CSharpProjCore.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace CSharpProjCore.View
{
    /// <summary>
    /// Interaction logic for EditQuestionWin.xaml
    /// </summary>
    public partial class EditQuestionWin : Window
    {
        public EditQuestionWin(int selectedItemID)
        {
            InitializeComponent();
            this.DataContext = new EditQuestionViewModel();
            labelgetID.Content = selectedItemID.ToString();
            
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
