using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;


namespace Picman_Project

{
    public class Shotgun : gun
    {

 

        public Shotgun(AnimatedSprite aa, Texture2D g)   : base(aa,g)
        {


            gun_animation = aa;
      
            gun_icon = g;
            Ammo = 60;
            attack_damage = 40;
        }

    

        public override void attack(player attacker)
        {
         
            if (Ammo > 0)
            {
                attacking = true;
              Ammo--;

            }


            foreach (Abstractmonster m in Global.monsters)
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
