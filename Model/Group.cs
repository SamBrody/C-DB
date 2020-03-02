using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using CSharpProjCore.Model;

namespace CSharpDB.Model
{
    public class Group: INotifyPropertyChanged 
    {
        private int idGroup;
        private string groupName;
        private ICollection<UserStudent> userStudents;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDGroup
        {
            get { return idGroup; }
            set
            {
                idGroup = value;
                OnPropertyChanged("IDGroup");
            }
        }
        [Required]
        public string GroupName
        {
            get { return groupName; }
            set
            {
                groupName = value;
                OnPropertyChanged("GroupName");
            }
        }

        public virtual ICollection<UserStudent> UserStudents
        {
            get { return userStudents; }
            set
            {
                userStudents = value;
                OnPropertyChanged("UserStudents");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
