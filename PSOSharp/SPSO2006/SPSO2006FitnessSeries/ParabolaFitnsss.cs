using PSOSharp.Particle;

namespace PSOSharp.SPSO2006.SPSO2006FitnessSeries
{
    public class ParabolaFitnsss
    {

        double f_min = 0;

        public ParabolaFitnsss(double min = 0) => f_min = min;
        public double Evaluate(IParticle particle)
        {
            double f = 0, p = 0, xd;
            for (int d = 0; d < particle.Dimension; d++)
            {
                xd = particle.Position[d] - p;
                f = f + xd * xd;
            }
            return Math.Abs(f - f_min);
        }
    }
}
