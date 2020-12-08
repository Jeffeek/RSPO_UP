using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RSPO_UP_6.ViewModel;

namespace RSPO_UP_6.View.Maps
{
    public partial class Map8x8 : Page
    {
        private ObservableCollection<BrickViewModel> _bricks;

        public Map8x8(ObservableCollection<BrickViewModel> bricks, bool[,] matrix)
        {
            InitializeComponent();
            _bricks = bricks;
            InitBricks(matrix);
        }

        private void InitBricks(bool[,] matrix)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (matrix[i, j])
                    {
                        _bricks.Add(new BrickViewModel() { Column = j, Row = i });
                    }
                }
            }
            PlaceBricksOnMap();
        }

        private void PlaceBricksOnMap()
        {
            foreach (var brick in _bricks)
            {
                if (brick.Row == 0 && brick.Column == 0 ||
                    brick.Row == 7 && brick.Column == 7) continue;
                var image = new Image { Source = new BitmapImage(new Uri(brick.Settings.ImagePath)), Stretch = Stretch.Fill };
                Grid.SetColumn(image, brick.Column);
                Grid.SetRow(image, brick.Row);
                Map.Children.Add(image);
            }
        }
    }
}
