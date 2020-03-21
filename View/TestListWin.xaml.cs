using CSharpProjCore.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CSharpProjCore.View
{
    /// <summary>
    /// Interaction logic for TestListWin.xaml
    /// </summary>
    public partial class TestListWin : Window
    {
        public TestListWin()
        {
            InitializeComponent();
            this.DataContext = new TestListViewModel();
        }
    }
}
