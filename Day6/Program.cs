using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AoC;

namespace Day6
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = @"C:\Dev\AdventOfCode\Advent-Of-Code-2020\Day6\input.txt";
            var lastLine = File.ReadLines(input).Last();
            var totalLineCount = Helpers.CountLinesInFile(input);
            var lineCount = 0;
            var sr = new StreamReader(input);
            var sr2 = new StreamReader(input);

            string line = string.Empty;

            
            // part 1            
            var answers = new List<string>();

            // build list of group answers
            string indvAnswer = string.Empty;
            while((line = sr.ReadLine()) != null)
            {                
                lineCount++;
                if (Helpers.IsLineEmpty(line))
                {
                    answers.Add(indvAnswer);
                    //Console.WriteLine("groupAnswer: " + indvAnswer);
                    indvAnswer = string.Empty;
                }
                else
                {
                    indvAnswer = indvAnswer + line;

                    if (lineCount == totalLineCount)
                    {
                        answers.Add(indvAnswer);
                        //Console.WriteLine("last groupAnswer: " + indvAnswer);
                    }
                }
            }
                      
            int part1Answer = 0;
            foreach(var answer in answers)
            {
                part1Answer = part1Answer + Helpers.CountUniqueCharacters(answer);
            }
            Console.WriteLine("==========================");
            Console.WriteLine("part1Answer: " + part1Answer);
            Console.WriteLine("==========================");
            
            Console.WriteLine("==========================");
            Console.WriteLine("==========================");


            //-------
            // part 2
            //-------
            int part2Answer = 0;
            line = string.Empty;
            var groups = new List<Group>();

            var groupAnswers = new List<string>();

            while((line = sr2.ReadLine()) != null)
            {                
                lineCount++;
                if (Helpers.IsLineEmpty(line))
                {
                    var group = new Group{ Number = 1, People = new List<Person>() };
                    var personIndex = 0;
                    foreach(var personAnswer in groupAnswers)
                    {
                        var person = new Person{ Number = personIndex, Answers = new List<Answer>()};
                        var allPersonletters = Helpers.BreakStringIntoListOfLetters(personAnswer);
                        var uniquePersonLetters = Helpers.ReturnUniqueListOfStrings(allPersonletters);

                        foreach (var letter in uniquePersonLetters)
                        {
                            var answer = new Answer();
                            answer.Value = letter;
                            person.Answers.Add(answer);
                        }

                        group.People.Add(person);
                        personIndex++;
                    }
                    CalculateGroup(group);
                    groups.Add(group);

                    groupAnswers = new List<string>();
                    Console.WriteLine("--------------------");
                }
                else
                {
                    // add person's answer to list
                    Console.WriteLine("Adding to list: " + line);
                    groupAnswers.Add(line);
                }
            }

            foreach(var group in groups)
            {
                part2Answer = part2Answer + group.YesAnswerCount;
            }
            Console.WriteLine("==========================");
            Console.WriteLine("part2Answer: " + part2Answer);
            Console.WriteLine("==========================");
        }

        private static void CalculateGroup(Group group)
        {
            // get unique answers for whole group
            //   start with first person since collection can only get smaller from there
            group.UniqueAnswers = group.People[0].Answers;
            var uniqueAnswers = new List<Answer>();
            foreach (var answer in group.UniqueAnswers)
            {
                uniqueAnswers.Add(answer);
            }
            foreach (var person in group.People)
            {
                foreach (var answer in group.UniqueAnswers)
                {
                    // remove answers from group's unique collecton if they don't exist in a person's answer collection
                    var IsMatch = false;
                    foreach (var personAnswer in person.Answers)
                    {
                        if (answer.Value == personAnswer.Value)
                        {
                            IsMatch = true;
                        }
                    }

                    if (!IsMatch)
                    {
                        uniqueAnswers.Remove(answer);
                    }
                }
            }

            group.UniqueAnswers = uniqueAnswers;
            group.YesAnswerCount = uniqueAnswers.Count;
            var uniqueAnswerString = ConcatAnswerList(group.UniqueAnswers);
            Console.WriteLine("group.UniqueAnswers: " + uniqueAnswerString);
            Console.WriteLine("group.YesAnswerCount: " + group.YesAnswerCount);
        }

        private static string ConcatAnswerList(List<Answer> list)
        {
            var answers = string.Empty;
            foreach(var ans in list)
            {
                answers = answers + ans.Value;
            }

            return answers;
        }
    }
}
