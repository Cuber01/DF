using DF.General;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DF
{

    public class GameMain : Game
    {
        public static GameState gameState = GameState.playing;


        public const int canvasWidth = 128;
        public const int canvasHeight = 128;

        public const int scale = 8;

        private const int windowWidth = canvasWidth * scale;
        private const int windowHeight = canvasWidth * scale;

        private readonly Matrix scaleMatrix = Matrix.CreateScale(scale, scale, 1.0f);
        private readonly GraphicsDeviceManager graphics;

        public static SpriteBatch spriteBatch;
        //private static DrawUtils draw;

        public GameMain()
        {
            graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
            IsMouseVisible = false;
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = windowWidth;
            graphics.PreferredBackBufferHeight = windowHeight;
            graphics.ApplyChanges();

            spriteBatch = new SpriteBatch(GraphicsDevice, 0);
            
            base.Initialize();
            //
            // draw = new DrawUtils(GraphicsDevice, spriteBatch);
            //
            // GEventResponse.subscribeGeneralMethods();
        }

        protected override void LoadContent()
        {
            // spriteBatch = new SpriteBatch(GraphicsDevice);
            Assets assets = new Assets(Content);
            //
            assets.load();
            // assetLoader.loadSounds();
            // assetLoader.loadFonts();
            //
            // SoundManager.init();

        }

        protected override void Update(GameTime gameTime)
        {

            switch (gameState)
            {

                case GameState.playing:
                {
                    updateGame(gameTime);
                    break;
                }

                case GameState.lost:
                {
                    updateGameOver();
                    break;
                }

                case GameState.won:
                {
                    updateGameWon();
                    break;
                }

            }

            base.Update(gameTime);

        }

        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.Black);

            switch (gameState)
            {

                case GameState.playing:
                {
                    drawGame();
                    break;
                }

                case GameState.lost:
                {
                    drawGameOver();
                    break;
                }

                case GameState.won:
                {
                    drawGameWon();
                    break;
                }

            }

            base.Draw(gameTime);

        }

        private void updateGame(GameTime gameTime)
        {

            Assets.sprite.Play("main");
            Assets.sprite.Update(gameTime);
            
            // Input.updateKeyboardState();
            // Input.updateMouseState();
            //
            // GEventHandler.update();
            // GEventHandler.clearEvents();

            //spriteBatch.Begin(samplerState: SamplerState.PointClamp, transformMatrix: scaleMatrix);
            //
            // foreach (Entity spawn in entitiesToBeSpawned)
            // {
            //     entities.Add(spawn);
            // }
            //
            // entitiesToBeSpawned.Clear();
            //
            // foreach (Entity entity in entities)
            // {
            //     if (entity.dead)
            //     {
            //         entitiesToBeKilled.Add(entity);
            //     }
            //
            //     entity.update();
            //
            //     if (RoomLoader.changingRoom)
            //     {
            //         RoomLoader.changingRoom = false;
            //         break;
            //     }
            // }
            //
            // foreach (Entity victim in entitiesToBeKilled)
            // {
            //     entities.Remove(victim);
            // }
            //
            // playerHP.text = Player.stats.hitpoints.ToString();
            //
            // entitiesToBeKilled.Clear();
            //
            // FontRenderer.dissappearingTextQueue.Add(playerHP);
            // FontRenderer.textQueue.Add(playerHP);

            //spriteBatch.End();

        }

        private void drawGame()
        {
            spriteBatch.Begin(samplerState: SamplerState.PointClamp, transformMatrix: scaleMatrix);

         
            Assets.sprite.Render(spriteBatch);
         
            
            // //draw.drawGrid(Color.Gray);
            //
            // foreach( Entity entity in entities )
            // {
            //     entity.draw();
            //     
            //     //entity.collider.draw(draw);
            // }
            //
            // // Heart GUI
            // spriteBatch.Draw(AssetLoader.textures[dTextureKeys.heart], new Vector2(2, 2), Color.White);
            //
            // spriteBatch.End();
            //
            // // Fonts
            // spriteBatch.Begin();
            //
            // FontRenderer.renderQueue();

            spriteBatch.End();
        }

        private void drawGameWon()
        {

        }

        private void updateGameWon()
        {

        }

        private void drawGameOver()
        {

        }

        private void updateGameOver()
        {

        }

    }

}
        