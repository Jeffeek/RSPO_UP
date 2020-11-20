using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using RSPO_UP_5.View;

namespace RSPO_UP_5.ViewModel
{
    public class ChooseOperationWindowViewModel : ViewModelBase
    {
        private bool _isSecondWindowNotOpened = true;
        public ICommand MatrixChooseCommand { get; }
        public ICommand NonlinearEquationChooseCommand { get; }
        public ICommand IntegralChooseCommand { get; }

        public bool IsSecondFormNotOpened
        {
            get => _isSecondWindowNotOpened;
            set => SetValue(ref _isSecondWindowNotOpened, value, nameof(IsSecondFormNotOpened));
        }

        #region MyRegion

        public void OnMatrixChooseCommandExecuted()
        {
            var matrixWindow = new MatrixWindow(() => IsSecondFormNotOpened = true);
            matrixWindow.Show();
            IsSecondFormNotOpened = false;
        }

        public void OnNonlinearEquationChooseCommandExecuted()
        {
            var matrixWindow = new NonLinearEqualationWindow();
            matrixWindow.Show();
            IsSecondFormNotOpened = false;
        }

        public void OnIntegralChooseCommandExecuted()
        {
            IsSecondFormNotOpened = false;
        }

        private bool CanOpenSecondFromExecute() => IsSecondFormNotOpened;

        #endregion

        public ChooseOperationWindowViewModel()
        {
            MatrixChooseCommand = new RelayCommand(OnMatrixChooseCommandExecuted, CanOpenSecondFromExecute);
            NonlinearEquationChooseCommand = new RelayCommand(OnNonlinearEquationChooseCommandExecuted, CanOpenSecondFromExecute);
            IntegralChooseCommand = new RelayCommand(OnIntegralChooseCommandExecuted, CanOpenSecondFromExecute);
        }
    }
}
