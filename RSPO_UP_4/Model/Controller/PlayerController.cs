using RSPO_UP_4.ViewModel;

namespace RSPO_UP_4.Model.Controller
{
    public class PlayerController : ViewModelBase
    {
        private const int Step = 5;
        private int _left = 5;
        private int _right;
        private int _up = 5;
        private int _down;
        private Player _player;

        public PlayerController()
        {
            _player = new Player();
        }

        public int Left
        {
            get => _left;
            private set => SetValue(ref _left, value);
        }

        public int Up
        {
            get => _up;
            set => SetValue(ref _up, value);
        }

        public int Down
        {
            get => _left;
            set => SetValue(ref _down, value);
        }

        public int Right
        {
            get => _right;
            set => SetValue(ref _right, value);
        }

        public void GoLeft() => Left -= Step;

        public void GoRight() => Left += Step;

        public void GoUp() => Up -= Step;

        public void GoDown() => Up += Step;
    }
}
