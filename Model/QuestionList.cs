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
    public class QuestionList : INotifyPropertyChanged
    {
        private int idqlist;
        private string questionlistname;
        private ICollection<Question> qustions;
        private int idtest;
        private Test test;

        [Key]
        [ForeignKey("Test")]
        public int IDQuestionList 
        {
            get { return idqlist; }
            set 
            {
                idqlist = value;
                OnPropertyChanged("IDQuestionList");
            }
        }
        [Required]
        public string QuestionListName 
        {
            get { return questionlistname; }
            set
            {
                questionlistname = value;
                OnPropertyChanged("QuestionListName");
            }
        }
        
        public virtual ICollection<Question> Questions 
        {
            get { return qustions; }
        }

        public int IDTest
        {
            get { return idtest; }
            set
            {
                idtest = value;
                OnPropertyChanged("IDTest");
            }
        }
        public Test Test
        {
            get { return test; }
            set
            {
                test = value;
                OnPropertyChanged("Test");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop="")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
