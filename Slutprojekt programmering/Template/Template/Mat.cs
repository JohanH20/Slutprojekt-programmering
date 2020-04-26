using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace snake
{
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

        public void Initialize(GraphicsDeviceManager graphics)
        {
            GenererarMat(graphics);
        }

        public Rectangle GenererarMat(GraphicsDeviceManager graphics)
        {
            ormen = new Orm();

            x = random.Next(graphics.GraphicsDevice.Viewport.Bounds.Width / 20) * 20;
            y = random.Next(graphics.GraphicsDevice.Viewport.Bounds.Height / 20) * 20;

            matHitbox = new Rectangle(x, y, 20, 20);

            return matHitbox;
        }

        public void Kolliderar(GraphicsDeviceManager graphics, List<Vector2> kroppsdelar, List<Vector2> temp)
        {
            float x = kroppsdelar[0].X;
            float y = kroppsdelar[0].Y;

            int xs = (int)x;
            int ys = (int)y;

            huvudHitbox = new Rectangle(xs, ys, 20, 20);

            if (matHitbox.Intersects(huvudHitbox))
            {
                ormen.Växorm(kroppsdelar, temp);
                GenererarMat(graphics);
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
