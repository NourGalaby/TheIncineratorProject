using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;


namespace Picman_Project

{
    public class Shotgun : gun
    {

 

        public Shotgun(AnimatedSprite aa, Texture2D g,SoundEffect snd)   : base(aa,g,snd)
        {


            gun_animation = aa;
            this.shoot_snd = snd;
            gun_icon = g;
            Ammo = 10;
            attack_damage = 400;
            reload_time = 60;
            reload = 0;
        }

    

        public override void attack(player attacker)
        {
         
            if (reload > 0)
            {

                return;

            }

            reload = reload_time;
         


            if (Ammo <= 0)
            {
                return;

            }
     
            attacking = true;
            shoot_snd.Play(Global.volume, 0, 0);

            Ammo--;

            foreach (Abstractmonster m in Global.monsterlist)
            {
               
                if (direction == player.Diriction.right)
                {
                    for (int i = -2; i < 3; i++)
                        if (m.arr_x == attacker.array_posX + 1 && m.arr_y == attacker.array_posY + i)
                        {
                            m.is_Hit();
                            m.apply_damage(attack_damage);
                            attacker.score += 100;

                        }
                    if (m.arr_x == attacker.array_posX + 2 && m.arr_y == attacker.array_posY )
                    {
                        //longer range less damage
                        m.is_Hit();
                        m.apply_damage(attack_damage/2);
                        attacker.score += 100;

                    }


                }
                if (direction == player.Diriction.left)
                {
                    for (int i = -1; i < 2; i++)
                        if (m.arr_x == attacker.array_posX-1 && m.arr_y == attacker.array_posY + i)
                        {
                            m.is_Hit();
                            m.apply_damage(attack_damage);
                            attacker.score += 100;
                        }
                    if (m.arr_x == attacker.array_posX - 2 && m.arr_y == attacker.array_posY)
                    {
                        //longer range less damage
                        m.is_Hit();
                        m.apply_damage(attack_damage / 2);
                        attacker.score += 100;

                    }

                }
                if (direction == player.Diriction.up)
                {
                    for (int i = -1; i < 2; i++)
                        if (m.arr_x + i == attacker.array_posX  && m.arr_y+1 == attacker.array_posY )
                        {
                            m.is_Hit();
                            m.apply_damage(attack_damage);
                            attacker.score += 100;
                        }
                    if (m.arr_x == attacker.array_posX && m.arr_y + 2 == attacker.array_posY)
                    {
                        //longer range less damage
                        m.is_Hit();
                        m.apply_damage(attack_damage / 2);
                        attacker.score += 100;

                    }

                }
                if (direction == player.Diriction.down)
                {
                    for (int i = -1; i < 2; i++)
                        if (m.arr_x + i == attacker.array_posX && m.arr_y - 1 == attacker.array_posY)
                        {
                            m.is_Hit();
                            m.apply_damage(attack_damage);
                            attacker.score += 100;
                        }
                    if (m.arr_x == attacker.array_posX && m.arr_y - 2 == attacker.array_posY)
                    {
                        //longer range less damage
                        m.is_Hit();
                        m.apply_damage(attack_damage / 2);
                        attacker.score += 100;

                    }
//same
                    if (m.arr_x  == attacker.array_posX && m.arr_y == attacker.array_posY)
                    {
                        m.is_Hit();
                        m.apply_damage(attack_damage);
                        attacker.score += 100;
                    }

                }




            }
          


        }

    }
}
