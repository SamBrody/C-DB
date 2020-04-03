using CSharpDB.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Documents;
using System.Windows.Xps.Packaging;

namespace CSharpProjCore.ViewModel
{
    public class DBookViewModel : BaseViewModel
    {
        #region Constructor  
        public DBookViewModel()
        {
            
        }
        #endregion

        #region Commands    
        RelayCommand enterTCommand;
        RelayCommand appCrCommand;
        RelayCommand dbConCommand;
        RelayCommand uiCommand;
        RelayCommand finalCommand;

        public RelayCommand EnterTCommand
        {
            get
            {
                return enterTCommand ??
                  (enterTCommand = new RelayCommand((selectedItem) =>
                  {
                      string path = "../../../Docs/EnterWpf.xps";
                      OpenXps(path);
                  }));
            }
        }        
        public RelayCommand AppCrCommand
        {
            get
            {
                return appCrCommand ??
                  (appCrCommand = new RelayCommand((selectedItem) =>
                  {
                      string path = "../../../Docs/AppCreate.xps";
                      OpenXps(path);
                  }));
            }
        }
        public RelayCommand DbConCommand
        {
            get
            {
                return dbConCommand ??
                  (dbConCommand = new RelayCommand((selectedItem) =>
                  {
                      string path = "../../../Docs/DBconnection.xps";
                      OpenXps(path);
                  }));
            }
        }
        public RelayCommand UiCommand
        {
            get
            {
                return uiCommand ??
                  (uiCommand = new RelayCommand((selectedItem) =>
                  {
                      string path = "../../../Docs/UserInterfaceDesign.xps";
                      OpenXps(path);
                  }));
            }
        }
        public RelayCommand FinalCommand
        {
            get
            {
                return finalCommand ??
                  (finalCommand = new RelayCommand((selectedItem) =>
                  {
                      string path = "../../../Docs/Final.Func.xps";
                      OpenXps(path);
                  }));
            }
        }
        #endregion

        #region Properties       
        private FixedDocumentSequence docV;
        public FixedDocumentSequence DocV
        { 
            get { return docV; } 
            set 
            {
                docV = value;
                OnPropertyChanged("DocV");
            } 
        }
        #endregion

        #region Methods   
        private void OpenXps(string pathTo)
        {
            XpsDocument xpsDocument = new XpsDocument(pathTo, FileAccess.Read); 
            FixedDocumentSequence fds = xpsDocument.GetFixedDocumentSequence();
            DocV = fds;
        }
        #endregion
    }
}
