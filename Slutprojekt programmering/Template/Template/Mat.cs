using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace snake
{
    /// <summary>
    /// Detta är klassen som har hand om maten i spelet
    /// </summary>
    class Mat
    {
        private Vector2 mat;
        private int x;
        private int y;
        private Orm ormen;
        private Rectangle huvudHitbox;
        private Rectangle matHitbox;
        private Random random = new Random();

        public Mat() { }

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        /// <summary>
		/// Denna metoden gör så att vid start så kallar den genererarmat metoden för att det ska vara en matbit när spelet startar.
		/// </summary>
        public void Initialize(GraphicsDeviceManager graphics, List<Vector2> kroppsdelar)
        {
            GenererarMat(graphics, kroppsdelar);
        }

        /// <summary>
		/// Denna metoden genererar en matbit på en slumpmässig plats inom viewporten(skärmens bredd och höjd).
		/// </summary>
        public Rectangle GenererarMat(GraphicsDeviceManager graphics, List<Vector2> kroppsdelar)
        {
            ormen = new Orm();
            bool Ledigplats = false;

            /// <summary>
            /// Om ledigplats inte är sann så tar den en slumpmässig plats och kollar om ormen finns på denna platsen,
            /// om det finns en kroppsdel av ormen på den slumpmässiga platsen så gör den inget,
            /// och då börjar den om med processen tills den hittar en plats där det inte finns en orm på och då slutar while-loopen,
            /// sedan så skapas en ny rektangel som är matens plats och hitbox.
            /// </summary>
            while (!Ledigplats)
            {
                x = random.Next(graphics.GraphicsDevice.Viewport.Bounds.Width / 20) * 20;
                y = random.Next(graphics.GraphicsDevice.Viewport.Bounds.Height / 20) * 20;
                if (kroppsdelar.Exists(del => (del.X == x && del.Y == y))) { }
                else
                {
                    Ledigplats = true;
                    break;
                }
            }

            matHitbox = new Rectangle(x, y, 20, 20);

            return matHitbox;
        }
        /// <summary>
		/// Denna metoden är till för att se om ormens huvud kolliderar med matbiten.
		/// </summary>
        public void Kolliderar(GraphicsDeviceManager graphics, List<Vector2> kroppsdelar, List<Vector2> temp)
        {
            float x = kroppsdelar[0].X;
            float y = kroppsdelar[0].Y;

            int xs = (int)x;
            int ys = (int)y;

            huvudHitbox = new Rectangle(xs, ys, 20, 20);

            /// <summary>
            /// kollar om matens hitbox kolliderar med ormens huvud.
            /// Om den kolliderar så kallar den växorm metoden för att göra ormen en kroppsdel längre
            /// sedan så kallar den Genererarmat metoden för att den ska generera en ny plats för maten.
            /// </summary>
            if (matHitbox.Intersects(huvudHitbox))
            {
                ormen.Växorm(kroppsdelar, temp);
                GenererarMat(graphics, kroppsdelar);
            }
        }
        /// <summary>
        /// Denna metoden ritar ut matbiten och den gör detta genom att färga alla pixlar röda inom en area av 20x20 för att man ska kunna se maten.
        /// (Det var detta jag gjorde förut med hela ormen men när den blev en viss längd så använde programmet för mycket plats och det krachade, 
        /// detta fixade jag genom att byta ut det mot en bild och nu funkar det. Men detta behövs inte till maten eftersom det ändå bara kommer att vara en matbit på skärmen samtidigt.)
        /// </summary>
        public void Draw(GraphicsDeviceManager graphics, SpriteBatch spriteBatch)
        {
            mat = new Vector2(x, y);
            Texture2D maten = new Texture2D(graphics.GraphicsDevice, 20, 20);
            Color[] färg = new Color[maten.Width * maten.Height];

            for (int i = 0; i < färg.Length; i++)
                färg[i] = Color.Red;

            maten.SetData(färg);

            spriteBatch.Draw(maten, mat, Color.White);
        }
    }
}
