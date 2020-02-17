using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDB.Model
{
    public class ChooseAnswer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDChooseAnswer { get; set; }
        [Required]
        public string AnswerText { get; set; }
        public bool IsRight { get; set; }

        public int IDQuestion { get; set; }
        public virtual Question Question { get; set; }
    }
}
