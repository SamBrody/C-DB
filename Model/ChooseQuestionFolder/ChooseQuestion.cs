using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDB.Model.ChooseQuestionFolder
{
    public class ChooseQuestion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDChooseQuestion { get; set; }
        [Required]
        public string TaskText { get; set; }

        public virtual ICollection<ChooseAnswer> ChooseAnswers { get;  }
    }
}
