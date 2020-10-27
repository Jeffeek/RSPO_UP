using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSPO_UP_4.Model;

namespace RSPO_UP_4.ViewModel
{
    class LampViewModel : ViewModelBase
    {
        private Lamp _lamp;
        private bool _isActive;

        public bool IsActive
        {
            get => _lamp.IsActive;
            set => SetValue(ref _isActive, value);
        }

        public LampViewModel()
        {
            _lamp = new Lamp();
        }
    }
}
