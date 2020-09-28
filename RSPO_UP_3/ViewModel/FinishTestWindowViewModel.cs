using RSPO_UP_3.ViewModel.Base;
using System;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace RSPO_UP_3.ViewModel
{
    class FinishTestWindowViewModel : ViewModelBase
    {
        private int _points;
        private ImageSource _resultImage;
        private string _resultString;
        public int Points
        {
            get => _points;
            set => SetValue(ref _points, value, nameof(Points));
        }

        public ImageSource ResultImage
        {
            get => _resultImage;
            set => SetValue(ref _resultImage, value, nameof(ResultImage));
        }

        public string ResultString
        {
            get => _resultString;
            set => SetValue(ref _resultString, value, nameof(ResultString));
        }

        public FinishTestWindowViewModel(int points)
        {
            Points = points;
            ChangePicture();
            ChangeTextBox();
        }

        private void ChangeTextBox()
        {
            ResultString = "Вы набрали: {0} баллов!".Replace("{0}", $"{Points}");
        }

        private void ChangePicture()
        {
            if (Points == 0)
                ResultImage = new BitmapImage(new Uri($"{Directory.GetCurrentDirectory()}\\Images\\ResultImages\\sad.jpg"));
            if (Points < 3)
                ResultImage = new BitmapImage(new Uri($"{Directory.GetCurrentDirectory()}\\Images\\ResultImages\\normy.png"));
            if (Points >= 3)
                ResultImage = new BitmapImage(new Uri($"{Directory.GetCurrentDirectory()}\\Images\\ResultImages\\happy.png"));
        }
    }
}
