using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
namespace Picman_Project
{
    class gift
    {

  
        public float x_pos;
        public float y_pos;
       AnimatedSprite gift_anim;
       public bool open = false;
       public bool exist = true;
       int TTL;




        private int arrX;

        public int ArrX
        {
            get { return arrX; }
            set { arrX = value; }
        }
        private int arrY;

        public int ArrY
        {
            get { return arrY; }
            set { arrY = value; }
        }




        public virtual void Effect(player winner){


        }

        public gift(Texture2D a,int x,int y) {

           
             gift_anim = new AnimatedSprite(a,1, 2);
             x_pos = x;
             y_pos = y;
             TTL = 100;
        }

        

        public void draw(SpriteBatch spritebatch)
        {
            

            if (open) { TTL--; }
            if (TTL > 0)
            {
                gift_anim.Draw(spritebatch, new Vector2(x_pos, y_pos));
            }
            else
            {
                this.exist = false;
            }
        }



        public void update_() { 
        //.....
            gift_anim.Update();
            open = true;
            
            
        }


    }
}
