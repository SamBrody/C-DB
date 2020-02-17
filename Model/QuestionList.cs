using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDB.Model
{
    public class QuestionList 
    {
        [Key]
        [ForeignKey("TestResults")]
        public int IDTestResults { get; set; }
        [Required]
        public string QuestionListName { get; set; }
        public virtual TestResults TestResults { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}
