using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Picman_Project
{
    class Flamethrower : gun
    {

        ParticleEngine flamesengine; // FOR FLAMES . NEW  
        Random R;
        int range;

        int fire_sndT=0;
        float vol_snd = 0;
        SoundEffectInstance shoot_loop_inst;
        bool first_attack = true;


        double changeX = 0;
        double changeY = 0;


        List<Abstractmonster> hitlist = new List<Abstractmonster>();
        SoundEffect shoot_loop;
        public Flamethrower(AnimatedSprite aa, Texture2D g, List<Texture2D> textures,SoundEffect snd,SoundEffect snd_loop)
            : base(aa, g,snd)
        {


            gun_animation = aa;
            range = 3;

            this.shoot_snd = snd;
              shoot_loop_inst = snd_loop.CreateInstance();

            gun_icon = g;
            Ammo = 999999;
            attack_damage = 1;
          flamesengine=  new ParticleEngine(textures, new Vector2(400, 240));
          R = new Random();
        }

        public override void attack_hit(player attacker, Abstractmonster m)
        {
            m.is_Hit();
            m.apply_damage(attack_damage);
            attacker.score += 2;

        }

        public void stop_sound()
        {

        }
        public override void update(player man)
        {
          
            flamesengine.add(1,new Vector2(0,0));
            flamesengine.Update();
            flamesengine.EmitterLocation = man.Position+new Vector2(70f,90);

            fire_sndT++;
            if (attacking)
            {
                if (vol_snd < Global.volume-0.05)
                    vol_snd += 0.009f;
            }
            else
            {
                if (vol_snd > 0.1f)
                    vol_snd -= 0.007f;
                first_attack = true;
            }
            shoot_loop_inst.Volume = vol_snd;
            if (shoot_loop_inst.State== SoundState.Stopped)
            {
                
                   shoot_loop_inst.Play();
                    fire_sndT = 0;
                

            }
        }





        void addflame(player attacker)
        {
          
            if (direction == player.Diriction.right)
            {
                if (changeX < 30 + attacker.speedX)
                {
                    changeX += 3;
                }

                changeY = 20.0f * R.NextDouble() - 7;
                

 
        }

            if (direction == player.Diriction.down)
            {
              //  double vX = 20.0f * R.NextDouble() - 7;
               // double vY = 30 + attacker.speedY;

                changeX = 20.0f * R.NextDouble() - 7;
                if (changeY < 30 + attacker.speedY)
                {
                    changeY += 3;
                }
            }

            if (direction == player.Diriction.left)
            {
               // double vX = -30 + attacker.speedX;
             //   double vY = 20.0f * R.NextDouble() - 7;

                if (changeX > -30 + attacker.speedX)
                {
                    changeX -= 3;
                }
              
                    changeY = 20.0f * R.NextDouble() - 7;
            }

            if (direction == player.Diriction.up)
            {
             //   double vX = 20.0f * R.NextDouble() - 7;
               // double vY = -30 + attacker.speedY;

           
                changeX = 20.0f * R.NextDouble() - 7;
                if (changeY > -30 + attacker.speedY)
                {
                    changeY -= 3 ;
                }
            }

            double vX = changeX;
            double vY = changeY;
            Vector2 velocity = new Vector2((float)vX, (float)vY);

            flamesengine.add(35, velocity);
        }

        public override void attack(player attacker)
        {
            if (Ammo <= 0)
            {
                return;
            }
          


            addflame(attacker);


           
     
            if (first_attack)
            {
                shoot_snd.Play(Global.volume-0.04f,(float)(R.NextDouble()*1.4)-0.55f,0);
                first_attack = false;
            }
            //random for pitch, 
         

            foreach (Abstractmonster m in Global.monsterlist)
            {



                if (direction == player.Diriction.right)
                {
                    for (int i = 0; i < range; i++)
                        if (m.arr_x == attacker.array_posX + i && m.arr_y == attacker.array_posY)
                        {
                            if (m.isalive())
                            {
                                attack_hit(attacker, m);
                            }
                       
                        }


                }
                if (direction == player.Diriction.left)
                {
                    for (int i = 0; i < range; i++)
                        if (m.arr_x == attacker.array_posX - i && m.arr_y == attacker.array_posY)
                        {
                            if (m.isalive())
                            {
                                attack_hit(attacker, m);
                            }
                        }


                }
                if (direction == player.Diriction.up)
                {
                    for (int i = -1; i < range; i++)
                        if (m.arr_x == attacker.array_posX && m.arr_y + i == attacker.array_posY)
                        {
                            if (m.isalive())
                            {
                                attack_hit(attacker, m);
                            }


                        }


                }
                if (direction == player.Diriction.down)
                {
                    for (int i = 0; i < range; i++)
                        if (m.arr_x == attacker.array_posX && m.arr_y - i == attacker.array_posY)
                        {
                            if (m.isalive())
                            {
                             
                                attack_hit(attacker, m);
                            }
                        }
                }


            }//end of loop

            //sort and apply damage



            if (hitlist.Count > 0)
            {
                apply_damage(attacker);
            }

        }


     public override void draw(SpriteBatch spritebatch) {
            base.draw(spritebatch);
            flamesengine.Draw(spritebatch);
        
        }
        void apply_damage(player man)
        {
            //if (hitlist.Count > 0)
            //{
            ////    hitlist.Sort();

            //}


            foreach (Abstractmonster h in hitlist)
            {
                //attack
                attack_hit(man, h);

            }
           

        }

    }
}
