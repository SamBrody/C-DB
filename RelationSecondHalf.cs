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
    public class RelationSecondHalf: INotifyPropertyChanged 
    {
        private int idRelationFH;
        private string answerText;
        private RelationFirstHalf relationFirstHalf;

        [Key]
        public int IDRelationFH
        {
            get { return idRelationFH; }
            set
            {
                idRelationFH = value;
                OnPropertyChanged("IDRelationFH");
            }
        }
        [Required]
        public string AnswerText
        {
            get { return answerText; }
            set
            {
                answerText = value;
                OnPropertyChanged("AnswerText");
            }
        }

        public virtual RelationFirstHalf RelationFirstHalf
        {
            get { return relationFirstHalf; }
            set
            {
                relationFirstHalf = value;
                OnPropertyChanged("RelationFirstHalf");
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
