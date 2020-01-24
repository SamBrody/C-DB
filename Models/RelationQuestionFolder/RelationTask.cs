using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDB.Models.RelationQuestionFolder
{
    public class RelationTask
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDRelationTask { get; set; }
        public string TaskText { get; set; }

        public int IDRelationQuestion { get; set; }
        public virtual RelationQuestion RelationQuestion { get; set; }

        public virtual RelationAnswer RelationAnswers { get; set; }
    }
}
