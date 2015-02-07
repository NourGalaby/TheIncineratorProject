using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Picman_Project
{
    class Sniper : gun
    {
        int range;

         List<Abstractmonster> hitlist = new List<Abstractmonster>();

            public Sniper(AnimatedSprite aa, Texture2D g,SoundEffect snd)   : base(aa,g, snd)
        {

            this.shoot_snd = snd;
            gun_animation = aa;
      
            gun_icon = g;
            Ammo = 10;
            attack_damage = 200;
            range = 10;
            reload_time = 40;
            reload = 0;
        }

            public override void attack_hit(player attacker,Abstractmonster m)
            {
                m.is_Hit();
                m.apply_damage(attack_damage);
                attacker.score += 50;

            }




            public override void attack(player attacker)
            {


                if (reload > 0)
                {

                    return;

                }

                reload = reload_time;

                hitlist.Clear();

                if (Ammo <= 0)
                {
                    return;

                }
     
        

                shoot_snd.Play(Global.volume, 0, 0);
                attacking = true;
                Ammo--;

                foreach (Abstractmonster m in Global.monsterlist)
            {
                  


                if (direction == player.Diriction.right)
                {
                    for (int i = 0; i < range; i++)
                        if (m.arr_x == attacker.array_posX + i && m.arr_y == attacker.array_posY )
                        {
                            if (m.isalive() && m.exist) { 
                            hitlist.Add(m);
                        }
                            

                        }


                }
                if (direction == player.Diriction.left)
                {
                    for (int i = 0; i < range; i++)
                        if (m.arr_x == attacker.array_posX -i && m.arr_y == attacker.array_posY )
                        {
                            if (m.isalive())
                            {
                                hitlist.Add(m);
                            }
                        }


                }
                if (direction == player.Diriction.up)
                {
                    for (int i = -1; i < range; i++)
                        if (m.arr_x  == attacker.array_posX && m.arr_y + i == attacker.array_posY)
                        {
                            if (m.isalive())
                            {
                                hitlist.Add(m);
                            }
                          
                       
                        }


                }
                if (direction == player.Diriction.down)
                {
                    for (int i = 0; i <range; i++)
                        if (m.arr_x  == attacker.array_posX && m.arr_y -i == attacker.array_posY)
                        {
                            if (m.isalive())
                            {
                                hitlist.Add(m);
                            }
                        }
                }


                }//end of loop

                //find min distance
                if(hitlist.Count>0){
                    apply_damage(attacker);
                }
           

            }
            void apply_damage(player man)
            {

                     Abstractmonster min = hitlist[0];

                  foreach (Abstractmonster h in hitlist)
                  {
                      //find min distance in hit list
                      if (h.distance_to_player(man) < min.distance_to_player(man))
                      {

                          min = h;
                      }

                  }
                  attack_hit(man, min);

            }

    }
}
