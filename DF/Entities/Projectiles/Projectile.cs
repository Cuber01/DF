using DF.Framework;
using DF.General;
using Microsoft.Xna.Framework;

namespace DF.Entities.Projectiles
{
    public class Projectile : Entity
    {
        protected float speed = 2;
        protected Collider hitbox;

        protected Projectile(Vector2 targetPos, Vector2 position)
        {
            this.position = position;

            setCourse(targetPos);
        }

        protected void setCourse(Vector2 target)
        {
            float dist = Util.calculateDistance(position, target);
            this.velocity.X = (target.X - position.X) / dist;
            this.velocity.Y = (target.Y - position.Y) / dist;
        }
        
        protected void move()
        {
            position += velocity * speed;
        }
        
    }
}