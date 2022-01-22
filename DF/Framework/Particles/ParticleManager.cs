using System.Collections.Generic;

namespace DF.Framework.Particles
{
    public static class ParticleManager
    {
        public static List<Particle> particles = new List<Particle>();

        public static void addParticles(List<Particle> newParts)
        {
            foreach (var part in newParts)
            {
                particles.Add(part);
            }
        }

        public static void update()
        {
            
            for (int i = 0; i < particles.Count; i++)
            {
                if (particles[i].radius < 0)
                {
                    particles.Remove(particles[i]);
                    continue;
                }
                
                particles[i].update();
            }
            
        }

        public static void draw()
        {
            foreach (var part in particles)
            {
                part.draw();
            }
        }
        
    }
}