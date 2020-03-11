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
    public class RelationFirstHalf: INotifyPropertyChanged
    {
        private int idRelationFH;
        private int idQuestion;
        private string textLeft;
        private string textRight;
        //private RelationSecondHalf relationSecondHalf;        
        private Question question;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        public string TextLeft
        {
            get { return textLeft; }
            set
            {
                textLeft = value;
                OnPropertyChanged("TextLeft");
            }
        }

        [Required]
        public string TextRight
        {
            get { return textRight; }
            set
            {
                textRight = value;
                OnPropertyChanged("TextRight");
            }
        }

        //public virtual RelationSecondHalf RelationSecondHalf
        //{
        //    get { return relationSecondHalf; }
        //    set
        //    {
        //        relationSecondHalf = value;
        //        OnPropertyChanged("RelationSecondHalf");
        //    }
        //}
        public int IDQuestion
        {
            get { return idQuestion; }
            set
            {
                idQuestion = value;
                OnPropertyChanged("IDQuestion");
            }
        }
        public virtual Question Question
        {
            get { return question; }
            set
            {
                question = value;
                OnPropertyChanged("Question");
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
