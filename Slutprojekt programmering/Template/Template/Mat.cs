using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace snake
{
    class Mat
    {
        private Vector2 mat;
        private int x;
        private int y;
        private Orm ormen;
        private Rectangle huvudhitbox;
        private Rectangle mathitbox;
        private GraphicsDeviceManager graphics;

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

        public void Initialize(GraphicsDeviceManager graphics)
        {
            Random random = new Random();
            x = random.Next(graphics.GraphicsDevice.Viewport.Bounds.Width / 20) * 20;
            y = random.Next(graphics.GraphicsDevice.Viewport.Bounds.Height / 20) * 20;
        }

        public void Kollision()
        {
            ormen = new Orm();
            huvudhitbox = new Rectangle(ormen.X, ormen.Y, 20, 20);
            mathitbox = new Rectangle(x, y, 20, 20);

            if (huvudhitbox.Intersects(mathitbox))
            {
                ormen.Storlek += 1;

                Initialize(graphics);
            }
        }

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
