using System;
using System.Collections.Generic;
using System.Linq;
using DF.Entities;
using DF.Entities.Mobs;
using DF.Framework;
using DF.General;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Collisions;
using MonoGame.Extended.Tweening;

namespace DF
{

    public class GameMain : Game
    {
        private static GameState gameState = GameState.playing;
        public static List<Entity> entities = new List<Entity>();
        

        private readonly GraphicsDeviceManager graphics;
        public static CollisionComponent collision;
        public static Tweener tweener;
        
        public static SpriteBatch spriteBatch;

        public static DrawUtils draw;
        private Space spaceBG;
        
        public static Player player;
        
        
        public GameMain()
        {
            graphics = new GraphicsDeviceManager(this);
            tweener = new Tweener();
            
            collision = new CollisionComponent(new RectangleF(0,0, GConst.canvasWidth, GConst.canvasHeight));
            
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = GConst.windowWidth;
            graphics.PreferredBackBufferHeight = GConst.windowHeight;
            graphics.ApplyChanges();
            
            // Cap at 60fps
            this.IsFixedTimeStep = true;
            this.TargetElapsedTime = TimeSpan.FromSeconds(1d / 60d);

            spriteBatch = new SpriteBatch(GraphicsDevice, 0);
            draw = new DrawUtils(GraphicsDevice, spriteBatch);
            spaceBG = new Space();
            
            base.Initialize();

        }

        protected override void LoadContent()
        {
            Assets assets = new Assets(Content);
            assets.loadTextures("/assets/images/");
            assets.loadShaders("/shaders/");

            // I really wanna keep my player outside of the main update loop. This sacrifice should save a lot of dirty code.
            player = new Player(new Vector2(100, 100));
            
            entities.Add(new GreenAlien(new Vector2(50, 50)));
            
            ParticleManager.addParticles(
            new List<Particle>() {
                    new Particle(
                        new particleArgs(
                                    new Vector2(10,10),
                                    new Vector2(0, 0),
                                    0.99f,
                        100,
                                     10,
                                           palette.red
            
                                    )
                        )
            }
            );

        }

        private Timer timer = new Timer(50, 50);
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
            
            timer.update();
            if (timer.oneIsRunning)
            {
                TemplateParticles.createPoofEffect(new Vector2(62, 62), 62, 20, palette.red);
            }
            
            spaceBG.update();
            
            ParticleManager.update();

            player.update(gameTime);
                
            collision.Update(gameTime);
            
            tweener.Update(gameTime.GetElapsedSeconds());

            for (int i = 0; i <= entities.Count - 1; i++)
            {
                entities[i].update(gameTime);
            }

            spaceBG.update();
        }

        private void drawGame()
        {
            spriteBatch.Begin(GConst.dB.spriteSortMode, GConst.dB.blendState, GConst.dB.samplerState, GConst.dB.depthStencilState, GConst.dB.rasterizerState, GConst.dB.effect, GConst.dB.transformMatrix);
            
            spaceBG.draw();

            ParticleManager.draw();
            
            foreach (var entity in entities)
            {
                entity.draw();
            }

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
        