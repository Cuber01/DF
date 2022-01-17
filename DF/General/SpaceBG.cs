using System.Collections.Generic;
using DF.Framework;
using Microsoft.Xna.Framework;

namespace DF.General
{
    public class Space
    {
        private List<Star> stars = new List<Star>();

        private static Color[] starColors = 
        {
            palette.dark_blue,
            palette.dark_gray
        };
        
        public void update()
        {
            for (int i = 0; i <= GameMain.canvasWidth; i++)
            {
                
                if (Util.randomBool(0.1f))
                {
                    stars.Add(new Star(new Point(i, 0), starColors[ Util.random.Next(0, starColors.Length) ] ));
                }
                
            }
        }
        
        public void draw()
        {
            DrawUtils d = GameMain.draw;

            foreach (var star in stars)
            {
                d.spixel(star.position.X, star.position.Y, star.color);
            }

        }
    
        private struct Star
        {
            public Star(Point position, Color color)
            {
                this.position = position;
                this.color = color;
            }
            
            public Point position;
            public Color color;
        }
        
    }
    
}