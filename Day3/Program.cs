using System;
using System.IO;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            var sr = new StreamReader(@"C:\Dev\AdventOfCode\Advent-Of-Code-2020\Day3\input.txt");

            string line = string.Empty;
            int lineNumber = 1;
            int index = 0;
            int part1Answer = 0;
            int part2Answer = 0;

            while((line = sr.ReadLine()) != null)
            {
                var longLine = line + line + line + line + line + line + line + line + line + line + line + line + 
                line + line + line + line + line + line + line + line + line + line + line + line + line + line + 
                line + line + line + line + line + line + line + line + line + line + line + line + line + line + 
                line + line + line + line + line + line + line + line + line + line + line + line + line + line + 
                line + line + line + line + line + line + line + line + line + line + line + line + line + line + 
                line + line + line + line + line + line + line + line + line + line + line + line + line + line + 
                line + line + line + line + line + line + line + line + line + line + line + line + line + line + 
                line + line + line + line + line + line + line + line + line + line + line + line + line + line + 
                line + line + line + line + line + line + line;
                

                if (lineNumber != 1)
                if (IsOdd(lineNumber))
                {
                    {
                        index = index + 1;
                        if (longLine.Length >= index)
                        {
                            string square = longLine.Substring(index, 1);
                            Console.WriteLine("square at line " + lineNumber + ", index " + index + ": " + square);
                            if (square == "#")
                            {
                                part1Answer++;
                            }
                        } else {
                            Console.WriteLine("Out of squares at: " + line);
                        }
                    }
                }
                lineNumber++;
                
                //Console.WriteLine(line);
                
            }
            Console.WriteLine("part1Answer: " + part1Answer);
            //Console.WriteLine("part2Answer: " + part2Answer);

            // part 2 final answer:
            // 58 x 223 x 105 x 74 x 35 =
            // 3517401300
        }

        public static bool IsOdd(int value)
        {
            return value % 2 != 0;
        }

        public static bool IsEven(int value)
        {
            return value % 2 == 0;
        }
    }
}
