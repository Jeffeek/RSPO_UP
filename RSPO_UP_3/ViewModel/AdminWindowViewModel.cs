using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using RSPO_UP_3.Models.DataModels;
using RSPO_UP_3.Services;
using RSPO_UP_3.ViewModel.Base;

namespace RSPO_UP_3.ViewModel
{
    class AdminWindowViewModel : ViewModelBase
    {

        #region fields

        private ObservableCollection<Question> _questions;
        private Question _selectedQuestion;
        private bool _isReadOnlyMode = true;
        private string _title = "Admin Panel";
        private int _selectedCheckBoxCount = 2;

        #endregion

        #region commands

        public ICommand EditingModeCommand { get; }
        public ICommand LoadQuestionsCommand { get; }
        public ICommand ReloadQuestionsCommand { get; }
        public ICommand SaveQuestionsCommand { get; }
        public ICommand RemoveQuestionCommand { get; }
        public ICommand AddQuestionCommand { get; }
        public ICommand CheckBoxCommand { get; }

        #endregion

        #region properties

        public string Title
        {
            get => _title;
            set => SetValue(ref _title, value);
        }

        public Question SelectedQuestion
        {
            get => _selectedQuestion;
            set => SetValue(ref _selectedQuestion, value);
        }

        public ObservableCollection<Question> Questions
        {
            get => _questions;
            set => SetValue(ref _questions, value);
        }

        public bool IsReadOnlyMode
        {
            get => _isReadOnlyMode;
            set => SetValue(ref _isReadOnlyMode, value);
        }

        #endregion

        public bool CanRemoveQuestionExecute() => SelectedQuestion != null;
        public void OnRemoveQuestionExecuted()
        {
            Questions.Remove(SelectedQuestion);
            SelectedQuestion = null;
        }

        public bool CanAddQuestionExecute() => true;
        public void OnAddQuestionExecuted()
        {
            var item = new Question()
            {
                Answers = new Answer[5]
                {
                    new Answer(), 
                    new Answer(), 
                    new Answer(), 
                    new Answer(), 
                    new Answer()
                },
                Text = String.Empty,
                Id = Questions.LastOrDefault()?.Id + 1 ?? 999
            };
            Questions.Add(item);
            SelectedQuestion = Questions.Last();
        }

        private bool CanLoadQuestionsExecute() => true;
        private void OnLoadQuestionsExecuted()
        {
            Questions = QuestionDeserializer.GetObservableCollectionOfQuestions();
            if (Questions.Any())
                SelectedQuestion = Questions.First();
        }

        private bool CanReloadQuestionsExecute() => true;
        private void OnReloadQuestionsExecuted()
        {
            IsReadOnlyMode = true;
            OnLoadQuestionsExecuted();
            SelectedQuestion = Questions.FirstOrDefault();
        }

        private bool CanChangeEditingMode() => true;
        private void OnEditingModeExecuted()
        {
            IsReadOnlyMode = !IsReadOnlyMode;
            if (IsReadOnlyMode)
                Title = "Admin Panel";
            else
                Title = "Admin Panel (edit mode)";
        }


        private bool CanSaveQuestionsExecute() => IsReadOnlyMode && Questions != null && Questions.All(x => x.Answers.Count(y => y.IsRight) == 2) && Questions.All(x => x.Answers.All(y => y.Text != null)) && Questions.All(x => !string.IsNullOrEmpty(x.Text));
        private void OnSaveQuestionsExecuted()
        {
            if (IsReadOnlyMode)
            {
                var list = _questions.ToList();
                QuestionDeserializer.WriteQuestionsToFile(list);
            }
        }

        public AdminWindowViewModel()
        {
            LoadQuestionsCommand = new RelayCommand(OnLoadQuestionsExecuted, CanLoadQuestionsExecute);
            ReloadQuestionsCommand = new RelayCommand(OnReloadQuestionsExecuted, CanReloadQuestionsExecute);
            EditingModeCommand = new RelayCommand(OnEditingModeExecuted, CanChangeEditingMode);
            SaveQuestionsCommand = new RelayCommand(OnSaveQuestionsExecuted, CanSaveQuestionsExecute);
            AddQuestionCommand = new RelayCommand(OnAddQuestionExecuted, CanAddQuestionExecute);
            RemoveQuestionCommand = new RelayCommand(OnRemoveQuestionExecuted, CanRemoveQuestionExecute);
        }
    }
}
