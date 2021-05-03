using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SWaverLib.SecondLab.BasicParameters;
using SWaverLib.Utils;

namespace SWaverLib.ThirdLab
{
    public class ThirdLabCalculationObject
    {
        private Conductivity conductivity;
        private ElectricalPermeability electricalPermeability;
        private WaveLength waveLength;
        private Height transmitterHeight;
        private Height receiverHeight;
        private ThetaDegrees thetaDegrees;
        private TraceLength traceLength;
        public ThirdLabCalculationObject(Conductivity conductivity, ElectricalPermeability electricalPermeability, WaveLength waveLength, Height transmitterHeight, Height receiverHeight, ThetaDegrees thetaDegrees, TraceLength traceLength)
        {
            this.conductivity = conductivity;
            this.electricalPermeability = electricalPermeability;
            this.waveLength = waveLength;
            this.transmitterHeight = transmitterHeight;
            this.receiverHeight = receiverHeight;
            this.thetaDegrees = thetaDegrees;
            this.traceLength = traceLength;
        }

        public MathObject CalculateRelativeElectricalDensity()
        {
            var relativeValue = this.electricalPermeability /
                                (new MathObject(60, MetricPrefixes.One, UnitsOfMeasurement.Units) * this.waveLength *
                                 this.conductivity);
            return relativeValue;
        }

        public MathObject CalculateDirectionalFactor()
        {
            var directionalFactor = (new MathObject(32000, MetricPrefixes.One, UnitsOfMeasurement.Units)) /
                                    (this.thetaDegrees * new MathObject(360, MetricPrefixes.One,
                                        UnitsOfMeasurement.Degree));
            return directionalFactor;
        }
    }
}
