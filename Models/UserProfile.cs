using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSharpDB.Models
{
    public class UserProfile
    {
        [Key]
        [ForeignKey("User")]
        public int IDUserProfile { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Role { get; set; }

        public User User { get; set; }
    }
}
