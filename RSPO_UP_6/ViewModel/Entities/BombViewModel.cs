#region Using namespaces

using System;
using System.IO;
using System.Threading.Tasks;
using RSPO_UP_6.Model.Controllers;

#endregion

namespace RSPO_UP_6.ViewModel.Entities
{
	public sealed class BombViewModel : ViewModelBase
	{
		public BombViewModel(Func<int, int, bool> isCellFree) => _isCellFree = isCellFree;

		public bool IsGameStopped
		{
			get => _isGameStopped;
			set => SetValue(ref _isGameStopped, value);
		}

		public bool IsExploded
		{
			get => _isExploded;
			private set
			{
				_isExploded = value;
				BombStateChanged?.Invoke(this, _isExploded);
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

		public async Task Start()
		{
			await Task.Run(SpawnBomb);
			//SpawnBomb();
		}

		private async Task SpawnBomb()
		{
			Settings.ImagePath = $"{Directory.GetCurrentDirectory()}\\Files\\bomb.png";
			IsExploded = false;
			if (IsGameStopped)
			{
				Row = 0;
				Column = 0;
				return;
			}

			var row = _randomBomb.Next(0, 10);
			var column = _randomBomb.Next(0, 10);
			while (!_isCellFree(row, column))
			{
				row = _randomBomb.Next(0, 10);
				column = _randomBomb.Next(0, 10);
			}

			Row = row;
			Column = column;
			await BombExplode();
		}

		private async Task BombExplode()
		{
			await Task.Delay(Settings.Delay);
			Settings.ImagePath = $"{Directory.GetCurrentDirectory()}\\Files\\explosion.png";
			IsExploded = true;
			BombExploded?.Invoke(Row, Column);
			await Task.Delay(Settings.Delay / 5);
			if (!IsGameStopped)
				await SpawnBomb();
		}

		#region Events

		public event EntityMovedTo BombExploded;
		public event EventHandler<bool> BombStateChanged;

		#endregion

		#region Fields

		private readonly Func<int, int, bool> _isCellFree;

		private readonly Random _randomBomb =
			new Random(DateTime.Now.Millisecond * DateTime.Now.Second * DateTime.UtcNow.Millisecond / 2);

		private EntitySettingsViewModel _settings;
		private int _currentRow, _currentColumn;
		private bool _isExploded;
		private bool _isGameStopped;

		#endregion
	}
}