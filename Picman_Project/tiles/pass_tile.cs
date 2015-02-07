using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Picman_Project
{
    class pass_tile : tile
    {
      
           public pass_tile(Texture2D x) : base(x)
        {


            rate = 169990;
            max_rate_value = 170000;
        }


    }
}
