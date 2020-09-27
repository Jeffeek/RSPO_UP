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
        private QuizGame _game;
        public FinishTestWindow(QuizGame game)
        {
            InitializeComponent();
            _game = game;
            ChangePicture();
            ChangeTextBox();
        }

        private void ChangeTextBox()
        {
            txtResult.Text = txtResult.Text.Replace("{0}", $"{_game.CurrentPoints}");
        }

        private void ChangePicture()
        {
            int points = _game.CurrentPoints;
            if (points == 0)
                ImageResult.Source = new BitmapImage(new Uri($"{Directory.GetCurrentDirectory()}\\Images\\ResultImages\\sad.jpg"));
            if (points < 3)
                ImageResult.Source = new BitmapImage(new Uri($"{Directory.GetCurrentDirectory()}\\Images\\ResultImages\\normy.png"));
            if (points >= 3)
                ImageResult.Source = new BitmapImage(new Uri($"{Directory.GetCurrentDirectory()}\\Images\\ResultImages\\happy.png"));
        }
    }
}
