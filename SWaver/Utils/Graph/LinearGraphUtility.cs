using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using SWaverLib;
using SWaverLib.SecondLab.BasicParameters;

namespace SWaver.Utils.Graph
{
    public class LinearGraphUtility
    {
        private Canvas canvas;
        private const double margin = 20;

        private double xDeviceMin;
        private double yDeviceMin;

        private double xDeviceMax;
        private double yDeviceMax;

        private double xDeviceStep;
        private double yDeviceStep;

        private double xRealMin = 0;
        private double yRealMin = 0;

        private double xRealMax = Math.PI * 2;
        private double yRealMax = 1;

        private double xRealStep;
        private double yRealStep;

        private Matrix RealToDevice;
        private Matrix DeviceToReal;

        public LinearGraphUtility(Canvas canvas, 
            double xRealMax,
            double yRealMax, double xRealStep, double yRealStep,
            double xDeviceStep = 10, double yDeviceStep = 1,
            double xRealMin = -0.5, double yRealMin = -0.1)
        {
            this.canvas = canvas;
            this.xDeviceMin = margin;
            this.yDeviceMin = margin;

            this.xDeviceMax = canvas.Width - margin;
            this.yDeviceMax = canvas.Height - margin;

            this.xDeviceStep = xDeviceStep;
            this.yDeviceStep = yDeviceStep;

            this.xRealMin = xRealMin;
            this.yRealMin = yRealMin;

            this.xRealMax = xRealMax;
            this.yRealMax = yRealMax;

            this.xRealStep = xRealStep;
            this.yRealStep = yRealStep;

            PrepareTransformations();
        }

        private void DrawX()
        {
            GeometryGroup xaxisGrp = new GeometryGroup();
            var startPoint = TranslateRealToDevicePoint(new Point(this.xRealMin, 0));
            var endPoint = TranslateRealToDevicePoint(new Point(this.xRealMax, 0));
            var xAxisLine =
                new LineGeometry(startPoint, endPoint);
            xaxisGrp.Children.Add(xAxisLine);

            for (double x = this.xRealStep; x <= this.xRealMax - this.xRealStep; x += this.xRealStep)
            {
                var point0 = TranslateRealToDevicePoint(new Point(x, 0.01));
                var point1 = TranslateRealToDevicePoint(new Point(x, -0.01));
                var deliminatorLine = new LineGeometry(point0, point1);
                xaxisGrp.Children.Add(deliminatorLine);
                var strValue = string.Format("{0:0.0}", x);
                DrawText(strValue, new Point(point1.X, point1.Y + 5), HorizontalAlignment.Center, VerticalAlignment.Top);
            }

            Path xAxisPath = new Path();
            xAxisPath.StrokeThickness = 1;
            xAxisPath.Stroke = Brushes.Black;
            xAxisPath.Data = xaxisGrp;

            this.canvas.Children.Add(xAxisPath);
        }

        private void DrawY()
        {
            GeometryGroup yaxisGrp = new GeometryGroup();
            var startPoint = TranslateRealToDevicePoint(new Point(0, this.yRealMin));
            var endPoint = TranslateRealToDevicePoint(new Point(0, this.yRealMax));
            var yAxisLine =
                new LineGeometry(startPoint, endPoint);
            yaxisGrp.Children.Add(yAxisLine);

            for (double y = this.yRealStep; y <= this.yRealMax - this.yRealStep; y += this.yRealStep)
            {
                var point0 = TranslateRealToDevicePoint(new Point(0.1, y));
                var point1 = TranslateRealToDevicePoint(new Point(-0.1, y));
                var deliminatorLine = new LineGeometry(point0, point1);
                yaxisGrp.Children.Add(deliminatorLine);
                var strValue = string.Format("{0:0.0}", y);
                DrawText(strValue, new Point(point1.X - 10, point1.Y), HorizontalAlignment.Center, VerticalAlignment.Center);
            }

            Path yAxisPath = new Path();
            yAxisPath.StrokeThickness = 1;
            yAxisPath.Stroke = Brushes.Black;
            yAxisPath.Data = yaxisGrp;

            this.canvas.Children.Add(yAxisPath);
        }
        private void DrawText(string text, Point location,
            HorizontalAlignment halign, VerticalAlignment valign)
        {
            // Make the label.
            Label label = new Label();
            label.Content = text;
            label.FontSize = 12;
            this.canvas.Children.Add(label);

            // Position the label.
            label.Measure(new Size(double.MaxValue, double.MaxValue));

            double x = location.X;
            if (halign == HorizontalAlignment.Center)
                x -= label.DesiredSize.Width / 2;
            else if (halign == HorizontalAlignment.Right)
                x -= label.DesiredSize.Width;
            Canvas.SetLeft(label, x);

            double y = location.Y;
            if (valign == VerticalAlignment.Center)
                y -= label.DesiredSize.Height / 2;
            else if (valign == VerticalAlignment.Bottom)
                y -= label.DesiredSize.Height;
            Canvas.SetTop(label, y);
        }
        private void PrepareTransformations()
        {
            RealToDevice = Matrix.Identity;
            RealToDevice.Translate(-this.xRealMin, -this.yRealMin);

            double xscale = (this.xDeviceMax - this.xDeviceMin) / (this.xRealMax - this.xRealMin);
            double yscale = (this.yDeviceMin - this.yDeviceMax) / (this.yRealMax - this.yRealMin);
            RealToDevice.Scale(xscale, yscale);

            RealToDevice.Translate(this.xDeviceMin, this.yDeviceMax);
            DeviceToReal = RealToDevice;
            DeviceToReal.Invert();
        }

        private Point TranslateRealToDevicePoint(Point point)
        {
            var translatedPoint = RealToDevice.Transform(point);
            return translatedPoint;
        }
        public void DrawPlot()
        {
            DrawX();
            DrawY();
        }

        public void Drawfunction(Func<ThetaDegrees, MathObject> calculator, double step = double.PositiveInfinity, SolidColorBrush color = null)
        {
            if (step == Double.PositiveInfinity) step = this.xRealStep;
            if (color == null) color = Brushes.Green;
            PointCollection points = new PointCollection();
            
            for (double x = this.xRealMin; x < this.xRealMax; x += step)
            {
                var yValue = calculator(new ThetaDegrees(0){Radians = x});
                points.Add(TranslateRealToDevicePoint(new Point(x, yValue.Value)));
            }
            Polyline polyline = new Polyline();
            polyline.StrokeThickness = 1;
            polyline.Stroke = color;
            polyline.Points = points;

            canvas.Children.Add(polyline);
        }
    }
}
