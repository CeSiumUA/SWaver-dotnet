using System;

namespace SWaverLib
{
    public static class FiderCalculation
    {
        public const double CharacteristicImpedance = 120 * Math.PI;

        public static double FiderExtinction(double length, double linearExtinction)
        {
            var power = -(length * linearExtinction / 10);
            return Math.Pow(10, power);
        }

        public static double RetreiveAntennaEfficiency(double fiderExtinction, double swr)
        {
            return fiderExtinction * (1 - Math.Pow(RetreiveReflectionCoefficient(SWR: swr), 2));
        }

        public static double RetreivePoitingVectorModule(double realTransmittingPower, double radius)
        {
            return Math.Abs(realTransmittingPower / ValuesConverter.CalculateSphereSquare(radius));
        }

        public static double RetreivePoitingVectorModule(double transmitterPower, double transmitterEfficiency,
            double radius)
        {
            return RetreivePoitingVectorModule(transmitterPower * transmitterEfficiency, radius);
        }

        private static double RetreiveReflectionCoefficient(double SWR)
        {
            return ((SWR - 1) / (SWR + 1));
        }

        public static double PowerFluxDensity(double transmitterPower, double transmitterEfficiency,
            double directionalFactor, double radius)
        {
            return (transmitterEfficiency * transmitterPower * directionalFactor) / (ValuesConverter.CalculateSphereSquare(radius));
        }

        public static double PowerFluxDensity(double EFS)
        {
            return (Math.Pow(EFS, 2) / CharacteristicImpedance);
        }

        public static double CalculateElectricalFieldStrength(double transmitterPower, double transmitterEfficiency,
            double directionalFactor, double radius)
        {
            return Math.Sqrt(30 * transmitterEfficiency * transmitterPower * directionalFactor) / radius;
        }

        public static double CalculateElectricalFieldStrengthAmplitude(double transmitterPower,
            double transmitterEfficiency,
            double directionalFactor, double radius)
        {
            return CalculateElectricalFieldStrength(transmitterPower, transmitterEfficiency, directionalFactor,
                radius) * Math.Sqrt(2);
        }

        public static double CalculateReceiverPower(double transmitterPower, double transmitterDirectionalFactor,
            double receiverDirectionalFactor, double transmitterEfficiency, double receiverEfficiency,
            double waveLength, double radius)
        {
            return (transmitterEfficiency * transmitterPower * transmitterDirectionalFactor * receiverDirectionalFactor * receiverEfficiency * Math.Pow(waveLength, 2))/(Math.Pow((4 * Math.PI * radius), 2));
        }
        public static double CalculateTransmittingRange(double receiverPower, double radius, double receiverSensivity)
        {
            return Math.Sqrt(receiverPower/(Math.Pow(radius, 2) * receiverSensivity));
        }
    }
}
