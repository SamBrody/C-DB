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

namespace CSharpProjCore.ViewModel
{
    public class GroupViewModel : BaseViewModel
    {
        #region Constructor
        public GroupViewModel()
        {
            DBCContext db = new DBCContext();
            db.Groups.Load();
            Groups = db.Groups.Local.ToObservableCollection();
        }
        #endregion

        #region Commands
        RelayCommand updateCommand;
        RelayCommand deleteCommand;
        //RelayCommand selectionChangedCommand;

        //public RelayCommand SelectionChangedCommand
        //{
        //    get
        //    {
        //        return selectionChangedCommand ??
        //            (selectionChangedCommand = new RelayCommand((selectedItem) =>
        //            {
        //                if (selectedItem == null) return;                        
        //            }));
        //    }
        //}
        // команда обновления
        public RelayCommand UpdateCommand
        {
            get
            {
                return updateCommand ??
                  (updateCommand = new RelayCommand((o) =>
                  {
                      DBCContext db = new DBCContext();
                      db.SaveChanges();
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
                      DBCContext db = new DBCContext();
                      if (selectedItem == null) return;
                      // получаем выделенный объект
                      Group group = selectedItem as Group;
                      db.Groups.Remove(group);
                      db.SaveChanges();
                  }));
            }
        }
        #endregion

        #region Properties
        ObservableCollection<Group> groups;
        public ObservableCollection<Group> Groups
        {
            get { return groups; }
            set
            {
                groups = value;
                OnPropertyChanged("Groups");
            }
        }
        public ListCollectionView GroupsView { get; set; }

        private Group selectedGroup;
        public Group SelectedGroup
        {
            get { return selectedGroup; }
            set
            {
                selectedGroup = value;
                OnGroupChanged();
                OnPropertyChanged("SelectedGroup");
            }
        }
        #endregion

        #region Methods
        private void OnGroupChanged()
        {
            GroupsView.Refresh();
        }
        #endregion        
    }
}
            