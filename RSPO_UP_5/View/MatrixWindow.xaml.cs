#region Using namespaces

using System;
using RSPO_UP_5.ViewModel;

#endregion

namespace RSPO_UP_5.View
{
	public partial class MatrixWindow
	{
		private readonly Action _closeAction;

		public MatrixWindow(Action closeAction)
		{
			InitializeComponent();
			DataContext = new MatrixWindowViewModel();
			_closeAction = closeAction;
		}

		private void MatrixWindow_OnClosed(object sender, EventArgs e)
		{
			_closeAction();
		}
	}
}