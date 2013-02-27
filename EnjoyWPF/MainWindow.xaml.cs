using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Controls.Primitives;

namespace EnjoyWPF
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var pop = FindResource("popTest") as Popup;
            pop.PlacementTarget = sender as Button;
            pop.Placement = PlacementMode.Custom;
            pop.CustomPopupPlacementCallback += (Size popupSize, Size targetSize, Point offset) =>
            new[] { new CustomPopupPlacement() 
            { 
                Point = new Point((targetSize.Width-popupSize.Width)/2, targetSize.Height) 
            } };
            pop.IsOpen = true;
        }
    }
}
