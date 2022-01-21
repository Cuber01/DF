using DF.General;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DF
{
    public class GConst
    {
        public const int canvasWidth = 128;
        public const int canvasHeight = 128;
        public const int scale = 8;

        public const int windowWidth = canvasWidth * scale;
        public const int windowHeight = canvasWidth * scale;

        private static readonly Matrix scaleMatrix = Matrix.CreateScale(scale, scale, 1.0f);

        // Default Batch
        public static SpriteBatchArgs dB = new SpriteBatchArgs(SpriteSortMode.Deferred,
            BlendState.NonPremultiplied, SamplerState.PointClamp,
            null, null, null, scaleMatrix);
    }
}