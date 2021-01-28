#region Using namespaces

using System;

#endregion

namespace RSPO_UP_5.View
{
	public partial class IntegralWindow
	{
		private readonly Action _closeAction;

		public IntegralWindow(Action closeAction)
		{
			InitializeComponent();
			_closeAction = closeAction;
		}

		private void IntegralWindow_OnClosed(object sender, EventArgs e)
		{
			_closeAction?.Invoke();
		}
	}
}