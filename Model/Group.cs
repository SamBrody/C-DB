using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace CSharpDB.Model
{
    public class Group : INotifyPropertyChanged
    {
        private int idgroup;
        private string groupname;
        private ICollection<UserProfile> userprofiles;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDGroup 
        {
            get { return idgroup; }
            set
            {
                idgroup = value;
                OnPropertyChanged("IDGroup");
            }
        }
        [Required]
        public string GroupName 
        {
            get { return groupname; }
            set
            {
                groupname = value;
                OnPropertyChanged("GroupName");
            }
        }

        public virtual ICollection<UserProfile> UserProfiles 
        {
            get { return userprofiles; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
