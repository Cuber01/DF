using Microsoft.Xna.Framework;

namespace DF.Entities.Mobs
{
    // Mob is defined as a killable Entity.
    public class Mob : Entity
    {
        public int hitpoints = 5;

        public void takeDamage(int damage)
        {
            hitpoints -= damage;
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
            updateSprite(gameTime);
            updateBounds(position); 
        }
    }
}