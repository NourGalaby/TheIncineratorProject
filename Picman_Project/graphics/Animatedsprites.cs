using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Picman_Project
{
    public class AnimatedSprite
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int totalFrames;

        //constructor 
        public AnimatedSprite(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
           totalFrames = Rows * Columns; 

        
        }

        public void Update()
        {
            currentFrame++;
            if (currentFrame == totalFrames)
                currentFrame = 0;

        }
    

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {

            //calculate which part of the sheet to draw 
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
          int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            //source rect is what i want to draw
            //destination rect is where i want to draw it
            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend,
     null, null, null, null, Global.camera.TranslationMatrix);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }


        //override/ with rotation
        public void Draw(SpriteBatch spriteBatch, Vector2 location,float angle,Vector2 origin)
        {

            //calculate which part of the sheet to draw 
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            //source rect is what i want to draw
            //destination rect is where i want to draw it
            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend,
     null, null, null, null, Global.camera.TranslationMatrix);

//            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
       //     spriteBatch.Draw(Texture, destinationRectangle,sourceRectangle , Color.White, angle, origin, new Vector2(Gl Global.depthobal.scaleX, Global.scaleY), SpriteEffects.None, Global.depth);
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White, angle, origin, SpriteEffects.None, Global.depth);
            spriteBatch.End();
        }

    }
}
