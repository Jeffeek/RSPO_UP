using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using RSPO_UP_5.ViewModel;

namespace RSPO_UP_5.View
{
    /// <summary>
    /// Логика взаимодействия для MatrixWindow.xaml
    /// </summary>
    public partial class MatrixWindow : Window
    {
        private Action _closeAction;
        public MatrixWindow(Action closeAction)
        {
            InitializeComponent();
            DataContext = new MatrixWindowViewModel();
            _closeAction = closeAction;
        }

        private void MatrixWindow_OnClosed(object sender, EventArgs e)
        {
            _closeAction();
        }
    }
}
