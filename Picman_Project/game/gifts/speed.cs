using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Picman_Project
{
    class speed : gift
    {
            public speed(Texture2D aaa, int x, int y)
                : base(aaa, x, y)
            {

            }

            public override void Effect(player winner)
            {
                winner.maxspeed+= 1; // awesome    
                base.update_();
            }
    }
}
