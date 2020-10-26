using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using RSPO_UP_4.ViewModel;

namespace RSPO_UP_4.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_OnKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.W:
                {
                    ((RoomsViewModel)(DataContext)).Player.Top -= 3;
                    break;
                }
                case Key.A:
                {
                    ((RoomsViewModel)(DataContext)).Player.Left -= 3;
                    break;
                }
                case Key.S:
                {
                    ((RoomsViewModel)(DataContext)).Player.Top += 3;
                    break;
                }
                case Key.D:
                {
                    ((RoomsViewModel)(DataContext)).Player.Left += 3;
                    break;
                }
            }
        }
    }
}
