using System;
using System.IO;
using System.Linq;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {   
           var sr = new StreamReader(@"C:\Dev\AdventOfCode\Advent-Of-Code-2020\Day4\input.txt");

            string line = string.Empty;
            //int lineNumber = 1;
            //int index = 0;
            int part1Answer = 0;
            string passport = string.Empty;

            var lastLine = "iyr:2011 ecl:brn hgt:59in";
            //Console.WriteLine("lastLine: " + lastLine);

            while((line = sr.ReadLine()) != null)
            {
                if (IsLineEmpty(line))
                {
                    // last line of passport
                    passport = passport + " " + line;
                    //Console.WriteLine("Full Passport: " + passport);

                    if (IsPassportComplete(passport))
                    {
                        Console.WriteLine("Full Passport: " + passport + " VALID");
                        part1Answer++;
                    } else {
                        Console.WriteLine("Full Passport: " + passport + " INVALID");
                    }
                    passport = string.Empty;
                } else {
                    passport = passport + " " + line;
                    if (line == lastLine)
                    {
                        Console.WriteLine("LAST LINE");
                        if (IsPassportComplete(passport))
                        {
                            Console.WriteLine("Full Passport: " + passport + " VALID");
                            part1Answer++;
                        }
                    }
                }
            }

            Console.WriteLine("part1Answer: " + part1Answer);
        }

        public static bool IsPassportComplete(string passport)
        { 
            // ecl:gry pid:860033327 eyr:2020 hcl:#fffffd byr:1937 iyr:2017 cid:147 hgt:183cm

            string byr = string.Empty;
            int ibyr = passport.IndexOf("byr:") + 4;
            var ibyrSpace = passport.IndexOf(" ", ibyr);
            byr = passport.Substring(ibyr, ibyrSpace - ibyr);
            //Console.WriteLine("byr: " + byr);

            string iyr = string.Empty;
            int iiyr = passport.IndexOf("iyr:") + 4;
            var iiyrSpace = passport.IndexOf(" ", iiyr);
            iyr = passport.Substring(iiyr, iiyrSpace - iiyr);
            //Console.WriteLine("iyr: " + iyr);

            string eyr = string.Empty;
            int ieyr = passport.IndexOf("eyr:") + 4;
            var ieyrSpace = passport.IndexOf(" ", ieyr);
            eyr = passport.Substring(ieyr, ieyrSpace - ieyr);
            //Console.WriteLine("eyr: " + eyr);

            string hgt = string.Empty;
            int ihgt = passport.IndexOf("hgt:") + 4;
            var ihgtSpace = passport.IndexOf(" ", ihgt);
            hgt = passport.Substring(ihgt, ihgtSpace - ihgt);
            //Console.WriteLine("hgt: " + hgt);

            string hcl = string.Empty;
            int ihcl = passport.IndexOf("hcl:") + 4;
            var ihclSpace = passport.IndexOf(" ", ihcl);
            hcl = passport.Substring(ihcl, ihclSpace - ihcl);
            //Console.WriteLine("hcl: " + hcl);

            string ecl = string.Empty;
            int iecl = passport.IndexOf("ecl:") + 4;
            var ieclSpace = passport.IndexOf(" ", iecl);
            ecl = passport.Substring(iecl, ieclSpace - iecl);
            //Console.WriteLine("ecl: " + ecl);

            string pid = string.Empty;
            int ipid = passport.IndexOf("pid:") + 4;
            var ipidSpace = passport.IndexOf(" ", ipid);
            pid = passport.Substring(ipid, ipidSpace - ipid);
            //Console.WriteLine("pid: " + pid);

            if (passport.Contains("byr:") &&
                passport.Contains("iyr:") &&
                passport.Contains("eyr:") &&
                passport.Contains("hgt:") &&
                passport.Contains("hcl:") &&
                passport.Contains("ecl:") &&
                passport.Contains("pid:"))
                {
                    if (IsbyrValid(byr) &&
                        IsiyrValid(iyr) &&
                        IseyrValid(eyr) &&
                        IshgtValid(hgt) &&
                        IshclValid(hcl) &&
                        IseclValid(ecl) &&
                        IspidValid(pid))
                    {
                        return true;
                    }
                }

            return false;
        }

        public static bool IsPassportComplete2(string passport)
        { 
            // not used -- doesn't return proper number of valid responses.
            bool isValid = false;
            string[] passportItems = new string[] { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid"};
            foreach(var item in passportItems)
            {
                int iItem = passport.IndexOf(item + ":") + 4;
                var iItemSpace = passport.IndexOf(" ", iItem);
                string itemValue = passport.Substring(iItem, iItemSpace - iItem);
                Console.WriteLine("itemValue: " + itemValue);          

                if (passport.Contains(item + ":"))
                {
                    switch (item)
                    {
                        case "byr":
                            isValid = IsbyrValid(itemValue);
                            break;
                        case "iyr":
                            isValid = IsiyrValid(itemValue);
                            break;
                        case "eyr":
                            isValid = IseyrValid(itemValue);
                            break;
                        case "hgt":
                            isValid = IshgtValid(itemValue);
                            break;
                        case "hcl":
                            isValid = IshclValid(itemValue);
                            break;
                        case "ecl":
                            isValid = IseclValid(itemValue);
                            break;
                        case "pid":
                            isValid = IspidValid(itemValue);
                            break;
                        default:
                            isValid = false;
                            break;
                    }
                }
                else{
                    isValid = false;
                }
            }

            return isValid;
        }

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

        public static bool IsbyrValid(string byr)
        {
            // byr (Birth Year) - four digits; at least 1920 and at most 2002.

            var isValid = false;

            var byrInt = Int32.Parse(byr);
            if (byr.Length == 4) {
                if ((byrInt >= 1920) && (byrInt <= 2002))
                {
                    Console.WriteLine("byr VALID");
                    isValid = true;
                }
            }
            return isValid;
        }

        public static bool IsiyrValid(string iyr)
        {
            // iyr (Issue Year) - four digits; at least 2010 and at most 2020.
            var isValid = false;

            var iyrInt = Int32.Parse(iyr);
            if (iyr.Length == 4) {
                if ((iyrInt >= 2010) && (iyrInt <= 2020))
                {
                    Console.WriteLine("iyr VALID");
                    isValid = true;
                }
            }
            return isValid;
        }

        public static bool IseyrValid(string eyr)
        {
           // eyr (Expiration Year) - four digits; at least 2020 and at most 2030.
            var isValid = false;

            var eyrInt = Int32.Parse(eyr);
            if (eyr.Length == 4) {
                if ((eyrInt >= 2020) && (eyrInt <= 2030))
                {
                    Console.WriteLine("eyr VALID");
                    isValid = true;
                }
            }
            return isValid;
        }

        public static bool IshgtValid(string hgt)
        {
            // hgt (Height) - a number followed by either cm or in:
            // If cm, the number must be at least 150 and at most 193.
            // If in, the number must be at least 59 and at most 76.
            var isValid = false;

            if (hgt.Length >= 4) {
                if (hgt.Any(char.IsDigit))
                {
                    var hgtNum = Int32.Parse(hgt.Substring(0, hgt.Length -2));
                    //Console.WriteLine("hgtNum: " + hgtNum);

                    if (hgt.EndsWith("cm"))
                    {
                        if (hgtNum >= 150 && hgtNum <= 193)
                        {
                            Console.WriteLine("hgt VALID");
                            isValid = true;
                        }
                    } 
                    else if (hgt.EndsWith("in"))
                    {
                        if (hgtNum >= 59 && hgtNum <= 76)
                        {
                            Console.WriteLine("hgt VALID");
                            isValid = true;
                        }
                    }

                }
            }
            return isValid;
        }

        public static bool IshclValid(string hcl)
        {
            // hcl (Hair Color) - a # followed by exactly six characters 0-9 or a-f.
            var isValid = false;
            if (hcl.Contains("#"))
            {
                var hash = hcl.Substring(0, 1);
                var hclValue = hcl.Substring(1, 6);
                var char1 = hcl.Substring(1, 1);
                var char2 = hcl.Substring(2, 1);
                var char3 = hcl.Substring(3, 1);
                var char4 = hcl.Substring(4, 1);
                var char5 = hcl.Substring(5, 1);
                var char6 = hcl.Substring(6, 1);
                //Console.WriteLine("hcl hash: " + hash);
                //Console.WriteLine("hcl value: " + hclValue);
                //Console.WriteLine("hclValue.Length: " + hclValue.Length);

                if (hash == "#")
                {
                    if (hclValue.Length == 6)
                    {
                        if (IsHclCharValid(char1) &&
                            IsHclCharValid(char2) &&
                            IsHclCharValid(char3) &&
                            IsHclCharValid(char4) &&
                            IsHclCharValid(char5) &&
                            IsHclCharValid(char6))
                        {
                            Console.WriteLine("hcl VALID");
                            isValid = true;
                        }
                    }
                }
            }
            return isValid;
        }

        public static bool IsHclCharValid(string hclStr)
        {
            //Console.WriteLine("hcl character: " + hclStr);
            var isValid = false;
            if (hclStr.Any(char.IsDigit))
            {
                var hclInt = Int32.Parse(hclStr);
                if (hclInt >= 0 && hclInt <= 9)
                {
                    //Console.WriteLine("hcl character: " + hclStr + " VALID");
                    isValid = true;
                }
            } else
            {
                if (hclStr.ToLower() == "a" ||
                    hclStr.ToLower() == "b" ||
                    hclStr.ToLower() == "c" ||
                    hclStr.ToLower() == "d" ||
                    hclStr.ToLower() == "e" ||
                    hclStr.ToLower() == "f")
                    {
                        //Console.WriteLine("hcl character: " + hclStr + " VALID");
                        isValid = true;
                    }
            }

            return isValid;
        }

        public static bool IseclValid(string ecl)
        {
            // ecl (Eye Color) - exactly one of: amb blu brn gry grn hzl oth.
            var isValid = false;

            if (ecl.ToLower() == "amb" ||
                ecl.ToLower() == "blu" ||
                ecl.ToLower() == "brn" ||
                ecl.ToLower() == "gry" ||
                ecl.ToLower() == "grn" ||
                ecl.ToLower() == "hzl" ||
                ecl.ToLower() == "oth")
                {
                    Console.WriteLine("ecl VALID");
                    isValid = true;
                }
            return isValid;
        }

        public static bool IspidValid(string pid)
        {
            // pid (Passport ID) - a nine-digit number, including leading zeroes.

            var isValid = false;
            if (IsDigitsOnly(pid))
            {
                if (pid.Length == 9) {
                    var byrInt = Int64.Parse(pid);
                    Console.WriteLine("pid " + pid + " VALID");
                    isValid = true;
                }
            }
            return isValid;
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
    }
}
