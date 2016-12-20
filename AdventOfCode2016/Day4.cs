using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016
{
    class Day4
    {
        public string InputText { get; private set; }
        List<string> instructionLines = new List<string>();

        public Day4(string inputText)
        {
            InputText = inputText;
        }
        public string Process()
        {
            string output = "";
            ProcessInput();
            int count = 0;
            foreach (string line in instructionLines)
            {
                count += CalculateChecksum(line);
            }
            
            return "Part 1: " + count.ToString();
        }
        private void ProcessInput()
        {
            List<string> unprocessedLines = InputText.Split('\n').ToList();
            foreach (var item in unprocessedLines)
            {
                if( item != "")
                    instructionLines.Add(item.Remove(item.Length - 1, 1));
            }
        }
        private int CalculateChecksum(string line)
        {
            string processedLine = line;
            string checkSum = line.Substring(line.Length - 6, 5);
            int sectorId = Int32.Parse(line.Substring(line.Length - 10, 3));
            string encryptedName = line.Substring(0, line.Length - 10);
            List<int> amountOfCheckSumChars = new List<int>();
            foreach (char check in checkSum)
            {
                amountOfCheckSumChars.Add(encryptedName.Count(x => x == check));
            }
            List<int> sortedCheckSums = amountOfCheckSumChars;
            sortedCheckSums.Sort();
            if (amountOfCheckSumChars.SequenceEqual(sortedCheckSums))
            {
                return sectorId;
            }
            return 0;
            //return string.Format("checkSum: {0}, sectorID: {1}, encryptedName: {2}\n", checkSum, sectorId, encryptedName);

        }
    }
}
