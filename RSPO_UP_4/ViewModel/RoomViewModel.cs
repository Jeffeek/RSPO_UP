namespace RSPO_UP_4.ViewModel
{
	public class RoomViewModel : ViewModelBase
	{
		public RoomViewModel(int btnTop, int btnLeft)
		{
			Lamp = new LampViewModel(btnTop, btnLeft);
			Bruh = new LampViewModel(btnTop - 170, btnLeft - 150);
		}

		public LampViewModel Lamp { get; }
		public LampViewModel Bruh { get; }
	}
}