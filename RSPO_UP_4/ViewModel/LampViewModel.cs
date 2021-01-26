#region Using namespaces

using System;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using RSPO_UP_4.Model.Controller;

#endregion

namespace RSPO_UP_4.ViewModel
{
	public sealed class LampViewModel : ViewModelBase
	{
		private readonly int _top;
		private readonly int _left;
		private bool _isPlayerNearLamp;
		private bool _isOn;

		public LampViewModel(int top, int left)
		{
			_top = top;
			_left = left;
			TurnOnLampCommand = new RelayCommand(ChangeState, IsPlayerNearLamp);
		}

		public ICommand TurnOnLampCommand { get; }

		public bool IsOn
		{
			get => _isOn;
			set => SetValue(ref _isOn, value);
		}

		public bool IsPlayerNearLamp
		{
			get => _isPlayerNearLamp;
			set => SetValue(ref _isPlayerNearLamp, value);
		}

		private void ChangeState()
		{
			IsOn = !IsOn;
		}

		public void CheckPlayer(in PlayerController controller)
		{
			var radius = 30;
			IsPlayerNearLamp = Math.Abs(_top - controller.Up) < radius &&
			                   Math.Abs(_left - controller.Left) <= radius;
		}
	}
}