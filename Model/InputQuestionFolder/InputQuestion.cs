using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDB.Model.InputQuestionFolder
{
    public class InputQuestion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDInputQuestion { get; set; }
        [Required]
        public string TaskText { get; set; }

        public virtual ICollection<InputAnswer> InputAnswers { get;  }
    }
}
