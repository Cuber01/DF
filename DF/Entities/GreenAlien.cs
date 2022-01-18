using DF.Framework;
using DF.General;
using Microsoft.Xna.Framework;
using MonoGame.Extended;

namespace DF.Entities
{
    public class GreenAlien : Mob
    {
        public GreenAlien(Vector2 position)
        {
            this.position = position;
            this.hitbox = new Collider(new RectangleF(position, new Size2(8, 8)));
            
            GameMain.collision.Insert(hitbox);
            
            sprite = Assets.animations["alien_green2"];
            sprite.Play("idle");
        }

        public override void update(GameTime gameTime)
        {
            updateSprite(gameTime);
            hitbox.update(position);
        }

    }
}