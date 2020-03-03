using CSharpDB.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CSharpProjCore.Model
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDUser{ get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }

        public virtual UserProfile UserProfile { get; set; }

        public int IDRole { get; set; }
        public virtual Role Role { get; set; }
    }
}
