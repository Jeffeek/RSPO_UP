#region Using namespaces

using RSPO_UP_3.ViewModel;

#endregion

namespace RSPO_UP_3.View.Windows
{
	/// <summary>
	///     Логика взаимодействия для FinishTestWindow.xaml
	/// </summary>
	public partial class FinishTestWindow
	{
		public FinishTestWindow(int points)
		{
			InitializeComponent();
			DataContext = new FinishTestWindowViewModel(points);
		}
	}
}