using DF.Framework;
using Microsoft.Xna.Framework;

namespace DF.Entities
{
    public class GreenAlien : Mob
    {
        public GreenAlien(Vector2 position)
        {
            this.position = position;
            
            sprite = Assets.animations["alien_green2"];
            sprite.Play("idle");
        }
        
        public override void update(GameTime gameTime)
        {
            updateSprite(gameTime);
        }

    }
}