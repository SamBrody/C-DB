using CSharpDB.Context;
using CSharpDB.Model;
using Microsoft.EntityFrameworkCore;
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
using System.Linq;

namespace CSharpProjCore.View
{
    /// <summary>
    /// Interaction logic for GroupListWin.xaml
    /// </summary>
    public partial class GroupListWin : Window
    {
        public GroupListWin()
        {
            InitializeComponent();

            SetDataGrid();
            bindComboGroup();
        }

        public List<Group> groups { get; set; }
        private void bindComboGroup()
        {
            DBCContext db = new DBCContext();
            var item = db.Groups.ToList();
            groups = item;
            DataContext = groups;
        }

        private void SetDataGrid()
        {
            comboBoxGroupNameSearch.SelectedIndex = -1;
            DBCContext db = new DBCContext();
            db.Groups.Load();
            var group = (from gr in db.Groups select gr).ToList();
            ObservableCollection<Object> oc = new ObservableCollection<object>(group);
            datagridGroupList.ItemsSource = oc;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void comboBoxGroupNameSearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SearchOnGroupName();
        }

        private void SearchOnGroupName()
        {
            DBCContext db = new DBCContext();
            var student = (from gr in db.Groups
                           where gr.IDGroup == comboBoxGroupNameSearch.SelectedIndex + 1                          
                           select gr).ToList();
            ObservableCollection<Object> oc = new ObservableCollection<object>(student);
            datagridGroupList.ItemsSource = oc;
        }

        private void buttonCancelFilt_Click(object sender, RoutedEventArgs e)
        {
            SetDataGrid();
        }

        private void buttonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
