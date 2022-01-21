using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DF.General
{
    public struct SpriteBatchArgs
    {
        public SpriteBatchArgs(SpriteSortMode spriteSortMode, BlendState blendState, SamplerState samplerState, 
                DepthStencilState depthStencilState, RasterizerState rasterizerState, Effect effect,
                Matrix transformMatrix)
        {
            this.spriteSortMode = spriteSortMode;
            this.blendState = blendState;
            this.samplerState = samplerState;
            this.depthStencilState = depthStencilState;
            this.rasterizerState = rasterizerState;
            this.effect = effect;
            this.transformMatrix = transformMatrix;
        }
        
        public SpriteSortMode spriteSortMode;
        public BlendState blendState;
        public SamplerState samplerState;
        public DepthStencilState depthStencilState;
        public RasterizerState rasterizerState;
        public Effect effect;
        public Matrix transformMatrix;
        
    }
}