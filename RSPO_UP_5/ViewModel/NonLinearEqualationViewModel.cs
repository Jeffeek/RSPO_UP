using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using OxyPlot;
using RSPO_UP_5.Model;

namespace RSPO_UP_5.ViewModel
{
    public class NonLinearEqualationViewModel : ViewModelBase
    {
        private List<DataPoint> _points;
        private string _title = String.Empty;
        private double _lowerValue = 0.0d, _upperValue = 0.0d, _c=0.0d;
        private IEqualation _equalationStrategy;

        public ICommand ApplyEqualationCommand { get; }
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

        private async void OnApplyEqualationExecuted()
        {
            GC.Collect();
            var solvedPoints = _equalationStrategy.Solve(_lowerValue, _upperValue, _c);
            await Task.Run(() => LogPoints(solvedPoints));
            Points = new List<DataPoint>(solvedPoints);
        }

        private void SinXStrategyChanged() => _equalationStrategy = new Sinusoid();

        private void XsubAxStrategyChanged() => _equalationStrategy = new XsupAx();

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

        public NonLinearEqualationViewModel()
        {
            ApplyEqualationCommand = new RelayCommand(OnApplyEqualationExecuted);
            SinXCommand = new RelayCommand(SinXStrategyChanged);
            XsupAxCommand = new RelayCommand(XsubAxStrategyChanged);
            AsubXCommand = new RelayCommand(AsubXStrategyChanged);
        }
    }
}
