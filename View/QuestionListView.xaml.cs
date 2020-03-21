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
using CSharpDB;

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
            this.DataContext = new QuestionListViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (datagridQuestionList.SelectedItem == null) MessageBox.Show("Вы не выбрали вопрос!", "", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
            {
                int id = GetID(datagridQuestionList.SelectedItem.ToString());
                EditQuestionWin editQuestion = new EditQuestionWin(id);
                editQuestion.Show();
            }            
        }

        private int GetID(string str)
        {
            str = str.Remove(0, 7);
            int i = 0;
            int start = 0;
            int count = 0;
            while (start == 0)
            {
                if (str[i] == ',') start = i;
                else i++;
            }
            while (i < str.Length)
            {
                count++;
                i++;
            }
            str = str.Remove(start, count);
            return (Int32.Parse(str));
        }
    }
}
