using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Picman_Project
{
    public class Abstractmonster
    {
        //PROTOTYPE

       public Vector2 position;

       // BloodEngine bloodengine;
        static protected Random R = new Random();

     Color tint;
      public  int arr_x;
      public int arr_y;
      int TTL=200;

      int animaterate = 20;
            Multi_AnimatedSprite monster_anim;

        static    protected int max_Cspeed = 9;
            protected int constant_speed;
            protected int speed;
            private int health;

            public int Health
            {
                get { return health; }
                set { health = value; }
            }
    public   int attack_damage;
    int recovery_time;

   public    bool is_hit=false;
       public bool exist = false;




       public Abstractmonster(Texture2D a, int x, int y,BloodEngine Bloodengine)
       {

           monster_anim = new Multi_AnimatedSprite(a, 2, 2);
           position.X = x;
           position.Y = y;
           tint = Color.White;
         //  bloodengine = Bloodengine;
        }


      

        public Boolean isalive(){

            if( health >= 0)
                return true;
            else return false;
        }

       public virtual void attack(player winner)
       {


       }

       public void increase_speed()
       {
           max_Cspeed++;
       }
       public void is_Hit()
       {
           
          // bloodengine.add(10, new Vector2(0.03f * (float)(R.NextDouble() - 0.5), 0.1f));
           is_hit = true;
       }

       public void apply_damage(int X)
       {

           health -= X;
       }

       public float distance_to_player(player man) {

           //returns square distance to player

           float playercenterX = man.Position.X + (man.Width / 2);
           float playercenterY = man.Position.X + (man.Height / 2);

           float enemydistanceX = (playercenterX ) - this.position.X;
           float enemydistanceY = (playercenterY ) - this.position.Y;

           // R^2 = X^2  + Y^2
           return Math.Abs((enemydistanceX * enemydistanceX) + (enemydistanceY * enemydistanceY));
       
       }
       public static bool set=false;
        void Enemymovement(player man) {
     
            
            double smartness = R.Next(1,25);
          double  playercenterX =Math.Round( man.Position.X + (man.Width / 2),5);
           double  playercenterY =Math.Round( man.Position.Y+ (man.Height /2),5);


           double enemydistanceX =Math.Round( (playercenterX + (double)Math.Abs(man.speedX * smartness)) - this.position.X,5);
          double  enemydistanceY = Math.Round((playercenterY +(double) Math.Abs( man.speedY * smartness)) - this.position.Y,5);

           double enemyangle = (double) Math.Atan2(enemydistanceY , enemydistanceX);
      
     
          enemyangle= Math.Round(enemyangle, 5);




            float changeinX=Math.Abs((float)(speed * Math.Cos(enemyangle)));
            float changeinY=Math.Abs((float)(speed * Math.Sin(enemyangle)));

            //debug.the_string = enemydistanceX.ToString();
            //debug.the_string2 = Math.Atan2(enemydistanceY , enemydistanceX).ToString();
            //debug.the_string3 = enemydistanceY.ToString(); 

          if (man.Position.X < this.position.X)
          {
              this.position.X -= changeinX;
          }
          else
          {
              this.position.X += changeinX;
          }

          if (man.Position.Y > this.position.Y)
          {
              this.position.Y += changeinY;
          }
          else { this.position.Y -= changeinY; }
     
        }

        public static void reset_speed()
        {

            max_Cspeed = 7;

        }
    
  public   virtual void update(player man) {

//bloodengine.Update();
//bloodengine.EmitterLocation = position;

      if (TTL < 0)
      {
          exist = false;
          TTL = 200;
          return;
      }
      if (health < 0)
      {
          speed = 0;
       //   this.attack_damage = 0;
          monster_anim.change_line(1);
          TTL--;
          return;
      }

      Enemymovement(man);

         if (is_hit)
         {
             monster_anim.change_line(1);
             speed = constant_speed/2;
             recovery_time++;
             if (recovery_time > 10)
             {
                 recovery_time = 0;
                 is_hit = false;
             }
             tint = Color.SlateBlue;
         }
         else
         {
             tint = Color.White;
             monster_anim.change_line(0);
             speed = constant_speed;
         }

       


         update_arrayPos();

     }
  public void animate()
  {
      animaterate--;
      if (animaterate < 0)
      {
          monster_anim.Update();
          animaterate = 20;
      }
  }

     void update_arrayPos()
     {

         Vector2 t = get_arraypos(position);
         arr_x = Convert.ToInt16(t.X);
         arr_y = Convert.ToInt16(t.Y);

     }

     public Vector2 get_arraypos(Vector2 current)
     {
         Vector2 t = new Vector2(current.X/ Global.tile_width,
             current.Y / Global.tile_width);
         return t;
     }

     public void draw(SpriteBatch spritebatch)
     {
         monster_anim.Draw(spritebatch, position,tint);
        // bloodengine.Draw(spritebatch);
     }


    }
}
