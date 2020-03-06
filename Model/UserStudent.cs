using CSharpDB.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace CSharpProjCore.Model
{
    public class UserStudent: UserProfile
    {
        private int idGroup;
        private Group group;

        public int IDGroup
        {
            get { return idGroup; }
            set
            {
                idGroup = value;
                OnPropertyChanged("IDGroup");
            }
        }
        public virtual Group Group
        {
            get { return group; }
            set
            {
                group = value;
                OnPropertyChanged("Group");
            }
        }
    }
}
