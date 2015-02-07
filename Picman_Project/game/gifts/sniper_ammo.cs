using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Picman_Project
{
    class sniper_ammo: gift
    {
        public sniper_ammo(Texture2D aaa, int x, int y)
                : base(aaa, x, y)
            {

            }

            public override void Effect(player winner)
            {
                guns_pool.Mysniper.Ammo += 15;
              base.update_();
            }
    }
}
