using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSPO_UP_6.ViewModel.Entities;

namespace RSPO_UP_6.ViewModel
{
    public class BrickViewModel : ViewModelBase
    {
        private EntitySettingsViewModel _settings;
        private int _row, _column;

        public EntitySettingsViewModel Settings
        {
            get => _settings;
            set => SetValue(ref _settings, value);
        }

        public int Row
        {
            get => _row;
            set => SetValue(ref _row, value);
        }

        public int Column
        {
            get => _column;
            set => SetValue(ref _column, value);
        }

        public BrickViewModel()
        {
            Settings = new EntitySettingsViewModel()
            {
                ImagePath = $"{Directory.GetCurrentDirectory()}\\Files\\brick.jpg"
            };
        }
    }
}
