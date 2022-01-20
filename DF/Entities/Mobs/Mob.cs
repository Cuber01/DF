using DF.Framework;
using DF.General;
using Microsoft.Xna.Framework;

namespace DF.Entities.Mobs
{
    public class Mob : Entity
    {
        public override void update(GameTime gameTime)
        {
            updateSprite(gameTime);
            updateBounds(position); // Try to remove this
        }
    }
}