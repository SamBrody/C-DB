using CSharpDB.Context;
using CSharpDB.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Linq;


namespace CSharpProjCore.ViewModel
{
    public class EditQuestionViewModel: BaseViewModel
    {
        DBCContext db = new DBCContext();

        #region Constructor  
        public EditQuestionViewModel()
        {
            ComboBoxQTSet();
            ComboBoxThemeSet();
            ComboBoxTestSet();
            SetCBIndex();
            GridInput = "Collapsed";
            GridChoose = "Collapsed";
            GridRelation = "Collapsed";
            VisibleButton = "Collapsed";
        }        
        #endregion

        //команды
        #region Commands       
        RelayCommand editCommand;
        RelayCommand clearCommand;
        RelayCommand showGrid;
        RelayCommand deleteCommandR;
        RelayCommand deleteCommandCh;
        RelayCommand getIDCommand;
        RelayCommand updatePageCommand;

        public RelayCommand GetIDCommand
        {
            get
            {
                return getIDCommand ??
                  (getIDCommand = new RelayCommand((selectedItem) =>
                  {
                      IDQ = selectedItem.ToString();
                      SelectedQuestionSet(Int32.Parse(IDQ));
                  }));
            }
        }
        public RelayCommand EditCommand
        {
            get
            {
                return editCommand ??
                  (editCommand = new RelayCommand((selectedItem) =>
                  {
                      if (CBindex1 + 1 == 1) EditChooseQuestion();
                      if (CBindex1 + 1 == 2) EditInputQuestion();
                      if (CBindex1 + 1 == 3) EditRelationQuestion();
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
                      ComboBoxQTSet();
                      ComboBoxThemeSet();
                      ComboBoxTestSet();
                  }));
            }
        }  
        public RelayCommand ClearCommand
        {
            get
            {
                return clearCommand ??
                  (clearCommand = new RelayCommand((selectedItem) =>
                  {
                      ClearFunction();
                  }));
            }
        }
        public RelayCommand ShowGrid
        {
            get
            {
                return showGrid ??
                  (showGrid = new RelayCommand((selectedItem) =>
                  {
                      if (CBindex1 + 1 == 1)
                      {
                          GridChoose = "Visible";
                          GridInput = "Collapsed";
                          GridRelation = "Collapsed";
                          VisibleButton = "Collapsed";                          
                      }
                      if (CBindex1 + 1 == 2)
                      {
                          GridInput = "Visible";
                          GridChoose = "Collapsed";
                          GridRelation = "Collapsed";
                          VisibleButton = "Collapsed";
                      }
                      if (CBindex1 + 1 == 3)
                      {
                          GridInput = "Collapsed";
                          GridChoose = "Collapsed";
                          GridRelation = "Visible";
                          VisibleButton = "Visible";
                      }
                  }));
            }
        }
        public RelayCommand DeleteCommandCh
        {
            get
            {
                return deleteCommandCh ??
                  (deleteCommandCh = new RelayCommand((selectedItem) =>
                  {
                      if (selectedItem == null) return;
                      // получаем выделенный объект
                      DelChooseQuestion(selectedItem);
                  }));
            }
        }
        public RelayCommand DeleteCommandR
        {
            get
            {
                return deleteCommandR ??
                  (deleteCommandR = new RelayCommand((selectedItem) =>
                  {
                      if (selectedItem == null) return;
                      // получаем выделенный объект
                      DelRelationQuestion(selectedItem);
                  }));
            }
        }
        #endregion

        //Свойства
        #region Properties  
        private string idQ;
        public string IDQ
        {
            get { return idQ; }
            set
            {
                idQ = value;
                OnPropertyChanged("IDQ");
            }
        }
        private string visibleButton;
        public string VisibleButton
        {
            get { return visibleButton; }
            set
            {
                visibleButton = value;
                OnPropertyChanged("VisibleButton");
            }
        }
        private int cbIndex1;
        public int CBindex1
        {
            get { return cbIndex1; }
            set
            {
                cbIndex1 = value;
                OnPropertyChanged("CBindex1");
            }
        }

        private int cbIndex2;
        public int CBindex2
        {
            get { return cbIndex2; }
            set
            {
                cbIndex2 = value;
                OnPropertyChanged("CBindex2");
            }
        }

        private int cbIndex3;
        public int CBindex3
        {
            get { return cbIndex3; }
            set
            {
                cbIndex3 = value;
                OnPropertyChanged("CBindex3");
            }
        }

        private ObservableCollection<Test> tests = new ObservableCollection<Test>();
        public ObservableCollection<Test> TestView
        {
            get { return tests; }
            set
            {
                tests = value;
                OnPropertyChanged("TestView");
            }
        }

        private Test selectedItem3 = new Test();
        public Test SelectedItem3
        {
            get { return selectedItem3; }
            set
            {
                selectedItem3 = value;
                OnPropertyChanged("SelectedItem3");
            }
        }

        private ObservableCollection<QuestionType> questionTypes = new ObservableCollection<QuestionType>();
        public ObservableCollection<QuestionType> QuestionView
        {
            get { return questionTypes; }
            set
            {
                questionTypes = value;
                OnPropertyChanged("QuestionView");
            }
        }

        private QuestionType selectedItem1 = new QuestionType();
        public QuestionType SelectedItem1
        {
            get { return selectedItem1; }
            set
            {
                selectedItem1 = value;
                OnPropertyChanged("SelectedItem1");
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

        private Theme selectedItem2 = new Theme();
        public Theme SelectedItem2
        {
            get { return selectedItem2; }
            set
            {
                selectedItem2 = value;
                OnPropertyChanged("SelectedItem2");
            }
        }

        private ObservableCollection<Group> groups = new ObservableCollection<Group>();
        public ObservableCollection<Group> GroupsView
        {
            get { return groups; }
            set
            {
                groups = value;
                OnPropertyChanged("GroupsView");
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

        private ChooseAnswer selectedItemChoose = new ChooseAnswer();
        public ChooseAnswer SelectedItemChoose
        {
            get { return selectedItemChoose; }
            set
            {
                selectedItemChoose = value;
                OnPropertyChanged("SelectedItemChoose");
            }
        }

        private ObservableCollection<ChooseAnswer> chooseAnswers = new ObservableCollection<ChooseAnswer>();
        public ObservableCollection<ChooseAnswer> ChooseAnswers
        {
            get { return chooseAnswers; }
            set
            {
                chooseAnswers = value;
                OnPropertyChanged("ChooseAnswers");
            }
        }

        private RelationFirstHalf selectedRFH = new RelationFirstHalf();
        public RelationFirstHalf SelectedRFH
        {
            get { return selectedRFH; }
            set
            {
                selectedRFH = value;
                OnPropertyChanged("SelectedRFH");
            }
        }

        private ObservableCollection<RelationFirstHalf> relationFirstHalves = new ObservableCollection<RelationFirstHalf>();
        public ObservableCollection<RelationFirstHalf> RelationFirstHalves
        {
            get { return relationFirstHalves; }
            set
            {
                relationFirstHalves = value;
                OnPropertyChanged("RelationFirstHalves");
            }
        }
        #endregion

        //Методы
        #region Methods    
        private void ClearFunction()
        {
            CBindex1 = -1;
            CBindex2 = -1;
            CBindex3 = -1;
            QuestionTextInput = "";
            AnswerTextInput = "";
            QuestionTextChoose = "";
            QuestionTextRelation = "";
            RelationFirstHalves.Clear();
            ChooseAnswers.Clear();
        }
        private void ComboBoxQTSet()
        {
            db.QuestionTypes.Load();
            QuestionView = db.QuestionTypes.Local.ToObservableCollection();            
        }
        private void ComboBoxThemeSet()
        {
            db.Themes.Load();
            ThemesView = db.Themes.Local.ToObservableCollection();            
        }
        private void ComboBoxTestSet()
        {
            db.Tests.Load();
            TestView = db.Tests.Local.ToObservableCollection();            
        }
        private void SetCBIndex()
        {
            CBindex1 = -1;
            CBindex2 = -1;
            CBindex3 = -1;
        }
        private void EditInputQuestion()
        {
            try
            {
                if (CBindex2 == -1) MessageBox.Show("Выберите тему!", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                else
                {
                    if (QuestionTextInput == null) MessageBox.Show("Введите вопрос!", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                    else
                    {
                        if (AnswerTextInput == null) MessageBox.Show("Введите ответ!", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                        else
                        {
                            Question q1 = db.Questions.Find(Int32.Parse(IDQ));
                            q1.TaskText = QuestionTextInput;
                            q1.IDQType = CBindex1 + 1;
                            q1.IDTheme = CBindex2 + 1;
                            q1.IDTest = CBindex3 + 1;
                            db.Questions.Update(q1);
                            InputAnswer i1 = db.InputAnswers.Find(q1.IDQuestion);
                            i1.AnswerText = AnswerTextInput; 
                            db.InputAnswers.Update(i1);
                            db.SaveChanges();
                            MessageBox.Show("Операция успешно выполнена!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Возникло исключение -\n {e}", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void EditChooseQuestion()
        {
            try
            {
                if (CBindex2 == -1) MessageBox.Show("Выберите тему!", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                else
                {
                    if (QuestionTextChoose == null) MessageBox.Show("Введите вопрос!", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                    else
                    {
                        if (ChooseAnswers.Count == 0) MessageBox.Show("Добавьте ответов!", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                        else
                        {
                            int BoolCount = 0;
                            for (int i = 0; i < ChooseAnswers.Count; i++)
                            {
                                if (ChooseAnswers[i].IsRight) BoolCount++;
                            }
                            if (BoolCount == 0) MessageBox.Show("Выберите хотя бы один верный вариант!", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                            else
                            {
                                Question q1 = db.Questions.Find(Int32.Parse(IDQ));
                                q1.TaskText = QuestionTextChoose;
                                q1.IDQType = CBindex1 + 1;
                                q1.IDTheme = CBindex2 + 1;
                                q1.IDTest = CBindex3 + 1;
                                db.Questions.Update(q1);
                                var chooseanswerLinq = (from c in db.ChooseAnswers
                                                    where c.IDQuestion== Int32.Parse(IDQ)
                                                    select c).ToList();
                                ObservableCollection<ChooseAnswer> chooseAnswers = new ObservableCollection<ChooseAnswer>(chooseanswerLinq);
                                for (int i = 0; i < chooseAnswers.Count; i++)
                                {                                    
                                    chooseAnswers[i].AnswerText = ChooseAnswers[i].AnswerText;
                                    chooseAnswers[i].IsRight = ChooseAnswers[i].IsRight;
                                    db.ChooseAnswers.Update(chooseAnswers[i]);
                                    db.SaveChanges();
                                }
                                if (chooseAnswers.Count<ChooseAnswers.Count)
                                {
                                    for(int i=chooseAnswers.Count;i<ChooseAnswers.Count;i++)
                                    {
                                        ChooseAnswer c1 = new ChooseAnswer { IDQuestion = q1.IDQuestion, AnswerText = ChooseAnswers[i].AnswerText, IsRight = ChooseAnswers[i].IsRight };
                                        db.ChooseAnswers.Add(c1);
                                        db.SaveChanges();
                                    }
                                }
                                MessageBox.Show("Операция успешно выполнена!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Возникло исключение -\n {e}", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void EditRelationQuestion()
        {
            try
            {
                if (CBindex2 == -1) MessageBox.Show("Выберите тему!", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                else
                {
                    if (QuestionTextRelation == null) MessageBox.Show("Введите вопрос!", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                    else
                    {
                        if (RelationFirstHalves.Count == 0) MessageBox.Show("Добавьте ответов!", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                        else
                        {
                            int EmpCounter = 0;
                            for (int i = 0; i < RelationFirstHalves.Count; i++)
                            {
                                if ((RelationFirstHalves[i].TextLeft == "") || (RelationFirstHalves[i].TextRight == "")) EmpCounter++;
                            }
                            if (EmpCounter != 0) MessageBox.Show("Одно из полей не заполнено!", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                            else
                            {
                                Question q1 = db.Questions.Find(Int32.Parse(IDQ));
                                q1.TaskText = QuestionTextRelation;
                                q1.IDQType = CBindex1 + 1;
                                q1.IDTheme = CBindex2 + 1;
                                q1.IDTest = CBindex3 + 1;
                                db.Questions.Update(q1);
                                var relanswerLinq = (from r in db.RelationFirstHalves
                                                     where r.IDQuestion == Int32.Parse(IDQ)
                                                     select r
                                                    ).ToList();
                                ObservableCollection<RelationFirstHalf> relationFirstHalves = new ObservableCollection<RelationFirstHalf>(relanswerLinq);
                                for (int i = 0; i < relationFirstHalves.Count; i++)
                                {
                                    relationFirstHalves[i].TextLeft = RelationFirstHalves[i].TextLeft;
                                    relationFirstHalves[i].TextRight = RelationFirstHalves[i].TextRight;
                                    db.RelationFirstHalves.Update(relationFirstHalves[i]);
                                    db.SaveChanges();
                                }
                                if (relationFirstHalves.Count < RelationFirstHalves.Count)
                                {
                                    for (int i = relationFirstHalves.Count; i < RelationFirstHalves.Count; i++)
                                    {
                                        RelationFirstHalf r1 = new RelationFirstHalf { IDQuestion = q1.IDQuestion, TextLeft = RelationFirstHalves[i].TextLeft, TextRight = RelationFirstHalves[i].TextRight };
                                        db.RelationFirstHalves.Add(r1);
                                        db.SaveChanges();
                                    }
                                }
                                MessageBox.Show("Операция успешно выполнена!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Возникло исключение -\n {e}", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void DelRelationQuestion(object selectedItem)
        {
            RelationFirstHalf relationFirstHalf = selectedItem as RelationFirstHalf;
            try
            {
                RelationFirstHalves.Remove(relationFirstHalf);
                MessageBox.Show("Операция успешно выполнена!", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show($"Возникло исключение -\n {e}", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void DelChooseQuestion(object selectedItem)
        {
            ChooseAnswer chooseAnswer = selectedItem as ChooseAnswer;
            try
            {
                ChooseAnswers.Remove(chooseAnswer);
                MessageBox.Show("Операция успешно выполнена!", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show($"Возникло исключение -\n {e}", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void SelectedQuestionSet(int IDQ)
        {
            var questionLinq = (from q in db.Questions
                                where q.IDQuestion == IDQ
                                select q).ToList();
            ObservableCollection<Question> oc = new ObservableCollection<Question>(questionLinq);
            if (oc[0].IDQType == 1) SetChooseAnswer(oc);
            if (oc[0].IDQType == 2) SetInputAnswer(oc);
            if (oc[0].IDQType == 3) SetRelationAnswer(oc);
        }
        private void SetChooseAnswer(ObservableCollection<Question> question)
        {
            SetStandartQuestionInfo(question);           
            QuestionTextChoose = question[0].TaskText;
            var answerLinq = (from a in db.ChooseAnswers
                              where a.IDQuestion == question[0].IDQuestion
                              select a).ToList();
            ObservableCollection<ChooseAnswer> oc = new ObservableCollection<ChooseAnswer>(answerLinq);
            ChooseAnswers = oc;
        }      
        private void SetInputAnswer(ObservableCollection<Question> question)
        {
            SetStandartQuestionInfo(question);            
            var answerLinq = (from a in db.InputAnswers
                              where a.IDQuestion == question[0].IDQuestion
                              select a).ToList();
            ObservableCollection<InputAnswer> oc = new ObservableCollection<InputAnswer>(answerLinq);
            QuestionTextInput = question[0].TaskText;
            AnswerTextInput = oc[0].AnswerText;
        }
        private void SetRelationAnswer(ObservableCollection<Question> question)
        {
            SetStandartQuestionInfo(question);
            QuestionTextRelation = question[0].TaskText;
            var answerLinq = (from a in db.RelationFirstHalves
                              where a.IDQuestion == question[0].IDQuestion
                              select a).ToList();
            ObservableCollection<RelationFirstHalf> oc = new ObservableCollection<RelationFirstHalf>(answerLinq);
            RelationFirstHalves = oc;
        }
        private void SetStandartQuestionInfo(ObservableCollection<Question> questions)
        {
            SelectedItem1 = questions[0].QuestionType;
            SelectedItem2 = questions[0].Theme;
            SelectedItem3 = questions[0].Test;
        }
        #endregion
    }
}
