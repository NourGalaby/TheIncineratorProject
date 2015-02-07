using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Picman_Project
{
    class health : gift
    {


   
        
            public health(Texture2D aaa, int x, int y)
                : base(aaa, x, y)
            {

            }

            public override void Effect(player winner)
            {
                winner.Health += 100;  // awesome !!!
                base.update_();

            }

        
    }
}
