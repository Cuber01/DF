using System;
using Microsoft.Xna.Framework;

namespace DF.Framework
{
    public static class Util
    {
        public static Random random = new Random();
        
        public static float calculateDistance(Vector2 point1, Vector2 point2)
        {
            float dx = Math.Abs(point2.X - point1.X);
            float dy = Math.Abs(point2.Y - point1.Y);
            float dist = (float)Math.Sqrt(dx * dx + dy * dy);
            return dist;
        }
        
        public static bool randomBool(float chance)
        {
            return random.NextDouble() > chance;
        }

        public static int randomPositiveOrNegative(int number, float chance)
        {
            bool positive = randomBool(chance);

            if (positive)
            {
                return Math.Abs(number);
            }
            
            return -Math.Abs(number);
            
        }
    }
}