using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDB.Models
{
    public enum Grade
    {
        five = 5,
        four = 4,
        three = 3,
        two = 2
    }
    public class Test
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDTest { get; set; }
        public DateTime Date {get;set;}
        public Grade Grade { get; set; }

        public int IDUserProfile { get; set; }
        public virtual UserProfile UserProfile { get; set; }
    }
}
