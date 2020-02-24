using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Navigation;

namespace CSharpDB.Pages
{
    /// <summary>
    /// Interaction logic for DBook.xaml
    /// </summary>
    public partial class DBook : Page
    {
        public DBook()
        {
            InitializeComponent();
        }

        string path1 = "pack://application:,,,/Docs/mysql.xaml";

        private void button1Load_Click(object sender, RoutedEventArgs e)
        {
            using (FileStream fs = File.Open(path1, FileMode.Open))
            {                
                FlowDocument document = XamlReader.Load(fs) as FlowDocument;
                if (document != null)
                    docViewer.Document = document;
            }
        }
    }
}
