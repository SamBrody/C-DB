using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDB.Model
{
    public class Question
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDQuestion { get; set; }
        public string TaskText { get; set; }

        public int IDQType { get; set; }
        public virtual QuestionType QuestionType { get; set; }

        public virtual ICollection<ChooseAnswer> ChooseAnswers { get; set;}
        public virtual ICollection<RelationFirstHalf> RelationFirstHalfs { get; set;}
        public virtual ICollection<InputAnswer> InputAnswers { get; set; }

        public int IDTheme { get; set; }
        public virtual Theme Theme { get; set; }

        public int IDTest { get; set; }
        public virtual Test Test { get; set; }
    }
}
