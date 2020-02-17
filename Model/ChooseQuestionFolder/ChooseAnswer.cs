using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDB.Model.ChooseQuestionFolder
{
    public class ChooseAnswer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDChooseAnswer
        {
            get { return idchooseanswer; }
            set
            {
                idchooseanswer = value;
                OnPropertyChanged("IDChooseAnswer");
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
        public bool IsRight 
        {
            get { return isright; }
            set
            {
                isright = value;
                OnPropertyChanged("IsRight");
            }
        }
        
        public int IDChooseQuestion 
        {
            get { return idchoosequestion; }
            set
            {
                idchoosequestion = value;
                OnPropertyChanged("IDChooseQuestion");
            }
        }
        public virtual ChooseQuestion ChooseQuestion
        {
            get { return choosequestion; }
            set
            {
                choosequestion = value;
                OnPropertyChanged("ChooseQuestion");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
}
