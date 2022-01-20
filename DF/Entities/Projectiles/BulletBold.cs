using DF.Framework;
using Microsoft.Xna.Framework;
using MonoGame.Extended;

namespace DF.Entities.Projectiles
{
    public class BulletBold : Projectile
    {
        
        public BulletBold(Vector2 targetPos, Vector2 position, float speed = 0.2f) : base(targetPos, position)
        {
            this.sprite = Assets.asepriteToAnimation("bullet_bold");
            this.Bounds = new RectangleF(position.X, position.Y, 4, 4);
            GameMain.collision.Insert(this);
            this.speed = speed;
            
            setCourse(targetPos);
        }

        public override void update(GameTime gameTime)
        {
            move();

            base.update(gameTime);
        }
    }
}