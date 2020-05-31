using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace snake
{
	/// <summary>
	/// Detta är klassen som har hand om ormen i spelet.
	/// </summary>
	public class Orm
	{
		private int hastighet = 20;
		private int storlek;
		private KeyboardState oldkstate;
		private KeyboardState kstate;
		private int x;
		private int y;
		private Vector2 plats;
		private bool up = false;
		private bool höger = true;
		private bool vänster = true;
		private bool ner = true;
		private int startx;
		private int starty;

		/// <summary>
		/// Detta är en konstruktor för orm klassen för att ge värden på x och y.
		/// </summary>
		public Orm(int X, int Y)
		{
			this.x = X;
			this.y = Y;
		}
		/// <summary>
		/// Detta är en tom konstruktor för ormklassen för att jag ska kunna kalla den utan att ha några parametrar.
		/// </summary>
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

		public int Startx
		{
			get { return startx; }
			set { startx = value; }
		}

		public int Starty
		{
			get { return starty; }
			set { starty = value; }
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
		/// <summary>
		/// Denna metoden gör så att rörelsen för ormen fungerar som den ska genom att läsa av vilken knapp som trycks 
		///och sedan ger en ny vektor för ormens huvud och då får alla kroppsdelar den tidigare kroppsdelens plats
		/// </summary>
		public void Riktning(List<Vector2> kroppsdelar, List<Vector2> temp)
		{
			kstate = Keyboard.GetState();
			if (kstate.GetPressedKeys() == null || kstate.GetPressedKeys().Length == 0 || kstate.GetPressedKeys().Length > 0)
			{

				if (kstate.IsKeyDown(Keys.S) && ner == true && kstate.GetPressedKeys().Length == 1)
				{
					kroppsdelar[0] = new Vector2(x, y += hastighet);
					oldkstate = kstate;
					up = false;
					höger = true;
					vänster = true;
					ner = true;
				}

				else if (kstate.IsKeyDown(Keys.W) && up == true && kstate.GetPressedKeys().Length == 1)
				{
					kroppsdelar[0] = new Vector2(x, y -= hastighet);
					oldkstate = kstate;
					up = true;
					höger = true;
					vänster = true;
					ner = false;
				}

				else if (kstate.IsKeyDown(Keys.D) && höger == true && kstate.GetPressedKeys().Length == 1)
				{
					kroppsdelar[0] = new Vector2(x += hastighet, y);
					oldkstate = kstate;
					up = true;
					höger = true;
					vänster = false;
					ner = true;
				}

				else if (kstate.IsKeyDown(Keys.A) && vänster == true && kstate.GetPressedKeys().Length == 1)
				{
					kroppsdelar[0] = new Vector2(x -= hastighet, y);
					oldkstate = kstate;
					up = true;
					höger = false;
					vänster = true;
					ner = true;
				}

				else
				{
					if (oldkstate.IsKeyDown(Keys.S))
					{
						kroppsdelar[0] = new Vector2(x, y += hastighet);
					}
					if (oldkstate.IsKeyDown(Keys.W))
					{
						kroppsdelar[0] = new Vector2(x, y -= hastighet);
					}
					if (oldkstate.IsKeyDown(Keys.D))
					{
						kroppsdelar[0] = new Vector2(x += hastighet, y);
					}
					if (oldkstate.IsKeyDown(Keys.A))
					{
						kroppsdelar[0] = new Vector2(x -= hastighet, y);
					}
				}
			}

			temp[0] = kroppsdelar[0];
			for (int i = 1; i < kroppsdelar.Count; i++)
			{
				temp[i] = kroppsdelar[i];
				kroppsdelar[i] = new Vector2(temp[i - 1].X, temp[i - 1].Y);
			}
		}
		/// <summary>
		/// Denna metoden ritar ut ormen.
		/// </summary>
		public void Draw(SpriteBatch spriteBatch, List<Vector2> kroppsdelar, Texture2D kroppen)
		{
			for (int i = 0; i < kroppsdelar.Count; i++)
			{
				plats = kroppsdelar[i];

				spriteBatch.Draw(kroppen, plats, Color.White);
			}
		}
		/// <summary>
		/// Denna metoden gör så att ormen växer och denna kallas när det sker en kollison med en mat.
		/// </summary>
		public void Växorm(List<Vector2> kroppsdelar, List<Vector2> temp)
		{
			int sista = kroppsdelar.Count - 1;

			float xsista = kroppsdelar[sista].X;
			float ysista = kroppsdelar[sista].Y;

			kroppsdelar.Add(new Vector2(xsista, ysista));
			temp.Add(new Vector2(xsista, ysista));
		}
	}

}
