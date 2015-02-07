using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Picman_Project
{
    class Maze_creator
    {
        int border = 9;
        int wall = 5;
        int free = 0;
        int free2 = 2;
        int start = 3;
        int end = 4;
        Random r = new Random();
        private int[,] maze_array;
        public Maze_creator(int x,int y)
        {
            maze_array = new int[x, y];
            build_maze();
        }

        public int[,] get_maze() {
            return maze_array;
        }


        void build_maze()
        {
            //step1 : borders

            for (int i = 0; i < maze_array.GetLength(0); i++)
            {
               
                maze_array[i, 0] = border;
           
                maze_array[i, maze_array.GetLength(1) - 1] = border;

            }
            for (int i = 0; i < maze_array.GetLength(1); i++)
            {

                maze_array[0, i] = border;
                maze_array[maze_array.GetLength(0) - 1, i] = border;

            }


            //step2: every other line
            Random ABC= new Random();
            for (int i = 2; i < maze_array.GetLength(0) - 1; i+=ABC.Next(2,4))
            {

                for (int col = 1; col < maze_array.GetLength(1) - 1; col++)
                {
                    maze_array[i, col] = wall;
                 //   maze_array[i+1, col] = wall;

                }
            }

            //vertical, each 2
            for (int i = 2; i < maze_array.GetLength(1) - 1; i +=ABC.Next(2,4))
            {
                for (int col = 1; col < maze_array.GetLength(0) - 1; col++)
                {


                    maze_array[col, i] = wall;
                }
            }


            maze_array[maze_array.GetLength(0) / 2, maze_array.GetLength(1) / 2] = free;
            maze_array[(maze_array.GetLength(0) / 2)+1, (maze_array.GetLength(1) / 2)+1] = free;
            maze_array[(maze_array.GetLength(0) / 2) - 1, (maze_array.GetLength(1) / 2) - 1] = free;
            maze_array[(maze_array.GetLength(0) / 2) + 2, (maze_array.GetLength(1) / 2) + 2] = free;
            //step 3: random each space
            Random r = new Random();
            int n = 0;
            for (int row = 0; row < maze_array.GetLength(0); row++)
            {
                for (int col = 0; col < maze_array.GetLength(1); col++)
                {
                    if (maze_array[row, col] == free)
                    {
                        List<int> options = new List<int>();
                        options.Add(0);
                        options.Add(1);
                        options.Add(2);
                        options.Add(3);
                        n = r.Next(0, 4);
                        make_space(row, col, n, options);

                    }
                }

            }

            // step 4 : start randomly
            Random myrandomst = new Random();
            int s = myrandomst.Next(1, maze_array.GetLength(1) - 2);
            //  maze_array[0,0]=s;

            int Ys = myrandomst.Next(1, 6); //start in the first part
            if (maze_array[s,Ys] == 0 || maze_array[s, Ys] == 2)
            {
                maze_array[s, 1] = start;
            }
            else
            {
                maze_array[s + 1, 1] = start;

            }


            Random myrandomen = new Random();
            int e = myrandomst.Next(1, maze_array.GetLength(0) - 1);
          //  maze_array[0, 0] = e;

            bool noEnd = true;

            while (noEnd)
            {
                 int yy = myrandomst.Next(1, maze_array.GetLength(0) - 2);
                 int xx = myrandomst.Next(1, maze_array.GetLength(1) - 2);
                if (maze_array[yy, xx] == 0 || maze_array[yy, xx] == 2)
                {
                    maze_array[yy, xx] = end;
                    noEnd = false;
                }
            }


       



            //step 5 add gifts

            //
            Random myrandomgen = new Random();
            //gifts
            //for (int i = 1; i < maze_array.GetLength(0) * 1.5; i++)
            //{


            //    int x = myrandomgen.Next(2, maze_array.GetLength(0) - 2);
            //    int y = myrandomgen.Next(2, maze_array.GetLength(1) - 2);

            //    if (maze_array[x, y] == 2 || maze_array[x, y] == 0)
            //    {
            //        maze_array[x, y] = myrandomgen.Next(-4, 0);

            //    }

            //}

   


        }

        bool checkoptions(List<int> options)
        {
            if (options.Count > 0)

                return true;
            else
                return false;
        }


        void make_space(int row, int col, int n, List<int> options)
        {

            switch (n)
            {
                case 0:
                    if (maze_array[row + 1, col] == wall)
                    {
                        maze_array[row + 1, col] = free2;
                        break;
                    }
                    else
                    {
                        options.Remove(0);
                        if (options.Count > 0)
                        {// still options exist

                            int N = options[r.Next(0, options.Count)];
                            make_space(row, col, N, options);
                        }
                        else
                        {//no mroe options
                            return;
                        }




                        break;
                    }

                case 1:
                    if (maze_array[row - 1, col] == wall)
                    {
                        maze_array[row - 1, col] = free2;
                        break;
                    }
                    else
                    {
                        options.Remove(1);
                        if (options.Count > 0)
                        {// still options exist

                            int N = options[r.Next(0, options.Count)];
                            make_space(row, col, N, options);
                        }
                        else
                        {//no mroe options
                            return;
                        }


                    }
                    break;

                case 2:
                    if (maze_array[row, col + 1] == wall)
                    {
                        maze_array[row, col + 1] = free2;
                        break;
                    }
                    else
                    {
                        options.Remove(2);
                        if (options.Count > 0)
                        {// still options exist

                            int N = options[r.Next(0, options.Count)];
                            make_space(row, col, N, options);
                        }
                        else
                        {//no mroe options
                            return;
                        }


                    }
                    break;
                case 3:
                    if (maze_array[row, col - 1] == wall)
                    {
                        maze_array[row, col - 1] = free2;
                        break;
                    }
                    else
                    {
                        options.Remove(3);
                        if (options.Count > 0)
                        {// still options exist

                            int N = options[r.Next(0, options.Count)];
                            make_space(row, col, N, options);
                        }
                        else
                        {//no mroe options
                            return;
                        }


                    } break;
                default:
                    break;

            }
            return;
        }


        public string geT_maze()
        {

            StringBuilder x = new StringBuilder(); ;
            x.Append("");

            for (int row = 0; row < maze_array.GetLength(0); row++)
            {
                for (int col = 0; col < maze_array.GetLength(1); col++)
                {
                    //  Console.Write(maze_array[row, col] + " ");
                    x.Append("" + maze_array[row, col]);
                }
                x.AppendLine();
            }



            return x.ToString();
        }


    }
}
