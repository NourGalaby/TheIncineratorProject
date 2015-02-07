using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Picman_Project
{
    class guns_pool
    {

        static public Shotgun Myshotgun;
        static public Sniper Mysniper;
        static public void make_guns(Texture2D shotgunT,Texture2D shotgun_icon,Texture2D Sniper_icon ) {

            AnimatedSprite shotgun_anim = new AnimatedSprite(shotgunT, 5, 2);

            Myshotgun = new Shotgun(shotgun_anim, shotgun_icon);
            Mysniper = new Sniper(shotgun_anim, Sniper_icon);

        }
    }
}
