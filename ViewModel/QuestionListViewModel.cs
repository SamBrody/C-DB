using CSharpDB.Context;
using CSharpDB.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace CSharpProjCore.ViewModel
{
    public class QuestionListViewModel : BaseViewModel
    {
        DBCContext db = new DBCContext();
        #region Constructor
        public QuestionListViewModel()
        {
            SetDataGrid();
            SetStartValue();
        }       
        #endregion

        #region Commands
        RelayCommand setAnswerCommand;
        RelayCommand addCommand;
        RelayCommand deleteCommand;

        // команда добавления
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand((selectedItem) =>
                  {
                      if (selectedItem == null) return;
                      try
                      {
                          db.SaveChanges();
                          MessageBox.Show("Операция успешно выполнена!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                      }
                      catch (Exception e)
                      {
                          MessageBox.Show($"Возникло исключение -\n {e}", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                      }
                  }));
            }
        }
        // команда удаления
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ??
                  (deleteCommand = new RelayCommand((selectedItem) =>
                  {
                      if (selectedItem == null) return;
                    // получаем выделенный объект
                    try
                    {
                          int id = GetID(selectedItem.ToString());
                          db.Questions.Remove(db.Questions.Find(id));
                          if (GetIdQt(id) == 1) ChooseAnswers.Clear();
                          else AnswerList.Clear();
                          SetStartValue();
                          db.SaveChanges();
                          SetDataGrid();
                          MessageBox.Show("Операция успешно выполнена!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception e)
                    {
                          MessageBox.Show($"Возникло исключение -\n {e}", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                  }));
            }
        }
        public RelayCommand SetAnswerCommand
        {
            get
            {
                return setAnswerCommand ??
                  (setAnswerCommand = new RelayCommand((o) =>
                  {
                      if (o!=null) SetAnswer(o.ToString());
                  }));
            }
        }

        #endregion

        #region Properties
        private string chooseAnswerVis;
        public string ChooseAnswerVis
        {
            get { return chooseAnswerVis; }
            set
            {
                chooseAnswerVis = value;
                OnPropertyChanged("ChooseAnswerVis");
            }
        }
        private string relationAnswerVis;
        public string RelationAnswerVis
        {
            get { return relationAnswerVis; }
            set
            {
                relationAnswerVis = value;
                OnPropertyChanged("RelationAnswerVis");
            }
        }
        private string inputAnswerVis;
        public string InputAnswerVis
        {
            get { return inputAnswerVis; }
            set
            {
                inputAnswerVis = value;
                OnPropertyChanged("InputAnswerVis");
            }
        }
        private int selectedIndexQ;
        public int SelectedIndexQ
        {
            get { return selectedIndexQ; }
            set
            {
                selectedIndexQ = value;
                OnPropertyChanged("SelectedIndexQ");
            }
        }
        ObservableCollection<Question> selectedItemQ;
        public ObservableCollection<Question> SelectedItemQ
        {
            get { return selectedItemQ; }
            set
            {
                selectedItemQ = value;
                OnPropertyChanged("SelectedItemQ");
            }
        }
        ObservableCollection<ChooseAnswer> chooseAnswers;
        public ObservableCollection<ChooseAnswer> ChooseAnswers
        {
            get { return chooseAnswers; }
            set
            {
                chooseAnswers = value;
                OnPropertyChanged("ChooseAnswers");
            }
        }
        ObservableCollection<Object> answerList;
        public ObservableCollection<Object> AnswerList
        {
            get { return answerList; }
            set
            {
                answerList = value;
                OnPropertyChanged("AnswerList");
            }
        }
        ObservableCollection<Object> questionList;
        public ObservableCollection<Object> QuestionList
        {
            get { return questionList; }
            set
            {
                questionList = value;
                OnPropertyChanged("QuestionList");
            }
        }
        ObservableCollection<Question> questionListCopy;
        public ObservableCollection<Question> QuestionListCopy
        {
            get { return questionListCopy; }
            set
            {
                questionListCopy = value;
                OnPropertyChanged("QuestionListCopy");
            }
        }
        #endregion

        #region Methods
        private void SetDataGrid()
        {
            db.Questions.Load();
            var question = (from q in db.Questions
                           join qt in db.QuestionTypes on q.IDQType equals qt.IDQuestionType
                           join th in db.Themes on q.IDTheme equals th.IDTheme
                           join te in db.Tests on q.IDTest equals te.IDTest
                           orderby q 
                            select new
                           {
                               ID = q.IDQuestion,
                               TaskText = q.TaskText,
                               QuestionType = qt.TextType,
                               Theme = th.TextTheme,
                               Test = te.TestName
                            }).ToList();
            ObservableCollection<Object> oc = new ObservableCollection<Object>(question);
            QuestionList = oc;
            
            QuestionListCopy = db.Questions.Local.ToObservableCollection();
        }
        private void SetStartValue()
        {
            RelationAnswerVis = "Collapsed";
            ChooseAnswerVis = "Collapsed";
            InputAnswerVis = "Collapsed";
        }
        private void SetAnswer(string selectedItem)
        {
            int id = GetID(selectedItem.ToString());
            int idQt = GetIdQt(id);
            if (idQt == 1) SetChooseAnswer(id);
            if (idQt == 2) SetInputAnswer(id);
            if (idQt == 3) SetRelationAnswer(id);
        }
        private int GetIdQt(int id)
        {
            Question question = db.Questions.Find(id);
            if (question == null) return (0);
            return(question.IDQType);
        }
        private void SetRelationAnswer(int selectedItem)
        {
            ChooseAnswerVis = "Collapsed";
            InputAnswerVis = "Collapsed";
            RelationAnswerVis = "Visible";
            var answer = (from ra in db.RelationFirstHalves
                          where ra.IDQuestion == selectedItem
                          select new
                          {
                              ID = ra.IDRelationFH,
                              TextLeft=ra.TextLeft,
                              TextRight = ra.TextRight
                          }).ToList();
            ObservableCollection<Object> oc = new ObservableCollection<object>(answer);
            AnswerList = oc;
        }
        private void SetInputAnswer(int selectedItem)
        {
            RelationAnswerVis = "Collapsed";
            ChooseAnswerVis = "Collapsed";
            InputAnswerVis = "Visible";
            var answer = (from ia in db.InputAnswers
                          where ia.IDQuestion == selectedItem
                          select new
                          {
                              ID = ia.IDQuestion,
                              AnswerText = ia.AnswerText, 
                          }).ToList();
            ObservableCollection<Object> oc = new ObservableCollection<object>(answer);
            AnswerList = oc;
        }
        private void SetChooseAnswer(int selectedItem)
        {
            RelationAnswerVis = "Collapsed";
            InputAnswerVis = "Collapsed";
            ChooseAnswerVis = "Visible";
            var answer = db.ChooseAnswers.Where(c => c.IDQuestion == selectedItem).ToList();
            ObservableCollection<ChooseAnswer> oc = new ObservableCollection<ChooseAnswer>(answer);
            ChooseAnswers = oc;
        }
        private int GetID(string str)
        {
            str = str.Remove(0,7);
            int i= 0;
            int start = 0;
            int count = 0;
            while (start==0)
            {
                if (str[i] == ',') start = i;
                else i++;
            }
            while (i<str.Length)
            {
                count++;
                i++;
            }
            str = str.Remove(start, count);
            return (Int32.Parse(str));
        }
        #endregion
    }
}
