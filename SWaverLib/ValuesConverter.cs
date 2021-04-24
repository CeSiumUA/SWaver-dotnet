using System;
using System.Collections.Generic;
using System.Text;

namespace SWaverLib
{
    public static class ValuesConverter
    {
        public static readonly double SpeedOfLight = 3 * Math.Pow(10, 8);
        public static double CalculateSphereSquare(double radius)
        {
            return 4 * Math.PI * Math.Pow(radius, 2);
        }

        public static double GetFrequency(double waveLength)
        {
            return SpeedOfLight / waveLength;
        }

        public static double GetWaveLength(double frequency)
        {
            return SpeedOfLight / frequency;
        }

        public static double GetReceiverSensivity(double value)
        {
            return Math.Pow(10, value / 10) - 3;
        }

        public static Dictionary<MetricPrefixes, double> PrefixValues = new Dictionary<MetricPrefixes, double>()
        {
            {MetricPrefixes.Y, Math.Pow(10, 24)},
            {MetricPrefixes.Z, Math.Pow(10, 21)},
            {MetricPrefixes.E, Math.Pow(10, 18)},
            {MetricPrefixes.P, Math.Pow(10, 15)},
            {MetricPrefixes.T, Math.Pow(10, 12)},
            {MetricPrefixes.G, Math.Pow(10, 9)},
            {MetricPrefixes.M, Math.Pow(10, 6)},
            {MetricPrefixes.k, Math.Pow(10, 3)},
            {MetricPrefixes.h, Math.Pow(10, 2)},
            {MetricPrefixes.da, Math.Pow(10, 1)},
            {MetricPrefixes.One, Math.Pow(10, 0)},
            {MetricPrefixes.d, Math.Pow(10, -1)},
            {MetricPrefixes.c, Math.Pow(10, -2)},
            {MetricPrefixes.m, Math.Pow(10, -3)},
            {MetricPrefixes.μ, Math.Pow(10, -6)},
            {MetricPrefixes.n, Math.Pow(10, -9)},
            {MetricPrefixes.p, Math.Pow(10, -12)},
            {MetricPrefixes.f, Math.Pow(10, -15)},
            {MetricPrefixes.a, Math.Pow(10, -18)},
            {MetricPrefixes.z, Math.Pow(10, -21)},
            {MetricPrefixes.y, Math.Pow(10, -24)},
            {MetricPrefixes.Percents, Math.Pow(10, -2)}
        };

        public static double TransformToSystemInternational(this MathObject mathObject,
            MetricPrefixes metricPrefix = MetricPrefixes.One)
        {
            double rawValue = mathObject.Value * PrefixValues[mathObject.Prefix];
            double calculatedValue = rawValue / PrefixValues[metricPrefix];
            return calculatedValue;
        }
    }

    public enum MetricPrefixes
    {
        Y,
        Z,
        E,
        P,
        T,
        G,
        M,
        k,
        h,
        da,
        One,
        d,
        c,
        m,
        μ,
        n,
        p,
        f,
        a,
        z,
        y,
        Percents
    }

    public enum UnitsOfMeasurement
    {
        Meter,
        Kilogram,
        Second,
        Hertz,
        Units,
        Degree,
        Percents,
        Other
    }
}
