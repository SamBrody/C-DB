using CSharpProjCore.ViewModel;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Navigation;
using System.Windows.Xps.Packaging;

namespace CSharpProjCore.View
{
    /// <summary>
    /// Interaction logic for DBook.xaml
    /// </summary>
    public partial class DBook : Page
    {
        public DBook()
        {
            InitializeComponent();
            this.DataContext = new DBookViewModel();
            //OpenXps();
        }

        private void OpenXps()
        {
            XpsDocument xpsDocument = new XpsDocument("F:/CSharpProjCore — копия/Docs/xpstest.xps", FileAccess.Read);
            FixedDocumentSequence fds = xpsDocument.GetFixedDocumentSequence();
            docViewerTest.Document = fds;
        }
    }
}
