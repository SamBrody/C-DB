using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CSharpDB.Model.ChooseQuestionFolder;
using CSharpDB.Model.InputQuestionFolder;
using CSharpDB.Model.RelationQuestionFolder;

namespace CSharpDB.Model
{
    public class Question : INotifyPropertyChanged
    {
        private int idquestion;
        private int idchoosequestion;
        private ChooseQuestion choosequestion;
        private int idinputquestion;
        private InputQuestion inputquestion;
        private int idrelationquestion;
        private RelationQuestion relationquestion;
        private int idquestionlist;
        private QuestionList questionlist;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDQuestion 
        {
            get { return idquestion; }
            set
            {
                idquestion = value;
                OnPropertyChanged("IDQuestion");
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
        public int IDInputQuestion 
        {
            get { return idinputquestion; }
            set
            {
                idinputquestion = value;
                OnPropertyChanged("IDInputQuestion");
            }
        }
        public virtual InputQuestion InputQuestion 
        {
            get { return inputquestion; }
            set
            {
                inputquestion = value;
                OnPropertyChanged("InputQuestion");
            }
        }
        public int IDRelationQuestion 
        {
            get { return idrelationquestion; }
            set
            {
                idrelationquestion = value;
                OnPropertyChanged("IDRelationQuestion");
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
        public int IDQuestionList 
        {
            get { return idquestion; }
            set
            {
                idquestion = value;
                OnPropertyChanged("IDQuestionList");
            }
        }
        public virtual QuestionList QuestionList 
        {
            get { return questionlist; }
            set
            {
                questionlist = value;
                OnPropertyChanged("QuestionList");
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
