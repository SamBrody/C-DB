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
    public class Test : INotifyPropertyChanged
    {
        private int idTest;
        private string testName;
        private int questionCount;
        private int time;
        private int tryCount;
        private DateTime access;
        private ICollection<Question> questions;
        private ICollection<TestResults> testResults;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDTest
        {
            get { return idTest; }
            set
            {
                idTest = value;
                OnPropertyChanged("IDTest");
            }
        }
        public string TestName
        {
            get { return testName; }
            set
            {
                testName = value;
                OnPropertyChanged("TestName");
            }
        }
        public int QuestionCount
        {
            get { return questionCount; }
            set
            {
                questionCount = value;
                OnPropertyChanged("TestName");
            }
        }
        public int Time
        {
            get { return time; }
            set
            {
                time = value;
                OnPropertyChanged("Time");
            }
        }
        public int TryCount
        {
            get { return tryCount; }
            set
            {
                tryCount = value;
                OnPropertyChanged("TryCount");
            }
        }
        public DateTime Access
        {
            get { return access; }
            set
            {
                access = value;
                OnPropertyChanged("Access");
            }
        }
        public virtual ICollection<Question> Questions
        {
            get { return questions; }
            set
            {
                questions = value;
                OnPropertyChanged("Questions");
            }
        }
        public virtual ICollection<TestResults> TestResults
        {
            get { return testResults; }
            set
            {
                testResults = value;
                OnPropertyChanged("TestResults");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
