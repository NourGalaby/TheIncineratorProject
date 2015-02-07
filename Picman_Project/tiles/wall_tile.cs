using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Picman_Project
{
    class wall_tile : tile
    {
    
          public wall_tile(Texture2D x) : base(x)
        {
            rate = 16999;
            max_rate_value = 17000;
        }
    }
}
