using Microsoft.Xna.Framework;

namespace DF.Framework
{

    public class Particle
    {
        private Vector2 position;
        private Vector2 velocity;
        private readonly float friction;
        
        private int radius;
        private readonly Color color;
        
        private int maxFramesUntilSmaller;
        private int framesUntilSmaller;
        
        public Particle(particleArgs args)
        {
            this.position = args.position;
            this.velocity = args.velocity;
            this.friction = args.friction;

            this.maxFramesUntilSmaller = args.maxFramesUntilSmaller;
            this.radius = args.radius;
            this.color = args.color;
        }

        public void update()
        {
            position += velocity;
            velocity *= friction;

            if (framesUntilSmaller > 0)
            {
                framesUntilSmaller--;
                return;
            }

            framesUntilSmaller = maxFramesUntilSmaller;
            radius--;
        }

        public void draw()
        {
            GameMain.draw.circfill((int)position.X, (int)position.Y, radius, color);
        }
        
    }
    
    public struct particleArgs
    {
        public particleArgs(Vector2 position, Vector2 velocity, float friction, int maxFramesUntilSmaller, int radius, Color color)
        {
            this.position = position;
            this.velocity = velocity;
            this.friction = friction;

            this.maxFramesUntilSmaller = maxFramesUntilSmaller;
            this.radius = radius;
            this.color = color;
        }

        public Vector2 position;
        public Vector2 velocity;
        public float friction;

        public int maxFramesUntilSmaller;
        public int radius;
        public Color color;
    }
}