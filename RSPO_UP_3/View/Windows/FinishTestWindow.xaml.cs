using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using RSPO_UP_3.Models;

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
            _points = points;
            InitializeComponent();
            ChangePicture();
            ChangeTextBox();
        }

        private void ChangeTextBox()
        {
            txtResult.Text = txtResult.Text.Replace("{0}", $"{_points}");
        }

        private void ChangePicture()
        {
            if (_points == 0)
                ImageResult.Source = new BitmapImage(new Uri($"{Directory.GetCurrentDirectory()}\\Images\\ResultImages\\sad.jpg"));
            if (_points < 3)
                ImageResult.Source = new BitmapImage(new Uri($"{Directory.GetCurrentDirectory()}\\Images\\ResultImages\\normy.png"));
            if (_points >= 3)
                ImageResult.Source = new BitmapImage(new Uri($"{Directory.GetCurrentDirectory()}\\Images\\ResultImages\\happy.png"));
        }
    }
}
