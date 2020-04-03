using CSharpDB.Context;
using CSharpDB.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Windows;
using CSharpProjCore.Model;

namespace CSharpProjCore.ViewModel
{
    public class EditStudentViewModel:BaseViewModel
    {
        DBCContext db = new DBCContext();

        #region Constructor
        public EditStudentViewModel(int id)
        {
            UserID = id;
            SetValues();            
        }
        #endregion

        #region Commands
        RelayCommand updateCommand;
        RelayCommand setFNameCommand;
        RelayCommand setLNameCommand;
        RelayCommand setComboBoxId;
        
        public RelayCommand UpdateCommand
        {
            get
            {
                return updateCommand ??
                  (updateCommand = new RelayCommand((selectedItem) =>
                  {
                      var studentLinq = (from s in db.UserStudents
                                     where s.IDUser == UserID
                                     select s).ToList();
                      UserStudent userStudent = studentLinq[0] as UserStudent;
                      userStudent.LastName = LNameText;
                      userStudent.FirstName = FNameText;
                      var group = (from g in db.Groups
                                   where g == SelectedGroup
                                   select g).ToList();
                      userStudent.IDGroup = group[0].IDGroup;
                      db.UserStudents.Update(userStudent);
                      db.SaveChanges();
                      MessageBox.Show("Операция успешно выполнена!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                  }));
            }
        }
        public RelayCommand SetFNameCommand
        {
            get
            {
                return setFNameCommand ??
                  (setFNameCommand = new RelayCommand((selectedItem) =>
                  {
                      FNameText = selectedItem.ToString();
                  }));
            }
        }
        public RelayCommand SetLNameCommand
        {
            get
            {
                return setLNameCommand ??
                  (setLNameCommand = new RelayCommand((selectedItem) =>
                  {
                      LNameText = selectedItem.ToString();
                  }));
            }
        }
        public RelayCommand SetComboBoxId
        {
            get
            {
                return setComboBoxId ??
                  (setComboBoxId = new RelayCommand((selectedItem) =>
                  {
                      SelectedGroup = selectedItem as Group;
                  }));
            }
        }
        #endregion

        #region Properties
        private ObservableCollection<Group> group = new ObservableCollection<Group>();
        public ObservableCollection<Group> GroupView
        {
            get { return group; }
            set
            {
                group = value;
                OnPropertyChanged("GroupView");
            }
        }

        private Group selectedGroup = new Group();
        public Group SelectedGroup
        {
            get { return selectedGroup; }
            set
            {
                selectedGroup = value;
                OnPropertyChanged("SelectedGroup");
            }
        }

        private int userID;
        public int UserID
        {
            get { return userID; }
            set
            {
                userID = value;
                OnPropertyChanged("UserID");
            }
        }

        private string fNameText;
        public string FNameText
        {
            get { return fNameText; }
            set
            {
                fNameText = value;
                OnPropertyChanged("FNameText");
            }
        }

        private string lNameText;
        public string LNameText
        {
            get { return lNameText; }
            set
            {
                lNameText = value;
                OnPropertyChanged("LNameText");
            }
        }
        #endregion

        #region Methods
        private void SetValues()
        {
            var student = (from s in db.UserStudents
                           where s.IDUser == UserID
                           select s).ToList();
            UserStudent userStudent = student[0] as UserStudent;
            LNameText = userStudent.LastName;
            FNameText = userStudent.FirstName;
            var group = (from g in db.Groups
                         where g.IDGroup == userStudent.IDGroup
                         select g).ToList();
            SelectedGroup = group[0];
            db.Groups.Load();
            GroupView = db.Groups.Local.ToObservableCollection();
        }
        #endregion  
    }
}
