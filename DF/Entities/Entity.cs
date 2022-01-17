using Microsoft.Xna.Framework;
using MonoGame.Aseprite.Graphics;

namespace DF.Entities
{
    public class Entity
    {
        protected AnimatedSprite sprite;
        protected Vector2 position;
        protected Vector2 velocity;
        
        public virtual void update(GameTime gameTime)
        {
            
        }

        public virtual void draw()
        {
            
        }
    }
}