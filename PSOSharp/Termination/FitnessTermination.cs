using PSOSharp.Common;
using PSOSharp.Swarm;

namespace PSOSharp.Termination
{
    public class FitnessTermination : ITermination
    {
        double m_target;
        double m_tolerance;
        public FitnessTermination(double target, double tolerance)
        {
            m_target = target;
            m_tolerance = tolerance;
        }

        public bool HasReached(ISwarm swarm)
        {
            return NumberUtils.CompValue(swarm.BestParticle.Fitness, m_target, m_tolerance) == 0;
        }
    }
}
