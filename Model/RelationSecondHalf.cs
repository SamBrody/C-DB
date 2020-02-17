using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDB.Model
{
    public class RelationSecondHalf 
    {
        [Key]
        [ForeignKey("RelationFirstHalf")]
        public int IDRelationFirstHalf { get; set; }
        [Required]
        public string AnswerText { get; set; }

        public virtual RelationFirstHalf RelationFirstHalf { get; set; }
    }
}
