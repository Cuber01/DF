using DF.Framework;
using DF.General;
using Microsoft.Xna.Framework;
using MonoGame.Extended;

namespace DF.Entities.Projectiles
{
    public class BulletBold : Projectile
    {
        
        public BulletBold(Vector2 targetPos, Vector2 position) : base(targetPos, position)
        {
            this.sprite = Assets.animations["bullet_bold"];
            this.hitbox = new Collider(new RectangleF(position.X, position.Y, 4, 4));
            this.speed = 0.2f;
            
            setCourse(targetPos);
        }

        public override void update(GameTime gameTime)
        {
            move();
            updateSprite(gameTime);
        }
    }
}