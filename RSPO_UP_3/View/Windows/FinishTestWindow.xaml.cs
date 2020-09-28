using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using RSPO_UP_3.Models;
using RSPO_UP_3.ViewModel;

namespace RSPO_UP_3.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для FinishTestWindow.xaml
    /// </summary>
    public partial class FinishTestWindow : Window
    {
        private int _points;
        public FinishTestWindow(int points)
        {
            InitializeComponent();
            DataContext = new FinishTestWindowViewModel(points);
        }
    }
}
