using System.Collections.Generic;
using MonoGame.Aseprite.Documents;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using MonoGame.Aseprite.Graphics;
using Microsoft.Xna.Framework.Graphics;

namespace DF.General
{
    public class Assets
    {
        public Dictionary<string, AnimatedSprite> animations = new Dictionary<string, AnimatedSprite>();
        public Dictionary<string, AsepriteDocument> aseprite = new Dictionary<string, AsepriteDocument>();

        private readonly ContentManager Content;
        public Assets(ContentManager contentManager)
        {
            this.Content = contentManager;
        }
        
        public void loadTextures()
        {
            
            string[] files = 
                Directory.GetFiles(txtPath.Text, "*ProfileHandler.cs", SearchOption.AllDirectories);
            //aseprite = Content.Load<AsepriteDocument>("assets/ufo");
            //sprite = new AnimatedSprite(aseprite);
        }

        private void asepriteToAnimation()
        {
            foreach (var ase in aseprite)
            {
                animations.Add(ase.Key, new AnimatedSprite(ase.Value));
            }    
        }
        
    }
}