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
    public class Theme : INotifyPropertyChanged
    {
        private int idTheme;
        private string textTheme;
        private ICollection<Question> questions;
        private ICollection<Test> tests;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDTheme
        {
            get { return idTheme; }
            set
            {
                idTheme = value;
                OnPropertyChanged("IDTheme");
            }
        }
        public string TextTheme
        {
            get { return textTheme; }
            set
            {
                textTheme = value;
                OnPropertyChanged("TextTheme");
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
        public virtual ICollection<Test> Tests
        {
            get { return tests; }
            set
            {
                tests = value;
                OnPropertyChanged("Tests");
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
