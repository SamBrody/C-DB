using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using CSharpProjCore.Model;

namespace CSharpDB.Model
{
    public class Group 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDGroup { get; set; }
        [Required]
        public string GroupName { get; set; }

        public virtual ICollection<UserStudent> UserStudents { get; set; }
    }
}
