using PSOSharp.Particle;

namespace PSOSharp.Fitness
{
    public interface IFitness
    {
        double Evaluate(IParticle particle);
    }
}
