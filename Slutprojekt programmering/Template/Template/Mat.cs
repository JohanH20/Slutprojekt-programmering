using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace snake
{
    class Mat
    {
        private Vector2 mat;

        public Mat()
        {

        }

        public Vector2 Maten
        {
            get
            {
                return mat;
            }
            set
            {
                mat = value;
            }
        }

        public void Draw(GraphicsDeviceManager graphics, SpriteBatch spriteBatch)
        {
            Texture2D maten = new Texture2D(graphics.GraphicsDevice, 20, 20);
            Color[] färg = new Color[maten.Width * maten.Height];

            for (int i = 0; i < färg.Length; i++)
                färg[i] = Color.Red;

            maten.SetData(färg);

            spriteBatch.Draw(maten, mat, Color.White);
        }
    }
}
