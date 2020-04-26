using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace snake
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private Orm ormen = new Orm();
        private Mat maten = new Mat();
        private List<Vector2> kroppsdelar = new List<Vector2>();
        private List<Vector2> temp = new List<Vector2>();

        //KOmentar
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            IsFixedTimeStep = true;
            TargetElapsedTime = TimeSpan.FromMilliseconds(80);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            ormen = new Orm(graphics.GraphicsDevice.Viewport.Bounds.Width / 2 - 20, graphics.GraphicsDevice.Viewport.Bounds.Height / 2 - 20);

            ormen.Startx = ormen.X;
            ormen.Starty = ormen.Y;

            kroppsdelar = new List<Vector2>(ormen.Storlek);

            if (kroppsdelar.Count == 0)
            {
                for (int i = 0; i < ormen.Storlek; i++)
                {
                    kroppsdelar.Add(new Vector2(ormen.Startx, ormen.Starty - i * 20));
                }
            }


            temp = new List<Vector2>(ormen.Storlek);

            for (int i = 0; i < ormen.Storlek; i++)
            {
                temp.Add(kroppsdelar[0]);
            }

            maten.Initialize(graphics);
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here 
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            ormen.Riktning(kroppsdelar, temp);

            maten.Kolliderar(graphics, kroppsdelar, temp);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            maten.Draw(graphics, spriteBatch);

            ormen.Draw(graphics, spriteBatch, kroppsdelar);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
