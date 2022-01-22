using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace DF.Framework.Particles
{
    public static class TemplateParticles
    {
        private static particleArgs
            poof = new particleArgs(Vector2.Zero, Vector2.Zero, 1f, 10, 5, palette.red);

        public static void createPoofEffect(Vector2 position, int range, int amount, Color color, List<Color> colors = null)
        {
            particleArgs args = poof;

            args.position.X = position.X + ( Util.random.Next(0, range) * Util.randomPositiveOrNegative(1, 0.5f) );
            args.position.Y = position.Y + ( Util.random.Next(0, range) * Util.randomPositiveOrNegative(1, 0.5f));

            if (colors is null)
            {
                args.color = color;
            }
            else
            {
                args.color = colors[Util.random.Next(0, colors.Count)];
            }

            while (amount >= 0)
            {
                amount--;
                
                ParticleManager.particles.Add(new Particle(args));
            }
            
        }
    }
}