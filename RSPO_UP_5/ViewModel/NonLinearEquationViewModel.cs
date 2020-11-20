using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using OxyPlot;
using RSPO_UP_5.Model;

namespace RSPO_UP_5.ViewModel
{
    public class NonLinearEquationViewModel : ViewModelBase
    {
        private List<DataPoint> _points;
        private string _title = String.Empty;
        private double _lowerValue = 0.0d, _upperValue = 0.0d, _c=0.0d;
        private IEquation _equalationStrategy;

        public ICommand ApplyEquationCommand { get; }
        public ICommand SinXCommand { get; } //1
        public ICommand XsupAxCommand { get; } //2
        public ICommand AsubXCommand { get; } //3

        public string Title
        {
            get => _title;
            set => SetValue(ref _title, value);
        }

        public List<DataPoint> Points
        {
            get => _points;
            set => SetValue(ref _points, value);
        }

        public double LowerValue
        {
            get => _lowerValue;
            set => SetValue(ref _lowerValue, value);
        }

        public double UpperValue
        {
            get => _upperValue;
            set => SetValue(ref _upperValue, value);
        }

        public double C
        {
            get => _c;
            set => SetValue(ref _c, value);
        }

        private async void OnApplyEquationExecuted()
        {
            var solvedPoints = _equalationStrategy.Solve(_lowerValue, _upperValue, _c);
            await Task.Run(() => LogPoints(solvedPoints));
            Points = new List<DataPoint>(solvedPoints);
            MessageBox.Show(_equalationStrategy.Root != null ? $"Корень: {_equalationStrategy.Root}" : $"Корня нет");
        }

        private void SinXminusAStrategyChanged() => _equalationStrategy = new SinXminusA();

        private void XsubAminusXStrategyChanged() => _equalationStrategy = new XsupAminusx();

        private void AsubXStrategyChanged() => _equalationStrategy = new AsupX();

        private async Task LogPoints(IEnumerable<DataPoint> points)
        {
            var stringsList = points.Select(x => $"({x.X};{x.Y})");
            var joined = String.Join("\n", stringsList);
            using (var writer = new StreamWriter($"{Directory.GetCurrentDirectory()}//nonLinearPoints_log.txt"))
            {
                await writer.WriteAsync(joined);
            }
        }

        public NonLinearEquationViewModel()
        {
            ApplyEquationCommand = new RelayCommand(OnApplyEquationExecuted);
            SinXCommand = new RelayCommand(SinXminusAStrategyChanged);
            XsupAxCommand = new RelayCommand(XsubAminusXStrategyChanged);
            AsubXCommand = new RelayCommand(AsubXStrategyChanged);
        }
    }
}
