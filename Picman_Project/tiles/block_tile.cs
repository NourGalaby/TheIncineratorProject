using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Picman_Project
{
    class block_tile : tile
    {
      
        public block_tile(Texture2D x) : base(x)
        {
            rate = 175000 - 2;
            this.max_rate_value = 175000;
           
        }
  


    }
}
