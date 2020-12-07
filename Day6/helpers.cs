using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC
{
    public class Helpers
    {
        public static bool IsLineEmpty(string line)
        {
            line = line.Trim();
            if (line == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        public static bool IsOdd(int value)
        {
            return value % 2 != 0;
        }

        public static bool IsEven(int value)
        {
            return value % 2 == 0;
        }

        public static int CountUniqueCharacters(string input)
        {
            return input.Distinct().Count();
        }

        public static int CountLinesInFile(string input){
            return File.ReadLines(input).Count();
        }

        public static bool ListContainsString(List<string> list, string input)
        {
            if (list.Contains(input) == true) {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static List<string> ListofNonMatchingItems(List<string> list1, List<string> list2)
        {
            return list1.Except(list2).ToList();
        }

        public static List<string> ListOfMatchingItems(List<string> list1, List<string> list2)
        {
            var matchingList = list1;
            var nonMatchList = ListofNonMatchingItems(list1, list2);
            foreach(var item in nonMatchList)
            {
                matchingList.Remove(item);
            }

            return matchingList;
        }

        public static string ConcatStringList(List<string> list)
        {
            var fullString = string.Empty;
            foreach(var item in list)
            {
                fullString = fullString + item;
            }
            return fullString;
        }

        public static List<string> BreakStringIntoListOfLetters(string input)
        {
            var list = new List<string>();

            for(int i=0; i<input.Length; i++)
            {
                list.Add(input[i].ToString());
            }
            return list;
        }

        public static List<string> ReturnUniqueListOfStrings(List<string> list)
        {
            return list.Distinct().ToList();
        }
    }
}