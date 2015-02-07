using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Picman_Project
{
   public class tile
    {
        private Texture2D Wall_texture;
  
       public double maxspeed=5;
        public double deacceleration=2;
        public int width;
        public int height;
        public int x_pos;
        public int y_pos;
        public float rebound=2.2f;
        protected int rate=14992;
        protected int max_rate_value=15000;
     
      
        Color random_color;
        public tile(Texture2D x) {
            Wall_texture = x;
            width = x.Width;
            height = x.Height;



        }
        public tile()
        {
            //for first value only

           
           width = 240;
            height = 240;
            
        }




        private void random_lor() {

            rate++;
            if (rate <max_rate_value) {
                return;
              
            }

            Random R = new Random();
            //int X= R.Next(0, 20);
            if (rate < max_rate_value + 60)
            {
                random_color = Color.White;
                return;
            }
            if (rate < max_rate_value+1360)
            {
                random_color = Color.SkyBlue;
                return;
            }

            if (rate < max_rate_value + 1840)
            {
                random_color = Color.White;
                return;
            }
            if (rate < max_rate_value + 3620)
            {
                random_color = Color.SkyBlue;
                return;
            }
            if (rate < max_rate_value + 5990)
            {
                random_color = Color.SkyBlue;
                rate =(int) R.NextDouble() * 10000 ;
            return;
            }

            //switch (X)
            //{
            //    case 1:

            //        random_color = Color.White;
            //        break;

            //    case 2:


            //        random_color = Color.SlateGray;
            //        break;
            //    case 3:

            //        random_color = Color.SkyBlue;
            //        break;

            //    case 4:

            //        random_color = Color.PowderBlue;
            //        break;
            //    case 5:

            //        random_color = Color.LightBlue;
            //        break;

            //    default:
            //        random_color = Color.White;
            //        break;

            //}

           
        }
        public void draw(SpriteBatch spritebatch ) {
          //  spritebatch.Begin();
            random_lor();// genrate random color tint
            spritebatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend,
     null, null, null, null, Global.camera.TranslationMatrix);
       
   
            spritebatch.Draw(Wall_texture, new Vector2(x_pos, y_pos),null,random_color, 0.0f, Vector2.Zero, new Vector2( Global.scaleX,Global.scaleY), SpriteEffects.None, Global.depth);
         spritebatch.End();
        
        }

        public void tile_effect() { 
        //normal tile
        }


    }
}
