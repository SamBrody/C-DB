using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDB.Model
{
    public class RelationFirstHalf
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDRelationFirstHalf { get; set; }
        [Required]
        public string Text { get; set; }

        public virtual RelationSecondHalf RelationSecondHalf { get; set; }

        public int IDQuestion { get; set; }
        public virtual Question Question { get; set; }
    }
}
