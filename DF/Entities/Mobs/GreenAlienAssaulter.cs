using System;
using DF.Entities.Projectiles;
using DF.Framework;
using DF.General;
using Microsoft.Xna.Framework;
using MonoGame.Extended;
using MonoGame.Extended.Tweening;

namespace DF.Entities.Mobs
{
    public class GreenAlienAssaulter : Mob
    {
        private Vector2 velocity;

        private readonly Vector2 tipOffset = new Vector2(3, 7);

        private const int maxShootDelay = 300;
        private int shootDelay = 300;
        
        public GreenAlienAssaulter(Vector2 position)
        {
            this.position = position;
            this.team = Team.enemies;
            
            this.Bounds = new RectangleF(position, new Size2(8, 8));
            GameMain.collision.Insert(this);
            
            sprite = Assets.asepriteToAnimation("alien_green1");

            sprite.Play("idle");
            
            setVelocity(new Vector2(Util.random.Next(100, 500) * Util.randomPositiveOrNegative(1, 0.5f), 999));
 
        }

        public override void update(GameTime gameTime)
        {
            updateShoot();
            move();
            
            base.update(gameTime);
        }

        private void move()
        {
            position += velocity; 
        }

        private void updateShoot()
        {
            shootDelay--;

            if (shootDelay <= 0)
            {
                shoot();
                shootDelay = maxShootDelay;
            }
        }

        private void shoot()
        {
            GameMain.entities.Add(new BulletBold(
                                                    GameMain.player.position,
                                                     new Vector2(position.X + tipOffset.X, position.Y + tipOffset.Y),
                                                            team
                                                    ));
        }
        
        private void setVelocity(Vector2 destination)
        {
            float dist = Util.calculateDistance(position, destination);
            this.velocity.X = (destination.X - position.X) / (dist*2); // To make him slower
            this.velocity.Y = (destination.Y - position.Y) / (dist*2);
        }
    }
    
}