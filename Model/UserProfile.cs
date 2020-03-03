using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CSharpProjCore.Model;

namespace CSharpDB.Model
{
    public class UserProfile 
    {
        [Key]
        [ForeignKey("User")]
        public int IDUser { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public virtual ICollection<TestResults> TestResults { get; set; }

        public User User { get; set; }
    }
}
