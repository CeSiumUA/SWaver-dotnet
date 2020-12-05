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
    }
}
