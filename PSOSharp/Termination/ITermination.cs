using PSOSharp.Swarm;

namespace PSOSharp.Termination
{
    public interface ITermination
    {
        bool HasReached(ISwarm swarm);
    }
}
