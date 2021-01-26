namespace RSPO_UP_4.ViewModel
{
	public class BathroomViewModel : ViewModelBase
	{
		public BathroomViewModel(int btnTop, int btnLeft) => Lamp = new LampViewModel(btnTop, btnLeft);

		public LampViewModel Lamp { get; }
	}
}