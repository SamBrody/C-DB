using CSharpDB.Context;
using CSharpProjCore.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace CSharpProjCore.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        DBCContext db = new DBCContext();
        #region Constructor
        public MainViewModel()
        {            
            SetBaseValue();                         
        }       
        #endregion

        #region Commands
        RelayCommand openMenuCommand;
        RelayCommand closeMenuCommand;
        RelayCommand navigateToStudentList;
        RelayCommand navigateToQuestionAdd;
        RelayCommand navigateTTestResultView;
        RelayCommand navigateToDBook;
        RelayCommand navigateSettings;
        RelayCommand exitCommand;
        RelayCommand navigateToQuestionListView;
        RelayCommand navigateToTest;
        RelayCommand checkUserPos;        

        public RelayCommand NavigateToTest
        {
            get
            {
                return navigateToTest ??
                  (navigateToTest = new RelayCommand((o) =>
                  {                      
                      ViewSource = new TestView(o.ToString());
                  }));
            }
        }
        public RelayCommand NavigateTTestResultView
        {
            get
            {
                return navigateTTestResultView ??
                  (navigateTTestResultView = new RelayCommand((o) =>
                  {                      
                      ViewSource = new TestResult();
                  }));
            }
        }
        public RelayCommand NavigateToQuestionAdd
        {
            get
            {
                return navigateToQuestionAdd ??
                  (navigateToQuestionAdd = new RelayCommand((o) =>
                  {
                      ViewSource = new AddQuestion();
                  }));
            }
        }
        public RelayCommand ExitCommand
        {
            get
            {
                return exitCommand ??
                  (exitCommand = new RelayCommand((o) =>
                  {
                      MessageBoxResult result = MessageBox.Show("Вы действительно хотите выйти?", "Выход из программы", MessageBoxButton.YesNo, MessageBoxImage.Question);
                      if (result == MessageBoxResult.Yes)
                      {
                          System.Windows.Application.Current.Shutdown();
                      }
                  }));
            }            
        }
        public RelayCommand OpenMenuCommand
        {
            get
            {
                return openMenuCommand ??
                  (openMenuCommand = new RelayCommand((o) =>
                  {
                      VisibilityOpenMenu = "Collapsed";
                      VisibilityCloseMenu = "Visible";
                  }));
            }
        }
        public RelayCommand NavigateToDBook
        {
            get
            {
                return navigateToDBook ??
                    (navigateToDBook = new RelayCommand((o) =>
                    {
                        ViewSource = new DBook();
                    }));
            }
        }
        public RelayCommand NavigateSettings
        {
            get
            {
                return navigateSettings ??
                    (navigateSettings = new RelayCommand((o) =>
                    {
                        ViewSource = new ProfileSettings(UserNameText);
                    }));
            }
        }
        public RelayCommand NavigateToStudentList
        {
            get
            {
                return navigateToStudentList ??
                  (navigateToStudentList = new RelayCommand((o) =>
                  {
                      ViewSource = new StudentList();
                  }));
            }
        }
        public RelayCommand CloseMenuCommand
        {
            get
            {
                return closeMenuCommand ??
                  (closeMenuCommand = new RelayCommand((o) =>
                  {
                      VisibilityOpenMenu = "Visible";
                      VisibilityCloseMenu = "Collapsed";
                  }));
            }
        }
        public RelayCommand NavigateToQuestionListView
        {
            get
            {
                return navigateToQuestionListView ??
                  (navigateToQuestionListView = new RelayCommand((o) =>
                  {
                      ViewSource = new QuestionListView();
                  }));
            }
        }
        public RelayCommand CheckUserPos
        {
            get
            {
                return checkUserPos ??
                  (checkUserPos = new RelayCommand((o) =>
                  {
                      UserNameText = o.ToString();
                      var user = (from u in db.Users
                                  where u.Login==UserNameText
                                  select u).ToList();
                      if (user[0].IDRole != 1) VisFun = "Hidden";
                      else VisFun = "Visible";
                      if (user[0].IDRole == 3) EditableSettings = "false";
                      else EditableSettings = "true";
                  }));
            }
        }
        #endregion

        #region Properties
        private object viewSource;
        public object ViewSource
        {
            get { return viewSource; }
            set
            {
                viewSource = value;
                OnPropertyChanged("ViewSource");
            }
        }

        private string editableSettings;
        public string EditableSettings
        {
            get { return editableSettings; }
            set
            {
                editableSettings = value;
                OnPropertyChanged("EditableSettings");
            }
        }

        private string visibilityOpenMenu;
        public string VisibilityOpenMenu
        {
            get { return visibilityOpenMenu; }
            set
            {
                visibilityOpenMenu = value;
                OnPropertyChanged("VisibilityOpenMenu");
            }
        }

        private string visibilityCloseMenu;
        public string VisibilityCloseMenu
        {
            get { return visibilityCloseMenu; }
            set
            {
                visibilityCloseMenu = value;
                OnPropertyChanged("VisibilityCloseMenu");
            }
        }

        private string visFun;
        public string VisFun
        {
            get { return visFun; }
            set
            {
                visFun = value;
                OnPropertyChanged("VisFun");
            }
        }

        private bool selectedTheory;
        public bool SelectedTheory
        {
            get { return selectedTheory; }
            set
            {
                selectedTheory = value;
                OnPropertyChanged("SelectedTheory");
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
        #endregion

        #region Methods
        private void SetBaseValue()
        {            
            ViewSource = new DBook();
            SelectedTheory = true;
            VisibilityCloseMenu = "Collapsed";
            VisibilityOpenMenu = "Visible";
        }
        #endregion
    }
}
