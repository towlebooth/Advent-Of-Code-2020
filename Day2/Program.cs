using System;
using System.IO;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            var sr = new StreamReader(@"C:\Dev\AdventOfCode\Advent-Of-Code-2020\Day2\pass.txt");

            string line = string.Empty;
            int part1Correct = 0;
            int part2Correct = 0;

            while((line = sr.ReadLine()) != null)
            {
                // shared
                int iDash = line.IndexOf('-');
                int iSpace = line.IndexOf(' ');
                int iColon = line.IndexOf(':');
                int iSpace2 = line.IndexOf(' ', line.IndexOf(' ') + 1);
                string pass = line.Substring(iSpace2);
                string letter = line.Substring(iSpace + 1, 1);
                int num1 = Int32.Parse(line.Substring(0, iDash));
                
                int num2Length = iSpace - iDash -1;
                int num2 = Int32.Parse(line.Substring(iDash + 1, num2Length)); 

                // part 1
                int count = pass.Split(letter).Length - 1;
                if ((num1 <= count) && (count <= num2))
                {
                    part1Correct++;
                }

                // part 2
                bool isNum1Correct = pass.Substring(num1, 1) == letter;
                bool isNum2Correct = pass.Substring(num2, 1) == letter;

                if (!(isNum1Correct && isNum2Correct))
                {
                    if (isNum1Correct || isNum2Correct)
                    {
                        part2Correct++;
                    }
                }
            }
            Console.WriteLine("part1Correct: " + part1Correct);
            Console.WriteLine("part2Correct: " + part2Correct);
        }
    }
}
