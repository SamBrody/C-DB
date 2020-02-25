using CSharpDB.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Storage;
using CSharpProjCore.View;

namespace CSharpDB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {        
        public MainWindow(string username)
        {
            InitializeComponent();
            textBlockUSERNAME.Text += username.ToUpper();            
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void ButtonPopUpExit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы действительно хотите выйти?", "Выход из программы", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                System.Windows.Application.Current.Shutdown();
            }
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }

        private void buttonChangeUser_Click(object sender, RoutedEventArgs e)
        {
            AuthorizationWin authorizationWin = new AuthorizationWin();
            authorizationWin.Show();

            this.Close();
        }

        private void ListViewStudentList_Selected(object sender, RoutedEventArgs e)
        {
            frameMainWindow.NavigationService.Navigate(new Uri("View/StudentList.xaml", UriKind.RelativeOrAbsolute));
        }

        private void ListViewTheory_Selected(object sender, RoutedEventArgs e)
        {
            frameMainWindow.NavigationService.Navigate(new Uri("View/DBook.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
