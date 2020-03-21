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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CSharpProjCore.View
{
    /// <summary>
    /// Interaction logic for TestResult.xaml
    /// </summary>
    public partial class TestResult : Page
    {
        public TestResult()
        {
            InitializeComponent();
            this.DataContext = new TestResultViewModel();
        }
    }
}
