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
		private int storlek = 5;
		private KeyboardState oldkstate;
		private KeyboardState kstate;
		private int x;
		private int y;
		private List<Vector2> kroppsdelar;
		private List<Vector2> temp;
		private Vector2 plats;
		private bool up = false;
		private bool höger = true;
		private bool vänster = true;
		private bool ner = true;
		private int startx;
		private int starty;

		public Orm(int X, int Y)
		{
			this.x = X;
			this.y = Y;
		}
		public Orm() { }

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

		public List<Vector2> Kroppsdelar
		{
			get { return kroppsdelar; }
			set { kroppsdelar = value; }
		}

		public void Initialize()
		{

			startx = x;
			starty = y;

			kroppsdelar = new List<Vector2>(storlek);
			if (kroppsdelar.Count == 0)
			{
				for (int i = 0; i < storlek; i++)
				{
					kroppsdelar.Add(new Vector2(startx, starty - i * 20));
				}
			}

			temp = new List<Vector2>(storlek);

			for (int i = 0; i < storlek; i++)
			{
				temp.Add(kroppsdelar[0]);
			}
		}

		public void Riktning()
		{
			kstate = Keyboard.GetState();
			if (kstate.GetPressedKeys().Length == 1)
			{

				if (kstate.IsKeyDown(Keys.S) && ner == true)
				{
					kroppsdelar[0] = new Vector2(x, y += hastighet);
					oldkstate = kstate;
					up = false;
					höger = true;
					vänster = true;
					ner = true;
				}

				else if (kstate.IsKeyDown(Keys.W) && up == true)
				{
					kroppsdelar[0] = new Vector2(x, y -= hastighet);
					oldkstate = kstate;
					up = true;
					höger = true;
					vänster = true;
					ner = false;
				}

				else if (kstate.IsKeyDown(Keys.D) && höger == true)
				{
					kroppsdelar[0] = new Vector2(x += hastighet, y);
					oldkstate = kstate;
					up = true;
					höger = true;
					vänster = false;
					ner = true;
				}

				else if (kstate.IsKeyDown(Keys.A) && vänster == true)
				{
					kroppsdelar[0] = new Vector2(x -= hastighet, y);
					oldkstate = kstate;
					up = true;
					höger = false;
					vänster = true;
					ner = true;
				}
			}

			else if (kstate.GetPressedKeys() == null || kstate.GetPressedKeys().Length == 0)
			{
				if (oldkstate.IsKeyDown(Keys.S) && ner == true)
				{
					kroppsdelar[0] = new Vector2(x, y += hastighet);
				}
				if (oldkstate.IsKeyDown(Keys.W) && up == true)
				{
					kroppsdelar[0] = new Vector2(x, y -= hastighet);
				}
				if (oldkstate.IsKeyDown(Keys.D) && höger == true)
				{
					kroppsdelar[0] = new Vector2(x += hastighet, y);
				}
				if (oldkstate.IsKeyDown(Keys.A) && vänster == true)
				{
					kroppsdelar[0] = new Vector2(x -= hastighet, y);
				}
			}

			temp[0] = kroppsdelar[0];
			for (int i = 1; i < kroppsdelar.Count; i++)
			{
				temp[i] = kroppsdelar[i];
				kroppsdelar[i] = new Vector2(temp[i - 1].X, temp[i - 1].Y);
			}
		}
		public void Draw(GraphicsDeviceManager graphics, SpriteBatch spriteBatch)
		{
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
