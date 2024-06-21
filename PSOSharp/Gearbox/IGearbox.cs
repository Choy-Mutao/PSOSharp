using PSOSharp.Particle;

namespace PSOSharp.Gearbox
{
    public interface IGearbox
    {
        void Drive(ref IParticle particle);
    }
}
