using DF.Content;
using DF.Entities;
using DF.Framework;
using DF.Framework.Input;
using DF.General;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DF
{

    public class GameMain : Game
    {
        private static GameState gameState = GameState.playing;
        
        private readonly Matrix scaleMatrix = Matrix.CreateScale(GConstants.scale, GConstants.scale, 1.0f);
        private readonly GraphicsDeviceManager graphics;
        public static SpriteBatch spriteBatch;

        public static DrawUtils draw;
        private Space spaceBG;
        
        public Player player;
        
        
        public GameMain()
        {
            graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
            IsMouseVisible = false;
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = GConstants.windowWidth;
            graphics.PreferredBackBufferHeight = GConstants.windowHeight;
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

            // I really wanna keep my player outside of the main update loop. This sacrifice should save a lot of dirty code.
            player = new Player(new Vector2(100, 100));
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
            Input.update();
            
            spaceBG.update();
            
            player.update(gameTime);

            spaceBG.update();
        }

        private void drawGame()
        {
            spriteBatch.Begin(samplerState: SamplerState.PointClamp, transformMatrix: scaleMatrix);
            
            spaceBG.draw();
            
            player.draw();

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
        