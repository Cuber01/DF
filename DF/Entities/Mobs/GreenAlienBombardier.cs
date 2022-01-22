using DF.Entities.Projectiles;
using DF.Framework;
using DF.General;
using Microsoft.Xna.Framework;
using MonoGame.Extended;
using MonoGame.Extended.Tweening;

namespace DF.Entities.Mobs
{
    public class GreenAlienBombardier : Mob
    {
        private Vector2 destination;
        private const int offsetX = 5;
        private const int downYPerMove = 3;

        private readonly Vector2 tipOffset = new Vector2(3, 7);
        private int maxShootDelay = 100;
        private int shootDelay = 100;
        
        public GreenAlienBombardier(Vector2 position)
        {
            this.position = position;
            this.team = Team.enemies;
            
            this.Bounds = new RectangleF(position, new Size2(8, 8));
            GameMain.collision.Insert(this);
            
            sprite = Assets.asepriteToAnimation("alien_green2");

            sprite.Play("idle");
            
            setNewCourse();
        }

        public override void update(GameTime gameTime)
        {
            updateShoot();
            
            base.update(gameTime);
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
                                                    new Vector2(position.X + tipOffset.X, 999), 
                                                     new Vector2(position.X + tipOffset.X, position.Y + tipOffset.Y),
                                                            team
                                                    ));
        }

        private void setNewCourse()
        {
            // Am I on the right side of the screen?
            if (position.X >= GConst.canvasWidth/2)
            {
                // Move to the left
                (destination.X, destination.Y) = (0 + offsetX, position.Y += downYPerMove);
            }
            else
            {
                // Move to the right
                (destination.X, destination.Y) = (GConst.canvasWidth - offsetX - sprite.Width, position.Y += downYPerMove);
            }
            
            executeCourse(new Vector2(destination.X, position.Y));
            
        }

        private void executeCourse(Vector2 newPosition)
        {
            // 1. Go to newPosition.X
            // 2. Go to newPosition.Y
            // 3. Set a new destination
            // 4. Repeat
            
            GameMain.tweener.TweenTo(target: this, expression: me => this.position, toValue: new Vector2(newPosition.X, position.Y), duration: 3, delay: 0.1f)
                .Easing(EasingFunctions.QuadraticIn)
                .OnEnd(tween =>
                    
                        GameMain.tweener.TweenTo(target: this, expression: me => this.position, toValue: new Vector2(newPosition.X, position.Y), duration: 0.00000001f, delay: 0.1f)
                            .Easing(EasingFunctions.Linear)
                            .OnEnd(tweenie => setNewCourse())
                    
                   );
        }


    }
}