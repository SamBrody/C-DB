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
            SetDataGrid(null);
            SetStartValue();
            ComboBoxTestSet();
            SetCBIndex();
        }       
        #endregion

        #region Commands
        RelayCommand setAnswerCommand;        
        RelayCommand deleteCommand;
        RelayCommand searchOnTestName;
        RelayCommand clearDataCommand;
        RelayCommand updatePageCommand;
        RelayCommand updateDataGCommand;

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
                          SetDataGrid(null);
                          MessageBox.Show("Операция успешно выполнена!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                      }
                    catch (Exception e)
                    {
                          MessageBox.Show($"Возникло исключение -\n {e}", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                  }));
            }
        }

        public RelayCommand ClearDataCommand
        {
            get
            {
                return clearDataCommand ??
                  (clearDataCommand = new RelayCommand((o) =>
                  {                      
                      SetCBIndex();
                      SetDataGrid(null);                      
                  }));
            }
        }

        public RelayCommand UpdatePageCommand
        {
            get
            {
                return updatePageCommand ??
                  (updatePageCommand = new RelayCommand((o) =>
                  {
                      ComboBoxTestSet();                         
                  }));
            }
        }
        public RelayCommand UpdateDataGCommand
        {
            get
            {
                return updateDataGCommand ??
                  (updateDataGCommand = new RelayCommand((o) =>
                  {
                      QuestionList.Clear();
                      if (AnswerList!=null) AnswerList.Clear();
                      if (ChooseAnswers != null) ChooseAnswers.Clear();
                      SetCBIndex();
                      if (o == null)
                      {                         
                          SetDataGrid(null);
                      }
                      else
                      {
                          SetDataGrid(o.ToString());
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
                      if (o != null)
                      {
                          if (o != null) SetAnswer(o.ToString());
                      }
                  }));
            }
        }

        public RelayCommand SearchOnTestName
        {
            get
            {
                return searchOnTestName ??
                  (searchOnTestName = new RelayCommand((o) =>
                  {
                      SearchTestName();                     
                  }));
            }
        }

        #endregion

        #region Properties
        private int cbIndex;
        public int CBindex
        {
            get { return cbIndex; }
            set
            {
                cbIndex = value;
                OnPropertyChanged("CBindex");
            }
        }

        private Test selectedItemCB = new Test();
        public Test SelectedItemCB
        {
            get { return selectedItemCB; }
            set
            {
                selectedItemCB = value;
                OnPropertyChanged("SelectedItemCB");
            }
        }

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

        private ObservableCollection<QuestionType> questionTypes = new ObservableCollection<QuestionType>();
        public ObservableCollection<QuestionType> QuestionTypesView
        {
            get { return questionTypes; }
            set
            {
                questionTypes = value;
                OnPropertyChanged("QuestionTypesView");
            }
        }

        private QuestionType selectedQtype = new QuestionType();
        public QuestionType SelectedQtype
        {
            get { return selectedQtype; }
            set
            {
                selectedQtype = value;
                OnPropertyChanged("SelectedQtype");
            }
        }

        private ObservableCollection<Theme> themes = new ObservableCollection<Theme>();
        public ObservableCollection<Theme> ThemesView
        {
            get { return themes; }
            set
            {
                themes = value;
                OnPropertyChanged("ThemesView");
            }
        }

        private Theme selectedTheme = new Theme();
        public Theme SelectedTheme
        {
            get { return selectedTheme; }
            set
            {
                selectedTheme = value;
                OnPropertyChanged("SelectedTheme");
            }
        }

        private ObservableCollection<Test> tests = new ObservableCollection<Test>();
        public ObservableCollection<Test> TestsView
        {
            get { return tests; }
            set
            {
                tests = value;
                OnPropertyChanged("TestsView");
            }
        }

        private Test selectedTest = new Test();
        public Test SelectedTest
        {
            get { return selectedTest; }
            set
            {
                selectedTest = value;
                OnPropertyChanged("SelectedTest");
            }
        }
        #endregion

        #region Methods
        private void SetDataGrid(string o)
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
                               Theme = th.TextTheme,
                               Test = te.TestName,
                               QuestionType = qt.TextType                              
                            }).ToList();
            ObservableCollection<Object> oc = new ObservableCollection<Object>(question);
            QuestionList = oc;
            
            QuestionListCopy = db.Questions.Local.ToObservableCollection();

            if (o != null) SetAnswer(o);
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
            return (question.IDQType);
        }
        private int GetID(string str)
        {
            str = str.Remove(0, 7);
            int i = 0;
            int start = 0;
            int count = 0;
            while (start == 0)
            {
                if (str[i] == ',') start = i;
                else i++;
            }
            while (i < str.Length)
            {
                count++;
                i++;
            }
            str = str.Remove(start, count);
            return (Int32.Parse(str));
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
            db.ChooseAnswers.Load();
            var answer = db.ChooseAnswers.Where(c => c.IDQuestion == selectedItem).ToList();
            ObservableCollection<ChooseAnswer> oc = new ObservableCollection<ChooseAnswer>(answer);
            ChooseAnswers = oc;
        }
        
        private void ComboBoxTestSet()
        {
            db.Tests.Load();
            TestsView = db.Tests.Local.ToObservableCollection();            
        }
        private void SetCBIndex()
        {
            CBindex = -1;
        }
        private void SearchTestName()
        {
            var student = (from q in db.Questions
                           where q.IDTest == CBindex + 1
                           join qt in db.QuestionTypes on q.IDQType equals qt.IDQuestionType
                           join th in db.Themes on q.IDTheme equals th.IDTheme
                           join te in db.Tests on q.IDTest equals te.IDTest
                           orderby q
                           select new
                           {
                               ID = q.IDQuestion,
                               TaskText = q.TaskText,
                               Theme = th.TextTheme,
                               Test = te.TestName,
                               QuestionType = qt.TextType
                           }).ToList();
            ObservableCollection<Object> oc = new ObservableCollection<object>(student);
            QuestionList = oc;
        }
        #endregion
    }
}
