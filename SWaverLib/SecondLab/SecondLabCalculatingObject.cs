using System;
using System.Collections.Generic;
using System.Text;
using SWaverLib.SecondLab.BasicParameters;

namespace SWaverLib.SecondLab
{
    public class SecondLabCalculatingObject
    {
        private TraceLength traceLength;
        private WaveLength length1;
        private WaveLength length2;
        private ThetaDegrees thetaDegrees;
        private RelativeTraceLength relativeTraceLength;
        public SecondLabCalculatingObject(TraceLength traceLength, WaveLength length1, WaveLength length2,
            ThetaDegrees thetaDegrees, RelativeTraceLength relativeTraceLength)
        {
            this.traceLength = traceLength;
            this.length1 = length1;
            this.length2 = length2;
            this.thetaDegrees = thetaDegrees;
            this.relativeTraceLength = relativeTraceLength;
        }
    }
}
