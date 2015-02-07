using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace Picman_Project
{
    class guns_pool
    {
        static public Flamethrower Myflamethrower;
        static public Shotgun Myshotgun;
        static public Sniper Mysniper;
        static public void make_guns(Texture2D shotgunT, Texture2D shotgun_icon, Texture2D Sniper_icon, Texture2D Flameico, List<Texture2D> textures,SoundEffect shotgun_snd ,SoundEffect snipe,SoundEffect flame,SoundEffect flame_loop)
        {

            AnimatedSprite shotgun_anim = new AnimatedSprite(shotgunT, 5, 2);

            Myflamethrower = new Flamethrower(shotgun_anim, Flameico,textures,flame,flame_loop);
            Myshotgun = new Shotgun(shotgun_anim, shotgun_icon,shotgun_snd);
            Mysniper = new Sniper(shotgun_anim, Sniper_icon,snipe);

        }
    }
}
