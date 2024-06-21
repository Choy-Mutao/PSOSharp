using PSOSharp.Common;
using PSOSharp.Fitness;
using PSOSharp.Gearbox;
using PSOSharp.Particle;
using PSOSharp.Randomization;
using PSOSharp.Swarm;

namespace PSOSharp.SPSO2006
{
    public class S06Swarm : ISwarm
    {
        IFitness m_fitness;
        IGearbox m_gearbox;
        IParticle meta_particle; // 元祖粒子

        // statistic numbers;
        int Size;
        IParticle[] m_particles;
        int[,] LINKS;

        IParticle m_bestparticle = null;
        public IParticle BestParticle { get => m_bestparticle; } //TODO: 不可以被任意改变, 存值而非引用

        public IGearbox GearBox => m_gearbox;

        public IParticle Meta_Particle { get => meta_particle; }

        public IParticle[] Particles { get => m_particles; }

        double mean_fitness;

        public S06Swarm(int size, IParticle mp, IGearbox gearbox, IFitness fitness)
        {
            Size = size;
            meta_particle = mp;
            m_fitness = fitness;
            m_gearbox = gearbox;
        }

        public void Initialization()
        {
            ExceptionHelper.ThrowIfNull("meta_particle", meta_particle);
            ExceptionHelper.ThrowIfNull("gearbox", m_gearbox);

            m_particles = new S06Particle[Size];
            LINKS = new int[Size, Size];

            // 根据不同的问题, 需要具体定义; 这是有向的粒子群优化方案
            var m_bestfitness = double.MaxValue;

            for (int i = 0; i < Size; i++)
            {
                m_particles[i] = meta_particle.CreateNew();

                double f = m_fitness.Evaluate(m_particles[i]);
                m_particles[i].Fitness = f;
                //m_particles[i].BestFitness = f;

                if (f < m_bestfitness)
                {
                    m_bestfitness = f;
                    m_bestparticle = m_particles[i].Clone();
                }
            }
        }

        private void ResetLINKS()
        {
            int size = m_particles.Length;
            for (int i = 0; i < size; i++)
            {
                //LINKS[i] = new int[size];
                for (int j = 0; j < size; j++)
                {
                    LINKS[i, j] = 0;
                }
                LINKS[i, i] = 1;
            }
        }

        private void Inform()
        {
            ResetLINKS();
            int K = 3;
            int S = m_particles.Length;
            KISSRandomization randomization = new KISSRandomization();
            for (int m = 0; m < S; m++)
            {
                for (int i = 0; i < K; i++)
                {
                    int s = randomization.GetInt(0, S - 1);
                    LINKS[m, s] = 1;
                }
            }
        }

        // 决定了移动的细节和方向
        public void TakeAction()
        {
            Inform();

            for (int s = 0; s < Size; s++)
            {
                S06Particle sp = (S06Particle)m_particles[s];
                //sp.BestPosition = BestParticle.Position;

                IParticle better = m_particles[s];
                for (int m = 0; m < Size; m++)
                {
                    if (LINKS[s, m] == 1 && m_particles[m].Fitness < better.Fitness) // 隐含的 move 方向
                        better = m_particles[m].Clone();
                }

                sp.BetterPosition = better.Position;

                // ... compute the new velocity, and move
                GearBox.Drive(ref sp);
                sp.Move();

                double f = m_fitness.Evaluate(sp);

                sp.Fitness = f;
                if (sp.Fitness < sp.BestFitness)
                {
                    // 防止回退
                    sp.BestPosition = (double[])sp.Position.Clone();

                    // update best
                    if (sp.Fitness < m_bestparticle.Fitness)
                    {
                        m_bestparticle = sp.Clone();
                    }
                }

            }
            // statistic
        }

        public override string ToString()
        {
            string str = "Swarm [ " + GetType().Name + "] Data: \n";
            str += "Swarm Iparticle Meta Data:" + Meta_Particle.ToString() + "\n";
            str += "Swarm Best Particle :" + BestParticle.ToString() + "\n";
            str += "SwarmParticle Array: ";
            for (int i = 0; i < Size; i++)
            {
                var particle = m_particles[i];
                str += "\n Particle [" + i + "]" + particle.ToString();
            }
            return str;
        }
    }
}
