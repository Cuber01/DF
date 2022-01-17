using DF.Framework;
using DF.General;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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
        public readonly GraphicsDeviceManager graphics;

        public static SpriteBatch spriteBatch;

        public static DrawUtils draw;
        private Space spaceBG;
        
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
            draw = new DrawUtils(GraphicsDevice, spriteBatch);
            spaceBG = new Space();
            
            base.Initialize();

        }

        protected override void LoadContent()
        {
            Assets assets = new Assets(Content);
            assets.loadTextures("/assets/images/");
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
            Assets.animations["ufo"].Play("main");
            Assets.animations["ufo"].Update(gameTime);
            
            spaceBG.update();
        }

        private void drawGame()
        {
            spriteBatch.Begin(samplerState: SamplerState.PointClamp, transformMatrix: scaleMatrix);
            
            Assets.animations["ufo"].Render(spriteBatch);
            spaceBG.draw();

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
        