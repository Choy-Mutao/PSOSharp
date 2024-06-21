namespace PSOSharp.Particle
{
    public interface IParticle
    {
        int Dimension { get; }
        object[] Positions { get; }
        object[] Velocity { get; }

        IParticle CreateNew();
        IParticle Clone();
        IParticle CopyTo();
        string ToString();
    }
}
