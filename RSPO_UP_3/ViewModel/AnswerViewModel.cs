using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSPO_UP_3.Models;
using RSPO_UP_3.ViewModel.Base;

namespace RSPO_UP_3.ViewModel
{
    internal class AnswerViewModel : ViewModelBase
    {
        private Answer _answer;

        public Answer Answer
        {
            get => _answer; 
            set => SetValue(ref _answer, value);
        }

        public AnswerViewModel(Answer answer)
        {
            Answer = answer;
        }
    }
}
