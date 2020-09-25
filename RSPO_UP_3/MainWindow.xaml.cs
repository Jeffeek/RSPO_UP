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
        private int ResultPoints = 0;
        private List<CheckBox> pressedCheckBoxes = new List<CheckBox>();

        public MainWindow()
        {
            InitializeComponent();
            StartGame();
        }

        private void StartGame()
        {
            game = new TestGame();
            ReloadCheckBoxes();
            FillTheQuest();
        }

        private void FillTheQuest()
        {
            txtQuestionText.Text = game.CurrentQuestion.Text;
            checkBox_1.Content = game.CurrentQuestion.GetTextQuestionByIndex(0);
            checkBox_2.Content = game.CurrentQuestion.GetTextQuestionByIndex(1);
            checkBox_3.Content = game.CurrentQuestion.GetTextQuestionByIndex(2);
            checkBox_4.Content = game.CurrentQuestion.GetTextQuestionByIndex(3);
            checkBox_5.Content = game.CurrentQuestion.GetTextQuestionByIndex(4);
        }

        private void ReloadCheckBoxes()
        {
            checkBox_1.IsChecked = false;
            checkBox_2.IsChecked = false;
            checkBox_3.IsChecked = false;
            checkBox_4.IsChecked = false;
            checkBox_5.IsChecked = false;
        }

        private void BtnApply_Click(object sender, RoutedEventArgs e)
        {
            if (pressedCheckBoxes.Count != 2)
            {
                MessageBox.Show("Ошибочка", "Нужно минимум 2 отметки в чекбоксах");
                return;
            }
            game.CheckForWin(pressedCheckBoxes[0], pressedCheckBoxes[1]);
            var nextQuest = game.NextQuestion();
            if (nextQuest == null)
            {
                FinishTestWindow finish = new FinishTestWindow();
                finish.ShowDialog();
                return;
            }
            pressedCheckBoxes.Clear();
            ReloadCheckBoxes();
            FillTheQuest();
        }

        private void CheckBox_OnClick(object sender, RoutedEventArgs e)
        {
            var pressedCheckBox = sender as CheckBox;
            if (pressedCheckBoxes.Count == 2 && pressedCheckBoxes.Contains(pressedCheckBox))
            {
                pressedCheckBoxes.Remove(pressedCheckBox);
                return;
            }

            if (pressedCheckBoxes.Count == 2)
            {
                pressedCheckBox.IsChecked = false;
                return;
            }
            pressedCheckBoxes.Add(pressedCheckBox);
        }
    }
}
