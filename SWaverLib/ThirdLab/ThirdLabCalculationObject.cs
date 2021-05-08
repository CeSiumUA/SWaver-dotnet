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
        private MaterialConductivityFactor materialConductivityFactor = MaterialConductivityFactor.Unknown;
        public PolarizationType PolarizationType { get; set; }
        public MaterialConductivityFactor MaterialConductivityFactor
        {
            get
            {
                var relevation = CalculateRelativeElectricalDensity();
                if (relevation.Value >= 3)
                {
                    materialConductivityFactor = MaterialConductivityFactor.Dielectric;
                }
                else if (relevation.Value <= 0.3)
                {
                    materialConductivityFactor = MaterialConductivityFactor.Conductor;
                }
                else
                {
                    var frequency = new MathObject(ValuesConverter.SpeedOfLight, MetricPrefixes.One, UnitsOfMeasurement.MetersPerSecond) / waveLength;
                    var borderFrequency = new MathObject(1.5, MetricPrefixes.M, UnitsOfMeasurement.Hertz);
                    if (frequency < borderFrequency)
                    {
                        materialConductivityFactor = MaterialConductivityFactor.Conductor;
                    }
                    else
                    {
                        materialConductivityFactor = MaterialConductivityFactor.Dielectric;
                    }
                }
                return materialConductivityFactor;
            }
        }
        public ThirdLabCalculationObject(Conductivity conductivity, ElectricalPermeability electricalPermeability, WaveLength waveLength, Height transmitterHeight, Height receiverHeight, ThetaDegrees thetaDegrees, TraceLength traceLength, PolarizationType polarizationType)
        {
            this.conductivity = conductivity;
            this.electricalPermeability = electricalPermeability;
            this.waveLength = waveLength;
            this.transmitterHeight = transmitterHeight;
            this.receiverHeight = receiverHeight;
            this.thetaDegrees = thetaDegrees;
            this.traceLength = traceLength;
            this.PolarizationType = polarizationType;
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

        public MathObject CalculateReflectionCoefficientByAngle(ThetaDegrees angle)
        {
            if (this.MaterialConductivityFactor == MaterialConductivityFactor.Conductor)
            {
                return CalculateReflectionCoefficientByAngleForConductor(angle);
            }

            return CalculateReflectionCoefficientByAngleForDielectric(angle);
        }

        private MathObject CalculateReflectionCoefficientByAngleForDielectric(ThetaDegrees angle)
        {
            if (this.PolarizationType == PolarizationType.Horizontal)
            {
                var res = Math.Abs((Math.Sin(angle.Radians) - Math.Sqrt(this.electricalPermeability.Value -
                                                                        Math.Pow(Math.Cos(angle.Radians), 2))) / (Math.Sin(angle.Radians) + Math.Sqrt(this.electricalPermeability.Value -
                    Math.Pow(Math.Cos(angle.Radians), 2))));
                return (MathObject) res;
            }

            return (MathObject)Math.Abs((this.electricalPermeability * Math.Sin(angle.Radians) - Math.Sqrt(this.electricalPermeability.Value -
                                                                     Math.Pow(Math.Cos(angle.Radians), 2))) / (this.electricalPermeability * Math.Sin(angle.Radians) + Math.Sqrt(this.electricalPermeability.Value -
                Math.Pow(Math.Cos(angle.Radians), 2))));
        }
        private MathObject CalculateReflectionCoefficientByAngleForConductor(ThetaDegrees angle)
        {
            return new MathObject(1, MetricPrefixes.One, UnitsOfMeasurement.Units);
        }
    }

    public enum MaterialConductivityFactor
    {
        Unknown,
        Dielectric,
        Conductor
    }

    public enum PolarizationType
    {
        Vertical,
        Horizontal
    }
}
