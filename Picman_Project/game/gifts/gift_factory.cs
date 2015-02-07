using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Picman_Project
{
    class gift_factory
    {
    static     Texture2D ammo_texture;
    static Texture2D health_texture;
    static Texture2D points_texture;
    static Texture2D speed_texture;
    static Texture2D sniperAmmo_txt;
    static Texture2D shotgunAmmo_txt;
    static Random R = new Random();
         public  gift_factory(Texture2D ammoT, Texture2D healthT, Texture2D pointsT,Texture2D speedT,Texture2D sniperA,Texture2D shotgunA)
        {
            ammo_texture = ammoT;
            health_texture = healthT;
            points_texture = pointsT;
            speed_texture = speedT;

            sniperAmmo_txt = sniperA;
            shotgunAmmo_txt = shotgunA;
        }

     static public gift create_ammo(int x, int y)
    {
            return new ammo(ammo_texture, x, y);
        
        }
     static public gift create_health(int x, int y)
     {
         return new health(health_texture, x, y);
     }
     static public gift create_points(int x, int y)
     {
         return new points(points_texture, x, y);
     }
     static public gift create_speed(int x, int y)
     {

         return new speed(speed_texture, x, y);
     }
     static public gift createSniperAmmo(int x, int y)
     {

         return new sniper_ammo(sniperAmmo_txt, x, y);
     }
     static public gift createShotgunAmmo(int x, int y)
     {

         return new shotgunAmmo(shotgunAmmo_txt, x, y);
     }




     static public gift create_randomgift(int x, int y)
     {
         int A = R.Next(0, 7);
            switch(A){

                case 1:
                    return create_ammo(x,y);
                    break;
                case 2:
                    return create_health(x,y);
                    break;
                case 3: return create_health(x, y);
                    break;
                case 4: return create_speed(x, y);
                    break;
                case 5: return createShotgunAmmo(x, y);
                    break;
                case 6: return createSniperAmmo(x, y);
                    break;
                default:
                    return create_ammo(x,y);

            }


     }
    }
}
