using PSOSharp.Gearbox;
using PSOSharp.Particle;

namespace PSOSharp.Swarm
{
    public interface ISwarm
    {
        // per-swarm has only one type of particle
        IParticle Meta_Particle { get; }
        IParticle[] Particles { get; }

        //// record
        //IParticle Best_Particle { get; }

        //// for a single objective problem, the gearbox is only and same;
        //IGearbox GearBox { get; }

        void Initialization();
        void TakeAction();
    }
}
