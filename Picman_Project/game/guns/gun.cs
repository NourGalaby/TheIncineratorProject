using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace Picman_Project
{
    public  class gun
    {
     protected   AnimatedSprite gun_animation;
     protected Texture2D gun_icon;

     protected SoundEffect shoot_snd;

      protected  Boolean attacking=false;
      public int Ammo = 10;
      protected int reload_time = 0;
        protected int  reload;
      public  float x_pos;
      public float y_pos;
      float angle;
 
      public player.Diriction direction;

     protected int  attack_damage;

      int dx;
      int dy;
      int dx2;
      int dy2;
     // float scaleX=1;
      float scaleY=1;
      SpriteEffects effect;
             public gun(AnimatedSprite animatedsprite,Texture2D g,SoundEffect ss) {
                 gun_icon=g;
                 shoot_snd = ss;
            gun_animation = animatedsprite;

        }

     void   update_direction(){

         if (direction == player.Diriction.right) {

             dx = 81;
             dy = 85;
             angle = 0;

             dx2=230;
             dy2 = 87;
             scaleY = 1.0f;
             effect = SpriteEffects.None;

          
         }
         if (direction == player.Diriction.left)
         {

             dx = -10;
             dy = 85;
             angle = 3.14f;
            scaleY = 1.0f;
             effect = SpriteEffects.FlipVertically;

             dx2 = -150;
             dy2 = 87;
         }
         if (direction == player.Diriction.down)
         {

             dx =50;
             dy =130;
             angle = 1.57f;
              scaleY = 0.5f;
             effect = SpriteEffects.FlipVertically;

             dx2 = 50;
             dy2 = 260;
         }
         if (direction == player.Diriction.up)
         {

             dx = 50;
             dy = 0;
             angle = -1.57f;
             scaleY = 0.5f;
             effect = SpriteEffects.FlipVertically;

             dx2 = 50;
             dy2 = -100;
         }

        }

             int x=0;
      virtual public void draw(SpriteBatch spritebatch){


           update_direction();

           //draw ammo
           text_sprite.draw(spritebatch, "Ammo:" + Ammo.ToString(),600,10,Color.White,0.5f);

           //drawo icon

                spritebatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend,
         null, null, null, null, Global.camera.TranslationMatrix);



                spritebatch.Draw(gun_icon, new Vector2(x_pos+dx, y_pos+dy), null, Color.White,angle,new  Vector2(gun_icon.Width/2, gun_icon.Height/2), new Vector2(scaleY,1 ), effect, Global.depth);
                spritebatch.End();

               
            if (attacking)
            {


            

                gun_animation.Draw(spritebatch, new Vector2(x_pos+dx2, y_pos+dy2),angle,new Vector2(100,50));

              x++;
               
                    gun_animation.Update();
                    if (x > 9)
                    {
                        attacking = false;
                        x = 0;
                    }
                
            }


        }





        
        public   virtual  void update(player man){

                 if (reload > 0) reload--;

         }


             

             public virtual void attack(player attacker)
             {
                 
             }
             public virtual void attack_hit(player attacker,Abstractmonster m)
             {

             }
    }

    }
