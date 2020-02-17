using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDB.Model.InputQuestionFolder
{
    public class InputAnswer : INotifyPropertyChanged
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDInputAnswer 
        {
            get { return idinputanswer; }
            set
            {
                idinputanswer = value;
                OnPropertyChanged("IDInputAnswer");
            }
        }
        [Required]
        public string AnswerText 
        {
            get { return answertext; }
            set
            {
                answertext = value;
                OnPropertyChanged("AnswerText");
            }
        }

        public int IDInputQuestion
        {
            get { return idinputquestion; }
            set
            {
                idinputquestion = value;
                OnPropertyChanged("IDInputQuestion");
            }
        }
        public InputQuestion InputQuestion 
        {
            get { return inputquestion; }
            set
            {
                inputquestion = value;
                OnPropertyChanged("InputQuestion");
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
