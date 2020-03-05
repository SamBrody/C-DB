using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpProjCore.ViewModel
{
    public class RegistrationWin : BaseViewModel
    {
        #region Constructor
        public RegistrationWin ()
        {

        }
        #endregion

        #region Commands
        #endregion

        #region Properties
        private string login;
        public string Login
        {
            get { return login; }
            set
            {
                login = value;
                OnPropertyChanged("Login");
            }
        }
        //private string login;
        //public string Login
        //{
        //    get { return login; }
        //    set
        //    {
        //        login = value;
        //        OnPropertyChanged("Login");
        //    }
        //}
        //private string login;
        //public string Login
        //{
        //    get { return login; }
        //    set
        //    {
        //        login = value;
        //        OnPropertyChanged("Login");
        //    }
        //}
        #endregion

        #region Methods
        #endregion  
    }
}
