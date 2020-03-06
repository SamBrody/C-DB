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
        private ICollection<Question> questions;
        private ICollection<TestResults> testResults;
        private int idTheme;
        private Theme theme;

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

        public int IDTheme
        {
            get { return idTheme; }
            set
            {
                idTheme = value;
                OnPropertyChanged("IDTheme");
            }
        }
        public virtual Theme Theme
        {
            get { return theme; }
            set
            {
                theme = value;
                OnPropertyChanged("Theme");
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
