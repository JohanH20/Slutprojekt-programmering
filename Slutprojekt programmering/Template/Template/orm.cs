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
		private KeyboardState kstate = Keyboard.GetState();
		private Vector2 riktning;
		private Vector2 startposition;

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
				else hastighet = 5;
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

		public override void Update(GameTime gameTime)
		{
			riktning.Y = 5;

			if (kstate.IsKeyDown(Keys.Down))
				riktning.Y = 5;
			if (kstate.IsKeyDown(Keys.Up))
				riktning.Y = -5;
			if (kstate.IsKeyDown(Keys.Right))
				riktning.X = 5;
			if (kstate.IsKeyDown(Keys.Left))
				riktning.X = -5;
		}
		public virtual void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Begin();

			spriteBatch.Draw();
			spriteBatch.End();
		}
	}

}
