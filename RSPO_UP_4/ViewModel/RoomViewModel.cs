using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RSPO_UP_4.ViewModel
{
    public class RoomViewModel : ViewModelBase
    {
        public LampViewModel Lamp { get; }
        public LampViewModel Bruh { get; }

        public RoomViewModel(int btnTop, int btnLeft)
        {
           Lamp = new LampViewModel(btnTop, btnLeft);
           Bruh = new LampViewModel(btnTop-170, btnLeft-150);
        }
    }
}
