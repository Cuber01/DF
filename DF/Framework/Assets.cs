using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Aseprite.Documents;
using MonoGame.Aseprite.Graphics;

namespace DF.Framework
{
    public class Assets
    {
        private static readonly Dictionary<string, AsepriteDocument> aseprite = new Dictionary<string, AsepriteDocument>();
        public static Dictionary<string, Effect> shaders = new Dictionary<string, Effect>();

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
                            Content.Load<AsepriteDocument>(file.Substring(0, file.Length - 4)
                            ));
            }

        }

        public void loadShaders(string directory)
        {
            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory() + "/Content" + directory, "", SearchOption.TopDirectoryOnly);

            foreach (var file in files)
            {
                shaders.Add(Path.GetFileNameWithoutExtension(file),
                    Content.Load<Effect>(file.Substring(0, file.Length - 4)
                    ));
            }
        }

        public static AnimatedSprite asepriteToAnimation(string key)
        {
            return new AnimatedSprite(aseprite[key]);
        }
        
    }
}