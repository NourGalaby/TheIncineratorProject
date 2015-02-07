using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Picman_Project
{
   public class MonstersPool
    {
        static int health_change=1;
        static int health_rate=10;
        Random R = new Random();
        public MonstersPool(Texture2D red,BloodEngine BE)
        {
            Global.monsterlist=new List<Abstractmonster>();
            for(int i =0;i<25;i++)
            {
                Global.monsterlist.Add(new demon(red, 1260, 1260, BE));
            }
        }

        public void resurrect()
        {
            foreach (Abstractmonster m in Global.monsterlist)
            {

                if (!m.exist)
                {
                   
                    init(m);
                    return;
                }
               
            }
           

        }
        public static void reset_health()
        {

            health_change = 0;

        }

        private void init(Abstractmonster m)
        {
            m.position = new Vector2(R.Next(240, (Global.maze_array.GetLength(0) - 3) * 240), R.Next(240, (Global.maze_array.GetLength(1) - 3) * 240));

     
            m.Health = 100 +health_change;
            m.exist = true;
            m.is_hit = false;
            health_rate--;
            if (health_rate < 0)
            {
                Global.Level++;
                health_change += health_change + 10 * Global.Level  ;
                health_rate = 15;
                m.increase_speed();
            }
        }
    }
}
