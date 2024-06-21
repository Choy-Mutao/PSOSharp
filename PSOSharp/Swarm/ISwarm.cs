using PSOSharp.Gearbox;
using PSOSharp.Particle;

namespace PSOSharp.Swarm
{
    public interface ISwarm
    {
        // per-swarm has only one type of particle
        IParticle Meta_Particle { get; }
        IParticle[] Particles { get; }
        IParticle BestParticle { get; }

        void Initialization();
        void TakeAction();
    }
}
