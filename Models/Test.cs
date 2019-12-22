using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDB.Models
{
    public class Test
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDTest { get; set; }

        public int IDStudent { get; set; }
        public virtual Student Student { get; set; }
        public int IDGrade { get; set; }
        public virtual Grade Grade { get; set; }
    }
}
