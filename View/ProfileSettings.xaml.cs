using CSharpDB.Context;
using CSharpDB.Model;
using CSharpProjCore.Model;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CSharpProjCore.View
{
    /// <summary>
    /// Interaction logic for ProfileSettings.xaml
    /// </summary>
    public partial class ProfileSettings : Page
    {
        DBCContext db = new DBCContext();
        User user = new User();
        string username;
        public ProfileSettings(string UserName)
        {
            InitializeComponent();
            username = UserName;
            SetDefValue();
        }



        #region Methods
        private void SetDefValue()
        {
            var userLinq = (from u in db.Users
                           where u.Login == username
                            select u).ToList();
            user = userLinq[0];
            var userprofileLinq = (from u in db.UserProfiles
                                   where u.IDUser == userLinq[0].IDUser
                                   select u).ToList();
            UserProfile userProfile =userprofileLinq[0];
            textBoxFName.Text = userProfile.FirstName;
            textBoxLName.Text = userProfile.LastName;
            textBoxLogin.Text = username;                        
        }
        #endregion

        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            bool check = false;
            if ((textBoxFName.Text != "") || (textBoxLName.Text == "") || (textBoxLogin.Text == ""))
            {
                if ((passwordBoxPassword.Password=="")&&(passwordBoxPasswordRepeat.Password==""))
                {
                    if (user.IDRole == 2)
                    {
                        UserStudent userStudent = db.UserStudents.Find(user.IDUser);
                        user.Login = textBoxLogin.Text;
                        userStudent.LastName = textBoxLName.Text;
                        userStudent.FirstName = textBoxFName.Text;
                        db.Users.Update(user);
                        db.UserStudents.Update(userStudent);
                        db.SaveChanges();
                        MessageBox.Show("Операция успешно выполнена!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                        check = true;
                    }
                    else
                    {
                        UserProfile userProfile = db.UserProfiles.Find(user.IDUser);
                        user.Login = textBoxLogin.Text;
                        userProfile.LastName = textBoxLName.Text;
                        userProfile.FirstName = textBoxFName.Text;
                        db.Users.Update(user);
                        db.UserProfiles.Update(userProfile);
                        db.SaveChanges();
                        MessageBox.Show("Операция успешно выполнена!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                        check = true;
                    }
                }
                else
                {
                    if(passwordBoxPassword.Password==passwordBoxPasswordRepeat.Password)
                    {
                        if (user.IDRole == 2)
                        {
                            UserStudent userStudent = db.UserStudents.Find(user.IDUser);
                            user.Login = textBoxLogin.Text;
                            user.Password = passwordBoxPassword.Password;
                            userStudent.LastName = textBoxLName.Text;
                            userStudent.FirstName = textBoxFName.Text;
                            db.Users.Update(user);
                            db.UserStudents.Update(userStudent);
                            db.SaveChanges();
                            MessageBox.Show("Операция успешно выполнена!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                            check = true;
                        }
                        else
                        {
                            UserProfile userProfile = db.UserProfiles.Find(user.IDUser);
                            user.Login = textBoxLogin.Text;
                            user.Password = passwordBoxPassword.Password;
                            userProfile.LastName = textBoxLName.Text;
                            userProfile.FirstName = textBoxFName.Text;
                            db.Users.Update(user);
                            db.UserProfiles.Update(userProfile);
                            db.SaveChanges();
                            MessageBox.Show("Операция успешно выполнена!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                            check = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Пароли не совпадают!", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
            }
            else MessageBox.Show("Необходимо заполнить все поля со *!", "", MessageBoxButton.OK, MessageBoxImage.Warning);
            if (check == true)
            {                
                AuthorizationWin authorizationWin = new AuthorizationWin();
                authorizationWin.Show();
            }
        }
    }
}
