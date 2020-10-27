using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSPO_UP_4.ViewModel
{
    class RoomViewModel : ViewModelBase
    {
        private LampViewModel _lamp;

        public LampViewModel Lamp => _lamp;

        public RoomViewModel()
        {
            _lamp = new LampViewModel();
        }
    }
}
