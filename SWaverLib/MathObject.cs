using System;
using System.Collections.Generic;
using System.Text;

namespace SWaverLib
{
    public class MathObject
    {
        private double value { get; set; }
        private MetricPrefixes prefix { get; set; }
        private UnitsOfMeasurement units { get; set; }
        public MathObject(double value, MetricPrefixes prefix = MetricPrefixes.One, UnitsOfMeasurement units = UnitsOfMeasurement.Other)
        {
            this.value = value;
            this.prefix = prefix;
            this.units = units;
        }

        public double Value
        {
            get
            {
                return value;
            }
        }
        
        public MetricPrefixes Prefix
        {
            get
            {
                return prefix;
            }
        }

        public UnitsOfMeasurement Units
        {
            get
            {
                return units;
            }
        }

        public static MathObject operator +(MathObject a, MathObject b)
        {
            var aOperator = a.TransformToSystemInternational();
            var bOperator = b.TransformToSystemInternational();
            var c = new MathObject(aOperator + bOperator, MetricPrefixes.One);
            return c;
        }
        public static MathObject operator -(MathObject a, MathObject b)
        {
            var aOperator = a.TransformToSystemInternational();
            var bOperator = b.TransformToSystemInternational();
            var c = new MathObject(aOperator - bOperator, MetricPrefixes.One);
            return c;
        }
        public static MathObject operator *(MathObject a, MathObject b)
        {
            var aOperator = a.TransformToSystemInternational();
            var bOperator = b.TransformToSystemInternational();
            var c = new MathObject(aOperator * bOperator, MetricPrefixes.One);
            return c;
        }
        public static MathObject operator /(MathObject a, MathObject b)
        {
            var aOperator = a.TransformToSystemInternational();
            var bOperator = b.TransformToSystemInternational();
            var c = new MathObject(aOperator / bOperator, MetricPrefixes.One);
            return c;
        }
    }
}
