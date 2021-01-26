#region Using namespaces

using System;
using System.IO;
using System.Threading.Tasks;
using RSPO_UP_6.Model.Controllers;

#endregion

namespace RSPO_UP_6.ViewModel.Entities
{
	public sealed class CannabisViewModel : ViewModelBase
	{
		public CannabisViewModel(Func<int, int, bool> isCellFree)
		{
			_isCellFree = isCellFree;
			Settings = new EntitySettingsViewModel
			           {
				           Delay = 2000,
				           ImagePath = $"{Directory.GetCurrentDirectory()}\\Files\\cannabis.png"
			           };
		}

		public async Task Start()
		{
			await SpawnCannabis();
		}

		private async Task SpawnCannabis()
		{
			await Task.Delay(Settings.Delay / 2);
			IsCollected = false;
			if (IsGameStopped)
			{
				Row = 0;
				Column = 0;
				return;
			}

			var row = _randomCannabis.Next(0, 10);
			var column = _randomCannabis.Next(0, 10);
			while (!_isCellFree(row, column))
			{
				row = _randomCannabis.Next(0, 10);
				column = _randomCannabis.Next(0, 10);
			}

			Row = row;
			Column = column;
			CannabisPositionChanged?.Invoke(Row, Column);
			await RemoveCannabis();
		}

		private async Task RemoveCannabis()
		{
			await Task.Delay(Settings.Delay / 2);
			if (!IsGameStopped)
				await SpawnCannabis();
		}

		#region Events

		public event EntityMovedTo CannabisPositionChanged;
		public event EventHandler CannabisCollected;

		#endregion

		#region Fields

		private readonly Func<int, int, bool> _isCellFree;

		private readonly Random _randomCannabis =
			new Random(DateTime.Now.Millisecond * DateTime.Now.Second / 2 * DateTime.MinValue.Second);

		private EntitySettingsViewModel _settings;
		private int _currentRow, _currentColumn;
		private bool _isCollected;
		private bool _isGameStopped;

		#endregion

		#region Properties

		public bool IsGameStopped
		{
			get => _isGameStopped;
			set => SetValue(ref _isGameStopped, value);
		}

		public bool IsCollected
		{
			get => _isCollected;
			set
			{
				if (value)
					CannabisCollected?.Invoke(this, EventArgs.Empty);

				SetValue(ref _isCollected, value);
			}
		}

		public int Row
		{
			get => _currentRow;
			set => SetValue(ref _currentRow, value);
		}

		public int Column
		{
			get => _currentColumn;
			set => SetValue(ref _currentColumn, value);
		}

		public EntitySettingsViewModel Settings
		{
			get => _settings;
			set => SetValue(ref _settings, value);
		}

		#endregion
	}
}