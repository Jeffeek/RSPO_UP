#region Using namespaces

using System;
using RSPO_UP_1.Views;

#endregion

namespace RSPO_UP_1
{
	internal static class Program
	{
		// ReSharper disable once UnusedParameter.Local
		private static void Main(string[] args)
		{
			var dummy = new MainView();
			Console.ReadKey();
		}
	}
}