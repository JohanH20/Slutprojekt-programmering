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
		private int x;
		private int y;

		public orm(int h, int s, int x, int y)
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

			if (kstate.IsKeyDown(Keys.S) || oldkstate.IsKeyUp(Keys.S))
			{
					y -= hastighet;
			}

			if (kstate.IsKeyDown(Keys.W) || oldkstate.IsKeyUp(Keys.W))
			{
					y += hastighet;
			}

			if (kstate.IsKeyDown(Keys.D) || oldkstate.IsKeyUp(Keys.D))
			{
					x -= hastighet;
			}

			if (kstate.IsKeyDown(Keys.A) || oldkstate.IsKeyUp(Keys.A))
			{
					x += hastighet;
			}
			oldkstate = kstate;
		}
		public void Draw(GraphicsDeviceManager graphics, SpriteBatch spriteBatch)
		{
			Texture2D kropp = new Texture2D(graphics.GraphicsDevice, storlek, storlek);
			Color[] färg = new Color[kropp.Width * kropp.Height];

			for (int i = 0; i < färg.Length; i++)
				färg[i] = Color.Green;

			kropp.SetData(färg);

			Vector2 plats = new Vector2(x,y);
			
			spriteBatch.Draw(kropp, plats, Color.White);
		}
	}

}
