using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace CSharpDB.Models
{
    public class UserProfile
    {
        [Key]
        [ForeignKey("User")]
        public int IDUser { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }

        public int IDGroup { get; set; }
        public virtual Group Group { get; set; }

        public virtual Test Test { get; set; }
        public User User { get; set; }
    }
}
