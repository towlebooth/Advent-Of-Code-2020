using System;
using System.Collections.Generic;
using System.IO;

namespace Day5
{
    class Program
    {
        static void Main(string[] args)
        {
            var sr = new StreamReader(@"C:\Dev\AdventOfCode\Advent-Of-Code-2020\Day5\input.txt");
            string line = string.Empty;
            int part1Answer = 0;
            int part2Answer = 0;

            List<int> seatIDs = new List<int>();

            while((line = sr.ReadLine()) != null)
            {
                //Console.WriteLine(line);
                int seatID = 0;
                int row = rowCheck(line.Substring(0, 7));
                int col = colCheck(line.Substring(7, 3));
                seatID = (row * 8) + col;
                seatIDs.Add(seatID);


                foreach(int sID in seatIDs) {
                    if(sID >= part1Answer) 
                        part1Answer = sID;
                    if(seatIDs.Contains(sID+2) && !seatIDs.Contains(sID + 1)) 
                        part2Answer = sID + 1;      
                }

                Console.WriteLine("2020 Day 4");
                Console.WriteLine("=================================");
                Console.WriteLine("Part 1: {0}", part1Answer);
                Console.WriteLine("Part 2: {0}", part2Answer);
                Console.WriteLine("=================================");
            }
        }

        static int rowCheck(string s) {
            int min = 0;
            int max = 127;
            int row = 0;

            foreach(char c in s) {
                switch (c) {
                    case 'F':// lower
                        //min = min;
                        max = (int)Math.Floor((float)(max - min) / 2) + min;
                        row = min;
                        break;
                    case 'B':// upper
                        //max = max;
                        min = (int)Math.Ceiling((float)(max - min) / 2) + min;
                        row = max;
                        break;
                }
            }
            return row;
        }

        static int colCheck(string s) {
            int min = 0;
            int max = 7;
            int col = 0;

            foreach (char c in s) {
                switch (c) {
                    case 'L':// lower
                        min = min;
                        max = (int)Math.Floor((float)(max - min) / 2) + min;
                        col = min;
                        break;
                    case 'R':// upper
                        max = max;
                        min = (int)Math.Ceiling((float)(max - min) / 2) + min;
                        col = max;
                        break;
                }
            }
            return col;
        }
    }
}
