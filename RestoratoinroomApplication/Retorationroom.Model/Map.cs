using System;
using System.IO;

namespace ApplicationRestorationroom.Retorationroom.model
{
    public class Map
    {
        private char[,] map;
        private int x;
        private int y;

        public Map(int x, int y)
        {
            this.x = x;
            this.y = y;
            map=new char[x,y];
        }

        public char[,] Map1
        {
            get => map;
            set => map = value;
        }

        public int X
        {
            get => x;
            set => x = value;
        }

        public int Y
        {
            get => y;
            set => y = value;
        }

      

        public void DrawMap()
        {
            string filepath = "map.txt";
            

            using (StreamReader file = new StreamReader(filepath))
            {
                string line;

                for (int j = 0; j <= y; j++)
                {
                    line = file.ReadLine();

                    for (int i = 0; i < x; i++)
                    {
                        Console.Write(line[i]);  
                    }

                    Console.Write("\n");
                }


            }


        }
    }
}