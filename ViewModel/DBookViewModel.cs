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
        RelayCommand goToTestPage;
        
        public RelayCommand GoToTestPage
        {
            get
            {
                return goToTestPage ??
                  (goToTestPage = new RelayCommand((selectedItem) =>
                  {
                      string path = "../../../Docs/xpstest.xps";//"F:/CSharpProjCore — копия/Docs/xpstest.xps"
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
