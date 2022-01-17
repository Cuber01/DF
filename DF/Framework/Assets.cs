using System.Collections.Generic;
using System.IO;
using MonoGame.Aseprite.Documents;
using Microsoft.Xna.Framework.Content;
using MonoGame.Aseprite.Graphics;

namespace DF.General
{
    public class Assets
    {
        public static Dictionary<string, AnimatedSprite> animations = new Dictionary<string, AnimatedSprite>();
        public Dictionary<string, AsepriteDocument> aseprite = new Dictionary<string, AsepriteDocument>();

        private readonly ContentManager Content;
        public Assets(ContentManager contentManager)
        {
            this.Content = contentManager;
        }
        
        public void loadTextures(string directory)
        {
            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory() + "/Content" + directory, "", SearchOption.TopDirectoryOnly);

            foreach (var file in files)
            {
                aseprite.Add(Path.GetFileNameWithoutExtension(file),
                            Content.Load<AsepriteDocument>(file.Substring(0, file.Length - 4
                            )));
            }
            
            asepriteToAnimation();
        }

        private void asepriteToAnimation()
        {
            foreach (var ase in aseprite)
            {
                if (ase.Value.Frames.Count == 1) continue;
                
                animations.Add(ase.Key, new AnimatedSprite(ase.Value));
            }    
        }
        
    }
}