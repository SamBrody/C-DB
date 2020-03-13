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
    /// Interaction logic for QuestionListView.xaml
    /// </summary>
    public partial class QuestionListView : Page
    {
        public QuestionListView()
        {
            InitializeComponent();
            InitializeComponent();
            this.DataContext = new QuestionListViewModel();
        }
    }
}
