using System.Collections.Generic;
using DF.Entities.Projectiles;
using DF.Framework;
using DF.General;
using Microsoft.Xna.Framework;
using MonoGame.Extended;
using MonoGame.Extended.Collisions;

namespace DF.Entities.Mobs
{
    
    public class Asteroid : Mob
    {
        private int damage = 1;
        
        private static readonly List<string> asteroidTextures = new List<string>()
        {
            "asteroid11x9",
            "asteroid12x12",
            "asteroid16x8",
            "asteroid6x5",
            "asteroid7x7"
        };

        public Asteroid(Vector2 position)
        {
            this.position = position;
            this.team = Team.enemies;

            int textureIndex = Util.random.Next(0, asteroidTextures.Count);
            
            sprite = Assets.asepriteToAnimation(asteroidTextures[textureIndex]);
            sprite.Play("idle");

            switch (textureIndex)
            {
                case 0: this.Bounds = new RectangleF(position, new Size2(11, 9)); break;
                case 1: this.Bounds = new RectangleF(position, new Size2(12, 12)); break;
                case 2: this.Bounds = new RectangleF(position, new Size2(16, 8)); break;
                case 3: this.Bounds = new RectangleF(position, new Size2(6, 5)); break;
                case 4: this.Bounds = new RectangleF(position, new Size2(7, 7)); break;
            }

            GameMain.collision.Insert(this);

            this.velocity = new Vector2(0, Util.random.NextSingle(0.1f, 0.5f));
        }
        
        public override void update(GameTime gameTime)
        {
            move();
                    
            base.update(gameTime);
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

        private void move()
        {
            position += velocity; 
        }
                
        
    }
}