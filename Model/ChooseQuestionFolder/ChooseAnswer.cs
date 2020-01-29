using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDB.Model.ChooseQuestionFolder
{
    public class ChooseAnswer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDChooseAnswer { get; set; }
        [Required]
        public string AnswerText { get; set; }
        public int QuestionNum { get; set; }
        public bool IsRight { get; set; }
        
        public int IDChooseQuestion { get; set; }
        public virtual ChooseQuestion ChooseQuestion { get; set; }
    }
}
