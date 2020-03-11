using CSharpDB.Context;
using CSharpDB.Model;
using CSharpProjCore.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CSharpProjCore.View;
using System.Windows.Data;
using System.Windows;


namespace CSharpProjCore.ViewModel
{
    public class ThemeListViewModel : BaseViewModel
    {
        DBCContext db = new DBCContext();

        #region Constructor
        public ThemeListViewModel()
        {
            UpdateDB();
        }
        #endregion

        #region Commands
        RelayCommand addCommand;
        RelayCommand deleteCommand;

        // команда добавления
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand((selectedItem) =>
                  {
                      if (selectedItem == null) return;
                      try
                      {
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
                      Theme theme = selectedItem as Theme;
                      try
                      {
                          db.Themes.Remove(theme);
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
        private ObservableCollection<Theme> themes = new ObservableCollection<Theme>();
        public ObservableCollection<Theme> ThemeView
        {
            get { return themes; }
            set
            {
                themes = value;
                OnPropertyChanged("ThemeView");
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
        private void UpdateDB()
        {
            db.Themes.Load();
            ThemeView = db.Themes.Local.ToObservableCollection();
        }
        #endregion
    }
}
