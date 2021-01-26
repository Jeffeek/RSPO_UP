#region Using namespaces

using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using RSPO_UP_6.ViewModel.Entities;

#endregion

namespace RSPO_UP_6.View.Maps
{
	public sealed partial class Map10X10 : Page
	{
		private readonly ObservableCollection<BrickViewModel> _bricks;

		public Map10X10(ObservableCollection<BrickViewModel> bricks)
		{
			InitializeComponent();
			_bricks = bricks;
			PlaceBricksOnMap();
		}

		private void PlaceBricksOnMap()
		{
			foreach (var brick in _bricks)
			{
				if (brick.Row == 0 && brick.Column == 0 ||
				    brick.Row == 9 && brick.Column == 9) continue;

				var image = new Image
				            {
					            Source = new BitmapImage(new Uri(brick.Settings.ImagePath)),
					            Stretch = Stretch.Fill
				            };

				Grid.SetColumn(image, brick.Column);
				Grid.SetRow(image, brick.Row);
				Map.Children.Add(image);
			}
		}
	}
}