using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SWaver.Utils.Graph;

namespace SWaver
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private LinearGraphUtility linearGraphUtility;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            //PointCollection points = new PointCollection();
            //for (double x = xmin; x <= xmax; x += xstep)
            //{
                
            //    points.Add(new Point(x, last_y));
            //}

            //Polyline polyline = new Polyline();
            //polyline.StrokeThickness = 1;
            //polyline.Stroke = Brushes.Green;
            //polyline.Points = points;

            //canvasGraph.Children.Add(polyline);
            
        }

        private void GetMatrixes()
        {
            Matrix realToDeviceMatrix = Matrix.Identity;

        }

        private void mainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.linearGraphUtility = new LinearGraphUtility(this.canvasGraph, Math.PI * 2, 1, 0.1, 0.01);
            this.linearGraphUtility.DrawPlot();
        }
    }
}
