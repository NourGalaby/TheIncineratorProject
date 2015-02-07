using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Picman_Project
{
    public class Multi_AnimatedSprite
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int totalFrames;
        private int Line=1;
       
        //constructor 
        public Multi_AnimatedSprite(Texture2D texture, int rows, int columns ) 
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
           // totalFrames = Rows * Columns; // old for squaure 
         
            totalFrames = Columns;
        }

        public void Update()
        {
            currentFrame++;
            if (currentFrame == totalFrames)
                currentFrame = 0;

        }
        public void change_line(int n)
        {

            Line = n;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {

            //calculate which part of the sheet to draw 
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
           // int row = (int)((float)currentFrame / (float)Columns);
           int column = currentFrame % Columns;
            int row = Line;
            //source rect is what i want to draw
            //destination rect is where i want to draw it
            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend,
     null, null, null, null, Global.camera.TranslationMatrix);
   
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();  
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location,Color tint)
        {

            //calculate which part of the sheet to draw 
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            // int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;
            int row = Line;
            //source rect is what i want to draw
            //destination rect is where i want to draw it
            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend,
     null, null, null, null, Global.camera.TranslationMatrix);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, tint);
            spriteBatch.End();
        }

    }
}
