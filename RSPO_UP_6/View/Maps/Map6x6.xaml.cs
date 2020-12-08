using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using RSPO_UP_6.ViewModel;

namespace RSPO_UP_6.View.Maps
{
    /// <summary>
    /// Логика взаимодействия для Map6x6.xaml
    /// </summary>
    public partial class Map6x6 : Page
    {
        private ObservableCollection<BrickViewModel> _bricks;

        public Map6x6(ObservableCollection<BrickViewModel> bricks)
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
                    brick.Row == 5 && brick.Column == 5) continue;
                var image = new Image { Source = new BitmapImage(new Uri(brick.Settings.ImagePath)), Stretch = Stretch.Fill };
                Grid.SetColumn(image, brick.Column);
                Grid.SetRow(image, brick.Row);
                Map.Children.Add(image);
            }
        }
    }
}
