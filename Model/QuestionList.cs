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
        private int idqlist;
        private string questionlistname;
        private ICollection<Question> questions;
        private int idtest;
        private Test test;

        [Key]
        [ForeignKey("Test")]
        public int IDQuestionList
        {
            get; set;
        }
        [Required]
        public string QuestionListName
        {
            get; set;
        }

        public virtual ICollection<Question> Questions
        {
            get { return questions; }
        }

        public int IDTest
        {
            get; set;
        }
        public Test Test
        {
            get; set;
        }
    }
}
