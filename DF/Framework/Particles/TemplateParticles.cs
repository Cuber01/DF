using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MonoGame.Extended;

namespace DF.Framework.Particles
{
    public static class TemplateParticles
    {
        

        public static void createPoofEffect(    Vector2 position,           // Initial position of the particle system
                                                int range,                  // Range in which particles should be spawned, counting from position
                                                int amount,                 // Amount of particles
                                                float minVelocity,          // Minimum velocity a particle may have
                                                float maxVelocity,          // Maximum radius a particle may have
                                                float friction,             // Friction of particles
                                                int minRadius,              // Minimum radius a particle may have
                                                int maxRadius,              // Maximum radius a particle may have
                                                int framesUntilSmaller,     // Frames until particle radius is decreased
                                                Color color,                // Color of the particle
                                                List<Color> colors = null   // Optional. List of colors a particle may have, if null, all particles will take color argument
                                                )
        {
            particleArgs args = new particleArgs();
            args.friction = friction;
            args.maxFramesUntilSmaller = framesUntilSmaller;
            
            while (amount > 0)
            {
                amount--;
                args.velocity = new Vector2(Util.random.NextSingle(minVelocity, maxVelocity) * Util.randomPositiveOrNegative(1, 0.5f), Util.random.NextSingle(minVelocity, maxVelocity) * Util.randomPositiveOrNegative(1,0.5f));

                args.position.X = position.X + ( Util.random.Next(0, range) * Util.randomPositiveOrNegative(1, 0.5f));
                args.position.Y = position.Y + ( Util.random.Next(0, range) * Util.randomPositiveOrNegative(1, 0.5f));
                
                args.radius = Util.random.Next(minRadius, maxRadius);
                
                if (colors is null)
                {
                    args.color = color;
                }
                else
                {
                    args.color = colors[Util.random.Next(0, colors.Count)];
                }
                
                ParticleManager.particles.Add(new Particle(args));
            }
            
        }
        
        public struct poofArgs
        {
            public poofArgs(
                Vector2 position,
                int range,  
                int amount,
                float minVelocity,
                float maxVelocity,
                float friction,
                int minRadius,
                int maxRadius,
                int framesUntilSmaller,
                Color color, 
                List<Color> colors)
            {
                this.position = position;
                this.range = range;
                this.amount = amount;
                this.minVelocity = minVelocity;
                this.maxVelocity = maxVelocity;
                this.friction = friction;
                this.minRadius = minRadius;
                this.maxRadius = maxRadius;
                this.framesUntilSmaller = framesUntilSmaller;
                this.color = color;
                this.colors = colors;
            }
            
            public Vector2 position;
            public int range;
            public int amount;
            public float minVelocity;
            public float maxVelocity;
            public float friction;
            public int minRadius;
            public int maxRadius;
            public int framesUntilSmaller;
            public Color color;
            public List<Color> colors;
        
        }
        
        public static poofArgs deathEffect = new poofArgs(new Vector2(62, 62),
            8,
            8,
            0,
            1,
            0.7f,
            3,
            5,
            7,
            Color.MonoGameOrange,
            null
        );
        
    }
}