#region Using namespaces

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using OxyPlot;
using RSPO_UP_5.Model;
using RSPO_UP_5.Model.NonLinear;

#endregion

namespace RSPO_UP_5.ViewModel
{
	public class NonLinearEquationViewModel : ViewModelBase
	{
		private List<DataPoint> _points;
		private string _title = string.Empty;
		private double _lowerValue, _upperValue, _c;
		private IEquation _equalationStrategy;
		private int _equationNumber;

		public NonLinearEquationViewModel()
		{
			ApplyEquationCommand = new RelayCommand(OnApplyEquationExecuted, CanApplyEquationExecute);
			SinXCommand = new RelayCommand(SinXminusAStrategyChanged);
			XsupAxCommand = new RelayCommand(XsubAminusXStrategyChanged);
			AsubXCommand = new RelayCommand(AsubXStrategyChanged);
		}

		public ICommand ApplyEquationCommand { get; }
		public ICommand SinXCommand { get; }   //1
		public ICommand XsupAxCommand { get; } //2
		public ICommand AsubXCommand { get; }  //3

		public int EquationNumber
		{
			get => _equationNumber;
			set => SetValue(ref _equationNumber, value);
		}

		public IEquation CurrentEquation
		{
			get => _equalationStrategy;
			set => SetValue(ref _equalationStrategy, value);
		}

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
			var solvedPoints = CurrentEquation.Solve(_lowerValue, _upperValue, _c);
			await Task.Run(() => LogPoints(solvedPoints));
			Points = new List<DataPoint>(solvedPoints);
			MessageBox.Show(_equalationStrategy.Root != null ? $"Корень: {CurrentEquation.Root}" : "Корня нет");
		}

		private bool CanApplyEquationExecute() => EquationNumber != 0;

		private void SinXminusAStrategyChanged()
		{
			CurrentEquation = new SinXminusA();
			EquationNumber = 1;
		}

		private void XsubAminusXStrategyChanged()
		{
			CurrentEquation = new XsupAminusx();
			EquationNumber = 2;
		}

		private void AsubXStrategyChanged()
		{
			CurrentEquation = new AsupX();
			EquationNumber = 3;
		}

		private async Task LogPoints(IEnumerable<DataPoint> points)
		{
			var stringsList = points.Select(x => $"({x.X};{x.Y})");
			var joined = string.Join("\n", stringsList);
			using (var writer = new StreamWriter($"{Directory.GetCurrentDirectory()}//nonLinearPoints_log.txt"))
				await writer.WriteAsync(joined);
		}
	}
}