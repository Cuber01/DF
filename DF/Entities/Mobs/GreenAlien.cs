using DF.Entities.Projectiles;
using DF.Framework;
using DF.General;
using Microsoft.Xna.Framework;
using MonoGame.Extended;
using MonoGame.Extended.Tweening;

namespace DF.Entities.Mobs
{
    public class GreenAlien : Mob
    {
        private Vector2 destination;
        private const int offsetX = 5;
        private const int downYPerMove = 3;
        
        public GreenAlien(Vector2 position)
        {
            this.position = position;
            this.hitbox = new Collider(new RectangleF(position, new Size2(8, 8)));
            
            GameMain.collision.Insert(hitbox);
            
            sprite = Assets.asepriteToAnimation("alien_green2");
            sprite.Play("idle");
            
            setNewCourse();
        }

        private bool simp = true;
        public override void update(GameTime gameTime)
        {
            updateSprite(gameTime);
            hitbox.update(position);

            if (simp)
            {
                GameMain.entities.Add(new BulletBold(GameMain.player.position, position));
                simp = false;
            }
            
        }

        private void setNewCourse()
        {
            // Am I on the right side of the screen?
            if (position.X >= GConstants.canvasWidth/2)
            {
                // Move to the left
                (destination.X, destination.Y) = (0 + offsetX, position.Y += downYPerMove);
            }
            else
            {
                // Move to the right
                (destination.X, destination.Y) = (GConstants.canvasWidth - offsetX - sprite.Width, position.Y += downYPerMove);
            }
            
            move(new Vector2(destination.X, position.Y));
            
        }

        private void move(Vector2 newPosition)
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