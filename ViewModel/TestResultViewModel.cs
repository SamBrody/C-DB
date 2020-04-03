using CSharpDB.Context;
using CSharpDB.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace CSharpProjCore.ViewModel
{
    public class TestResultViewModel:BaseViewModel
    {
        DBCContext db = new DBCContext();

        #region Constructor
        public TestResultViewModel()
        {
            //DateBegin = DateTime.Today;
            //DateEnd = DateTime.Today;            
        }
        #endregion

        #region Commands       
        RelayCommand startCommand;
        RelayCommand deleteCommand;
        RelayCommand beginDateCommand;
        RelayCommand endDateCommand;

        public RelayCommand StartCommand
        {
            get
            {
                return startCommand ??
                  (startCommand = new RelayCommand((o) =>
                  {
                      UpdateDB();
                  }));
            }
        }
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ??
                  (deleteCommand = new RelayCommand((selectedItem) =>
                  {
                      if (selectedItem == null) return;
                      // получаем выделенный объект
                      int id = GetID(selectedItem.ToString());
                      TestResults testResults = db.TestResultss.Find(id);
                      try
                      {                          
                          db.TestResultss.Remove(testResults);
                          db.SaveChanges();
                          UpdateDB();
                          MessageBox.Show("Операция успешно выполнена!", "", MessageBoxButton.OK, MessageBoxImage.Information);                          
                      }
                      catch (Exception e)
                      {
                          MessageBox.Show($"Возникло исключение -\n {e}", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                      }

                  }));
            }
        }
        public RelayCommand BeginDateCommand
        {
            get
            {
                return beginDateCommand ??
                  (beginDateCommand = new RelayCommand((selectedItem) =>
                  {
                      //DateBegin = (DateTime)selectedItem;
                      SetDataGridDatePickBegin((DateTime)selectedItem);
                  }));
            }
        }       
        public RelayCommand EndDateCommand
        {
            get
            {
                return endDateCommand ??
                  (endDateCommand = new RelayCommand((selectedItem) =>
                  {
                      DateEnd = (DateTime)selectedItem;
                      SetDataGridDatePickEnd((DateTime)selectedItem);
                  }));
            }
        }
        #endregion

        #region Properties   
        private DateTime dateEnd;
        public DateTime DateEnd
        {
            get { return dateEnd; }
            set
            {
                dateEnd = value;
                OnPropertyChanged("DateEnd");
            }
        }

        private DateTime dateBegin;
        public DateTime DateBegin
        {
            get { return dateBegin; }
            set
            {
                dateBegin = value;
                OnPropertyChanged("DateBegin");
            }
        }

        private string testlistViewVis;
        public string TestlistViewVis
        {
            get { return testlistViewVis; }
            set
            {
                testlistViewVis = value;
                OnPropertyChanged("TestlistViewVis");
            }
        }

        private string userNameText;
        public string UserNameText
        {
            get { return userNameText; }
            set
            {
                userNameText = value;
                OnPropertyChanged("UserNameText");
            }
        }

        private TestResults selectedItem;
        public TestResults SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        private ObservableCollection<Object> testsResView = new ObservableCollection<Object>();
        public ObservableCollection<Object> TestsResView
        {
            get { return testsResView; }
            set
            {
                testsResView = value;
                OnPropertyChanged("TestsResView");
            }
        }
        #endregion

        #region Methods
        private void SetDataGridDatePickBegin(DateTime dateTime)
        {
            db.TestResultss.Load();
            var testRes = (from tr in db.TestResultss
                           where tr.Date>=dateTime 
                           join t in db.Tests on tr.IDTest equals t.IDTest
                           join u in db.UserProfiles on tr.IDUserProfile equals u.IDUser
                           select new
                           {
                               IDTestResults = tr.IDTestResults,
                               TestName = t.TestName,
                               Date = tr.Date,
                               User = $"{u.LastName} {u.FirstName}",
                               Grade = tr.Grade
                           }).ToList();
            ObservableCollection<Object> oc = new ObservableCollection<Object>(testRes);
            TestsResView = oc;
        }
        private void SetDataGridDatePickEnd(DateTime dateTime)
        {
            db.TestResultss.Load();
            var testRes = (from tr in db.TestResultss
                           where tr.Date <= dateTime
                           join t in db.Tests on tr.IDTest equals t.IDTest
                           join u in db.UserProfiles on tr.IDUserProfile equals u.IDUser
                           select new
                           {
                               IDTestResults = tr.IDTestResults,
                               TestName = t.TestName,
                               Date = tr.Date,
                               User = $"{u.LastName} {u.FirstName}",
                               Grade = tr.Grade
                           }).ToList();
            ObservableCollection<Object> oc = new ObservableCollection<Object>(testRes);
            TestsResView = oc;
        }
        private void UpdateDB()
        {
            db.TestResultss.Load();
            var testRes = (from tr in db.TestResultss
                           join t in db.Tests on tr.IDTest equals t.IDTest
                           join u in db.UserProfiles on tr.IDUserProfile equals u.IDUser
                           select new
                           {
                               IDTestResults = tr.IDTestResults,
                               TestName = t.TestName,
                               Date = tr.Date,
                               User = $"{u.LastName} {u.FirstName}",
                               Grade = tr.Grade
                           }).ToList();
            ObservableCollection<Object> oc = new ObservableCollection<Object>(testRes);
            TestsResView = oc;
        }
        private int GetID(string str)
        {
            string numb="123456789";
            int countF = 0;
            int j = 0;
            bool check = false; 
            while (check!=true)
            {
                if (numb.Contains(str[j])) check = true;
                else
                {
                    countF++;
                    j++;
                }
            }
            str = str.Remove(0, countF);
            int i = 0;
            int startS = 0;
            int countS = 0;
            while (startS == 0)
            {
                if (str[i] == ',') startS = i;
                else i++;
            }
            while (i < str.Length)
            {
                countS++;
                i++;
            }
            str = str.Remove(startS, countS);
            return (Int32.Parse(str));
        }
        #endregion
    }
}
