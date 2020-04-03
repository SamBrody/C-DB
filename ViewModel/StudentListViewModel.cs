using CSharpDB.Context;
using CSharpDB.Model;
using CSharpProjCore.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Data;
using System.Windows;
using CSharpProjCore.View;

namespace CSharpProjCore.ViewModel
{
    public class StudentListViewModel : BaseViewModel
    {
        DBCContext db = new DBCContext();

        #region Constructor
        public StudentListViewModel ()
        {            
            SetDataGrid();
            ComboBoxGroupSet();            
        }
        #endregion

        #region Commands
        RelayCommand clearDataCommand;
        RelayCommand searchOnLastName;
        RelayCommand searchOnFirstName;
        RelayCommand searchOnGroupName;
        RelayCommand deleteCommand;
        RelayCommand editCommand;
        RelayCommand updateCommand;

        public RelayCommand ClearDataCommand
        {
            get
            {
                return clearDataCommand ??
                  (clearDataCommand = new RelayCommand((o) =>
                  {
                      SetDataGrid();
                  }));
            }
        }
        public RelayCommand SearchOnLastName
        {
            get
            {
                return searchOnLastName ??
                  (searchOnLastName = new RelayCommand((o) =>
                  {
                      SearchLastName(o.ToString());
                  }));
            }
        }
        public RelayCommand SearchOnFirstName
        {
            get
            {
                return searchOnFirstName ??
                  (searchOnFirstName = new RelayCommand((o) =>
                  {
                      SearchFirstName(o.ToString());
                  }));
            }
        }
        public RelayCommand SearchOnGroupName
        {
            get
            {
                return searchOnGroupName ??
                  (searchOnGroupName = new RelayCommand((o) =>
                  {
                      SearchGroupName();
                  }));
            }
        }
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ??
                  (deleteCommand = new RelayCommand((o) =>
                  {
                      if(o!=null)
                      {
                          var studentLinq = (from st in db.UserStudents
                                         join gr in db.Groups on st.IDGroup equals gr.IDGroup
                                         select new
                                         {
                                             ID = st.IDUser,
                                             FirstName = st.FirstName,
                                             LastName = st.LastName,
                                             GroupID = gr.GroupName
                                         }).ToList();
                          var student = studentLinq.Where(a => a.Equals(o)).ToList();
                          int ID = student[0].ID;
                          UserStudent userStudent = db.UserStudents.Find(ID);
                          db.UserStudents.Remove(userStudent);
                          db.SaveChanges();                          
                          MessageBox.Show("Операция успешно выполнена!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                          SetDataGrid();
                      }
                  }));
            }
        }
        public RelayCommand EditCommand
        {
            get
            {
                return editCommand ??
                  (editCommand = new RelayCommand((o) =>
                  {
                  if (o != null)
                  {
                      var studentLinq = (from st in db.UserStudents
                                         join gr in db.Groups on st.IDGroup equals gr.IDGroup
                                         select new
                                         {
                                             ID = st.IDUser,
                                             FirstName = st.FirstName,
                                             LastName = st.LastName,
                                             GroupID = gr.GroupName
                                         }).ToList();
                      var student = studentLinq.Where(a => a.Equals(o)).ToList();
                      int ID = student[0].ID;
                      UserStudent userStudent = db.UserStudents.Find(ID);
                      EditStudent editStudent = new EditStudent(userStudent);
                      editStudent.Show();
                      }
                  }));
            }
        }
        public RelayCommand UpdateCommand
        {
            get
            {
                return updateCommand ??
                  (updateCommand = new RelayCommand((o) =>
                  {                      
                      SetDataGrid();
                  }));
            }
        }
        #endregion

        #region Properties
        private Object selectedStudent;
        public Object SelectedStudent
        {
            get { return selectedStudent; }
            set
            {
                selectedStudent = value;
                OnPropertyChanged("SelectedStudent");
            }
        }

        private int cbIndex;
        public int CBindex
        {
            get {return cbIndex; }
            set
            {
                cbIndex = value;
                OnPropertyChanged("CBindex");
            }
        }

        ObservableCollection<Object> userStudents;
        public ObservableCollection<Object> UserStudents
        {
            get { return userStudents; }
            set
            {
                userStudents = value;
                OnPropertyChanged("UserStudents");
            }
        }

        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        private ObservableCollection<Group> groups = new ObservableCollection<Group>();
        public ObservableCollection<Group> GroupsView
        {
            get { return groups; }
            set 
            { 
                groups = value;
                OnPropertyChanged("GroupsView");
            }
        }

        private Group selectedItem = new Group();
        public Group SelectedItem
        {
            get { return selectedItem; }
            set
            { 
                selectedItem = value; 
                OnPropertyChanged("SelectedItem"); 
            }
        }
        #endregion

        #region Methods
        private void SetDataGrid()
        {
            CBindex = -1;
            LastName = "";
            FirstName = "";
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
            UserStudents = oc;
        }

        private void SearchLastName(string lastname)
        {
            if (CBindex >= 0)
            {
                var student = (from st in db.UserStudents
                               where st.LastName.ToUpper().Contains(lastname.ToUpper())  && st.IDGroup == CBindex + 1
                               join gr in db.Groups on st.IDGroup equals gr.IDGroup
                               select new
                               {
                                   ID = st.IDUser,
                                   FirstName = st.FirstName,
                                   LastName = st.LastName,
                                   GroupID = gr.GroupName
                               }).ToList();
                ObservableCollection<Object> oc = new ObservableCollection<object>(student);
                UserStudents = oc;
            }
            else
            {
                var student = (from st in db.UserStudents
                               where st.LastName.ToUpper().Contains(lastname.ToUpper())
                               join gr in db.Groups on st.IDGroup equals gr.IDGroup
                               select new
                               {
                                   ID = st.IDUser,
                                   FirstName = st.FirstName,
                                   LastName = st.LastName,
                                   GroupID = gr.GroupName
                               }).ToList();
                ObservableCollection<Object> oc = new ObservableCollection<object>(student);
                UserStudents = oc;
            }
        }

        private void SearchFirstName(string firstname)
        {
            if (CBindex >= 0)
            {
                var student = (from st in db.UserStudents
                               where st.FirstName.ToUpper().Contains(firstname.ToUpper()) && st.IDGroup == CBindex + 1
                               join gr in db.Groups on st.IDGroup equals gr.IDGroup
                               select new
                               {
                                   ID = st.IDUser,
                                   FirstName = st.FirstName,
                                   LastName = st.LastName,
                                   GroupID = gr.GroupName
                               }).ToList();
                ObservableCollection<Object> oc = new ObservableCollection<object>(student);
                UserStudents = oc;
            }
            else
            {
                var student = (from st in db.UserStudents
                               where st.FirstName.ToUpper().Contains(firstname.ToUpper())
                               join gr in db.Groups on st.IDGroup equals gr.IDGroup
                               select new
                               {
                                   ID = st.IDUser,
                                   FirstName = st.FirstName,
                                   LastName = st.LastName,
                                   GroupID = gr.GroupName
                               }).ToList();
                ObservableCollection<Object> oc = new ObservableCollection<object>(student);
                UserStudents = oc;
            }
        }

        private void SearchGroupName()
        {           
            var student = (from st in db.UserStudents
                           where st.IDGroup == CBindex + 1
                           join gr in db.Groups on st.IDGroup equals gr.IDGroup
                           select new
                           {
                               ID = st.IDUser,
                               FirstName = st.FirstName,
                               LastName = st.LastName,
                               GroupID = gr.GroupName
                           }).ToList();
            ObservableCollection<Object> oc = new ObservableCollection<object>(student);
            UserStudents= oc;
        }

        private void ComboBoxGroupSet()
        {
            db.Groups.Load();
            GroupsView = db.Groups.Local.ToObservableCollection();
            CBindex = -1;
        }        
        #endregion
    }
}
