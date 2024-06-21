using PSOSharp.Common;
using PSOSharp.Swarm;
using PSOSharp.Termination;

namespace PSOSharp
{
    public class ParticleSwarmAlgorithm
    {
        public ISwarm Swarm;
        public ITermination Termination;

        public event EventHandler InitializationHandler;
        public event EventHandler EvaluateHandler;
        public event EventHandler TerminateHandler;

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
            InitializationHandler?.Invoke(this, EventArgs.Empty);

            do
            {
                Swarm.TakeAction();
                EvaluateHandler?.Invoke(this, EventArgs.Empty);
            } while (!Termination.HasReached(Swarm));
            TerminateHandler?.Invoke(this, EventArgs.Empty);
        }
    }
}
