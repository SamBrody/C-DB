using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace CSharpDB.Model
{
    public class Test 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDTest
        {
            get; set;
        }
        public DateTime Date
        {
            get; set;
        }

        public int IDGrade
        {
            get; set;
        }
        public virtual Grade Grade
        {
            get; set;
        }

        public int IDUserProfile
        {
            get; set;
        }
        public virtual UserProfile UserProfile
        {
            get; set;
        }

        public virtual ICollection<QuestionList> QuestionLists
        {
            get; 
        }
    }
}
