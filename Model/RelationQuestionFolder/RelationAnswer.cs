using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDB.Model.RelationQuestionFolder
{
    public class RelationAnswer
    {
        [Key]
        [ForeignKey("RelationQuestion")]
        public int IDRelationTask { get; set; }
        [Required]
        public string AnswerText { get; set; }

        public virtual RelationQuestion RelationQuestion { get; set; }
    }
}
