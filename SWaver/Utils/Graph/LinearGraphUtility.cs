using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

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
            double xDeviceStep = 10, double yDeviceStep = 10,
            double xRealMin = 0, double yRealMin = 0)
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
            canvas.Children.Clear();
            GeometryGroup xaxisGrp = new GeometryGroup();
            var xAxisLine =
                new LineGeometry(new Point(0, this.yDeviceMax), new Point(this.xDeviceMax, this.yDeviceMax));
            xaxisGrp.Children.Add(xAxisLine);

            for (double x = this.xDeviceMin + this.xDeviceStep; x <= this.xDeviceMax - this.xDeviceStep; x += this.xDeviceStep)
            {
                var deliminatorLine = new LineGeometry(new Point(x, this.yDeviceMax - margin / 5),
                    new Point(x, this.yDeviceMax + margin / 5));
                xaxisGrp.Children.Add(deliminatorLine);
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
            var yAxisLine =
                new LineGeometry(new Point(this.xDeviceMin, this.yDeviceMin), new Point(this.xDeviceMin, this.yDeviceMax));
            yaxisGrp.Children.Add(yAxisLine);

            for (double y = this.yDeviceMin + this.yDeviceStep; y <= this.yDeviceMax - this.yDeviceStep; y += this.yDeviceStep)
            {
                var deliminatorLine = new LineGeometry(new Point(this.xDeviceMin - margin / 5, y),
                    new Point(this.xDeviceMin + margin / 5, y));
                yaxisGrp.Children.Add(deliminatorLine);
            }

            Path xAxisPath = new Path();
            xAxisPath.StrokeThickness = 1;
            xAxisPath.Stroke = Brushes.Black;
            xAxisPath.Data = yaxisGrp;

            this.canvas.Children.Add(xAxisPath);
        }
        private void PrepareTransformations()
        {
            RealToDevice = Matrix.Identity;
            RealToDevice.Translate(-this.xDeviceMin, -this.yDeviceMin);

            double xscale = (this.xDeviceMax - this.xDeviceMin) / (this.xRealMax - this.xRealMin);
            double yscale = (this.yDeviceMax - this.yDeviceMin) / (this.yRealMax - this.yRealMin);
            RealToDevice.Scale(xscale, yscale);

            RealToDevice.Translate(this.xDeviceMin, this.yDeviceMin);
            DeviceToReal = RealToDevice;
            DeviceToReal.Invert();
        }

        private Point TranslateRealToDevicePoint(Point point)
        {
            return RealToDevice.Transform(point);
        }
        public void DrawPlot()
        {
            DrawX();
            DrawY();
        }

        public void Drawfunction(Func<double, double> calculator, double step = double.PositiveInfinity)
        {
            if (step == Double.PositiveInfinity) step = this.xRealStep;

            PointCollection points = new PointCollection();



            for (double x = this.xRealMin; x < this.xRealMax; x += step)
            {
                var yValue = calculator(x);
                points.Add(new Point(x, yValue));
            }
        }
    }
}
