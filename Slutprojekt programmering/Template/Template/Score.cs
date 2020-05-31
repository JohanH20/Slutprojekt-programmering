using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Content
{
    class Score
    {
        private int poäng;
        private string text;
        private Vector2 textplats = new Vector2(5, 5);

        public int Poäng
        {
            get { return poäng; }
            set
            {
                if (value >= 0)
                    poäng = value;
            }
        }

        /// <summary>
        /// Denna metoden sätter poängen till 0 när spelet startar eller om det restartas och gör så att poäng inten blir en string.
        /// </summary>
        public void Inizialize()
        {
            poäng = 0;
            text = poäng.ToString();
        }

        /// <summary>
        /// Denna metoden lägger till ett poäng för varje gång metoden uppdateras. Den ändrar även inten till en string för att kunna skriva ut den senare.
        /// </summary>
        public void Update()
        {
            poäng += 1;
            text = poäng.ToString();
        }

        /// <summary>
        /// Ritar ut poängen för spelaren.
        /// </summary>
        public void Draw(SpriteBatch spriteBatch, SpriteFont font)
        {
            spriteBatch.DrawString(font, text, textplats, Color.White);
        }
    }
}
