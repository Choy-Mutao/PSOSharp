using PSOSharp.Particle;

namespace PSOSharp.Gearbox
{
    public interface IGearbox<T> where T : IParticle
    {
        void Drive(ref T particle);
    }
}
