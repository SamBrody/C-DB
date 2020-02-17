using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDB.Model.InputQuestionFolder
{
    public class InputQuestion : INotifyPropertyChanged
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDInputQuestion 
        {
            get { return idinputquestion; }
            set
            {
                idinputquestion = value;
                OnPropertyChanged("IDInputQuestion");
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

        public virtual ICollection<InputAnswer> InputAnswers
        {
            get { return inputanswers; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
