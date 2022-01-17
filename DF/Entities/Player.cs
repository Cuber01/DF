using DF.Framework;
using DF.Framework.Input;
using DF.General;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGame.Aseprite.Graphics;

namespace DF.Entities
{
    public class Player : Entity
    {

        private const float speed = 0.21f;
        private const float friction = 0.96f;
        private const float maxVelocity = 6;

        public Player(Vector2 position)
        {
            this.position = position;

            sprite = Assets.animations["ship"];
            sprite.Play("idle");
        }
        
        public override void update(GameTime gameTime)
        {
            reactToInput();
            applyFriction();
            move();

            sprite.X = position.X;
            sprite.Y = position.Y;
            sprite.Update(gameTime);
        }
        
        public override void draw()
        {
            sprite.Render(GameMain.spriteBatch);
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