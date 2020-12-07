using System.Collections.Generic;
namespace AoC
{

    public class Group
    {
        public int Number {get; set;}
        public List<Person> People {get; set;}
        public int YesAnswerCount {get; set;}
        public List<Answer> UniqueAnswers {get; set;}
    }
}