using DF.Arms;
using DF.Entities.Mobs;
using DF.Entities.Projectiles;
using DF.Framework;
using DF.General;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;

namespace DF.Entities
{
    public class Player : Mob
    {
        private readonly Weapon weapon;
        private readonly Vector2 tipOffset = new Vector2(3, -4);
        private bool wantToShoot = false;

        private const float speed = 0.21f;
        private const float friction = 0.96f;
        private const float maxVelocity = 6;

        public Player(Vector2 position)
        {
            this.position = position;
            this.team = Team.allies;
            
            this.weapon = new PlasmaCannon(position + tipOffset, team);
            
            this.Bounds = new RectangleF(position, new Size2(8, 8));
            GameMain.collision.Insert(this);

            sprite = Assets.asepriteToAnimation("ship");
            sprite.Play("idle");

            effect = Assets.shaders["whiteSprite"];
        }
        
        public override void update(GameTime gameTime)
        {
            reactToInput();
            applyFriction();
            move();

            weapon.update(position + tipOffset, wantToShoot);
            base.update(gameTime);
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
            
            wantToShoot = Input.keyboardState.IsKeyDown(Keys.X);

        }
    }
}