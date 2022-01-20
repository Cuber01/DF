using System;
using DF.Entities.Mobs;
using DF.Framework;
using DF.General;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Collisions;

namespace DF.Entities.Projectiles
{
    public class Projectile : Entity
    {
        protected float speed = 2;
        protected int damage = 1;

        protected Projectile(Vector2 targetPos, Vector2 position, Team team)
        {
            this.position = position;
            this.team = team;

            setCourse(targetPos);
        }

        protected void setCourse(Vector2 target)
        {
            float dist = Util.calculateDistance(position, target);
            this.velocity.X = (target.X - position.X) / dist;
            this.velocity.Y = (target.Y - position.Y) / dist;
        }

        public override void OnCollision(CollisionEventArgs collisionInfo)
        {
            if (collisionInfo.Other is Mob mob)
            {
                if(mob.team == team) return;
                
                mob.takeDamage(damage);
                die();
            }
        }

        private void die()
        {
            // Farewell!
            GameMain.entities.Remove(this);
            GameMain.collision.Remove(this);
        }

        public override void update(GameTime gameTime)
        {
            updateSprite(gameTime);
            updateBounds(position);
        }

        protected void move()
        {
            position += velocity * speed;
        }
        
    }
}