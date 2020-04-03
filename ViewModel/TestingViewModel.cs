using CSharpDB.Context;
using CSharpDB.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Windows;
using CSharpProjCore.Model;
using System.Windows.Input;
using System.Windows.Threading;

namespace CSharpProjCore.ViewModel
{
    public class TestingViewModel : BaseViewModel
    {
        DBCContext db = new DBCContext();
        DispatcherTimer _timer;
        TimeSpan _time;

        #region Constructor
        public TestingViewModel()
        {
            CheckButtonClick = false;
            ChooseAnswersCopy = new ObservableCollection<ChooseAnswer>();
            //RelationUserAnswers = new ObservableCollection<RelationFirstHalf>();
            RealtionAnswerCopy = new ObservableCollection<RelationFirstHalf>();
            //RealtionSetAnswer = new ObservableCollection<RelationFirstHalf>();
            InputAnswersCopy = new ObservableCollection<InputAnswer>();
            ChooseAnswers = new ObservableCollection<ChooseAnswer>();
            //SelectedRH = new RelationFirstHalf();            
            SetStartValue();
        }
        #endregion

        #region Commands 
        RelayCommand startCommand;
        RelayCommand isSelectedCommand;
        RelayCommand finishCommand;
        RelayCommand addInputCommand;
        RelayCommand addCheckUserCommand;
        RelayCommand addRelationCommand;
        RelayCommand setAnswerCommand;
        RelayCommand argeeCommand;
        RelayCommand closeCommand;
        RelayCommand getUserCommand;

        public RelayCommand StartCommand
        {
            get
            {
                return startCommand ??
                  (startCommand = new RelayCommand((o) =>
                  {                      
                      int id = Convert.ToInt32(o);
                      IDText = o.ToString();
                      var test = (from t in db.Tests
                                  where t.IDTest == id
                                  select t).ToList();
                      Test selItem = test[0] as Test;
                      StartTimer(selItem);
                      SetCountQuestion(selItem);
                      SetQuestionPool(selItem);
                      ResVis = "Collapsed";                      
                  }));
            }
        }        
        public RelayCommand IsSelectedCommand
        {
            get
            {
                return isSelectedCommand ??
                  (isSelectedCommand = new RelayCommand((o) =>
                  {
                      SelectedQuestionSet(Convert.ToInt32(o));
                  }));
            }
        }
        public RelayCommand FinishCommand
        {
            get
            {
                return finishCommand ??
                  (finishCommand = new RelayCommand((o) =>
                  {
                      MessageBoxResult result = MessageBox.Show("Вы действительно хотите закончить тестирование?", "Завершение тестирования", MessageBoxButton.YesNo, MessageBoxImage.Question);
                      if (result == MessageBoxResult.Yes)
                      {
                          CheckButtonClick = true;
                          FinishTest(o.ToString());
                      }
                  }));
            }
        }        
        public RelayCommand AddInputCommand
        {
            get
            {
                return addInputCommand ??
                  (addInputCommand = new RelayCommand((o) =>
                  {
                      AddUserAnswer((int)o);
                  }));
            }
        }
        public RelayCommand AddCheckUserCommand
        {
            get
            {
                return addCheckUserCommand ??
                  (addCheckUserCommand = new RelayCommand((o) =>
                  {
                      if (o != null)
                      {
                          int counter = 0;
                          ChooseAnswer choose = o as ChooseAnswer;
                          for (int i = 0; i < QuestionsList.Count; i++)
                          {
                              if (QuestionsList[i].IDQuestion == choose.IDQuestion) counter = i;
                          }
                          AddUserAnswer(counter + 1);
                      }
                      else
                      {
                          MessageBox.Show("Сначала выберите строку!");
                      }
                  }));
            }
        }
        public RelayCommand AddRelationCommand
        {
            get
            {
                return addRelationCommand ??
                  (addRelationCommand = new RelayCommand((o) =>
                  {
                      AddUserAnswer(Convert.ToInt32(o));
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
                          Question question = o as Question;
                          SetAnswer(question);
                      }
                  }));
            }
        }
        public RelayCommand ArgeeCommand
        {
            get
            {
                return argeeCommand ??
                  (argeeCommand = new RelayCommand((o) =>
                  {
                      MessageBoxResult result = MessageBox.Show("Вы действительно хотите закончить тестирование?\n По итогу результат будет всё равно просчитан!", "Закрыть тестирование", MessageBoxButton.YesNo, MessageBoxImage.Question);
                      if (result == MessageBoxResult.Yes)
                      {
                          FinishTest(o.ToString());                          
                      }
                  }));
            }
        }
        public RelayCommand CloseCommand
        {
            get
            {
                return closeCommand ??
                  (closeCommand = new RelayCommand((o) =>
                  {
                      if (CheckButtonClick!=true)
                      {
                          FinishTest(o.ToString());
                      }                        
                  }));
            }
        }
        public RelayCommand GetUserCommand
        {
            get
            {
                return getUserCommand ??
                  (getUserCommand = new RelayCommand((o) =>
                  {
                      UserNameText = o.ToString();
                  }));
            }
        }
        #endregion

        #region Properties  
        private bool checkButtonClick;
        public bool CheckButtonClick
        {
            get { return checkButtonClick; }
            set
            {
                checkButtonClick = value;
                OnPropertyChanged("CheckButtonClick");
            }
        }

        private string timerDisplay;
        public string TimerDisplay
        {
            get { return timerDisplay; }
            set
            {
                timerDisplay = value;
                OnPropertyChanged("TimerDisplay");
            }
        }

        private string colorTime;
        public string ColorTimer
        {
            get { return colorTime; }
            set
            {
                colorTime = value;
                OnPropertyChanged("ColorTimer");
            }
        }

        private string rateTextBlock;
        public string RateTextBlock
        {
            get { return rateTextBlock; }
            set
            {
                rateTextBlock = value;
                OnPropertyChanged("RateTextBlock");
            }
        }

        private string statText;
        public string StatText
        {
            get { return statText; }
            set
            {
                statText = value;
                OnPropertyChanged("StatText");
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

        private int rating;
        public int Rating
        {
            get { return rating; }
            set
            {
                rating = value;
                OnPropertyChanged("Rating");
            }
        }

        private string userNameText;
        public string UserNameText
        {
            get { return userNameText; }
            set
            {
                userNameText = value;
                OnPropertyChanged("UserNameText");
            }
        }

        private string idText;
        public string IDText
        {
            get { return idText; }
            set
            {
                idText = value;
                OnPropertyChanged("IDText");
            }
        }
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

        private ObservableCollection<int> selectedItemV;
        public ObservableCollection<int> SelectedItemV
        {
            get { return selectedItemV; }
            set
            {
                selectedItemV = value;
                OnPropertyChanged("SelectedItemV");
            }
        }

        //private string selectedList;
        //public string SelectedList
        //{
        //    get { return selectedList; }
        //    set
        //    {
        //        selectedList = value;
        //        OnPropertyChanged("SelectedList");
        //    }
        //}

        //private string listV;
        //public string ListV
        //{
        //    get { return listV; }
        //    set
        //    {
        //        listV = value;
        //        OnPropertyChanged("ListV");
        //    }
        //}

        private string resVis;
        public string ResVis
        {
            get { return resVis; }
            set
            {
                resVis = value;
                OnPropertyChanged("ResVis");
            }
        }

        private string questionTextChoose;
        public string QuestionTextChoose
        {
            get { return questionTextChoose; }
            set
            {
                questionTextChoose = value;
                OnPropertyChanged("QuestionTextChoose");
            }
        }

        private string questionTextRelation;
        public string QuestionTextRelation
        {
            get { return questionTextRelation; }
            set
            {
                questionTextRelation = value;
                OnPropertyChanged("QuestionTextRelation");
            }
        }

        private string answerTextInput;
        public string AnswerTextInput
        {
            get { return answerTextInput; }
            set
            {
                answerTextInput = value;
                OnPropertyChanged("AnswerTextInput");
            }
        }

        private string questionTextInput;
        public string QuestionTextInput
        {
            get { return questionTextInput; }
            set
            {
                questionTextInput = value;
                OnPropertyChanged("QuestionTextInput");
            }
        }

        private string gridInput;
        public string GridInput
        {
            get { return gridInput; }
            set
            {
                gridInput = value;
                OnPropertyChanged("GridInput");
            }
        }

        private string gridChoose;
        public string GridChoose
        {
            get { return gridChoose; }
            set
            {
                gridChoose = value;
                OnPropertyChanged("GridChoose");
            }
        }

        private string gridRelation;
        public string GridRelation
        {
            get { return gridRelation; }
            set
            {
                gridRelation = value;
                OnPropertyChanged("GridRelation");
            }
        }

        private ObservableCollection<Test> testI;
        public ObservableCollection<Test> TestI
        {
            get { return testI; }
            set
            {
                testI = value;
                OnPropertyChanged("TestI");
            }
        }

        private ObservableCollection<ChooseAnswer> chooseAnswers;
        public ObservableCollection<ChooseAnswer> ChooseAnswers
        {
            get { return chooseAnswers; }
            set
            {
                chooseAnswers = value;
                OnPropertyChanged("ChooseAnswers");
            }
        }

        private ObservableCollection<ChooseAnswer> chooseAnswersView;
        public ObservableCollection<ChooseAnswer> ChooseAnswersView
        {
            get { return chooseAnswersView; }
            set
            {
                chooseAnswersView = value;
                OnPropertyChanged("ChooseAnswersView");
            }
        }

        private ObservableCollection<InputAnswer> inputAnswersView;
        public ObservableCollection<InputAnswer> InputAnswersView
        {
            get { return inputAnswersView; }
            set
            {
                inputAnswersView = value;
                OnPropertyChanged("InputAnswersView");
            }
        }

        private ObservableCollection<RelationFirstHalf> relationFirstHalves;
        public ObservableCollection<RelationFirstHalf> RelationFirstHalves
        {
            get { return relationFirstHalves; }
            set
            {
                relationFirstHalves = value;
                OnPropertyChanged("RelationFirstHalves");
            }
        }

        //private ObservableCollection<Test> testsView;
        //public ObservableCollection<Test> TestsView
        //{
        //    get { return testsView; }
        //    set
        //    {
        //        testsView = value;
        //        OnPropertyChanged("TestsView");
        //    }
        //}

        private ObservableCollection<int> countQuestion;
        public ObservableCollection<int> CountQuestion
        {
            get { return countQuestion; }
            set
            {
                countQuestion = value;
                OnPropertyChanged("CountQuestion");
            }
        }

        //private string testlistViewVis;
        //public string TestlistViewVis
        //{
        //    get { return testlistViewVis; }
        //    set
        //    {
        //        testlistViewVis = value;
        //        OnPropertyChanged("TestlistViewVis");
        //    }
        //}

        private string testViewVis;
        public string TestViewVis
        {
            get { return testViewVis; }
            set
            {
                testViewVis = value;
                OnPropertyChanged("TestViewVis");
            }
        }

        private Test selectedItem;
        public Test SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        private ObservableCollection<Question> questions;
        public ObservableCollection<Question> QuestionsList
        {
            get { return questions; }
            set
            {
                questions = value;
                OnPropertyChanged("QuestionsListCopy");
            }
        }

        private ObservableCollection<Question> questionsListView;
        public ObservableCollection<Question> QuestionsListView
        {
            get { return questionsListView; }
            set
            {
                questionsListView = value;
                OnPropertyChanged("QuestionsListView");
            }
        }
        private ObservableCollection<ChooseAnswer> chooseAnswersCopy;
        public ObservableCollection<ChooseAnswer> ChooseAnswersCopy
        {
            get { return chooseAnswersCopy; }
            set
            {
                chooseAnswersCopy = value;
                OnPropertyChanged("ChooseAnswersCopy");
            }
        }

        private ObservableCollection<InputAnswer> inputAnswersCopy;
        public ObservableCollection<InputAnswer> InputAnswersCopy
        {
            get { return inputAnswersCopy; }
            set
            {
                inputAnswersCopy = value;
                OnPropertyChanged("InputAnswersCopy");
            }
        }

        private ObservableCollection<RelationFirstHalf> realtionAnswerCopy;
        public ObservableCollection<RelationFirstHalf> RealtionAnswerCopy
        {
            get { return realtionAnswerCopy; }
            set
            {
                realtionAnswerCopy = value;
                OnPropertyChanged("RealtionAnswerCopy");
            }
        }

        //private ObservableCollection<RelationFirstHalf> realtionSetAnswer;
        //public ObservableCollection<RelationFirstHalf> RealtionSetAnswer
        //{
        //    get { return realtionSetAnswer; }
        //    set
        //    {
        //        realtionSetAnswer = value;
        //        OnPropertyChanged("RealtionSetAnswer");
        //    }
        //}

        //private ObservableCollection<string> relationAnswersList;
        //public ObservableCollection<string> RelationAnswersList
        //{
        //    get { return relationAnswersList; }
        //    set
        //    {
        //        relationAnswersList = value;
        //        OnPropertyChanged("RelationAnswersList");
        //    }
        //}

        private ObservableCollection<ChooseAnswer> chooseUserAnswers;
        public ObservableCollection<ChooseAnswer> ChooseUserAnswers
        {
            get { return chooseUserAnswers; }
            set
            {
                chooseUserAnswers = value;
                OnPropertyChanged("ChooseUserAnswers");
            }
        }

        private ObservableCollection<InputAnswer> inputUserAnswers;
        public ObservableCollection<InputAnswer> InputUserAnswers
        {
            get { return inputUserAnswers; }
            set
            {
                inputUserAnswers = value;
                OnPropertyChanged("InputUserAnswers");
            }
        }

        //private ObservableCollection<RelationFirstHalf> relationUserAnswers;
        //public ObservableCollection<RelationFirstHalf> RelationUserAnswers
        //{
        //    get { return relationUserAnswers; }
        //    set
        //    {
        //        relationUserAnswers = value;
        //        OnPropertyChanged("RelationUserAnswers");
        //    }
        //}

        private ChooseAnswer selectedItemChoose;
        public ChooseAnswer SelectedItemChoose
        {
            get { return selectedItemChoose; }
            set
            {
                selectedItemChoose = value;
                OnPropertyChanged("SelectedItemChoose");
            }
        }

        private Question selectedQ;
        public Question SelectedQ
        {
            get { return selectedQ; }
            set
            {
                selectedQ = value;
                OnPropertyChanged("SelectedQ");
            }
        }

        //private RelationFirstHalf selectedRH;
        //public RelationFirstHalf SelectedRH
        //{
        //    get { return selectedRH; }
        //    set
        //    {
        //        selectedRH = value;
        //        OnPropertyChanged("SelectedRH");
        //    }
        //}

        private ObservableCollection<ChooseAnswer> defAnsw = new ObservableCollection<ChooseAnswer>();
        public ObservableCollection<ChooseAnswer> DefAnsw
        {
            get { return defAnsw; }
            set
            {
                defAnsw = value;
                OnPropertyChanged("DefAnsw");
            }
        }

        private ObservableCollection<ChooseAnswer> userAnsww = new ObservableCollection<ChooseAnswer>();
        public ObservableCollection<ChooseAnswer> UserAnsw
        {
            get { return userAnsww; }
            set
            {
                userAnsww = value;
                OnPropertyChanged("UserAnsw");
            }
        }
        #endregion

        #region Methods
        private void StartTimer(Test test)
        {
            ColorTimer = "#FFC5C5C5";
            _time = TimeSpan.FromSeconds(test.Time * 60);
            _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                TimerDisplay = _time.ToString("c");
                if (_time <= TimeSpan.FromSeconds(10)) ColorTimer = "Red";
                if (_time == TimeSpan.Zero)
                {
                    _timer.Stop();
                    FinishTest(UserNameText);
                }                    
                _time = _time.Add(TimeSpan.FromSeconds(-1));
            }, Application.Current.Dispatcher);

            _timer.Start();
        }

        public void Close()
        {
            this.Close();
        }

        private void FinishTest(string o)
        {
            Rating = 0;
            RatingScore();
            int FinalRating = 0;
            double percent = 0;
            double a = Rating;
            double b = QuestionsList.Count;
            percent = ((a / b) * 100);
            if ((percent >= 42) && (percent <= 61)) FinalRating = 3;
            if ((percent >= 62) && (percent <= 84)) FinalRating = 4;
            if ((percent >= 85) && (percent <= 100)) FinalRating = 5;
            if (percent < 42) FinalRating = 2;
            User user = FindUserByLogin(o.ToString());
            TestResults testResults = new TestResults { Date = DateTime.Now, IDTest = Convert.ToInt32(IDText), Grade = FinalRating.ToString(), IDUserProfile = user.IDUser };
            db.TestResultss.Add(testResults);
            db.SaveChanges();
            SetQuestionDataGrid();
            ResVis = "Visible";
            TestViewVis = "Collapsed";
            RateTextBlock = FinalRating.ToString();
            StatText = $"{Rating} правильных из {QuestionsList.Count}";
        }

        private User FindUserByLogin(string username)
        {
            var user = (from u in db.Users
                        where u.Login == username
                        select u).ToList();
            User UserL = user[0] as User;
            return (UserL);
        }

        private void SetStartValue()
        {
            if(InputAnswersCopy!=null) InputAnswersCopy.Clear();
            if (InputUserAnswers != null) InputUserAnswers.Clear();
            if (ChooseUserAnswers != null) ChooseUserAnswers.Clear();
            if (ChooseAnswersCopy != null) ChooseAnswersCopy.Clear();

            ChooseAnswerVis = "Collapsed";
            InputAnswerVis = "Collapsed";

            GridInput = "Collapsed";
            GridChoose = "Collapsed";
            GridRelation = "Collapsed";
            TestViewVis = "Visible";
            ResVis = "Collapsed";
        }

        private void SetQuestionDataGrid()
        {
            db.Questions.Load();
            QuestionsListView = QuestionsList;
        }

        private void SetCountQuestion(Test item)
        {
            int[] common = new int[item.QuestionCount];
            for (int i = 0; i < item.QuestionCount; i++)
            {
                common[i] = i + 1;
            };
            ObservableCollection<int> oc = new ObservableCollection<int>(common);
            CountQuestion = oc;
        }
        private void SetQuestionPool(Test selItem)
        {
            var questionLinq = (from q in db.Questions
                                where q.IDTest == selItem.IDTest
                                select q).ToList();
            Random rand = new Random();            
            ObservableCollection<Question> questions = new ObservableCollection<Question>(questionLinq.OrderBy(c=>rand.Next()).Take(questionLinq.Count));           
            QuestionsList = questions;
            SetEmptyAnswer(questions);
            //GetRandomValue();
        }

        private void SetEmptyAnswer(ObservableCollection<Question> questions)
        {
            foreach (var item in questions)
            {
                if (item.IDQType == 1) SetEmptyChooseAnswer(item);
                if (item.IDQType == 2) SetEmptyInputAnswer(item);
                //if (item.IDQType == 3) SetEmptyRelationAnswer(item);
            }
        }
        //private void SetEmptyRelationAnswer(Question item)
        //{
        //    var answerLinq = (from a in db.RelationFirstHalves
        //                      where a.IDQuestion == item.IDQuestion
        //                      select a).ToList();
        //    ObservableCollection<RelationFirstHalf> oc = new ObservableCollection<RelationFirstHalf>(answerLinq);
        //    for (int i = 0; i < oc.Count; i++)
        //    {
        //        RealtionAnswerCopy.Add(oc[i]);
        //    }
        //    var clonedCollection = RealtionAnswerCopy.Select(objEnt => (RelationFirstHalf)objEnt.Clone()).ToList();
        //    RelationUserAnswers = new ObservableCollection<RelationFirstHalf>(clonedCollection);
        //    foreach (var ra in RelationUserAnswers)
        //    {
        //        ra.TextRight = "";
        //    }
        //}
        private void SetEmptyInputAnswer(Question item)
        {
            var answerLinq = (from a in db.InputAnswers
                              where a.IDQuestion == item.IDQuestion
                              select a).ToList();
            ObservableCollection<InputAnswer> oc = new ObservableCollection<InputAnswer>(answerLinq);
            for (int i = 0; i < oc.Count; i++)
            {
                InputAnswersCopy.Add(oc[i]);
            }
            var clonedCollection = InputAnswersCopy.Select(objEnt => (InputAnswer)objEnt.Clone()).ToList();
            InputUserAnswers = new ObservableCollection<InputAnswer>(clonedCollection);
            foreach (var iua in InputUserAnswers)
            {
                iua.AnswerText = "";
            }
        }
        private void SetEmptyChooseAnswer(Question item)
        {
            var answerLinq = (from a in db.ChooseAnswers
                              where a.IDQuestion == item.IDQuestion
                              select a).ToList();
            ObservableCollection<ChooseAnswer> oc = new ObservableCollection<ChooseAnswer>(answerLinq);
            for (int i = 0; i < oc.Count; i++)
                ChooseAnswersCopy.Add(oc[i]);
            var clonedCollection = ChooseAnswersCopy.Select(objEnt => (ChooseAnswer)objEnt.Clone()).ToList();
            ChooseUserAnswers = new ObservableCollection<ChooseAnswer>(clonedCollection);
            foreach (var cua in ChooseUserAnswers)
                cua.IsRight = false;
        }

        private void SelectedQuestionSet(int idQ)
        {
            int poz = idQ - 1;
            if (QuestionsList[poz].IDQType == 1) SetChooseAnswer(poz);
            if (QuestionsList[poz].IDQType == 2) SetInputAnswer(poz);
            //if (QuestionsList[poz].IDQType == 3) SetRelationAnswer(poz);
        }
        private void SetChooseAnswer(int poz)
        {
            QuestionTextChoose = QuestionsList[poz].TaskText;
            var answerLinq = (from a in db.ChooseAnswers
                              where a.IDQuestion == QuestionsList[poz].IDQuestion
                              select a).ToList();
            //ObservableCollection<ChooseAnswer> oc = new ObservableCollection<ChooseAnswer>(answerLinq);                        
            //foreach (var item in answerLinq)
            //{
            //    var clone = (ChooseAnswer)item.Clone();
            //    ChooseAnswers.Add(clone);
            //}
            ChooseAnswers.Clear();
            var currentAnsw = ChooseUserAnswers.Where(id => id.IDQuestion == QuestionsList[poz].IDQuestion).ToList();
            ObservableCollection<ChooseAnswer> CurAnsw = new ObservableCollection<ChooseAnswer>();
            foreach (var item in currentAnsw)
            {
                var clone =(ChooseAnswer)item.Clone();
                CurAnsw.Add(clone);
            }
            foreach (var item in CurAnsw)
            {
                var clone = (ChooseAnswer)item.Clone();
                ChooseAnswers.Add(clone);
            }
            //for (int i = 0; i < ChooseAnswers.Count; i++)
            //{
            //    ChooseAnswers[i].IsRight = CurAnsw[i].IsRight;
            //}
            GridInput = "Collapsed";
            GridChoose = "Visible";
            GridRelation = "Collapsed";
        }
        private void SetInputAnswer(int poz)
        {
            QuestionTextInput = QuestionsList[poz].TaskText;
            for (int i = 0; i < InputUserAnswers.Count; i++)
            {
                if (InputUserAnswers[i].IDQuestion == QuestionsList[poz].IDQuestion)
                    AnswerTextInput = InputUserAnswers[i].AnswerText;
            }
            GridInput = "Visible";
            GridChoose = "Collapsed";
            GridRelation = "Collapsed";
        }
        //private void SetRelationAnswer(int poz)
        //{
        //    QuestionTextRelation = QuestionsList[poz].TaskText;
        //    var answerLinq = (from a in db.RelationFirstHalves
        //                      where a.IDQuestion == QuestionsList[poz].IDQuestion
        //                      select a).ToList();
        //    ObservableCollection<RelationFirstHalf> oc = new ObservableCollection<RelationFirstHalf>(answerLinq);
        //    RelationFirstHalves = new ObservableCollection<RelationFirstHalf>(oc);
        //    var currentAnsw = RelationUserAnswers.Where(id => id.IDQuestion == QuestionsList[poz].IDQuestion).ToList();
        //    ObservableCollection<RelationFirstHalf> CurAnsw = new ObservableCollection<RelationFirstHalf>(currentAnsw);
        //    RealtionSetAnswer = oc;
        //    for (int i = 0; i < RealtionSetAnswer.Count; i++)
        //    {
        //        if (CurAnsw[i].TextRight == "") CBindex = -1;
        //        //RelationFirstHalves[i].TextRight = CurAnsw[i].TextRight;
        //        //SelectedRH.TextRight = CurAnsw[i].TextRight;
        //    }
        //    GridInput = "Collapsed";
        //    GridChoose = "Collapsed";
        //    GridRelation = "Visible";
        //}

        //private string GetTextPart(string v)
        //{
        //    v = v.Remove(0, 8);
        //    int i = 0;
        //    int count = 0;
        //    while (count == 0)
        //    {
        //        if (v[i] == '=') count = i + 2;
        //        else i++;
        //    }
        //    v = v.Remove(0, count);
        //    v = v.Remove(v.Length - 2, 2);
        //    return (v);
        //}
        //private int GetID(string v)
        //{
        //    v = v.Remove(0, 8);
        //    int i = 0;
        //    int count = 0;
        //    while (count == 0)
        //    {
        //        if (v[i] == '}') count = i + 1;
        //        else i++;
        //    }
        //    v = v.Remove(0, count);
        //    return (Int32.Parse(v));
        //}

        private void AddUserAnswer(int idQ)
        {
            int poz = idQ - 1;
            if (QuestionsList[poz].IDQType == 1) AddUserChooseAnswer(poz);
            if (QuestionsList[poz].IDQType == 2) AddUserInputAnswer(poz);
            //if (QuestionsList[poz].IDQType == 3) AddUserRelationAnswer(poz);
        }
        private void AddUserChooseAnswer(int poz)
        {
            int j = 0;
            for (int i = 0; i < ChooseUserAnswers.Count; i++)
            {
                if (ChooseUserAnswers[i].IDQuestion == QuestionsList[poz].IDQuestion)
                {                    
                    ChooseUserAnswers[i] = ChooseAnswers[j];
                    j++;
                }
            }
            var a = ChooseAnswersCopy;
        }
        private void AddUserInputAnswer(int poz)
        {
            for (int i = 0; i < InputUserAnswers.Count; i++)
            {
                if (InputUserAnswers[i].IDQuestion == QuestionsList[poz].IDQuestion)
                {
                    InputUserAnswers[i].AnswerText = AnswerTextInput;
                }
            }
        }
        //private void AddUserRelationAnswer(int poz)
        //{
        //    int b = CBindex;
        //    var a = SelectedRH;
        //    for (int i = 0; i < RelationUserAnswers.Count; i++)
        //    {
        //        if ((RelationUserAnswers[i].IDQuestion == QuestionsList[poz].IDQuestion))
        //        {
        //            RelationUserAnswers[i].TextRight = SelectedRH.TextRight;
        //        }
        //    }
        //

        private void RatingScore()
        {
            foreach (var item in QuestionsList)
            {
                if (item.IDQType == 1) RateChoose(item);
                if (item.IDQType == 2) RateInput(item);
                //if (item.IDQType == 3) SetEmptyRelationAnswer(item);                
            }
        }
        private void RateChoose(Question item)
        {     
            //заменить все на копию
            //сделать копию коллекции
            var defAnsw = ChooseAnswersCopy.Where(id => id.IDQuestion == item.IDQuestion).ToList();
            DefAnsw.Clear();
            foreach (var ua in defAnsw)
            {
                var clone = (ChooseAnswer)ua.Clone();
                DefAnsw.Add(clone);
            }
            var userAnsw = ChooseUserAnswers.Where(id => id.IDQuestion == item.IDQuestion).ToList();
            UserAnsw.Clear();
            foreach (var ua in userAnsw)
            {
                var clone = (ChooseAnswer)ua.Clone();
                UserAnsw.Add(clone);
            }
            int checkCoincidence = 0;
            int TrueCount = 0;
            int checkTrue = 0;
            foreach (var t in DefAnsw)
            {
                if (t.IsRight == true) TrueCount++;
            }
            for (int i = 0; i < defAnsw.Count; i++)
            {
                if (DefAnsw[i].IsRight == UserAnsw[i].IsRight) checkCoincidence++;
                if ((DefAnsw[i].IsRight == UserAnsw[i].IsRight) && (DefAnsw[i].IsRight == true) && (UserAnsw[i].IsRight == true)) checkTrue++;
            }
            if ((checkCoincidence == DefAnsw.Count) && (checkTrue== TrueCount)) Rating++;
        }
        private void RateInput(Question item)
        {
            var defAnsw = InputAnswersCopy.Where(id => id.IDQuestion == item.IDQuestion).ToList();
            ObservableCollection<InputAnswer> DefAnsw = new ObservableCollection<InputAnswer>(defAnsw);
            var userAnsw = InputUserAnswers.Where(id => id.IDQuestion == item.IDQuestion).ToList();
            ObservableCollection<InputAnswer> UserAnsw = new ObservableCollection<InputAnswer>(userAnsw);
            if (DefAnsw == UserAnsw) Rating++;
            int k = 0;
            for (int i = 0; i < defAnsw.Count; i++)
            {
                if (DefAnsw[i].AnswerText.ToUpper() == UserAnsw[i].AnswerText.ToUpper()) k++;
            }
            if (k == defAnsw.Count) Rating++;
        }

        private void SetAnswer(Question selectedItem)
        {
            if (selectedItem.IDQType == 1) SetChooseAnswer2(selectedItem.IDQuestion);
            if (selectedItem.IDQType == 2) SetInputAnswer2(selectedItem.IDQuestion);
            //if (selectedItem.IDQType == 3) SetRelationAnswer(id);
        }
       
        private void SetInputAnswer2(int selectedItem)
        {            
            ChooseAnswerVis = "Collapsed";
            InputAnswerVis = "Visible";
            var answer = InputUserAnswers.Where(id => id.IDQuestion == selectedItem);
            ObservableCollection<InputAnswer> oc = new ObservableCollection<InputAnswer>(answer);
            InputAnswersView = oc;
        }
        private void SetChooseAnswer2(int selectedItem)
        {
            InputAnswerVis = "Collapsed";
            ChooseAnswerVis = "Visible";
            var answer = ChooseUserAnswers.Where(c => c.IDQuestion == selectedItem).ToList();
            ObservableCollection<ChooseAnswer> oc = new ObservableCollection<ChooseAnswer>(answer);
            ChooseAnswersView = oc;
        }
        #endregion
    }
}
