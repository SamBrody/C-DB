using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CSharpDB.Context;
using CSharpDB.Model;
using CSharpProjCore.Model;
using System.Collections.ObjectModel;

namespace CSharpProjCore.View
{
    /// <summary>
    /// Interaction logic for RegistrationWin.xaml
    /// </summary>
    public partial class RegistrationWin : Window
    {
        DBCContext db = new DBCContext();

        #region Constructor
        public RegistrationWin()
        {
            InitializeComponent();
            bindComboGroup();
        }
        #endregion

        #region Properties
        public List<Group> groups { get; set; }
        #endregion

        #region Events
        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            BackToAuthoriz();

        }

        private void buttonAcceptReg_Click(object sender, RoutedEventArgs e)
        {
            //CheckUserExist();
            if (addProfile() == true)
            {
                BackToAuthoriz();
            }
        }
        #endregion

        #region Methods
        private void bindComboGroup()
        {
            var item = from gr in db.Groups
                       select gr;
            ObservableCollection<Group> groups = new ObservableCollection<Group>(item);
            DataContext = groups;
        }
        private void BackToAuthoriz()
        {
            AuthorizationWin authorizationWin = new AuthorizationWin();
            authorizationWin.Show();

            this.Close();
        }
        private bool addProfile()
        {
            if ((textBoxFName.Text == "") || (textBoxLName.Text == "") || (passwordBoxPassword.Password == "") || (passwordBoxPasswordrepeat.Password == "") || (textBoxLogin.Text == ""))
            {
                MessageBox.Show("Необходимо заполнить все поля!", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                return (false);
            }
            else
            {
                if ((passwordBoxPassword.Password == passwordBoxPasswordrepeat.Password) && (passwordBoxPassword.Password != "") && (passwordBoxPasswordrepeat.Password != ""))
                {
                    var authoriz = from p in db.Users
                                   where p.Login == textBoxLogin.Text
                                   select p;
                    if (authoriz.Count() > 0)
                    {
                        MessageBox.Show("Введеный Логин уже занять.", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return (false);
                    }
                    else
                    {
                        try
                        {

                            User u1 = new User { Login = textBoxLogin.Text, Password = passwordBoxPassword.Password, IDRole = 2 };
                            db.Users.Add(u1);
                            UserStudent uS1 = new UserStudent { IDUser = u1.IDUser, FirstName = textBoxFName.Text, LastName = textBoxLName.Text, IDGroup = GetGroupID(comboBoxGroup.SelectedValue) };

                            db.UserStudents.Add(uS1);
                            db.SaveChanges();
                            MessageBox.Show("Регистрация прошла успешно!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                            return (true);
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show($"Возникло исключение -\n {e}", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                            return (false);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Введеные пароли не совпадают! Пожалуйста, убедитесь в правильности ввода паролей.", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return (false);
                }

            }
        }
        private int GetGroupID(object selectedValue)
        {
            return ((int)selectedValue);
        }
        private void buttonBack_Click_1(object sender, RoutedEventArgs e)
        {
            AuthorizationWin authorizationWin = new AuthorizationWin();
            authorizationWin.Show();

            this.Close();
        }        
        #endregion
    }
}
