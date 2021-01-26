namespace RSPO_UP_6.ViewModel.Entities
{
	public class EntitySettingsViewModel : ViewModelBase
	{
		private string _imagePath;
		private int _delay;

		public int Delay
		{
			get => _delay;
			set => SetValue(ref _delay, value);
		}

		public string ImagePath
		{
			get => _imagePath;
			set => SetValue(ref _imagePath, value);
		}
	}
}