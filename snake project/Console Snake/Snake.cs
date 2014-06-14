﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Console_Snake
{
    class Snake:movement
    {
        static private void checkfood(int x, int y)
        {
            if (x == foodloc[0] && y == foodloc[1])
            {
                eat = true;
                foodavail = false;
            }
        }
        static bool aborting = false;
        static public Thread t1,t3;
        public Thread t2;
        public List<int[]> point;
        static protected bool[,] screen=new bool[80,26];
        public Snake(int x=2,int y=2,byte nomor=1,ConsoleColor color=ConsoleColor.Cyan)
        {
            num = nomor;
            int tailx =x;
            int taily =y+2;
            point = new List<int[]>();
            for (int i = taily; i > y; i--)
            {
                int[] xy1 = { tailx, i };
                point.Add(xy1);
                screen[tailx, i] = true;
            }/*
            int[] xy1 = { tailx, 7 };
            point.Add(xy1);
            int[] xy4 = { tailx, 6 };
            point.Add(xy4);
            int[] xy5 = { tailx, 5 };
            point.Add(xy5);
            int[] xy6 = { tailx, taily };
            point.Add(xy6);
            int[] xy2 = { 2, 3 };
            point.Add(xy2);*/
            Console.ForegroundColor = color; 
            Console.SetCursorPosition(x, y);
            Console.Write((char)2);  
            for (int i = 0; i < point.LongCount(); i++)
            {
                int tx, ty;
                tx = point[i][0];
                ty = point[i][1];
                Console.SetCursorPosition(tx, ty);
                Console.ForegroundColor = color; 
                Console.Write((char)2);
            }
            t2 = new Thread(new ThreadStart(delegate
            {
            while (true)
            {
                Console.SetCursorPosition(x,y);
                Console.ForegroundColor = color;
                Console.Write((char)2);
                int[] tmp1 = { x, y };
                if (screen[x, y] == true)
                {
                    aborting = true;
                    Thread.CurrentThread.Abort();
                }
                if(aborting)
                    Thread.CurrentThread.Abort();
                point.Add(tmp1);
                screen[x, y] = true;
                Thread.Sleep(100);
                checkfood(x, y);
                if (!foodavail)
                {
                    makanan(screen);
                    foodavail = true;
                }
                if (!eat)
                {
                    Console.SetCursorPosition(point[0][0], point[0][1]);
                    screen[point[0][0], point[0][1]] = false;
                    Console.Write(' ');
                    point.RemoveAt(0);
                }
                else
                {
                    if (point[point.Count - 1][0] == x && point[point.Count - 1][1] == y)
                        eat = false;
                    else
                    {
                        Console.SetCursorPosition(point[0][0], point[0][1]);
                        screen[point[0][0], point[0][1]] = false;
                        Console.Write(' ');
                        point.RemoveAt(0);
                    }
                }
                if (snakehead[nomor-1] == 1)
                {
                    if (y > 0)
                    {
                        y--;
                    }
                    else
                    {
                        y += 24;
                    }
                }
                else if (snakehead[nomor-1] == 2)
                {
                    if (y<25)
                    {
                        y++;
                    }
                    else
                    {
                        y = 0;
                    }
                }
                else if (snakehead[nomor-1] == 3)
                {
                    if (x > 0)
                    {
                        x--;
                    }
                    else
                    {
                        x += 79;
                    }
                }
                else if (snakehead[nomor-1] == 4)
                {
                    if (x < 79)
                    {
                        x++;
                    }
                    else
                    {
                        x = 0;
                    }
                }
            }
            }));
            t1 = new Thread(new ThreadStart(delegate
            {
                while (t2.IsAlive)
                {
                    head(Console.ReadKey(true));
                    //Thread.Sleep(50);

                }
            }));
            //t2.Start();
            t3 = new Thread(new ThreadStart(delegate
            {
                while (true)
                {
                    
                }
            }));
            //t1.Start();
        }
    }
}