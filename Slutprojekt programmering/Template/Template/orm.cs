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
		private Vector2 plats;
		private KeyboardState oldkstate;
		private KeyboardState kstate;

		public orm(int h, int s)
		{
			this.hastighet = h;
			this.storlek = s;

		}

		public int Hastighet
		{
			get { return hastighet; }
			set
			{
				if (value > 0)
					hastighet = value;
				else hastighet = 20;
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

			plats.X += 5;

			if (kstate.IsKeyDown(Keys.S) || oldkstate.IsKeyUp(Keys.S))
			{
					plats.Y += hastighet;
			}

			if (kstate.IsKeyDown(Keys.W) || oldkstate.IsKeyUp(Keys.W))
			{
					plats.Y -= hastighet;
			}

			if (kstate.IsKeyDown(Keys.D) || oldkstate.IsKeyUp(Keys.D))
			{
					plats.X += hastighet;
			}

			if (kstate.IsKeyDown(Keys.A) || oldkstate.IsKeyUp(Keys.A))
			{
					plats.X -= hastighet;
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

			plats = new Vector2(graphics.GraphicsDevice.Viewport.Bounds.Width / 2 - 20, graphics.GraphicsDevice.Viewport.Bounds.Height / 2 - 20);
			
			spriteBatch.Draw(kropp, plats, Color.White);
		}
	}

}
