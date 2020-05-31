using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Timers;
using Template;
using Template.Content;

namespace snake
{
    /// <summary>
    /// Detta är huvudklassen för spelet.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private Orm ormen = new Orm();
        private Mat maten = new Mat();
        private Score score = new Score();
        private List<Vector2> kroppsdelar = new List<Vector2>();
        private List<Vector2> temp = new List<Vector2>();
        private Texture2D kroppen;
        private SpriteFont font;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            /// <summary>
            /// Gör så att den inte uppdaterar lika ofta och då att ormen inte rör sig lika snabbt.
            /// (Det fungerar fortfarande att styra den och den reagerar på alla tryck som man gör. 
            /// Detta kan vara ett problem om man sänker uppdateringen ännu lägre eftersom den inte registrerar att man klickar knappen)
            /// </summary>
            IsFixedTimeStep = true;
            TargetElapsedTime = TimeSpan.FromMilliseconds(80);
        }

        /// <summary>
        /// Denna metoden gör olika saker precis när programmet startar. Den ger ormen en startpunkt som är i mitten av skärmen.
        /// Den ger maten en startplats och startar score räkningen.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            ormen = new Orm(graphics.GraphicsDevice.Viewport.Bounds.Width / 2 - 20, graphics.GraphicsDevice.Viewport.Bounds.Height / 2 - 20);

            ormen.Startx = ormen.X;
            ormen.Starty = ormen.Y;

            ormen.Storlek = 3;

            kroppsdelar = new List<Vector2>(ormen.Storlek);

            /// <summary>
            /// Om kroppdelar listan inte har några värden så lägger den till storlek(3 i början) antal kroppsdelar och placerar dem på banan.
            /// </summary>
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

            maten.Initialize(graphics, kroppsdelar);

            score.Inizialize();
        }

        /// <summary>
        /// Denna metoden laddar in olika saker som en texture för ormens kroppsdelar och en font som används till att skriva ut spelarens score.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            kroppen = Content.Load<Texture2D>("snakekropp");
            font = Content.Load<SpriteFont>("Font");
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
        /// Denna metoden gör uppdateringar för spelet under hela spelets gång.
        /// Den kallar flera andra metoder som ska uppdateras under spelets gång. 
        /// Den gör så att ormen fortsätter röra sig, och så att den kollar efter kollisioner.
        /// Den uppdaterar även spelarens score och den kollar om spelaren dör.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            ormen.Riktning(kroppsdelar, temp);

            maten.Kolliderar(graphics, kroppsdelar, temp);

            score.Update();

            base.Update(gameTime);

            /// <summary>
            /// Gör så att om huvudet på ormen kolliderar med en annan del av kroppen så restartar spelet. 
            /// Har så att den bara kollar efter kollision med fjärde delen eller en del efter det eftersom den inte kan kollidera med de delarna som är innan 4 eftersom det är fysiskt omöjligt,
            /// och det gör så att den inte brhöver använda lika mycket kraft för att kolla igenom några extra delar som är onödiga.
            /// </summary>
            for (int i = 3; i < kroppsdelar.Count; i++)
            {
                if (kroppsdelar[0].X == kroppsdelar[i].X && kroppsdelar[0].Y == kroppsdelar[i].Y)
                {
                    Initialize();
                }
            }

            /// <summary>
            /// Kollar om ormens huvud kommer utanför viewporten och om den gör det så restartas spelet genom att den kallar initialize metoden igen.
            /// </summary>
            if (kroppsdelar[0].X > graphics.GraphicsDevice.Viewport.Bounds.Width - 1 || kroppsdelar[0].X < 0 || kroppsdelar[0].Y > graphics.GraphicsDevice.Viewport.Bounds.Height - 1 || kroppsdelar[0].Y < 0)
            {
                Initialize();
            }
        }

        /// <summary>
        /// Denna metoden ritar ut alla saker i spelet som maten, ormen och spelarens score.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            maten.Draw(graphics, spriteBatch);

            ormen.Draw(spriteBatch, kroppsdelar, kroppen);

            score.Draw(spriteBatch, font);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
