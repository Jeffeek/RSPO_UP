﻿#region Using namespaces

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using OxyPlot;
using RSPO_UP_5.Model;
using RSPO_UP_5.Model.Integral;
using AsupX = RSPO_UP_5.Model.Integral.AsupX;

#endregion

namespace RSPO_UP_5.ViewModel
{
	public class IntegralViewModel : ViewModelBase
	{
		private List<DataPoint> _points;
		private string _title = string.Empty;
		private double _lowerValue, _upperValue, _a, _b, _c, _d, _step = 0.1;
		private IIntegralFunc _equalationStrategy;
		private int _equationNumber;

		public IntegralViewModel()
		{
			ApplyEquationCommand = new RelayCommand(OnApplyEquationExecuted, CanApplyEquationExecute);
			SinXCommand = new RelayCommand(SinXStrategyChanged);
			CosXCommand = new RelayCommand(CosXStrategyChanged);
			XsupACommand = new RelayCommand(XsupAStrategyChanged);
			StrongCommand = new RelayCommand(StrongXStrategyChanged);
			AsupXCommand = new RelayCommand(AsupXStrategyChanged);
		}

		public ICommand ApplyEquationCommand { get; }
		public ICommand SinXCommand { get; }   //1
		public ICommand CosXCommand { get; }   //2
		public ICommand XsupACommand { get; }  //3
		public ICommand AsupXCommand { get; }  //4
		public ICommand StrongCommand { get; } //5

		public int EquationNumber
		{
			get => _equationNumber;
			set => SetValue(ref _equationNumber, value);
		}

		public IIntegralFunc CurrentEquation
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

		public double Step
		{
			get => _step;
			set
			{
				if (value < 0.1)
					return;

				SetValue(ref _step, value);
			}
		}

		public double C
		{
			get => _c;
			set => SetValue(ref _c, value);
		}

		public double A
		{
			get => _a;
			set => SetValue(ref _a, value);
		}

		public double B
		{
			get => _b;
			set => SetValue(ref _b, value);
		}

		public double D
		{
			get => _d;
			set => SetValue(ref _d, value);
		}

		private async void OnApplyEquationExecuted()
		{
			var solvedPoints = CurrentEquation.Solve(LowerValue, UpperValue, Step, A, B, C, D);
			await Task.Run(() => LogPoints(solvedPoints));
			Points = new List<DataPoint>(solvedPoints);
		}

		private bool CanApplyEquationExecute() => EquationNumber != 0;

		private void SinXStrategyChanged()
		{
			CurrentEquation = new SinX();
			EquationNumber = 1;
		}

		private void CosXStrategyChanged()
		{
			CurrentEquation = new CosX();
			EquationNumber = 2;
		}

		private void XsupAStrategyChanged()
		{
			CurrentEquation = new XsupA();
			EquationNumber = 3;
		}

		private void AsupXStrategyChanged()
		{
			CurrentEquation = new AsupX();
			EquationNumber = 4;
		}

		private void StrongXStrategyChanged()
		{
			CurrentEquation = new Ax3PlusBx2PlusCXplusD();
			EquationNumber = 5;
		}

		private async Task LogPoints(IEnumerable<DataPoint> points)
		{
			var stringsList = points.Select(x => $"({x.X};{x.Y})");
			var joined = string.Join("\n", stringsList);
			using (var writer = new StreamWriter($"{Directory.GetCurrentDirectory()}//integralPoints_log.txt"))
				await writer.WriteAsync(joined);
		}
	}
}