using Microsoft.Xna.Framework;
using MonoGame.Aseprite.Graphics;

namespace DF.Entities
{
    public class Entity
    {
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
    }
}