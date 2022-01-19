using DF.Framework;
using DF.General;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;

namespace DF.Entities
{
    public class Player : Entity
    {
        private Collider hitbox;
        private const float speed = 0.21f;
        private const float friction = 0.96f;
        private const float maxVelocity = 6;

        public Player(Vector2 position)
        {
            this.position = position;
            this.hitbox = new Collider(new RectangleF(position, new Size2(8, 8)));
            
            GameMain.collision.Insert(hitbox);
            
            sprite = Assets.animations["ship"];
            sprite.Play("idle");
        }
        
        public override void update(GameTime gameTime)
        {
            reactToInput();
            applyFriction();
            move();
            
            updateSprite(gameTime);
            
            hitbox.update(position);
        }

        private void move()
        {
            Vector2 newPosition = position + velocity * speed;

            position = newPosition;
        }
        
        private void applyFriction()
        {
            velocity.X *= friction;
            velocity.Y *= friction;
        }

        private void reactToInput()
        {
            if (!(velocity.Y < -maxVelocity))
            {
                if (Input.keyboardState.IsKeyDown(Keys.Up))
                {
                    velocity.Y -= 1 * speed;
                }
            }

            if (!(velocity.Y > maxVelocity))
            {
                if (Input.keyboardState.IsKeyDown(Keys.Down))
                {
                    velocity.Y += 1 * speed;
                }
            }

            if (!(velocity.X < -maxVelocity))
            {
                if (Input.keyboardState.IsKeyDown(Keys.Right))
                {
                    velocity.X += 1 * speed;
                }
            }

            if (!(velocity.X > maxVelocity))
            {
                if (Input.keyboardState.IsKeyDown(Keys.Left))
                {
                    velocity.X -= 1 * speed;
                }
            }

        }
    }
}