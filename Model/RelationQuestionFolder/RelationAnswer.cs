using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDB.Model.RelationQuestionFolder
{
    public class RelationAnswer : INotifyPropertyChanged
    {
        [Key]
        [ForeignKey("RelationQuestion")]
        public int IDRelationTask
        {
            get { return idrelationtask; }
            set
            {
                idrelationtask = value;
                OnPropertyChanged("IDRelationTask");
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

        public virtual RelationQuestion RelationQuestion 
        {
            get { return relationquestion; }
            set
            {
                relationquestion = value;
                OnPropertyChanged("RelationQuestion");
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
