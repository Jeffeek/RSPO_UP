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
        private ObservableCollection<Question> _questions;
        public Question SelectedQuestion { get; set; }

        public ICommand LoadQuestionsCommand { get; }

        private bool CanLoadQuestionsExecute() => true;

        private void OnLoadQuestionsExecuted()
        {
            Questions = QuestionDeserializer.GetObservableCollectionOfQuestions();
            if (Questions.Any())
                SelectedQuestion = Questions.First();
        }

        public ObservableCollection<Question> Questions
        {
            get => _questions;
            set => SetValue(ref _questions, value);
        }

        public AdminWindowViewModel()
        {
            LoadQuestionsCommand = new RelayCommand(OnLoadQuestionsExecuted, CanLoadQuestionsExecute);
        }
    }
}
