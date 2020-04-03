using CSharpDB.Context;
using CSharpDB.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Windows;


namespace CSharpProjCore.ViewModel
{
    public class TestListViewModel: BaseViewModel
    {
        DBCContext db = new DBCContext();

        #region Constructor
        public TestListViewModel()
        {            
            UpdateDB();
            DateTimeV = DateTime.Today;
        }        
        #endregion

        #region Commands
        RelayCommand addCommand;
        RelayCommand deleteCommand;
        RelayCommand setValueCommand;

        public RelayCommand SetValueCommand
        {
            get
            {
                return setValueCommand ??
                  (setValueCommand = new RelayCommand((selectedItem) =>
                  {
                      Test test = selectedItem as Test;
                      if (test.IDTest<=0)
                          test.Access = DateTime.Today;
                  }));
            }
        }
        // команда добавления
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand((selectedItem) =>
                  {
                      if (selectedItem == null) return;
                      Test test = selectedItem as Test;
                      try
                      {    
                          if ((test.QuestionCount>0)& (test.Time>0)& (test.Access!=null)&(test.TestName!=null)&(test.TryCount>0))
                          {
                              db.SaveChanges();
                              MessageBox.Show("Операция успешно выполнена!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                          }
                          else
                              MessageBox.Show($"Заполните все поля!", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                      }
                      catch (Exception e)
                      {
                          MessageBox.Show($"Возникло исключение -\n {e}", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                      }
                  }));
            }
        }
        // команда удаления
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ??
                  (deleteCommand = new RelayCommand((selectedItem) =>
                  {
                      if (selectedItem == null) return;
                      // получаем выделенный объект
                      Test test = selectedItem as Test;
                      try
                      {
                          db.Tests.Remove(test);
                          db.SaveChanges();                          
                          MessageBox.Show("Операция успешно выполнена!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                      }
                      catch (Exception e)
                      {
                          MessageBox.Show($"Возникло исключение -\n {e}", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                      }

                  }));
            }
        }

        #endregion

        #region Properties
        private ObservableCollection<Test> test = new ObservableCollection<Test>();
        public ObservableCollection<Test> TestView
        {
            get { return test; }
            set
            {
                test = value;
                OnPropertyChanged("TestView");
            }
        }

        private Test selectedItem = new Test();
        public Test SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }
        private DateTime dateTime;
        public DateTime DateTimeV
        {
            get { return dateTime; }
            set
            {
                dateTime = value;
                OnPropertyChanged("DateTimeV");
            }
        }
        #endregion

        #region Methods
        private void UpdateDB()
        {            
            db.Tests.Load();
            TestView = db.Tests.Local.ToObservableCollection();
        }
        #endregion
    }
}
