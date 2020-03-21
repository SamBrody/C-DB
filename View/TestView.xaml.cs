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
using System.Linq;
using CSharpProjCore.ViewModel;
using CSharpDB.Context;
using CSharpDB.Model;

namespace CSharpProjCore.View
{
    /// <summary>
    /// Interaction logic for Test.xaml
    /// </summary>
    public partial class TestView : Page
    {
        DBCContext db= new DBCContext();
        public TestView(string userNameText)
        {
            InitializeComponent();
            this.DataContext = new TestViewModel();
            textboxUN.Text = userNameText;
        }

        private void StartTest_Click(object sender, RoutedEventArgs e)
        {
            if (datagridTestList.SelectedItem == null) MessageBox.Show("Вы не выбрали тест!", "", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
            {
                MessageBoxResult result = MessageBox.Show("Хотите начать тестирование?", "Начало тестирования", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    Test test = datagridTestList.SelectedItem as Test;
                    var id = (from t in db.Tests
                              where t.IDTest == test.IDTest
                              select t.IDTest).ToList();
                    TestingWin testingWin = new TestingWin(textboxUN.Text, id[0]);                    
                    testingWin.Show();                    
                }
            }
        }
    }
}
