using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDB.Model.RelationQuestionFolder
{
    public class RelationTask : INotifyPropertyChanged
    {
        private int idrelationtask;
        private string tasktext;
        private int idrelationquestion;
        private RelationQuestion relationquestion;
        private RelationAnswer relationanswer;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDRelationTask
        {
            get { return idrelationtask; }
            set
            {
                idrelationtask = value;
                OnPropertyChanged("IDRelationTask");
            }
        }
        public string TaskText
        {
            get { return tasktext; }
            set
            {
                tasktext = value;
                OnPropertyChanged("TaskText");
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

        public virtual RelationAnswer RelationAnswers 
        {
            get { return relationanswer; }
            set
            {
                relationanswer = value;
                OnPropertyChanged("RelationAnswers");
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
