using DF.Framework;
using Microsoft.Xna.Framework;

namespace DF.Entities.Mobs
{
    // Mob is defined as a killable Entity.
    public class Mob : Entity
    {
        private int hitpoints = 5;

        private int blinkTimer;
        private const int maxBlinkTimer = 8;

        public void takeDamage(int damage)
        {
            hitpoints -= damage;
            blinkTimer = maxBlinkTimer;
            
            checkDeath();
        }

        private void checkDeath()
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

        private void handleBlink()
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