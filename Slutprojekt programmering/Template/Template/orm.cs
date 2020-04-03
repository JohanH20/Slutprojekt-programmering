using System;
using System.Collections.Generic;
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
		private List<Vector2> kroppsdelar;
		private Vector2 plats;

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
				kroppsdelar.Remove(kroppsdelar[storlek - 1]);
				kroppsdelar.Add(new Vector2(x,y + hastighet));
				for (int i = 0; i < storlek; i++)
				{
					plats = kroppsdelar[i];
				}
				oldkstate = kstate;
			}

			else if (kstate.IsKeyDown(Keys.W))
			{
				kroppsdelar.Remove(kroppsdelar[storlek - 1]);
				kroppsdelar.Add(new Vector2(x, y - hastighet));
				for (int i = 0; i < storlek; i++)
				{
					plats = kroppsdelar[i];
				}
				oldkstate = kstate;
			}

			else if(kstate.IsKeyDown(Keys.D))
			{
				kroppsdelar.Remove(kroppsdelar[storlek - 1]);
				kroppsdelar.Add(new Vector2(x + hastighet, y));
				for (int i = 0; i < storlek; i++)
				{
					plats = kroppsdelar[i];
				}
				oldkstate = kstate;
			}

			else if(kstate.IsKeyDown(Keys.A))
			{
				kroppsdelar.Remove(kroppsdelar[storlek - 1]);
				kroppsdelar.Add(new Vector2(x - hastighet, y));
				for (int i = 0; i < storlek; i++)
				{
					plats = kroppsdelar[i];
				}
				oldkstate = kstate;
			}

			else if(kstate.GetPressedKeys() == null || kstate.GetPressedKeys().Length == 0)
			{
				if (oldkstate.IsKeyDown(Keys.S))
				{
					kroppsdelar.Remove(kroppsdelar[storlek - 1]);
					kroppsdelar.Add(new Vector2(x, y + hastighet));
					for (int i = 0; i < storlek; i++)
					{
						plats = kroppsdelar[i];
					}
				}
				if (oldkstate.IsKeyDown(Keys.W))
				{
					kroppsdelar.Remove(kroppsdelar[storlek - 1]);
					kroppsdelar.Add(new Vector2(x, y - hastighet));
					for (int i = 0; i < storlek; i++)
					{
						plats = kroppsdelar[i];
					}
				}
				if (oldkstate.IsKeyDown(Keys.D))
				{
					kroppsdelar.Remove(kroppsdelar[storlek - 1]);
					kroppsdelar.Add(new Vector2(x + hastighet, y));
					for (int i = 0; i < storlek; i++)
					{
						plats = kroppsdelar[i];
					}
				}
				if (oldkstate.IsKeyDown(Keys.A))
				{
					kroppsdelar.Remove(kroppsdelar[storlek - 1]);
					kroppsdelar.Add(new Vector2(x - hastighet, y));
					for (int i =0; i<storlek; i++)
					{
						plats = kroppsdelar[i];
					}
				}
			}
		}
		public void Draw(GraphicsDeviceManager graphics, SpriteBatch spriteBatch)
		{
			kroppsdelar = new List<Vector2>(storlek + 1);
			for (int i = 0; i < storlek; i++)
			{
				kroppsdelar.Add(new Vector2(x, y - i * 20));
			}

			for (int i = 0; i < storlek; i++)
			{
				Texture2D kropp = new Texture2D(graphics.GraphicsDevice, 20, 20);
				Color[] färg = new Color[kropp.Width * kropp.Height];

				for (int v = 0; v < färg.Length; v++)
					färg[v] = Color.Green;
				
				kropp.SetData(färg);

				plats = kroppsdelar[i];

				spriteBatch.Draw(kropp, plats, Color.White);
			}
		}
	}

}
