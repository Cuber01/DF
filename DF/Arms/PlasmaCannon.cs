using System;
using DF.Entities;
using DF.Entities.Projectiles;
using DF.General;
using Microsoft.Xna.Framework;

namespace DF.Arms
{
    public class PlasmaCannon : Weapon
    {
        private readonly Team team;
        
        public PlasmaCannon(Vector2 tipPosition, Team team) : base(tipPosition)
        {
            this.maxReloadTime = 15;
            this.team = team;
            
            this.currentReloadTime = maxReloadTime;
            
            this.bulletSpeed = 1f;
        }

        protected override void shoot()
        {
            GameMain.entities.Add(new BulletThin(Vector2.Zero, tipPosition, team, false));
        }
    }
}