using PSOSharp.Common;
using PSOSharp.Swarm;
using PSOSharp.Termination;

namespace PSOSharp
{
    public class ParticleSwarmAlgorithm
    {
        public ISwarm Swarm;
        public ITermination Termination;

        public ParticleSwarmAlgorithm(ISwarm swarm, ITermination termination)
        {
            Swarm = swarm;
            Termination = termination;
        }

        public void Start()
        {
            ExceptionHelper.ThrowIfNull("swarm", Swarm);
            ExceptionHelper.ThrowIfNull("termination", Termination);

            // Build
            Swarm.Initialization();

            do
            {
                Swarm.TakeAction();
            } while (!Termination.HasReached(Swarm));
            
        }
    }
}
