using PSOSharp.SPSO2006;
using PSOSharp.SPSO2006.SPSO2006FitnessSeries;
using PSOSharp.Termination;
using System.Diagnostics;

namespace PSOSharp.Test
{
    public class SPSO2006_Test
    {
        [Test]
        public void Parabola()
        {
            S06Particle doubleParticle = new S06Particle(2, -100, 100);
            var termination = new FitnessTermination(0, 0.1);
            var fitness = new ParabolaFitnsss();

            int S = 10 + (int)(2 * Math.Sqrt(2));
            var swarm = new S06Swarm(S, doubleParticle, new SPSO2006Gearbox<S06Particle>(), fitness);

            ParticleSwarmAlgorithm pso = new ParticleSwarmAlgorithm(swarm, termination);
            pso.InitializationHandler += (o, e) =>
            {
                Debug.WriteLine(pso.Swarm.ToString());
            };

            pso.EvaluateHandler += (o, e) =>
            {
                Debug.WriteLine("Current Swamp Best Particle is --> ");
                Debug.WriteLine(pso.Swarm.BestParticle.ToString());
            };

            // handles

            pso.Start();
        }
    }
}
