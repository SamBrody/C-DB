﻿using System;
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
        private int idQuestion;
        private string text;
        private RelationSecondHalf relationSecondHalf;
        
        private Question question;

        [Key]
        public int IDQuestion
        {
            get { return idQuestion; }
            set
            {
                idQuestion = value;
                OnPropertyChanged("IDQuestion");
            }
        }
        [Required]
        public string Text
        {
            get { return text; }
            set
            {
                text = value;
                OnPropertyChanged("Text");
            }
        }

        public virtual RelationSecondHalf RelationSecondHalf
        {
            get { return relationSecondHalf; }
            set
            {
                relationSecondHalf = value;
                OnPropertyChanged("RelationSecondHalf");
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
