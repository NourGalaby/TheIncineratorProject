using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Picman_Project
{
    class Global
    {



        static public int Level = 0;

        static public bool keydown_pressed = false;
        static public bool keyup_pressed = false;
        static public bool keyright_pressed = false;
        static public bool keyleft_pressed = false;
        static public List<Abstractmonster> monsterlist;
      
        static public int[,] maze_array;

        static public List<gift> gifts = new List<gift>();

        static public float volume = 0.1f; 

        static public int screen_sizeX = 1366;
        static public int screen_sizeY = 768;

       

        public static float scaleX = 1.0f;
        public static float scaleY = 1.0f;
        public static int tile_width = 240;

        public static int playerHeight = 150;
        public static int playerWidth =80;




        public static Vector2 start_point = new Vector2(270,270);
      static public  Camera  camera = new Camera();
        public static int  sizeX= 30;
        public static int  sizeY = 40;

        public static float depth=0.5f;


        

    }
}
