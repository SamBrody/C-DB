using CSharpDB.Context;
using CSharpDB.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace CSharpProjCore.ViewModel
{
    public class TestViewModel: BaseViewModel
    {
        DBCContext db = new DBCContext();

        #region Constructor
        public TestViewModel()
        {                        
            TestlistViewVis = "Visible";            
        }
        #endregion

        #region Commands       
        RelayCommand startCommand;

        public RelayCommand StartCommand
        {
            get
            {
                return startCommand ??
                  (startCommand = new RelayCommand((o) =>
                  {
                      if (o != null)
                      {                         
                          UpdateDB(o.ToString());
                      }
                  }));
            }
        }
        #endregion

        #region Properties         
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

        private Test selectedItem;
        public Test SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        private ObservableCollection<Test> testsView;
        public ObservableCollection<Test> TestsView
        {
            get { return testsView; }
            set
            {
                testsView = value;
                OnPropertyChanged("TestsView");
            }
        }      
        #endregion

        #region Methods
        private void UpdateDB(string name )
        {
            int id = GetUserNameID(name);
            db.Tests.Load();
            db.TestResultss.Load();
            var testLinq = (from t in db.Tests
                            where (t.Access <= DateTime.Today) 
                            select t).ToList();
            foreach (var item in testLinq)
            {
                //запрос на нахождения КОЛ-ВА израсходованных попыток
                var accessCountLinq = (from tr in db.TestResultss
                                  where tr.IDUserProfile == id && tr.IDTest == item.IDTest
                                  select tr).ToList();
                item.TryCount = item.TryCount - accessCountLinq.Count;
            }
            testLinq = testLinq.Where(tc => tc.TryCount > 0).ToList();
            //var countLess= (from t in db.Tests
            //                where (t.Access <= DateTime.Today) && (t.TryCount - accessLinq.Count > 0)
            //                select t.TryCount).ToList();
            ObservableCollection<Test> tests = new ObservableCollection<Test>(testLinq);
            //foreach (var item in tests)
            //{
            //    item.TryCount = countLess[0] - accessLinq.Count;
            //}
            TestsView = tests;
        }        
        private int GetUserNameID(string name)
        {
            db.Users.Load();
            var userID = (from u in db.Users
                          where u.Login.ToUpper() == name.ToUpper()
                          select u.IDUser).ToList();
            return (userID[0]);
        }
        #endregion
    }
}
