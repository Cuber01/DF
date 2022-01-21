using DF.Framework;
using Microsoft.Xna.Framework;

namespace DF.Entities.Mobs
{
    // Mob is defined as a killable Entity.
    public class Mob : Entity
    {
        protected int hitpoints = 5;

        protected int blinkTimer;
        private const int maxBlinkTimer = 8;

        public virtual void takeDamage(int damage)
        {
            hitpoints -= damage;
            blinkTimer = maxBlinkTimer;
            
            checkDeath();
        }

        protected void checkDeath()
        {
            if (hitpoints <= 0)
            {
                die();
            }
        }

        private void die()
        {
            // Goodbye!
            GameMain.entities.Remove(this);
            GameMain.collision.Remove(this);
        }
        
        public override void update(GameTime gameTime)
        {
            handleBlink();
            updateSprite(gameTime);
            updateBounds(position); 
        }

        protected virtual void handleBlink()
        {
            if (blinkTimer > 0)
            {
                blinkTimer--;
                
                effect ??= Assets.shaders["blink"];
                return;
            }

            effect = null;
        }
    }
}