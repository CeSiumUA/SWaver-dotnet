using System;
using System.Collections.Generic;
using System.Text;
using SWaverLib.SecondLab.BasicParameters;

namespace SWaverLib.SecondLab
{
    public class SecondLabCalculatingObject
    {
        private TraceLength traceLength;
        private WaveLength waveLength;
        private ThetaDegrees thetaDegrees;
        private RelativeTraceLength relativeTraceLength;
        private DiafragmRadius diafragmRadius;
        private bool isDirected;
        private bool reverseRelativeDistance;
        public SecondLabCalculatingObject(TraceLength traceLength, WaveLength waveLength,
            ThetaDegrees thetaDegrees, RelativeTraceLength relativeTraceLength, DiafragmRadius diafragmRadius, bool isDirected, bool reverseRelativeDistance)
        {
            this.traceLength = traceLength;
            this.waveLength = waveLength;
            this.thetaDegrees = thetaDegrees;
            this.relativeTraceLength = relativeTraceLength;
            this.isDirected = isDirected;
            this.diafragmRadius = diafragmRadius;
            this.reverseRelativeDistance = reverseRelativeDistance;
        }

        public MathObject CalculateNFresnelZone(int zoneNumber)
        {
            MathObject zoneNumberMath = new MathObject(zoneNumber, MetricPrefixes.One, UnitsOfMeasurement.Units);
            var resultObject =
                (zoneNumberMath * waveLength * relativeTraceLength * traceLength *
                 (traceLength - (relativeTraceLength * traceLength))) / traceLength;
            MathObject nFresnelZoneRadius = new MathObject(Math.Sqrt(resultObject.Value), MetricPrefixes.One, UnitsOfMeasurement.Meter);
            return nFresnelZoneRadius;
        }
    }
}
