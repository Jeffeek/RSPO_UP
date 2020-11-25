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
using System.Windows.Shapes;

namespace RSPO_UP_5.View
{
    public partial class IntegralWindow : Window
    {
        private Action _closeAction;
        public IntegralWindow(Action closeAction)
        {
            InitializeComponent();
            _closeAction = closeAction;
        }

        private void IntegralWindow_OnClosed(object sender, EventArgs e)
        {
            _closeAction?.Invoke();
        }
    }
}
