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
    public class QuestionType : INotifyPropertyChanged
    {
        private int idQuestionType;
        private string textType;
        private ICollection<Question> questions;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDQuestionType
        {
            get { return idQuestionType; }
            set
            {
                idQuestionType = value;
                OnPropertyChanged("IDQuestionType");
            }
        }
        public string TextType
        {
            get { return textType; }
            set
            {
                textType = value;
                OnPropertyChanged("TextType");
            }
        }

        public virtual ICollection<Question> Questions
        {
            get { return questions; }
            set
            {
                questions = value;
                OnPropertyChanged("Questions");
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
