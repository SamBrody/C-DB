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
        private int idRelationFirstHalf;
        private string answerText;
        private RelationFirstHalf relationFirstHalf;

        [Key]
        [ForeignKey("RelationFirstHalf")]
        public int IDRelationFirstHalf
        {
            get { return idRelationFirstHalf; }
            set
            {
                idRelationFirstHalf = value;
                OnPropertyChanged("RelationFirstHalf");
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
