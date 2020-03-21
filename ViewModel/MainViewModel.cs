using CSharpProjCore.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace CSharpProjCore.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
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
        RelayCommand exitCommand;
        RelayCommand navigateToQuestionListView;
        RelayCommand navigateToTest;

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
