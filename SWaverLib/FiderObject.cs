using System;
using System.Collections.Generic;
using System.Text;

namespace SWaverLib
{
    public class FiderObject
    {
        public double Frequency { get; set; }
        public double TransmittingPower { get; set; }
        public double TransmittingFading { get; set; }
        public double TransmittingSWR { get; set; }
        public double ReceiverFading { get; set; }
        public double ReceiverSWR { get; set; }
        public double TransmitterRunningAttenuationRatio { get; set; }
        public double ReceiverRunningAttenuationRatio { get; set; }
        public double TransmitterFiderLength { get; set; }
        public double ReceiverFiderLength { get; set; }
        public double TransmittingRange { get; set; }
        public double ReceiverSensivity { get; set; }
        public FiderObject(double frequency, double transmittingPower, double transmitterFading, double transmittingSWR,
            double receiverFading, double receiverSWR, double transmitterRunningAttenuationRatio, double transmitterFiderLength,
            double receiverRunningAttenuationRatio, double receiverFiderLength,
            double transmittingRange, double receiverSensivity)
        {
            this.Frequency = frequency;
            this.TransmittingPower = transmittingPower;
            this.TransmittingFading = transmitterFading;
            this.TransmittingSWR = transmittingSWR;
            this.ReceiverFading = receiverFading;
            this.ReceiverSWR = receiverSWR;
            this.TransmitterRunningAttenuationRatio = transmitterRunningAttenuationRatio;
            this.TransmitterFiderLength = transmitterFiderLength;
            this.ReceiverFiderLength = receiverFiderLength;
            this.ReceiverRunningAttenuationRatio = receiverRunningAttenuationRatio;
            this.TransmittingRange = transmittingRange;
            this.ReceiverSensivity = receiverSensivity;
        }

        public double GetMaximumTransmittingRange()
        {
            var transmitterTermalExtinction =
                FiderCalculation.FiderExtinction(TransmitterFiderLength, TransmitterRunningAttenuationRatio);
            var receiverTermalExtinction =
                FiderCalculation.FiderExtinction(ReceiverFiderLength, ReceiverRunningAttenuationRatio);
            var transmitterAntennaEfficiency =
                FiderCalculation.RetreiveAntennaEfficiency(transmitterTermalExtinction, TransmittingSWR);
            var receiverAntennaEfficiency =
                FiderCalculation.RetreiveAntennaEfficiency(receiverTermalExtinction, ReceiverSWR);
            var pointingVector = FiderCalculation.RetreivePoitingVectorModule(TransmittingPower, TransmittingFading,
                transmitterAntennaEfficiency, TransmittingRange);
            var powerFluxDensity = FiderCalculation.PowerFluxDensity(TransmittingPower, transmitterAntennaEfficiency,
                TransmittingFading, TransmittingRange);
            var maxEFS = FiderCalculation.CalculateElectricalFieldStrengthAmplitude(TransmittingPower,
                transmitterAntennaEfficiency, TransmittingFading, TransmittingRange);
            var receiverPower = FiderCalculation.CalculateReceiverPower(TransmittingPower, TransmittingFading,
                ReceiverFading, receiverAntennaEfficiency, transmitterAntennaEfficiency,
                Frequency, TransmittingRange);
            var maximumTransmittingRange = FiderCalculation.CalculateTransmittingRange(receiverPower, TransmittingRange,
                ValuesConverter.GetReceiverSensivity(ReceiverSensivity));
            return maximumTransmittingRange;
        }
    }
}
