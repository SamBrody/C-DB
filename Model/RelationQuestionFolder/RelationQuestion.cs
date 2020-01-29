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
        public int IDRelationQuestion { get; set; }

        public int IDQuestionGroup { get; set; }
        public virtual QuestionGroup QuestionGroup { get; set; }
        public virtual ICollection<RelationTask> RelationTasks { get;  }
    }
}
