using System;
using DF.Framework;
using DF.General;
using Microsoft.Xna.Framework;
using MonoGame.Aseprite.Documents;
using MonoGame.Extended;

namespace DF.Entities.Projectiles
{
    public class BulletThin : Projectile
    {
        
        public BulletThin(Vector2 targetPos, Vector2 position, bool flyDown) : base(targetPos, position)
        {
            if (targetPos != Vector2.Zero)
            {
                throw new Exception("This bullet can move only vertically, use bool flyDown to specify whether it should go up or down. targetPos shall be Vector2.Zero.");
            }

            this.sprite = Assets.asepriteToAnimation("bullet_thin");
            this.hitbox = new Collider(new RectangleF(position.X, position.Y, 2, 5));
            this.speed = 1f;

            setCourse(flyDown
                ? new Vector2(position.X, position.Y += 999)
                : new Vector2(position.X, position.Y -= 999));
        }

        public override void update(GameTime gameTime)
        {
            move();
            updateSprite(gameTime);
        }
    }
}