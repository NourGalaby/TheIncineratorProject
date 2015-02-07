#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using System.Threading;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
#endregion




namespace Picman_Project
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    /// 



    public class Game1 : Game
    {

        enum GameState
        {
            StartMenu,
            Loading,
            Playing,
            Paused,
            Victory
        }
        private GameState gameState;
        private Thread backgroundThread;
        private bool isLoading = false;




        MediaLibrary mymedialibrary;
    
  Song[] songs_snd ;
 
  Song intro_snd;
  int current_song = 0;


        private bool start_animation = false;
        //difention of images
    
        private SpriteFont font;

        //maincharchater sprite
        private Multi_AnimatedSprite theman;


         public MonstersPool monsterspool;
        private int win_wait = 0;
        private int end_anime = 100;
        private bool onEnd = false;

        Random R = new Random();

        private int monsterload = 0;
        private int gift_load =600;
        Texture2D red_texture;


        bool intro_play = false;
        Texture2D background;

        ParticleEngine particleEngine;
        BloodEngine bloodengine;
        GraphicsDeviceManager graphics;
        //main canvas
        SpriteBatch spriteBatch;
        player mypicman;

        int gift_freq = 3;

     //   Vector2 start_point;
       // Vector2 en
        private KeyboardState oldState;
        //to use in maze builder
       
          tile block2;

          tile pass;
          tile wall;
          tile bound;
          tile end;
//sounds
          



          Mazebuilder mazebuilder;

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = Global.screen_sizeX;
         
          graphics.PreferredBackBufferHeight = Global.screen_sizeY;  
            graphics.IsFullScreen = true;
            graphics.ApplyChanges();
          

            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Global.camera.ViewportWidth = graphics.GraphicsDevice.Viewport.Width;
            Global.camera.ViewportHeight = graphics.GraphicsDevice.Viewport.Height;


            IsMouseVisible = true;

            gameState = GameState.StartMenu;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here


            SoundEffect sniper_snd = Content.Load<SoundEffect>("SoundFX/sniper1");

             background = Content.Load<Texture2D>("startscreen1");

             intro_snd = Content.Load<Song>("Music/POL-sad-story-short");
            

            font = Content.Load<SpriteFont>("myfonts");
            text_sprite.init(font);
            Thread.Sleep(20);
        }

        void build_maze() {

            Random maze_random_size = new Random();

            Maze_creator maze_creator = new Maze_creator(maze_random_size.Next(16, 30), maze_random_size.Next(14, 20));
            Global.maze_array = maze_creator.get_maze();
            //int[,] aaa = {
            //              {9, 9, 9, 9, 0, 0, 0, 0, 0, 9, 9, 9, 9, 9, 9, 9, 9, 9, 0, 0, 0},    
            //              {0, 0, 0, 0, 0, 0, 0, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},     
            //              {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},     
            //              {0, 0, 0, 5, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},    
            //              {0, 0, 0, 5, 0, 5,-1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},    
            //              {0, 0, 0,5, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},     
            //              {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0},    
            //              {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0},     
            //              {0, 0, 0, 0, -1, 0, 0, 0, 0, 0, 5, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0},     
            //              {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0},
            //              {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            //              {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            //              {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            //              {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            //              {0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0 ,0, 0, 0, 0},
            //              {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            //              {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            //              {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            //              {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            //              {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            //              {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
            //          };

      //      Global.maze_array = (int[,])aaa.Clone();
         Global.maze_array = maze_creator.get_maze();
         
        

            //gifts


            mazebuilder = new Mazebuilder(Global.maze_array, pass, wall, bound,end);
          

        }
        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        /// 
    

       void LoadGame(){
            
        
            // Create a new SpriteBatch, which can be used to draw textures.
          //  spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here


         //   background = Content.Load<Texture2D>("stars");
           //  shuttle = Content.Load<Texture2D>("shuttle");
           // Texture2D theman_texture = Content.Load<Texture2D>("SmileyWalk");
            Texture2D theman_texture = Content.Load<Texture2D>("player2");


            Texture2D shotgun_texture = Content.Load<Texture2D>("shotgun");
            Texture2D shotgun_fire_texture = Content.Load<Texture2D>("shotex");
            Texture2D Sniper_icon = Content.Load<Texture2D>("sniper");
            Texture2D flameico = Content.Load<Texture2D>("flamethrower");

                 //particles for flame
          List<Texture2D> textures = new List<Texture2D>();
          textures.Add(Content.Load<Texture2D>("particle1"));
          textures.Add(Content.Load<Texture2D>("particle22"));
                 textures.Add(Content.Load<Texture2D>("particle3"));
                 Thread.Sleep(10);
           


           //gun sounds
                 SoundEffect sniper_snd = Content.Load<SoundEffect>("SoundFX/sniper1");
                 SoundEffect shotgun_snd = Content.Load<SoundEffect>("SoundFX/shotgun1");
                 SoundEffect flamestart_snd = Content.Load<SoundEffect>("SoundFX/flame_start");
                 SoundEffect flamesloop_snd = Content.Load<SoundEffect>("SoundFX/flame_loop");

            guns_pool.make_guns(shotgun_fire_texture, shotgun_texture, Sniper_icon, flameico,textures,shotgun_snd,sniper_snd,flamestart_snd,flamesloop_snd);

            //particles for Blood
            List<Texture2D> Bloodtextures = new List<Texture2D>();
            Bloodtextures.Add(Content.Load<Texture2D>("particle1"));
            Bloodtextures.Add(Content.Load<Texture2D>("particle2"));
            Bloodtextures.Add(Content.Load<Texture2D>("particle3"));
            Thread.Sleep(10);
            bloodengine = new BloodEngine(Bloodtextures, new Vector2(50, 50));


           


            theman = new Multi_AnimatedSprite(theman_texture, 4, 4);
            //create instance of player
            mypicman = new player(theman, theman_texture);

            //give gun to my player :default first gun
            mypicman.set_gun(guns_pool.Myflamethrower);

            font = Content.Load<SpriteFont>("myfonts");
            text_sprite.init(font);



       Song s1=    Content.Load<Song>("Music/Full Onmp3");
       Song s2 = Content.Load<Song>("Music/POL-against-the-system-short");
       Song s3 = Content.Load<Song>("Music/POL-last-samurai-short");
       Song s4 = Content.Load<Song>("Music/POL-lost-hero-short");

           songs_snd=  new Song[] {s1,s2,s3,s4};

           Texture2D brick_texture = Content.Load<Texture2D>("brick");
           Texture2D wall_texture = Content.Load<Texture2D>("wall2");
           Texture2D pass_texture = Content.Load<Texture2D>("pass2dark");
           Texture2D bound_texture = Content.Load<Texture2D>("bound2");
           Texture2D end_texture = Content.Load<Texture2D>("end");
          block2 = new block_tile(brick_texture);

          pass = new pass_tile(pass_texture);
          wall = new wall_tile(wall_texture);
          bound = new bound_tile(bound_texture);
          end = new pass_tile(end_texture);

           red_texture = Content.Load<Texture2D>("redmonster");

          //Global.monsters.Add(new demon(red_texture, 1260, 1260,bloodengine));
          //Global.monsters.Add(new demon(red_texture, 500, 600,bloodengine));
          //Global.monsters.Add(new demon(red_texture, 100, 1260,bloodengine));
          //Global.monsters.Add(new demon(red_texture, 1200, 300,bloodengine));

           //monsters pool
          
         monsterspool = new MonstersPool(red_texture ,bloodengine);
         
           //particles
    //   List<Texture2D> textures1 = new List<Texture2D>();
      //  textures1.Add(Content.Load<Texture2D>("particle1"));
      // textures.Add(Content.Load<Texture2D>("star"));
        //  textures.Add(Content.Load<Texture2D>("diamond"));
      //    particleEngine = new ParticleEngine(textures1, new Vector2(400, 240));



          Texture2D points_texture = Content.Load<Texture2D>("box_pink");
          Texture2D health_texture = Content.Load<Texture2D>("box_green");
          Texture2D ammo_texture = Content.Load<Texture2D>("box_grey");
          Texture2D speed_texture = Content.Load<Texture2D>("box_yellow");

          Texture2D shotgunAmmotxt = Content.Load<Texture2D>("AMMO11");
          Texture2D sniperAmmotxt = Content.Load<Texture2D>("AMMO22");

          gift_factory giftfactory = new gift_factory(ammo_texture, health_texture, points_texture,speed_texture,sniperAmmotxt,shotgunAmmotxt);
          
  build_maze();
         
mazebuilder.add_gifts(spriteBatch);

Thread.Sleep(250);

mypicman.Position = Global.start_point;
gameState = GameState.Playing;
isLoading = false;



        }
        void initialise_game(){
            
         //   Global.monsterlist.Clear(); pool lol
            intro_play = false;
            //MediaPlayer.Stop();

            Global.gifts.Clear();
            Global.Level = 0;
            start_animation = false;
            current_song++;
            MonstersPool.reset_health();
            Abstractmonster.reset_speed();


            
        }
  
        protected override void Update(GameTime gameTime)
        {

            if (gameState == GameState.Loading && !isLoading) //isLoading bool is to prevent the LoadGame method from being called 60 times a seconds
            {
                //set backgroundthread
                backgroundThread = new Thread(LoadGame);
                isLoading = true;

                //start backgroundthread
                backgroundThread.Start();
            }



            //startMenu State 
            //**********************************************************************
            //**********************************************************************
            if (gameState == GameState.StartMenu)
            {

                if (!intro_play)
                {
                   MediaPlayer.IsRepeating = true;

                //   MediaPlayer.Play(intro_snd);
                    intro_play = true;
                }

             
                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    MediaPlayer.Stop();
                   
                    initialise_game();
                    gameState = GameState.Loading;

                }

                
            }

            //Loading State 
            //**********************************************************************
            //**********************************************************************
            if (gameState == GameState.Playing && isLoading)
            {
               
                LoadGame();
                isLoading = false;
            }


            //Playing State 
            //**********************************************************************
            //**********************************************************************

            if (gameState == GameState.Playing)
            {
               
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                    Exit();
                // TODO: Add your update logic here

                UpdateKeys();

             if(!intro_play){
                 
        
           //current_song++;
                 // MediaPlayer.IsRepeating = true;
            //     int a = current_song%songs_snd.Length;
            //     if (current_song > 3) current_song = 0;
                 MediaPlayer.Stop();
           
                   MediaPlayer.Play(songs_snd[0]);
                 
                   intro_play = true;
            }
   
        
                //for particles
               // particleEngine.EmitterLocation = mypicman.Position;
              //  particleEngine.Update();

                if (!start_animation)
                {
                    if (Global.camera.Zoom > 0.5f)
                    {
                        Global.camera.AdjustZoom(-0.025f);
                    }
                    else
                        start_animation = true;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.W))
                {
                    //Global.scaleX += 0.01f;
                    //Global.scaleY += 0.01f;
                    Global.camera.AdjustZoom(0.01f);
                }
                if (Keyboard.GetState().IsKeyDown(Keys.S))
                {
                    //Global.scaleX -= 0.05f;
                    //Global.scaleY -= 0.05f;
                    Global.camera.AdjustZoom(-0.01f);
                }


                if (Keyboard.GetState().IsKeyDown(Keys.Space) && oldState.IsKeyUp(Keys.Space))
                {

                    mypicman.attack();


                }

                //hold and fire
                if (mypicman.mygun.Equals(guns_pool.Myflamethrower))
                {
                    if (Keyboard.GetState().IsKeyDown(Keys.Space))
                    {
                        mypicman.attack();
                    }
                }



                if (Keyboard.GetState().IsKeyDown(Keys.LeftControl) && oldState.IsKeyUp(Keys.LeftControl))
                {

                    mypicman.switch_weopon();
                }






              

                //    Global.camera.HandleInput();




                mypicman.Update();
                mypicman.mygun.update(mypicman);

                check_gifts();
            
                    Global.gifts.RemoveAll(isGiftOpen);
                        
                

                onEnd = check_end();
                if (onEnd)
                {
                  

                    win_wait++;
                    if (win_wait> 100)
                    gameState = GameState.Victory ;
                }
                else { win_wait = 0; }


                if (Keyboard.GetState().IsKeyDown(Keys.P) && oldState.IsKeyUp(Keys.P))
                {
                    gameState = GameState.Paused;

                }

                if (gameState == GameState.Victory)
                {

                    if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                    {
                        gameState = GameState.StartMenu;

                    }

                }

                foreach (Abstractmonster m in Global.monsterlist)
                {
                  
                        m.update(mypicman);
                }

                if (!mypicman.alive)
                {
                    if (end_anime < 0)
                    {
                        Global.camera.AdjustZoom(-1f);
                        gameState = GameState.Victory;
                        end_anime = 90;
                        MediaPlayer.Stop();
                    }
                    end_anime--;

                    Global.camera.AdjustZoom(0.05f);
                }

                monsterload++;
                if (monsterload > 200)
                {
                  
                  //  Global.monsters.Add(new demon(red_texture, R.Next(240,(Global.maze_array.GetLength(0)-3)*240), R.Next(240,(Global.maze_array.GetLength(1)-3)*240),bloodengine));
                    monsterspool.resurrect();

                    monsterload = 0;
                }
                gift_load--;
                for (int i = 0; i < gift_freq; i++)
                {
                    //gift_freq is int.. = 3, added 3 times to make sure we put, because if wall no put.
                    add_gifts();
                }

                base.Update(gameTime);




            }
            // end of normal playing state
            // 
            //**********************************************************************
            //**********************************************************************



            if (Keyboard.GetState().IsKeyDown(Keys.P) && oldState.IsKeyUp(Keys.P))
            {
                gameState = GameState.Playing;
                
            }

            oldState = Keyboard.GetState();
        }
        //END OF UPDATE  
        //**********************************************************************
        //**********************************************************************


        bool isGiftOpen(gift g)
        {
            return g.open;
        }

        void add_gifts()
        {
            if (gift_load < 0)
            {
                int x = (R.Next(0, (Global.maze_array.GetLength(1) - 3)))  *Global.tile_width;
                int y = (R.Next(0,(Global.maze_array.GetLength(0) - 3) ))* Global.tile_width; // HIEGHT
                x += 75;
                y += 75;
                int x_arr = x / Global.tile_width;
                int y_arr = y / Global.tile_width;
                if (Global.maze_array[y_arr, x_arr] == 2 || Global.maze_array[y_arr, x_arr] == 0)
                {
                    gift temp = gift_factory.create_randomgift(x, y);
                    temp.ArrX = x_arr;
                    temp.ArrY = y_arr;
                    Global.gifts.Add(temp);
                   
                }
                gift_load = 500;
            }
        }


        bool check_end()
        {
            int x = mypicman.array_posX;
            int y = mypicman.array_posY;

            if (Global.maze_array[y, x] == 4)
            {


                return true;
            }
            return false;
        }

        void check_gifts()
        {

            int x = mypicman.array_posX;
            int y = mypicman.array_posY;


            foreach (gift g in Global.gifts)
            {

                if (x == g.ArrX && y == g.ArrY && g.open==false)
                {
                    g.Effect(mypicman);
                    
                    
                }
            }


     
        }


        private void UpdateKeys()
        {

            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                Global.keydown_pressed = true;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                Global.keyup_pressed = true;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                Global.keyright_pressed = true;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.Up))
            {
                Global.keyup_pressed = false;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.Down))
            {
                Global.keydown_pressed = false;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.Right))
            {
                Global.keyright_pressed = false;
            }


            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                Global.keyleft_pressed = true;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.Left))
            {
                Global.keyleft_pressed = false;
            }

        }


        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray); 
  
             if (gameState == GameState.StartMenu)
            {
              // text_sprite.draw(spriteBatch, "PRESS ENTER TO START" ,50,200);
                spriteBatch.Begin();
                spriteBatch.Draw(background, new Rectangle(0,0,1366,768), Color.White);
                spriteBatch.End();
            }
             if (gameState == GameState.Victory)
             {
                 if (mypicman.alive)
                 {
                  //   mypicman.score = mypicman.score * 100000 / (int) gameTime.TotalGameTime.TotalSeconds;
                     text_sprite.draw(spriteBatch, "You reached Level" + Global.Level.ToString(), 200, 200);
                     text_sprite.draw(spriteBatch, "SCORE:" + mypicman.score.ToString(), 200, 400,Color.White,1);
                 }

                 else
                 {
                  //   mypicman.score = mypicman.score * 100000 / (int)gameTime.TotalGameTime.TotalSeconds;
                     text_sprite.draw(spriteBatch, "YOU DIED!!!", 100, 100);
                     text_sprite.draw(spriteBatch, "You reached Level " + Global.Level.ToString(), 100, 200);
                     text_sprite.draw(spriteBatch, "SCORE:" + (mypicman.score).ToString(), 100, 300);
                       text_sprite.draw(spriteBatch, "Press Enter to play again", 100, 600);

                 }
                 if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                 {

                     gameState = GameState.StartMenu;
                 }

             }
                if (gameState == GameState.Loading)
            {
               // spriteBatch.Draw(loadingScreen, new Vector2((GraphicsDevice.Viewport.Width / 2) - (loadingScreen.Width / 2), (GraphicsDevice.Viewport.Height / 2) - (loadingScreen.Height / 2)), Color.YellowGreen);
   text_sprite.draw(spriteBatch, "LOADING" ,10,10,Color.White,0.5f);
            }

              if (gameState == GameState.Playing)
            {
            
            
            mazebuilder.build_maze(spriteBatch);


            foreach (gift g in Global.gifts) {
             g.draw(spriteBatch);  
            }

            foreach (Abstractmonster m in Global.monsterlist)
            {
                if(m.exist)
                m.draw(spriteBatch);
            }
         //   text_sprite.draw(spriteBatch, "count= " + Global.gifts.Count.ToString(),600,300);
      //   theman.Draw(spriteBatch, new Vector2(400, 200));
            mypicman.Draw(spriteBatch);
        

            if (onEnd)
            {
                text_sprite.draw(spriteBatch, "Had enough? !!!!!!!!!", 250, 400,Color.DarkRed,1f);

            }

            if (!mypicman.alive)
            {
                text_sprite.draw(spriteBatch, "GAME OVER", 400, 300, Color.DarkRed, 3f);
            }

            text_sprite.draw(spriteBatch, "GIFTS: " + Global.gifts.Count.ToString(), 400, 50, Color.White, 0.5f);

         //   particleEngine.Draw(spriteBatch);

            text_sprite.draw(spriteBatch, "LEVEL:"+ Global.Level.ToString(), 400, 10,Color.White,0.5f);

           // debug.draw(spriteBatch);

              }//end of playing state*************************



               if (gameState == GameState.Paused)
            {
                  text_sprite.draw(spriteBatch, "PAUSED" ,200,200);
            }

            base.Draw(gameTime);
        }
    }
}
