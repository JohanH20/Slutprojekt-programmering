using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace snake
{
	public class Orm
	{
		private int hastighet = 20;
		private int storlek = 3;
		private KeyboardState oldkstate;
		private KeyboardState kstate;
		private float x;
		private float y;
		private float xsenast;
		private float ysenast;
		private List<Vector2> kroppsdelar;
		private List<Orm> kropp;
		private Vector2 plats;

		public Orm(float X, float Y)
		{
			this.x = X;
			this.y = Y;
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

		public float Xsenast
		{
			get { return xsenast; }
			set { xsenast = value; }
		}

		public float Ysenast
		{
			get { return ysenast; }
			set { ysenast = value; }
		}

		public void Riktning()
		{
			kstate = Keyboard.GetState();

			kropp = new List<Orm>(storlek);

			for (int i = 0; i < storlek; i++)
			{
				Orm tempkropp = new Orm(x, y - i * 20);
				kropp.Add(tempkropp);
			}

			if (kstate.IsKeyDown(Keys.S))
			{
				kropp[0] = new Orm(x, y += hastighet);
				oldkstate = kstate;
			}

			else if (kstate.IsKeyDown(Keys.W))
			{
				kropp[0] = new Orm(x, y -= hastighet);
				oldkstate = kstate;
			}

			else if(kstate.IsKeyDown(Keys.D))
			{
				kropp[0] = new Orm(x += hastighet, y);
				oldkstate = kstate;
			}

			else if(kstate.IsKeyDown(Keys.A))
			{
				kropp[0] = new Orm(x -= hastighet, y);
				oldkstate = kstate;
			}

			else if(kstate.GetPressedKeys() == null || kstate.GetPressedKeys().Length == 0)
			{
				if (oldkstate.IsKeyDown(Keys.S))
				{
					kropp[0] = new Orm(x, y += hastighet);
				}
				if (oldkstate.IsKeyDown(Keys.W))
				{
					kropp[0] = new Orm(x, y -= hastighet);
				}
				if (oldkstate.IsKeyDown(Keys.D)) 
				{
					kropp[0] = new Orm(x += hastighet, y);
				}
				if (oldkstate.IsKeyDown(Keys.A))
				{
					kropp[0] = new Orm(x -= hastighet, y);
				}
			}
			for (int i = 1; i < kropp.Count; i++)
			{
				kropp[i].xsenast = kropp[i].x;
				kropp[i].ysenast = kropp[i].y;
				kropp[i].x = kropp[i - 1].xsenast;
				kropp[i].y = kropp[i - 1].ysenast;
			}
		}
		public void Draw(GraphicsDeviceManager graphics, SpriteBatch spriteBatch)
		{
			kroppsdelar = new List<Vector2>(storlek);
			for (int i = 0; i < storlek; i++)
			{
				kroppsdelar.Add(new Vector2(x, y - i * 20));
			}
			for (int i = 0; i < kroppsdelar.Count; i++)
			{
				Texture2D kroppen = new Texture2D(graphics.GraphicsDevice, 20, 20);
				Color[] färg = new Color[kroppen.Width * kroppen.Height];

				for (int v = 0; v < färg.Length; v++)
					färg[v] = Color.Green;
				
				kroppen.SetData(färg);

				plats = kroppsdelar[i];

				spriteBatch.Draw(kroppen, plats, Color.White);
			}
		}
	}

}
