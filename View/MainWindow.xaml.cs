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
using CSharpProjCore.ViewModel;

namespace CSharpProjCore.View
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
            MainViewModel mainViewModel = new MainViewModel();
            this.DataContext = mainViewModel;
        }

        private void buttonPopUpChangeUser_Click(object sender, RoutedEventArgs e)
        {
            AuthorizationWin authorizationWin = new AuthorizationWin();
            authorizationWin.Show();

            this.Close();
        }

        public static bool IsWindowOpen<T>(string name = "") where T : Window
        {
            return string.IsNullOrEmpty(name)
               ? Application.Current.Windows.OfType<T>().Any()
               : Application.Current.Windows.OfType<T>().Any(w => w.Name.Equals(name));
        }

        private void mainwin_Deactivated(object sender, EventArgs e)
        {
            if (IsWindowOpen<Window>("pgae")) this.Close();
        }
    }
}
