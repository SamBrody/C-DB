using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDB.Model.RelationQuestionFolder
{
    public class RelationQuestion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDRelationQuestion
        {
            get { return idrelationquestion; }
            set
            {
                idrelationquestion = value;
                OnPropertyChanged("IDRelationQuestion");
            }
        }

        public int IDQuestionGroup
        {
            get { return idquestiongroup; }
            set
            {
                idquestiongroup = value;
                OnPropertyChanged("IDQuestionGroup");
            }
        }

        public int IDRelationTask
        {
            get { return idrelationtask; }
            set
            {
                idrelationtask = value;
                OnPropertyChanged("IDRelationTask");
            }
        }

        public RelationTask RelationTask
        {
            get { return relationtask; }
            set
            {
                relationtask = value;
                OnPropertyChanged("RelationTask");
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
