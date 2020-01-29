using CSharpDB.Model.RelationQuestionFolder;
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
    public class QuestionGroup : INotifyPropertyChanged
    {
        private int idquestiongroup;
        private string qgroupname;
        private ICollection<RelationQuestion> relationquestions;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDQuestionGroup 
        {
            get { return idquestiongroup; }
            set
            {
                idquestiongroup = value;
                OnPropertyChanged("IDQuestionGroup");
            }
        }
        [Required]
        public string QGroupName 
        {
            get { return qgroupname; }
            set
            {
                qgroupname = value;
                OnPropertyChanged("QGroupName");
            }
        }

        public virtual ICollection<RelationQuestion> RelationQuestions
        {
            get { return relationquestions; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop="")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
