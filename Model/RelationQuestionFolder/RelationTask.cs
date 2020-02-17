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
    public class RelationTask 
    {
        private int idrelationtask;
        private string tasktext;
        private int idrelationquestion;
        private ICollection<RelationQuestion> relationquestions;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDRelationTask
        {
            get; set;
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

        public virtual ICollection<RelationQuestion> RelationQuestions
        {
            get { return relationquestions; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
