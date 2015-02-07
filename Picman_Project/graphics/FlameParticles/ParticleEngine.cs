using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Picman_Project
{
    public class ParticleEngine
    {

        private Random random;
        public Vector2 EmitterLocation { get; set; }
        private List<Particle> particles;
        private List<Texture2D> textures;
        private int pool_size = 500;
        public ParticleEngine(List<Texture2D> textures, Vector2 location)
        {
            EmitterLocation = location;
            this.textures = textures;
            this.particles = new List<Particle>();
            random = new Random();

            //make pool
            for (int i = 0; i < pool_size; i++)
            {
                particles.Add(GenerateNewParticle());

            }
        }


        public void add(int total, Vector2 velocity)
        {
            //add number 'total' new particles
            foreach (Particle p in particles)
            {
                if (!p.alive)
                {
                    total--;
                    p.Velocity = velocity;
                    init_particle(p);

                }
                if (total < 0) break;
            }

        }

        private void init_particle(Particle p)
        {


            p.Position = EmitterLocation;
            p.Deaccler = 0.5f * p.Velocity;
            p.TTL = 20 + random.Next(40);
            p.alive = true;


        }




        public void Update()
        {




            for (int p = 0; p < particles.Count; p++)
            {
                particles[p].Update();

                if (particles[p].TTL <= 0)
                {
                    particles[p].alive = false;

                }
            }
        }

        private Particle GenerateNewParticle()
        {
            Texture2D texture = textures[random.Next(textures.Count)];
            Vector2 position = EmitterLocation;
            //velocity = new Vector2(
            //                       1f * (float)(random.NextDouble() * energy - 1),
            //                       1f * (float)(random.NextDouble() * energy - 1)); //x20

            Vector2 velocity = new Vector2(0, 0);
            float angle = 0;
            //float angularVelocity = 0.1f * (float)(random.NextDouble() * 2 - 1);
            float angularVelocity = 0;
            Color color = Color.White;
            //Color color = new Color(
            //            0.2f,
            //           0.2f,
            //            (float)random.NextDouble());

            float size = (float)random.NextDouble() * 2; //3x size
            //int ttl = 20 + random.Next(40);
            //float size = 1;
            int ttl = 300;

            return new Particle(texture, position, velocity, angle, angularVelocity, color, size, ttl);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // spriteBatch.Begin();
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.Additive,
null, null, null, null, Global.camera.TranslationMatrix);
            foreach (Particle p in particles)
            {
                if (p.alive)
                {
                    p.Draw(spriteBatch);
                }
            }
            spriteBatch.DrawString(text_sprite.font, particles.Capacity.ToString(), new Vector2(250, 120), Color.White);
            spriteBatch.End();
            //  text_sprite.draw(spriteBatch, particles.Capacity.ToString(),300,100);
        }
    }
}