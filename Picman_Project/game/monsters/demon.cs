using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Picman_Project
{
    class demon : Abstractmonster
    {
       public demon(Texture2D demonT,int x,int y,BloodEngine BE):base(demonT,x,y,BE) 
        {
            constant_speed = R.Next(max_Cspeed-5, max_Cspeed);
            speed = 5;
            attack_damage = 1;
            Health = 50;
        }


 

       public override void attack(player myman)
       {

           

       }

    }
}
