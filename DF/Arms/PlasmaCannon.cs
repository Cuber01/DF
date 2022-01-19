using System;
using DF.Entities;
using DF.Entities.Projectiles;
using Microsoft.Xna.Framework;

namespace DF.Arms
{
    public class PlasmaCannon : Weapon
    {
        public PlasmaCannon(Vector2 tipPosition) : base(tipPosition)
        {
            this.maxReloadTime = 15;
            this.currentReloadTime = maxReloadTime;
            
            this.bulletSpeed = 1f;
        }

        protected override void shoot()
        {
            GameMain.entities.Add(new BulletThin(Vector2.Zero, tipPosition, false));
        }
    }
}