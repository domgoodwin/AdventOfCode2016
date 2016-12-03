using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2016
{
    class Day3
    {
        public string InputText { get; private set; }
        List<List<int>> instructions = new List<List<int>>();
        List<int> rawPart2Steps = new List<int>();
        List<List<int>> processedPart2 = new List<List<int>>();
        List<List<int>> validTriangles = new List<List<int>>();

        public Day3(string input)
        {
            InputText = input;
        }

        public string Process()
        {
            string output = "";
            ProcessInput();
            ProcessP2Input();
            foreach (List<int> triangle in instructions)
            {
                if (CheckTriangle(triangle))
                {
                    validTriangles.Add(triangle);
                }
            }
            output = "Part 1: " + validTriangles.Count.ToString();
            validTriangles.Clear();
            foreach (var triangle in processedPart2)
            {
                if (CheckTriangle(triangle))
                {
                    validTriangles.Add(triangle);
                }
            }
            output = output + "Part 2: " + validTriangles.Count.ToString();

            return output;
        }
        private void ProcessInput()
        {
            string[] lines = InputText.Split('\r');
            foreach (string line in lines )
            {
                string lineProcessed = Regex.Replace(line, @"\t|\n|\r", "");
                // this is terrible
                lineProcessed = lineProcessed.Replace("   ", " ");
                lineProcessed = lineProcessed.Replace("  ", " ");
                lineProcessed = lineProcessed.Trim();

                string[] steps = lineProcessed.Split(' ');
                List<int> processedSteps = new List<int>();
                foreach (string step in steps)
                {
                    processedSteps.Add(Int32.Parse(step));
                    rawPart2Steps.Add(Int32.Parse(step));
                }
                instructions.Add(processedSteps);

            }
        }

        private void ProcessP2Input()
        {
            //0, 3, 6 one tri
            List<int> triangle1 = new List<int>();
            //1, 4, 7 second tri
            List<int> triangle2 = new List<int>();
            //2, 5, 8 thrid tri
            List<int> triangle3 = new List<int>();

            for (int i = 0; i < rawPart2Steps.Count; i++)
            {
                int step = rawPart2Steps[i];
                if((i % 9 == 0 && i > 0))
                {
                    processedPart2.Add(triangle1);
                    processedPart2.Add(triangle2);
                    processedPart2.Add(triangle3);
                    //triangle1.Clear();
                    //triangle2.Clear();
                    //triangle3.Clear();
                    triangle1 = new List<int>();
                    triangle2 = new List<int>();
                    triangle3 = new List<int>();
                }
                if (i % 3 == 0)
                    triangle1.Add(step);
                if ((i - 1) % 3 == 0 || (i - 4) % 3 == 0)
                    triangle2.Add(step);
                if ((i - 2) % 3 == 0 || (i - 5) % 3 == 0)
                    triangle3.Add(step);
                if(i == rawPart2Steps.Count - 1)
                {
                    processedPart2.Add(triangle1);
                    processedPart2.Add(triangle2);
                    processedPart2.Add(triangle3);
                }
            }
        }

        private bool CheckTriangle(List<int> sides)
        {
            return (sides[0] + sides[1] > sides[2]) && (sides[0] + sides[2] > sides[1]) && (sides[1] + sides[2] > sides[0]);
        }
    }
}
