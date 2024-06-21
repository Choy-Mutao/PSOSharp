using PSOSharp.Particle;
using PSOSharp.Randomization;

namespace PSOSharp.SPSO2006
{
    public class S06Particle : IParticle
    {
        #region Interface Fields
        private int m_dimension;
        public int Dimension => m_dimension;

        private double[] m_position;
        public double[] Position => throw new NotImplementedException();

        private double[] m_velocity;
        public double[] Velocity => throw new NotImplementedException();
        #endregion

        #region Self Fields
        double m_min;
        double m_max;

        public double[] m_bestposition;
        public double[] BetterPosition { get => m_bestposition; set => m_bestposition = value; }

        double[] m_globalbest;
        public double[] BestPosition { get => m_globalbest; set => m_globalbest = value; }

        double m_fitness;
        public double Fitness { get => m_fitness; set => m_fitness = value; }

        double m_bestfitness;
        public double BestFitness { get => m_bestfitness; set => m_bestfitness = value; }

        int m_movecount;
        public int MoveCount => m_movecount;
        #endregion

        public S06Particle(int D, double min, double max)
        {
            m_dimension = D;
            m_min = min;
            m_max = max;

            m_position = new double[D];
            m_velocity = new double[D];
            m_bestposition = new double[D];
            m_globalbest = new double[D];

            m_fitness = 0;
            m_bestfitness = 0;
            m_movecount = 0;
        }

        public IParticle Clone()
        {
            S06Particle clone = new S06Particle(m_dimension, m_min, m_max);
            clone.m_position = m_position;
            clone.m_velocity = m_velocity;
            clone.m_fitness = m_fitness;
            clone.m_bestfitness = m_bestfitness;
            clone.m_bestposition = m_bestposition;
            clone.m_movecount = m_movecount;
            clone.m_globalbest = (double[])m_globalbest.Clone();

            return clone;
        }

        public IParticle CreateNew()
        {
            S06Particle dp = new S06Particle(m_dimension, m_min, m_max);
            dp.m_position = RandomizationProvider.KISS.GetDoubleArray(m_dimension, m_min, m_max);
            dp.BetterPosition = dp.Position;

            for (int i = 0; i < m_dimension; i++)
            {
                dp.m_velocity[i] = (RandomizationProvider.KISS.GetDouble(m_min, m_max) - m_position[i]) / 2;
            }
            return dp;
        }
        public void Move()
        {
            for (int d = 0; d < m_dimension; d++)
                m_position[d] = m_position[d] + m_velocity[d];
            Confine();
            m_movecount++;
        }
        private void Confine()
        {
            for (int d = 0; d < m_dimension; d++)
            {
                if (m_position[d] < m_min)
                {
                    m_position[d] = m_min;
                    m_velocity[d] = 0;
                }
                if (m_position[d] > m_max)
                {
                    m_position[d] = m_max;
                    m_velocity[d] = 0;
                }
            }
        }

        public override string ToString()
        {
            string str = "Particle: " + GetType().Name;
            str += ", Dimension: {" + Dimension + "}";
            str += ", Position: [" + string.Join(",", Position) + "]";
            str += ", Velocity: [" + string.Join(",", Velocity) + "]";
            str += ", Fitness: {" + Fitness + "}";
            str += ", PreFitness: {" + BestFitness + "}";
            str += ", BestPosition: [" + string.Join(",", BetterPosition) + "]";
            str += ", GlobalBest: [" + string.Join(",", BestPosition) + "]";
            str += ", MoveCount: {" + MoveCount + "}";

            return str;
        }
    }
}
