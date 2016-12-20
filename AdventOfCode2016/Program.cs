using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016
{
    class Program
    {
        static void Main(string[] args)
        {
            Inputs text = new Inputs();
            Day1 day1 = new Day1(text.Day1);
            string output = "Day 1: " + day1.Process();
            Console.WriteLine(output);
            Day2 day2 = new Day2(text.Day2);
            output = "Day 2: " + day2.Process();
            Console.WriteLine(output);
            Day3 day3 = new Day3(text.Day3);
            output = "Day 3: " + day3.Process();
            Console.WriteLine(output);
            Day4 day4 = new Day4(text.day4Input);
            output = "Day 4: " + day4.Process();
            Console.WriteLine(output);
            Day5 day5 = new Day5(text.Day5);
            output = "Day 5: " + day5.Process();
            Console.WriteLine(output);

            Console.ReadLine();            
        }
    }
}
