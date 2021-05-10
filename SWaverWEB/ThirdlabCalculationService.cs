using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SWaverLib.SecondLab.BasicParameters;
using SWaverLib.ThirdLab;
using SWaverLib.Utils;

namespace SWaverWEB
{
    public class ThirdlabCalculationService
    {
        private ThirdLabCalculationObject thirdLabCalculationObject;
        public ThirdlabCalculationService()
        {
            this.thirdLabCalculationObject = new ThirdLabCalculationObject(new Conductivity(0.001), new ElectricalPermeability(25),
                new WaveLength(20), new Height(150), new Height(150), new ThetaDegrees(90),
                new TraceLength(1), PolarizationType.Horizontal);
        }

        public async Task<IEnumerable<GraphPoint>> GetPlotPointsAsync()
        {
            List<GraphPoint> points = new List<GraphPoint>();
            for (double x = 0; x < Math.PI * 2; x += 0.1)
            {
                var y = this.thirdLabCalculationObject.CalculateReflectionCoefficientByAngle(new ThetaDegrees(0)
                    {Radians = x});
                var calculatedPoint = new GraphPoint(x, y);
                points.Add(calculatedPoint);
            }

            return points;
        }
    }
}
