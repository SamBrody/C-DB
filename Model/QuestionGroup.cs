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
    public class QuestionGroup 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDQuestionGroup
        {
            get; set;
        }
        [Required]
        public string QGroupName
        {
            get; set;
        }

        public virtual ICollection<RelationQuestion> RelationQuestions
        {
            get;
        }
    }
}
