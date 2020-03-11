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
    public class Question: INotifyPropertyChanged
    {
        private int idQuestion;
        private string taskText;
        private int idQType;
        private QuestionType questionType;
        private ICollection<ChooseAnswer> chooseAnswers;
        private ICollection<RelationFirstHalf> relationFirstHalves;
        private InputAnswer inputAnswers;
        private int idTheme;
        private Theme theme;
        private int idTest;
        private Test test;       

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDQuestion
        {
            get { return idQuestion; }
            set
            {
                idQuestion = value;
                OnPropertyChanged("IDQuestion");
            }
        }
        public string TaskText
        {
            get { return taskText; }
            set
            {
                taskText = value;
                OnPropertyChanged("TaskText");
            }
        }

        public int IDQType
        {
            get { return idQType; }
            set
            {
                idQType = value;
                OnPropertyChanged("IDQType");
            }
        }
        public virtual QuestionType QuestionType
        {
            get { return questionType; }
            set
            {
                questionType = value;
                OnPropertyChanged("QuestionType");
            }
        }

        public virtual ICollection<ChooseAnswer> ChooseAnswers
        {
            get { return chooseAnswers; }
            set
            {
                chooseAnswers = value;
                OnPropertyChanged("ChooseAnswers");
            }
        }
        public virtual ICollection<RelationFirstHalf> RelationFirstHalfs
        {
            get { return relationFirstHalves; }
            set
            {
                relationFirstHalves = value;
                OnPropertyChanged("RelationFirstHalfs");
            }
        }
        public virtual InputAnswer InputAnswers
        {
            get { return inputAnswers; }
            set
            {
                inputAnswers = value;
                OnPropertyChanged("InputAnswers");
            }
        }
        public int IDTheme
        {
            get { return idTheme; }
            set
            {
                idTheme = value;
                OnPropertyChanged("IDTheme");
            }
        }
        public virtual Theme Theme
        {
            get { return theme; }
            set
            {
                theme = value;
                OnPropertyChanged("Theme");
            }
        }

        public int IDTest
        {
            get { return idTest; }
            set
            {
                idTest = value;
                OnPropertyChanged("IDTest");
            }
        }
        public virtual Test Test
        {
            get { return test; }
            set
            {
                test = value;
                OnPropertyChanged("Test");
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
