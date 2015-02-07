using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Picman_Project
{
    class ammo : gift
    {
      public  ammo(Texture2D aaa,int x,int y) :base(aaa,x,y) { 

        }

      public override void Effect(player winner)
      {
          
          winner.mygun.Ammo += 10;  // awesome
          base.update_();
      }

    }
}
