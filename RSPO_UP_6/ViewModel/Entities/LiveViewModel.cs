#region Using namespaces

using System.IO;

#endregion

namespace RSPO_UP_6.ViewModel.Entities
{
	public class LiveViewModel : ViewModelBase
	{
		private EntitySettingsViewModel _settings;

		public LiveViewModel() => Settings = new EntitySettingsViewModel
		                                     {
			                                     ImagePath = $"{Directory.GetCurrentDirectory()}\\Files\\heart.png",
			                                     Delay = 0
		                                     };

		public EntitySettingsViewModel Settings
		{
			get => _settings;
			set => SetValue(ref _settings, value);
		}
	}
}