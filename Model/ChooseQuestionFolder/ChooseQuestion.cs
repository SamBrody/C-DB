using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDB.Model.ChooseQuestionFolder
{
    public class ChooseQuestion : INotifyPropertyChanged
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDChooseQuestion 
        {
            get { return idchoosequestion; }
            set
            {
                idchoosequestion = value;
                OnPropertyChanged("IDChooseQuestion");
            }
        }
        [Required]
        public string TaskText 
        {
            get { return tasktext; }
            set
            {
                tasktext = value;
                OnPropertyChanged("TaskText");
            }
        }

        public virtual ICollection<ChooseAnswer> ChooseAnswers
        {
            get { return chooseanswers; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
