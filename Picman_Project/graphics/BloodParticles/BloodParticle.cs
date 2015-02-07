using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Picman_Project
{
    public class BloodParticle : Particle
    {
        public BloodParticle(Texture2D texture, Vector2 position, Vector2 velocity,
            float angle, float angularVelocity, Color color, float size, int ttl):base(texture,position,velocity,angle,angularVelocity,color,size,ttl)
        { 
        
        }
    }
}