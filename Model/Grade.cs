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
    public class Grade: INotifyPropertyChanged
    {
        private int idGrade;
        private string gradeName;
        private ICollection<TestResults> testResults;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDGrade
        {
            get { return idGrade; }
            set
            {
                idGrade = value;
                OnPropertyChanged("IDGrade");
            }
        }
        public string GradeName
        {
            get { return gradeName; }
            set
            {
                gradeName = value;
                OnPropertyChanged("GradeName");
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
