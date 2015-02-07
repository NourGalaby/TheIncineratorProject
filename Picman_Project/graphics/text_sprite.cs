using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
namespace Picman_Project
{
    class text_sprite
    {

        static public SpriteFont font;
        private int score = 0;

        static public void init(SpriteFont f) {
            font = f;
        }

       static public void draw(SpriteBatch spriteBatch,string thestring)
        {


            spriteBatch.Begin();

            spriteBatch.DrawString(font, thestring, new Vector2(100, 100), Color.Black);

            spriteBatch.End();
        }
       static public void draw(SpriteBatch spriteBatch, string thestring,int x, int y,Color color,float scale)
       {


           spriteBatch.Begin();

            spriteBatch.DrawString(font, thestring, new Vector2(x, y),  color, 0f, new Vector2(0,0), scale, SpriteEffects.None, 0);

           spriteBatch.End();
       }

      static  public void draw(SpriteBatch spriteBatch, string thestring,int x, int y)
        {
    


            spriteBatch.Begin();

            spriteBatch.DrawString(font, thestring, new Vector2(x, y), Color.Black);

            spriteBatch.End();
        }
    }
}
