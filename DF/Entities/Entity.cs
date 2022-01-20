using System;
using System.Runtime.ConstrainedExecution;
using Microsoft.Xna.Framework;
using MonoGame.Aseprite.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Collisions;

namespace DF.Entities
{
    public class Entity : ICollisionActor
    {
        public IShapeF Bounds { get; set; }
        
        protected AnimatedSprite sprite;
        public Vector2 position;
        protected Vector2 velocity;
        
        public virtual void update(GameTime gameTime)
        {
            
        }

        public virtual void draw()
        {
            sprite.Render(GameMain.spriteBatch);
        }

        protected void updateSprite(GameTime gameTime)
        {
            sprite.X = position.X;
            sprite.Y = position.Y;
            
            sprite.Update(gameTime);
        }

        protected void updateBounds(Vector2 newPosition)
        {
            Bounds.Position = newPosition;
        }
        
        public virtual void OnCollision(CollisionEventArgs collisionInfo)
        {
            Console.WriteLine("base");    
        }

        
    }
}