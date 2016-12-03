using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016
{
    class Day2
    {
        public string InputText { get; private set; }
        public int CurrentPos { get; private set; }
        private string keyCode = "";
        private string keyCode2 = "";

        private List<List<char>> instructions = new List<List<char>>();


        public Day2(string input)
        {
            InputText = input;
        }

        public string Process()
        {
            string output = "";
            // Up, Down, Left, Right
            // 1 2 3
            // 4 5 6
            // 7 8 9
            ProcessInput();
            foreach (List<char> steps in instructions)
            {
                CalculateDigit(steps);
                CalculateDigitPart2(steps);
            }

            output = keyCode + "part 2:" + keyCode2;
            return output;
        }
        private void ProcessInput()
        {
            string[] instructions = InputText.Split('\n');
            foreach (var instruction in instructions)
            {
                List<char> steps = instruction.ToCharArray().ToList();
                this.instructions.Add(steps);
            }
        }
        private void CalculateDigit(List<char> steps)
        {
            int location = 5;
            foreach (char step in steps)
            {
                switch (step)
                {
                    case 'U':
                        location = location < 4 ? location : location -= 3;
                        break;
                    case 'L':
                        location = location == 1 || location == 4 || location == 7 ? location : location -= 1;
                        break;
                    case 'D':
                        location = location > 6 ? location : location += 3;
                        break;
                    case 'R':
                        location = location % 3 == 0? location : location += 1;
                        break;
                    default:
                        break;
                }
            }
            keyCode = keyCode + location.ToString();
        }
        private void CalculateDigitPart2(List<char> steps)
        {
            // A=10, B=11, C=12, D=13
            int location = 5;
            foreach (char step in steps)
            {
                location = MovePart2(location, step);
            }
            keyCode2 = keyCode2 + ConvertOutput(location);
        }
        private int MovePart2(int curLocation, char step)
        {
            int finalLocation = curLocation;
            int[] cantGoUp = new int[] { 1, 2, 4, 5, 9 };
            int[] cantGpLeft = new int[] { 1, 2, 5, 10, 13 };
            int[] cantGoDown = new int[] { 5, 9, 10, 12, 13 };
            int[] cantGoRight = new int[] { 1, 4, 9, 12, 13 };
            switch (step)
            {
                //    1
                //  2 3 4
                //5 6 7 8 9
                //  A B C
                //    D
                case 'U':
                    if (!cantGoUp.Contains(finalLocation))
                    {
                        finalLocation = (finalLocation == 13 || finalLocation == 3) ? finalLocation -= 2 : finalLocation -= 4;
                    }
                    break;
                case 'L':
                    finalLocation = cantGpLeft.Contains(finalLocation) ? finalLocation : finalLocation -= 1;
                    break;
                case 'D':
                    if (!cantGoDown.Contains(finalLocation))
                    {
                        finalLocation = (finalLocation == 1 || finalLocation == 11) ? finalLocation += 2 : finalLocation += 4;
                    }
                    break;
                case 'R':
                    finalLocation = cantGoRight.Contains(finalLocation) ? finalLocation : finalLocation += 1;
                    break;
                default:
                    break;
            }
            return finalLocation;
        }
        private string ConvertOutput(int digit)
        {
            switch (digit)
            {
                case 10:
                    return "A";
                case 11:
                    return "B";
                case 12:
                    return "C";
                case 13:
                    return "D";                     
                default:
                    return digit.ToString();
            }
        }

    }
}
