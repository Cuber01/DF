using System;
using DF.General;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Aseprite.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Collisions;

namespace DF.Entities
{
    // Entity is defined as an object with a sprite and a collider.
    public class Entity : ICollisionActor
    {
        protected AnimatedSprite sprite;
        protected Effect effect = null;
        
        public IShapeF Bounds { get; protected set; }
        public Team team;
        
        public Vector2 position;
        protected Vector2 velocity;
        
        public virtual void update(GameTime gameTime)
        {
            
        }

        public virtual void draw()
        {
            if (effect != null)
            {
                drawWithEffect();
                return;
            }
            
            sprite.Render(GameMain.spriteBatch);
        }

        private void drawWithEffect()
        {
            GameMain.spriteBatch.End();
            GameMain.spriteBatch.Begin(GConst.dB.spriteSortMode, GConst.dB.blendState, GConst.dB.samplerState, GConst.dB.depthStencilState, GConst.dB.rasterizerState, effect, GConst.dB.transformMatrix);
            
            sprite.Render(GameMain.spriteBatch);
            
            GameMain.spriteBatch.End();
            GameMain.spriteBatch.Begin(GConst.dB.spriteSortMode, GConst.dB.blendState, GConst.dB.samplerState, GConst.dB.depthStencilState, GConst.dB.rasterizerState, GConst.dB.effect, GConst.dB.transformMatrix);
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
 
        }

        
    }
}