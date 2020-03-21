using CSharpDB.Context;
using CSharpDB.Model;
using CSharpProjCore.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
    /// Interaction logic for StudentList.xaml
    /// </summary>
    public partial class StudentList : Page
    {
        public StudentList()
        {
            InitializeComponent();
            StudentListViewModel studentListViewModel = new StudentListViewModel();
            this.DataContext = studentListViewModel;
        }

        private void buttonGroupList_Click(object sender, RoutedEventArgs e)
        {
            GroupListWin groupListWin = new GroupListWin();
            groupListWin.Show();
        }
    }
}
