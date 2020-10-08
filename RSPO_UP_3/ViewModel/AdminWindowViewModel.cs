using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using RSPO_UP_3.Models.DataModels;
using RSPO_UP_3.Models.EntityFramework.Models;
using RSPO_UP_3.Services;
using RSPO_UP_3.ViewModel.Base;

namespace RSPO_UP_3.ViewModel
{
    class AdminWindowViewModel : ViewModelBase
    {

        #region fields

        private ObservableCollection<Question> _questions;
        private Question _selectedQuestion;
        private bool _isEditingMode = false;

        #endregion

        #region commands

        public ICommand EditingModeCommand { get; }
        public ICommand LoadQuestionsCommand { get; }
        public ICommand ReloadQuestionsCommand { get; }
        public ICommand SaveQuestionsCommand { get; }
        public ICommand RemoveQuestionCommand { get; }
        public ICommand AddQuestionCommand { get; }

        #endregion

        #region properties

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

        public bool IsEditingMode
        {
            get => _isEditingMode;
            set => SetValue(ref _isEditingMode, value);
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
                Text = String.Empty
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
            OnLoadQuestionsExecuted();
        }


        private bool CanChangeEditingMode() => true;
        private void OnEditingModeExecuted() => IsEditingMode = !IsEditingMode;


        private bool CanSaveQuestionsExecute() => !IsEditingMode;
        private void OnSaveQuestionsExecuted()
        {
            if (!IsEditingMode)
            {
                var list = _questions.ToList();
                QuestionDeserializer.WriteQuestionsToFile(list);
                IsEditingMode = true;
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
