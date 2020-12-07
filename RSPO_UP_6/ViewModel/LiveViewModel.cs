using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSPO_UP_6.ViewModel
{
    public class LiveViewModel : ViewModelBase
    {
        private EntitySettingsViewModel _settings;

        public EntitySettingsViewModel Settings
        {
            get => _settings;
            set => SetValue(ref _settings, value);
        }

        public LiveViewModel()
        {
            Settings = new EntitySettingsViewModel()
            {
                ImagePath = $"{Directory.GetCurrentDirectory()}\\Files\\heart.png", Delay = 0
            };
        }
    }
}
