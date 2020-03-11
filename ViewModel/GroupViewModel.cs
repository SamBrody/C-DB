﻿using CSharpDB.Context;
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
    public class GroupViewModel : BaseViewModel
    {
        DBCContext db = new DBCContext();

        #region Constructor
        public GroupViewModel()
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
                      Group group = selectedItem as Group;
                      try
                      {
                          db.Groups.Remove(group);
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
        private void UpdateDB()
        {
            db.Groups.Load();
            GroupsView = db.Groups.Local.ToObservableCollection();
        }
        #endregion
    }
}
            