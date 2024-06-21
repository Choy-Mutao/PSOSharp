using PSOSharp.Gearbox;
using PSOSharp.Particle;
using PSOSharp.Randomization;

namespace PSOSharp.SPSO2006
{
    public class SPSO2006Gearbox : IGearbox
    {
        readonly double w = 1 / (2 * Math.Log(2));
        readonly double c = 0.5 + Math.Log(2);

        public IRandomization randomization;

        public SPSO2006Gearbox()
        {
            randomization = new KISSRandomization();
        }

        public void Drive(ref IParticle particle)
        {
            int D = particle.Dimension;
            for (int d = 0; d < D; d++)
            {
                particle.Velocity[d] = w * particle.Velocity[d] + randomization.GetDouble(0, c) * (particle.BetterPosition[d] - particle.Position[d]);
                particle.Velocity[d] = particle.Velocity[d] + randomization.GetDouble(0, c) * (particle.BestPosition[d] - particle.Position[d]);
            }
        }
    }
}
