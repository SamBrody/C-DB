using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDB.Models.InputQuestionFolder
{
    public class InputAnswer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDInputAnswer { get; set; }
        [Required]
        public string AnswerText { get; set; }

        public int IDInputQuestion { get; set; }
        public InputQuestion InputQuestion { get; set; }
    }
}
