using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Picman_Project
{
    class Sniper : gun
    {


            public Sniper(AnimatedSprite aa, Texture2D g)   : base(aa,g)
        {


            gun_animation = aa;
      
            gun_icon = g;
            Ammo = 10;
            attack_damage = 100;

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
                    for (int i = 0; i < 4; i++)
                        if (m.arr_x == attacker.array_posX + i && m.arr_y == attacker.array_posY )
                        {
                            m.is_Hit();
                            m.apply_damage(attack_damage);
                            attacker.score += 20;

                        }


                }
                if (direction == player.Diriction.left)
                {
                    for (int i = 0; i < 4; i++)
                        if (m.arr_x == attacker.array_posX -i && m.arr_y == attacker.array_posY )
                        {
                            m.is_Hit();
                            m.apply_damage(attack_damage);
                            attacker.score += 20;
                        }


                }
                if (direction == player.Diriction.up)
                {
                    for (int i = -1; i < 2; i++)
                        if (m.arr_x  == attacker.array_posX && m.arr_y + i == attacker.array_posY)
                        {
                            m.is_Hit();
                            m.apply_damage(attack_damage);
                            attacker.score += 20;
                        }


                }
                if (direction == player.Diriction.down)
                {
                    for (int i = 0; i <4; i++)
                        if (m.arr_x  == attacker.array_posX && m.arr_y -i == attacker.array_posY)
                        {
                            m.is_Hit();
                            m.apply_damage(attack_damage);
                            attacker.score += 20;
                        }
                }


                }

            }

    }
}
