using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CSharpDB.Model
{
    public class User 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]        
        public int IDUser
        {
            get; set;
        }
        [Required]
        public string Login
        {
            get; set;
        }
        [Required]
        public string Password
        {
            get; set;
        }
        public int IDRole
        {
            get; set;
        }
        [DefaultValue("student")]
        public virtual Role Role
        {
            get; set;
        }

        public UserProfile UserProfile
        {
            get; set;
        }
    }
}
