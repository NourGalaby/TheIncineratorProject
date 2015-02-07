using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Picman_Project
{
    class shotgunAmmo : gift
    {
        public shotgunAmmo(Texture2D aaa, int x, int y)
            : base(aaa, x, y)
        {

        }

        public override void Effect(player winner)
        {
            guns_pool.Myshotgun.Ammo += 15;
            base.update_();
        }
    }
}
