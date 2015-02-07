using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

using Microsoft.Xna.Framework.Graphics;
namespace Picman_Project
{
    class Mazebuilder
    {
       
        int[,] mymaze;

        int width;
        int height;

        int curruntx = 0;
        int currunty = 0;
        tile pass;
        tile wall;
        tile bound;
        tile end;

        
      //  pass_tile pass;

        public Mazebuilder(int[,] themaze,tile pass,tile wall,tile bound,tile end)
        {
            mymaze = themaze;
            width = themaze.GetLength(0);
        height= themaze.GetLength(1);
            this.pass = pass;
            this.wall = wall;
            this.bound = bound;
            this.end = end;
        }

        public void add_gifts(SpriteBatch spritebatch)
        {

            for (int row = 0; row < width; row++)
            {
                for (int col = 0; col < height; col++)
                {

                    if (mymaze[row, col] == -1)
                    {
                        gift T= gift_factory.create_ammo(curruntx+70, currunty+70);
                        T.ArrX = col;
                        T.ArrY = row;

                        Global.gifts.Add(T);
                        curruntx += wall.width;

                    }else
                    if (mymaze[row, col] == -2)
                    {
                        gift T = gift_factory.create_health(curruntx + 70, currunty + 70);
                        T.ArrX = col;
                        T.ArrY = row;

                        Global.gifts.Add(T);
                        curruntx += wall.width;
                    }else
                    if (mymaze[row, col] == -3)
                    {
                        gift T = gift_factory.create_speed(curruntx + 70, currunty + 70);
                        T.ArrX = col;
                        T.ArrY = row;

                        Global.gifts.Add(T);
                        curruntx += wall.width;
                    }else
                        if (mymaze[row, col] == -4)
                        {
                            gift T = gift_factory.create_points(curruntx + 70, currunty + 70);
                            T.ArrX = col;
                            T.ArrY = row;

                            Global.gifts.Add(T);
                            curruntx += wall.width;
                        }
                    if (mymaze[row, col] == -5)
                    {
                        gift T = gift_factory.create_points(curruntx + 70, currunty + 70);
                        T.ArrX = col;
                        T.ArrY = row;

                        Global.gifts.Add(T);
                        curruntx += wall.width;
                    }
                        else {

                            curruntx += wall.width;
                        }
                    

                }
                curruntx = 0;
                currunty += (int)((float)wall.height * Global.scaleY);
            }
            currunty = 0;
            curruntx = 0;
        }

     public   void build_maze(SpriteBatch spritebatch)
        {

            for (int row = 0; row < width; row++)
            {
                for (int col = 0; col < height; col++)
                {

                      if (mymaze[row, col] == 3)
                    {
                        Global.start_point = new Vector2(curruntx, currunty);

                    }
                      

                    if (mymaze[row, col] < 4 )
                    {
                        pass.x_pos=(curruntx);
                        pass.y_pos=(currunty);
                        pass.draw(spritebatch);
                        curruntx +=pass.width;
                    }
                    if (mymaze[row, col] == 9)
                    {
                        bound.y_pos = (currunty);
                        bound.x_pos = (curruntx);
                        bound.draw(spritebatch);
                        curruntx += bound.width;
                    }
                    if (mymaze[row, col] == 5)
                    {
                   
                        wall.x_pos = (curruntx);
                        wall.y_pos = (currunty);
                        wall.draw(spritebatch);
                        curruntx +=wall.width;
                    }
                    if (mymaze[row, col] == 4)
                    {
                        end.x_pos = (curruntx);
                        end.y_pos = (currunty);
                        end.draw(spritebatch);
                        curruntx += pass.width;
                    }

                  
                  
                //    curruntx += (int)((float)wall.width); // INCREASE BASED ON SIZE OF TILE

                    
                }
                curruntx = 0;
                currunty += (int) ((float)wall.height *Global.scaleY);

            }

            currunty = 0;
             curruntx=0;
        }
    }
}
