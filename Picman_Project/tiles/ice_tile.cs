using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Picman_Project.tiles
{
    class ice_tile : tile
    {

               public ice_tile(Texture2D x) : base(x)
        {
           
        }

               public void tile_effect(player player)
               {
                   //ice tile
                   player.deccelaration = 1;

               }

    }
}
