using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace snake
{
	public class orm
	{
		private int hastighet;
		private int storlek;
		private KeyboardState oldkstate;
		private KeyboardState kstate;
		private float x;
		private float y;

		public orm(int h, int s, float x, float y)
		{
			hastighet = h;
			storlek = s;
			this.x = x;
			this.y = y;

		}

		public int Hastighet
		{
			get { return hastighet; }
			set
			{
				if (value > 0)
					hastighet = value;
				else hastighet = 1;
			}
		}

		public int Storlek
		{
			get { return storlek; }
			set
			{
				if (value > 1)
					storlek = value;
			}
		}

		public void Riktning()
		{
			kstate = Keyboard.GetState();

			if (kstate.IsKeyDown(Keys.S))
			{
				y += hastighet;
				oldkstate = kstate;
			}

			if (kstate.IsKeyDown(Keys.W))
			{
				y -= hastighet;
				oldkstate = kstate;
			}

			if (kstate.IsKeyDown(Keys.D))
			{
				x += hastighet;
				oldkstate = kstate;
			}

			if (kstate.IsKeyDown(Keys.A))
			{
				x -= hastighet;
				oldkstate = kstate;
			}

			if (kstate.GetPressedKeys() == null || kstate.GetPressedKeys().Length == 0)
			{
				if (oldkstate.IsKeyDown(Keys.S))
				{
					y += hastighet;
				}
				if (oldkstate.IsKeyDown(Keys.W))
				{
					y -= hastighet;
				}
				if (oldkstate.IsKeyDown(Keys.D))
				{
					x += hastighet;
				}
				if (oldkstate.IsKeyDown(Keys.A))
				{
					x -= hastighet;
				}
			}
		}
		public void Draw(GraphicsDeviceManager graphics, SpriteBatch spriteBatch)
		{
			Texture2D kropp = new Texture2D(graphics.GraphicsDevice, 20, 20);
			Color[] färg = new Color[kropp.Width * kropp.Height];

			for (int i = 0; i < färg.Length; i++)
				färg[i] = Color.Green;

			kropp.SetData(färg);

			Vector2 plats = new Vector2(x, y);

			spriteBatch.Draw(kropp, plats, Color.White);
		}
	}

}
