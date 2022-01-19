using DF.Entities.Projectiles;
using DF.Framework;
using DF.General;
using Microsoft.Xna.Framework;
using MonoGame.Extended;

namespace DF.Entities.Mobs
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
            
            move();
        }

        private bool simp = true;
        public override void update(GameTime gameTime)
        {
            updateSprite(gameTime);
            hitbox.update(position);

            if (simp)
            {
                GameMain.entities.Add(new BulletThin(Vector2.Zero, position, false));
                simp = false;
            }
            
        }

        private void move()
        {
            // GameMain.tweener.TweenTo(target: this, expression: me => this.position, toValue: new Vector2(100, 100), duration: 2, delay: 1)
            //     .Easing(EasingFunctions.ElasticOut);
            
            // CubicIn - Accelerate, sudden stop
            // QuadraticIn - Accelerate, slow down near end
            // BackOut/ElasticOut - Start fast and back off
        }

    }
}