using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSharpDB.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDStudent { get; set; }
        [Required]
        public string GroupName { get; set; }

        public int IDGroups { get; set; }
        public virtual Group Groups { get; set; }
        public int IDUserProfile { get; set; }
        public virtual UserProfile UserProfiles { get; set; }
    }
}
