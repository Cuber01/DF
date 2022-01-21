using System.Collections.Generic;
using System.Linq;

namespace DF.Framework
{
    public class ParticleManager
    {
        private static List<Particle> particles = new List<Particle>();

        public static void addParticles(List<Particle> newParts)
        {
            foreach (var part in newParts)
            {
                particles.Add(part);
            }
        }

        public static void update()
        {
            foreach (var part in particles)
            {
                part.update();
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