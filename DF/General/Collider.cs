using System;
using Microsoft.Xna.Framework;
using MonoGame.Extended;
using MonoGame.Extended.Collisions;

namespace DF.General
{
    
    public class Collider : ICollisionActor
    {
        public IShapeF Bounds { get; }

        public Collider(RectangleF rectangleF)
        {
            Bounds = rectangleF;
        }

        public void update(Vector2 position)
        {
            Bounds.Position = position;
        }

        public void OnCollision(CollisionEventArgs collisionInfo)
        {
            Console.WriteLine("Based!");
        }

    }
}