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
            ViewSource = "DBook.xaml";
            VisibilityCloseMenu = "Collapsed";
            VisibilityOpenMenu = "Visible";
        }
        #endregion

        #region Commands
        RelayCommand openMenuCommand;
        RelayCommand closeMenuCommand;
        RelayCommand navigateToStudentList;
        RelayCommand navigateToDBook;
        RelayCommand exitCommand;

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
                        ViewSource = "DBook.xaml";
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
                      ViewSource = "StudentList.xaml";
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
        #endregion

        #region Properties
        private string viewSource;
        public string ViewSource
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
        #endregion

        #region Methods
        #endregion
    }
}
