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

namespace CSharpProjCore.ViewModel
{
    public class StudentListViewModel : BaseViewModel
    {
        #region Constructor
        public StudentListViewModel ()
        {                        
            SetDataGrid();
            GroupSet();
        }
        #endregion

        #region Commands
        RelayCommand clearDataCommand;
        RelayCommand searchOnLastName;
        RelayCommand searchOnFirstName;
        RelayCommand searchOnGroupName;

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
        #endregion

        #region Properties
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
        public ObservableCollection<Group> Groups
        {
            get { return groups; }
            set { groups = value; OnPropertyChanged("Groups"); }
        }

        private Group selectedItem = new Group();
        public Group SelectedItem
        {
            get { return selectedItem; }
            set { selectedItem = value; OnPropertyChanged("SelectedItem"); }
        }
        #endregion

        #region Methods
        private void SetDataGrid()
        {
            CBindex = -1;
            LastName = "";
            FirstName = "";
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
            UserStudents = oc;
        }

        private void SearchLastName(string lastname)
        {
            DBCContext db = new DBCContext();
            if (CBindex >= 0)
            {
                var student = (from st in db.UserStudents
                               where st.LastName.Contains(lastname) && st.IDGroup == CBindex + 1
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
                               where st.LastName.Contains(lastname)
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
            DBCContext db = new DBCContext();
            if (CBindex >= 0)
            {
                var student = (from st in db.UserStudents
                               where st.FirstName.Contains(firstname) && st.IDGroup == CBindex + 1
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
                               where st.FirstName.Contains(firstname)
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
            DBCContext db = new DBCContext();
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

        private void GroupSet()
        {
            DBCContext db = new DBCContext();
            db.Groups.Load();
            Groups = db.Groups.Local.ToObservableCollection();
            CBindex = -1;
        }
        #endregion
    }
}
