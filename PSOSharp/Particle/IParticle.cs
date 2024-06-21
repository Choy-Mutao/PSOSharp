namespace PSOSharp.Particle
{
    public interface IParticle
    {
        int Dimension { get; }
        double[] Position { get; }
        double[] Velocity { get; }
        double Fitness { get; set; } 

        IParticle CreateNew();
        IParticle Clone();
        string ToString();
    }
}
