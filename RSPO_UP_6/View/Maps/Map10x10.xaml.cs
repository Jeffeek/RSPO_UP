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
    public partial class Map10x10 : Page
    {
        private ObservableCollection<BrickViewModel> _bricks;

        public Map10x10(ObservableCollection<BrickViewModel> bricks, bool[,] matrix)
        {
            InitializeComponent();
            _bricks = bricks;
            InitBricks(matrix);
        }

        private void InitBricks(bool[,] matrix)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (matrix[i, j])
                    {
                        _bricks.Add(new BrickViewModel(){Column = j, Row = i});
                    }
                }
            }
            PlaceBricksOnMap();
        }

        private void PlaceBricksOnMap()
        {
            for (int i = 0; i < Map.Children.Count; i++)
            {
                if (Map.Children[i] is Image img)
                {
                    if (img.Name != "WolfImage" && img.Name != "CowImage")
                        Map.Children.Remove(Map.Children[i]);
                }
            }

            for (int i = 0; i < _bricks.Count; i++)
            {
                if (_bricks[i].Row == 0 && _bricks[i].Column == 0 ||
                    _bricks[i].Row == 9 && _bricks[i].Column == 9) continue;
                var image = new Image(){Source = new BitmapImage(new Uri(_bricks[i].Settings.ImagePath)), Stretch = Stretch.Fill};
                Grid.SetColumn(image, _bricks[i].Column);
                Grid.SetRow(image, _bricks[i].Row);
                Map.Children.Add(image);
            }
        }
    }
}
