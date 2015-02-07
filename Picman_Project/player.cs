using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Microsoft.Xna.Framework;

using Microsoft.Xna.Framework.Graphics; 


namespace Picman_Project
{
    public class player
    {
        public player(Multi_AnimatedSprite animatedsprite,Texture2D p) {
            PlayerTexture = p;
            player_anim = animatedsprite;

            currunt_tile = new tile();

        
            newPosition = Position;


        }
        
        //Class for main picman 

        // Animation representing the player
        public Multi_AnimatedSprite player_anim; 
        public Texture2D PlayerTexture;




        
        public enum Diriction{
        up,
            down,
            left,
            right,
        }
        Diriction direction;
        // Position of the Player relative to the upper left side of the screen
        //Vector2 is just a variable that holds two values, x,y
        public Vector2 Position;

        public bool alive = true;

        public double speedY;
        public double speedX;
        public double accel_constant=1.5; //acceleration constant
        public double deccelaration=0.8; //deaccelration constant
        public int maxspeed = 6;
        // State of the player
        public bool Active;
        // Amount of hit points that player has
        public int Health=600;
        // Get the width of the picman
        public Vector2 newPosition;
     

        public int array_posX=0;
        public int array_posY=0;

        public gun mygun;
        public int  score=0;

       public void set_gun(gun g) { 
           mygun = g;

       mygun.x_pos = Position.X;
       mygun.y_pos = Position.Y;
       }


        private int update_rate=0;

        pass_tile sample_pass;
        bound_tile sample_bound;
        wall_tile sample_wall;


        tile currunt_tile; //current he is standing on to gain effects from it



        public int Width {
            get { return PlayerTexture.Width/4; }
        }

        // Get height 
        public int Height
        {

            get { return PlayerTexture.Height/4; }

        } 


        public void Initialize()
        {
            //load picman texture and set defualt location/


        }
        private void update_acceleration()
        {

              if ( Global.keydown_pressed) {
                if (speedY < maxspeed)
                {
                    
                    speedY+=accel_constant;
                }
            }
                   if ( Global.keyup_pressed) {
                if (speedY > -maxspeed)
                {
                    speedY-=accel_constant;
                }
            }
                   if ( Global.keyright_pressed) {
                if (speedX < maxspeed)
                {
                    speedX+=accel_constant;
                }
            }

                   if ( Global.keyleft_pressed)
                   {
                       if (speedX> -maxspeed)
                       {
                           speedX -= accel_constant;
                       }

                   }


            
                 if ( speedY != 0)
                   { speedY = deaccelerate(speedY); }
                   if ( speedX != 0)
                   { speedX = deaccelerate(speedX); }
       

        }
        private double deaccelerate(double speed) {
            if (speed < 1 && speed > -1) return 0;
        double sign = -speed/Math.Abs(speed);
          
        return speed + (sign * deccelaration);
        }



        public  Vector2 get_arraypos(Vector2 current){
              Vector2 t = new Vector2((current.X)/ currunt_tile.width,
                  (current.Y) / currunt_tile.height);
              return t;
        }
          void update_arrayPos() { 

            Vector2  t= get_arraypos(newPosition);
            array_posX = Convert.ToInt16( t.X);
            array_posY =Convert.ToInt16( t.Y);

          }



          public void attack() {

      
              mygun.attack(this);

             // player_anim.Update();

             
   
              
              }


  private void update_animation(){
      update_rate = Math.Max(
                 Math.Abs((int)speedX) + update_rate,
                  Math.Abs((int)speedY) + update_rate
         );
            if ( update_rate>maxspeed*3)
            {
                player_anim.Update();//move animation
                update_rate = 1;
            }
   }


        public void Update()
        {
            //update based on game logic and user input

            update_animation();


            if (alive) { update_acceleration(); }
            newPosition.X += (float)speedX;
            newPosition.Y += (float)speedY;

            update_arrayPos();



            check_collision(newPosition);

            //if (!Search_X(newPosition))
            //{
            
            //    Position.X += (float)speedX;
            //}
            //else {
            //    speedX = 0;

            //}
            //if (!Search_Y(newPosition))
            //{

            //    Position.Y += (float)speedY;
            //}
            //else
            //{
            //    Position.Y -= (float) speedY*1.5f;
            //    speedY = 0;
              
            //}

            newPosition.X = Position.X;
            newPosition.Y = Position.Y;
        

         // currunt_tile.
          


             direction_calc();
             mygun.x_pos =  Position.X;
             mygun.y_pos =  Position.Y;
             mygun.direction = this.direction;

             foreach (Abstractmonster m in Global.monsterlist)
             {
                 if(m.exist)
                 if (m.arr_x == array_posX && m.arr_y == array_posY )
                 {

                     speedX/= 1.2;
                     speedY /= 1.2;
                     if (m.isalive())
                     {
                         if (this.alive) //player is alive, to stop it in final scene
                         {
                             Health -= m.attack_damage;

                             m.animate();
                         }
                     }
                 }
             }
             if (Health < 1) {
                 alive = false;
             }

          

         Global. camera.CenterOn(Position);
          //  Global.camera.ScreenToWorld(Position);

        }//end of Update




        void direction_calc() {


            if (speedY > 0)
            {

                direction = Diriction.down;

                player_anim.change_line(0);
            }
            if (speedY < 0)
            {

                direction = Diriction.up;
                player_anim.change_line(3);

            }
            if (speedX < 0)
            {

                direction = Diriction.left;
                player_anim.change_line(1);
            }

            if (speedX > 0)
            {

                direction = Diriction.right;
                player_anim.change_line(2);
            }




        }
        

        void check_collision(Vector2 current){ 
            
            bool Right,Left, Up, Down;

    Right=Check_right( current);
     if (Right==false ){
         Position.X += (float)speedX;
     }
      else {
          speedX = -speedX;
          Position.X += (float)(currunt_tile.rebound * speedX);
 // return true;
     }
      

     Left=Check_left(current);
       if(Left==false){


           Position.X += (float)speedX;
        //  return false;
       }
       else {
           speedX = -speedX;
           Position.X += (float)(currunt_tile.rebound * speedX);
          //return true;
        }
     Down=Check_down( current);
       if(Down==false){
           Position.Y += (float)speedY;
        //  return false;
      }
       else{
           speedY = -speedY;
           Position.Y += (float)(currunt_tile.rebound * speedY);
         // return true;
       }
     Up=Check_up( current);
       if(Up==false){

           Position.Y += (float)speedY;
          //return false;
      }
       else{
           speedY = -speedY;
           Position.Y += (float)(currunt_tile.rebound * speedY);
        //  return true;
       }

}


        bool Check_right(Vector2 current)
        {
            current.X = current.X + Global.playerWidth;
            Vector2 t = get_arraypos(current);
            int indexI = (int)t.Y;
            int indexII = (int)t.X;

            current.Y = current.Y + Global.playerHeight;
            Vector2 t2 = get_arraypos(current);
            int index2Y = (int)t2.Y;
            int index2X = (int)t2.X;

            if (Global.maze_array[indexI, indexII ] > 4 || Global.maze_array[index2Y, index2X] > 4)
                return true;

            else
                return false;
        }

        bool Check_left(Vector2 current)
        {
         

            Vector2 t = get_arraypos(current);
            int indexI = (int)t.Y;
            int indexII = (int)t.X;

            current.Y = current.Y +Global.playerHeight;;
       
            Vector2 t2 = get_arraypos(current);
            int index2Y = (int)t2.Y;
            int index2X = (int)t2.X;

            if (Global.maze_array[indexI, indexII ] > 4 || Global.maze_array[index2Y, index2X ] > 4)
                return true;
            else
                return false;
        }

        bool Check_up(Vector2 current)
        {
       
            Vector2 t = get_arraypos(current);
            int indexI = (int)t.Y;
            int indexII = (int)t.X;


            current.X = current.X + Global.playerWidth;

            Vector2 t2 = get_arraypos(current);
            int index2Y = (int)t2.Y;
            int index2X = (int)t2.X;
            if (Global.maze_array[indexI , indexII] > 4 || Global.maze_array[index2Y , index2X] > 4)
                return true;
            else
                return false;

        }    
        bool Check_down(Vector2 current)
        {
            current.Y = current.Y + Global.playerHeight;
            Vector2 t = get_arraypos(current);
            int indexI = (int)t.Y;
            int indexII = (int)t.X;


            current.X = current.X + Global.playerWidth;
            Vector2 t2 = get_arraypos(current);
            int index2Y = (int)t2.Y;
            int index2X = (int)t2.X;

            if (Global.maze_array[indexI , indexII] > 4 || Global.maze_array[index2Y, index2X] > 4)// point below the most 1 most left point AND most right point
                return true;
            else
                return false;


        }



      void caluclate_currentTile(){
      
          int x=(int) Position.X;
          int y=(int) Position.Y;
        //  if (Global.maze_array[y][x] > 4)
            //  currunt_tile = block_tile;

       
      }
     public void switch_weopon()
      {

          if (mygun.Equals(guns_pool.Myshotgun))
          {
              set_gun(guns_pool.Mysniper);
              return;
          }

          if (mygun.Equals(guns_pool.Mysniper))
          {
              set_gun(guns_pool.Myflamethrower);
              return;
          }

          if (mygun.Equals(guns_pool.Myflamethrower))
          {
              set_gun(guns_pool.Myshotgun);
              return;
          }
      }


      void debug(SpriteBatch spritebatch)
      {
          
         // text_sprite.draw(spritebatch, speedY.ToString());
         // text_sprite.draw(spritebatch, speedX.ToString(), 100, 200);

      //    text_sprite.draw(spritebatch, "newposX= " + newPosition.X.ToString(),160,250);
        //  text_sprite.draw(spritebatch, "newposY= " + newPosition.Y.ToString(), 160, 200);
       

         text_sprite.draw(spritebatch,"X= "+ array_posX.ToString() );
          text_sprite.draw(spritebatch, "Y= " + array_posY.ToString(), 100, 200);

      }


        //draw 
        public void Draw(SpriteBatch spritebatch)
        {
            
            //spritebatch is the canvas I am drawing in
         //   debug(spritebatch);

            mygun.draw(spritebatch);

            text_sprite.draw(spritebatch, "SCORE " + score.ToString(), 50, 10,Color.White,0.5f);
            text_sprite.draw(spritebatch, "Health " + Health.ToString(), 50, 50,
          Color.Pink , 0.5f);

            player_anim.Draw(spritebatch, Position);

            //implement drawing
           /// spriteBatch.Draw(PlayerTexture, Position, null, Color.White, 0f, Vector2.Zero, 1f,

   //  SpriteEffects.None, 0f); 

        }   

    }
}
