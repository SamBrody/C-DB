using CSharpDB.Context;
using CSharpDB.Model;
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
            textBoxFirstNameSearch.Text = "";
            textBoxLastNameSearch.Text = "";
            DBCContext db = new DBCContext();
            db.UserStudents.Load();
            var student = (from st in db.UserStudents
                           join gr in db.Groups on st.IDGroup equals gr.IDGroup
                           select new
                           {
                               ID = st.IDUser,
                               FirstName = st.FirstName,
                               LastName = st.LastName,
                               GroupID = gr.GroupName
                           }).ToList();
            ObservableCollection<Object> oc = new ObservableCollection<object>(student);
            datagridStudentList.ItemsSource = oc;                       
        }

        private void SearchOnLastName()
        {
            DBCContext db = new DBCContext();
            if (comboBoxGroupNameSearch.SelectedIndex >= 0)
            {
                var student = (from st in db.UserStudents
                               where st.LastName.Contains(textBoxLastNameSearch.Text) && st.IDGroup == comboBoxGroupNameSearch.SelectedIndex + 1
                               join gr in db.Groups on st.IDGroup equals gr.IDGroup
                               select new
                               {
                                   ID = st.IDUser,
                                   FirstName = st.FirstName,
                                   LastName = st.LastName,
                                   GroupID = gr.GroupName
                               }).ToList();
                ObservableCollection<Object> oc = new ObservableCollection<object>(student);
                datagridStudentList.ItemsSource = oc;
            }
            else
            {
                var student = (from st in db.UserStudents
                               where st.LastName.Contains(textBoxLastNameSearch.Text)
                               join gr in db.Groups on st.IDGroup equals gr.IDGroup
                               select new
                               {
                                   ID = st.IDUser,
                                   FirstName = st.FirstName,
                                   LastName = st.LastName,
                                   GroupID = gr.GroupName
                               }).ToList();
                ObservableCollection<Object> oc = new ObservableCollection<object>(student);
                datagridStudentList.ItemsSource = oc;
            }           
        }

        private void SearchOnFirstName()
        {            
            DBCContext db = new DBCContext();
            if (comboBoxGroupNameSearch.SelectedIndex>=0)
            {
                var student = (from st in db.UserStudents
                               where st.FirstName.Contains(textBoxFirstNameSearch.Text) && st.IDGroup==comboBoxGroupNameSearch.SelectedIndex+1 
                               join gr in db.Groups on st.IDGroup equals gr.IDGroup
                               select new
                               {
                                   ID = st.IDUser,
                                   FirstName = st.FirstName,
                                   LastName = st.LastName,
                                   GroupID = gr.GroupName
                               }).ToList();
                ObservableCollection<Object> oc = new ObservableCollection<object>(student);
                datagridStudentList.ItemsSource = oc;
            }
            else
            {
                var student = (from st in db.UserStudents
                               where st.FirstName.Contains(textBoxFirstNameSearch.Text)
                               join gr in db.Groups on st.IDGroup equals gr.IDGroup
                               select new
                               {
                                   ID = st.IDUser,
                                   FirstName = st.FirstName,
                                   LastName = st.LastName,
                                   GroupID = gr.GroupName
                               }).ToList();
                ObservableCollection<Object> oc = new ObservableCollection<object>(student);
                datagridStudentList.ItemsSource = oc;
            }                       
        }

        private void SearchOnGroupName()
        {
            DBCContext db = new DBCContext();
            var student = (from st in db.UserStudents
                           where st.IDGroup==comboBoxGroupNameSearch.SelectedIndex+1
                           join gr in db.Groups on st.IDGroup equals gr.IDGroup
                           select new
                           {
                               ID = st.IDUser,
                               FirstName = st.FirstName,
                               LastName = st.LastName,
                               GroupID = gr.GroupName
                           }).ToList();
            ObservableCollection<Object> oc = new ObservableCollection<object>(student);
            datagridStudentList.ItemsSource = oc;
        }

        private void textBoxLastNameSearch_KeyDown(object sender, KeyEventArgs e)
        {
            SearchOnLastName();
        }

        private void textBoxLastNameSearch_KeyUp(object sender, KeyEventArgs e)
        {
            SearchOnLastName();
        }

        private void textBoxFirstNameSearch_KeyDown(object sender, KeyEventArgs e)
        {
            SearchOnFirstName();
        }

        private void textBoxFirstNameSearch_KeyUp(object sender, KeyEventArgs e)
        {
            SearchOnFirstName();
        }

        private void comboBoxGroupNameSearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SearchOnGroupName();
        }

        private void buttonCancelFilt_Click(object sender, RoutedEventArgs e)
        {
            SetDataGrid();
        }

        private void buttonGroupList_Click(object sender, RoutedEventArgs e)
        {
            OpenGoupList();
        }

        private void OpenGoupList()
        {
            GroupListWin groupListWin = new GroupListWin();
            groupListWin.Show();
        }
    }
}
