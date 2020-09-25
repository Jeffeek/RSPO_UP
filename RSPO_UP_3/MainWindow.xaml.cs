using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RSPO_UP_3.Models;

namespace RSPO_UP_3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TestGame game;
        private int choosedButtonsCount = 0;
        public MainWindow()
        {
            InitializeComponent();
            StartGame();
        }

        private void StartGame()
        {
            game = new TestGame();
        }

        private void ReloadCheckBoxes()
        {

        }
    }
}
