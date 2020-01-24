using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDB.Models.RelationQuestionFolder
{
    public class RelationQuestion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDRelationQuestion { get; set; }
        [Required]
        public string Group { get; set; }

        public virtual ICollection<RelationTask> RelationTasks { get; set; }
    }
}
