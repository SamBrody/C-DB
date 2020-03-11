using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDB.Model
{
    public class ChooseAnswer: INotifyPropertyChanged
    {
        private int idChooseAnswer;
        private int idQuestion;
        private string answerText;
        private bool isRight;        
        private Question question;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDChooseAnswer
        {
            get { return idChooseAnswer; }
            set
            {
                idChooseAnswer = value;
                OnPropertyChanged("IDChooseAnswer");
            }
        }        
        [Required]
        public string AnswerText
        {
            get { return answerText; }
            set
            {
                answerText = value;
                OnPropertyChanged("AnswerText");
            }
        }
        [Required]
        public bool IsRight
        {
            get { return isRight; }
            set
            {
                isRight = value;
                OnPropertyChanged("IsRight");
            }
        }
        public int IDQuestion
        {
            get { return idQuestion; }
            set
            {
                idQuestion = value;
                OnPropertyChanged("IDQuestion");
            }
        }
        public virtual Question Question
        {
            get { return question; }
            set
            {
                question = value;
                OnPropertyChanged("Question");
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
