using Microsoft.Xna.Framework;

namespace DF.Framework
{

    public class Particle
    {
        private Vector2 position;
        private Vector2 velocity;
        private float friction;

        private int framesUntilSmaller;
        private int radius;
        private int color;
        
        public Particle(particleArgs args)
        {
            this.position = args.position;
            this.velocity = args.velocity;
            this.friction = args.friction;

            this.framesUntilSmaller = args.framesUntilSmaller;
            this.radius = args.radius;
            this.color = args.color;
        }

        public void update()
        {
            
        }

        public void draw()
        {
            
        }
        
    }
    
    public struct particleArgs
    {
        public particleArgs(Vector2 position, Vector2 velocity, float friction, int framesUntilSmaller, int radius, int color)
        {
            this.position = position;
            this.velocity = velocity;
            this.friction = friction;

            this.framesUntilSmaller = framesUntilSmaller;
            this.radius = radius;
            this.color = color;
        }

        public Vector2 position;
        public Vector2 velocity;
        public float friction;

        public int framesUntilSmaller;
        public int radius;
        public int color;
    }
}