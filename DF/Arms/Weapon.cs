using System;
using Microsoft.Xna.Framework;

namespace DF.Arms
{
    
    // I'm taking a more hard-code approach because we don't really want to edit weapons at runtime.
    public class Weapon
    {
        protected Vector2 tipPosition;
        
        protected int currentReloadTime;
        protected int maxReloadTime;

        protected float bulletSpeed;
        protected Type Bullet;

        protected Weapon(Vector2 tipPosition)
        {
            this.tipPosition = tipPosition;
        }

        public void update(Vector2 newTipPosition, bool wantToShoot)
        {
            tipPosition = newTipPosition;
            
            if (currentReloadTime > 0) currentReloadTime--;

            if (wantToShoot && currentReloadTime <= 0)
            {
                shoot();
                currentReloadTime = maxReloadTime;
            }
            
        }

        protected virtual void shoot()
        {
            
        }
    }
}