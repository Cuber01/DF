using System;
using System.Collections.Generic;
using DF.Framework;
using Microsoft.Xna.Framework;

namespace DF.General
{
    public class Space
    {
        // TODO we never remove stars from this list...
        private readonly List<Star> stars = new List<Star>();
        private readonly List<Star> starsToBeRemoved = new List<Star>();

        private const int minVelocity = 1;
        private const int maxVelocity = 4;

        private static readonly Color[] starColors = 
        {
            palette.dark_blue,
            palette.dark_gray
        };
        
        public void update()
        {
            for (int i = 0; i <= GConst.canvasWidth; i++)
            {
                
                if (Util.randomBool(0.999f))
                {
                    stars.Add(new Star(new Vector2(i, 0), Util.random.Next(minVelocity, maxVelocity), starColors[ Util.random.Next(0, starColors.Length) ] ));
                }
                
            }

            for (int i = 0; i <= stars.Count - 1; i++)
            {
                var star_tmp = stars[i];

                if (star_tmp.position.Y > GConst.canvasHeight)
                {
                    starsToBeRemoved.Add(stars[i]);
                    continue;
                }

                star_tmp.position.Y += star_tmp.velocity;

                stars[i] = star_tmp;    
            }

            foreach (var star in starsToBeRemoved)
            {
                stars.Remove(star);
            }
            starsToBeRemoved.Clear();
            
            
        }
        
        public void draw()
        {
            DrawUtils d = GameMain.draw;

            foreach (var star in stars)
            {

                for (int i = 0; i <= star.trailLength; i++)
                {
                    d.spixel((int)star.position.X, (int)star.position.Y+i, star.color);
                }
            }

        }
    
        private struct Star
        {
            public Star(Vector2 position, float velocity, Color color)
            {
                this.velocity = velocity;
                this.position = position;

                this.trailLength = (int)velocity;
                this.color = color;
            }
            
            public Vector2 position;
            public readonly int trailLength;
            public readonly float velocity;
            
            public readonly Color color;
        }
        
    }
    
}