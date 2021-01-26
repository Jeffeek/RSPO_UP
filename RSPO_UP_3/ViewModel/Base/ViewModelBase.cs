#region Using namespaces

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

#endregion

namespace RSPO_UP_3.ViewModel.Base
{
	internal abstract class ViewModelBase : INotifyPropertyChanged, IDisposable
	{
		private bool _disposed;

		public void Dispose()
		{
			Dispose(true);
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		protected virtual bool SetValue<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
		{
			if (Equals(field, value)) return false;
			field = value;
			OnPropertyChanged(propertyName);
			return true;
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposing || _disposed) return;
			_disposed = true;
			GC.SuppressFinalize(this);
		}
	}
}