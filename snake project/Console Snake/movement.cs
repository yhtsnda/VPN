﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Console_Snake
{
   
    abstract class movement:eats
    {
        static public bool pause = false;
        protected byte num=1;
        static protected byte[] snakehead = new byte[2];//1=up 2=down 3=left 4= right
        public movement()
        {
            snakehead[0] = 1;
            snakehead[1] = 1;
        }
        protected void head(ConsoleKeyInfo i)
        {
            {
                if (i.Key == ConsoleKey.UpArrow && snakehead[0] != 2&&!pause)
                    snakehead[0]=1;
                else if (i.Key == ConsoleKey.DownArrow && snakehead[0] != 1 && !pause)
                    snakehead[0]=2;
                else if (i.Key == ConsoleKey.LeftArrow && snakehead[0] != 4 && !pause)
                    snakehead[0]=3;
                else if (i.Key == ConsoleKey.RightArrow && snakehead[0] != 3 && !pause)
                    snakehead[0]=4;
                else if (i.Key == ConsoleKey.W && snakehead[1] != 2 && !pause)
                    snakehead[1] = 1;
                else if (i.Key == ConsoleKey.S && snakehead[1] != 1 && !pause)
                    snakehead[1] = 2;
                else if (i.Key == ConsoleKey.A && snakehead[1] != 4 && !pause)
                    snakehead[1] = 3;
                else if (i.Key == ConsoleKey.D && snakehead[1] != 3 && !pause)
                    snakehead[1] = 4;
                else if(i.Key==ConsoleKey.P)
                    pause=!pause;
            }
        }
        
    }
}
