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
    public class Question 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDQuestion 
        {
            get;set;
        }

        public int IDChooseQuestion
        {
            get; set;
        }
        public virtual ChooseQuestion ChooseQuestion
        {
            get; set;
        }
        public int IDInputQuestion
        {
            get; set;
        }
        public virtual InputQuestion InputQuestion
        {
            get; set;
        }
        public int IDRelationTask
        {
            get; set;
        }
        public virtual RelationTask RelationTask
        {
            get; set;
        }
        public int IDQuestionList
        {
            get { return idquestionlist; }
            set
            {
                idquestionlist = value;
                OnPropertyChanged("IDQuestionList");
            }
        }
        public virtual QuestionList QuestionList
        {
            get; set;
        }
    }
}
