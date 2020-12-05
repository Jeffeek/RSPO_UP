using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using Microsoft.Win32;

namespace RSPO_UP_6.ViewModel
{
    public class SettingsViewModel : ViewModelBase
    {
        private string _cowImageSource = $"{Directory.GetCurrentDirectory()}\\Files\\cow.gif";
        private string _wolfImageSource = $"{Directory.GetCurrentDirectory()}\\Files\\wolf.png";

        public ICommand ChangeCowImageCommand { get; }
        public ICommand ChangeWolfImageCommand { get; }

        public string CowImageSource
        {
            get => _cowImageSource;
            set => SetValue(ref _cowImageSource, value);
        }

        public string WolfImageSource
        {
            get => _wolfImageSource;
            set => SetValue(ref _wolfImageSource, value);
        }

        private void OnChangeCowImageExecuted()
        {
            var dialog = new OpenFileDialog()
            {
                Filter = "Images(*.jpg, *.gif;*.png)|*.jpg;*.gif;*.png"
            };
            if (dialog.ShowDialog() ?? false)
            {
                CowImageSource = dialog.FileName;
            }
        }

        private void OnChangeWolfImageExecuted()
        {
            var dialog = new OpenFileDialog()
            {
                Filter = "Images(*.jpg, *.gif;*.png)|*.jpg;*.gif;*.png"
            };
            if (dialog.ShowDialog() ?? false)
            {
                WolfImageSource = dialog.FileName;
            }
        }

        public SettingsViewModel()
        {
            ChangeCowImageCommand = new RelayCommand(OnChangeCowImageExecuted);
            ChangeWolfImageCommand = new RelayCommand(OnChangeWolfImageExecuted);
        }
    }
}
