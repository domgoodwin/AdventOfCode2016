using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016
{
    class Day1
    {
        public string InputText { get; private set; }

        //North 0, East 1, South 2, West 3
        private int facingDirection = 0;
        private int xCoord = 0;
        private int yCoord = 0;

        List<string> locationHistory = new List<string>();
        int firstLocationVisitedTwiceDistance = 0;

        public Day1(string inputText)
        {
            InputText = inputText;
        }

        public string Process()
        {
            string output = "";
            //L = left 90, R = right 90, # = walk forward
            string[] steps = InputText.Split(',');
            locationHistory.Add("0,0");
            foreach (var step in steps)
            {
                ProcessStep(step);
            }
            int distance = CalculateDistance();
            output = String.Format("A: The distance to easter bunny HQ is {0}\nB: First location visited twice distance is {1}"
                , distance, firstLocationVisitedTwiceDistance);
            return output;
        }

        private void ProcessStep(string step)
        {
            step = step.Trim();
            char direction = step[0];
            step = step.Remove(0, 1);
            int movement = Int32.Parse(step);
            Turn(direction);
            Move(movement);
            LogCoord();
            CheckPosition();
        }
        private void Turn(char direction)
        {
            //Right +1
            if (direction == 'R')
            {
                facingDirection++;
            }
            else
            {
                facingDirection--;
            }
            if (facingDirection < 0)
            {
                facingDirection = 4 + facingDirection;
            }
            if(facingDirection > 3)
            {
                facingDirection -= 4;
            }
        }
        private void Move(int forward)
        {
            switch (facingDirection)
            {
                case 0:
                    //North
                    yCoord += forward;

                    break;
                case 1:
                    //East
                    xCoord += forward;
                    break;
                case 2:
                    //South
                    yCoord -= forward;
                    break;
                case 3:
                    //West
                    xCoord -= forward;
                    break;          
                default:
                    break;
            }
        }
        private int CalculateDistance()
        {
            //y2-y1 + x2-x1
            return (Math.Abs(0 - yCoord)) + (Math.Abs(0 - xCoord));
        }
        private void CheckPosition()
        {
            int count = 0;
            foreach (var prevLocation in coordLog)
            {
                count++;    
                string curLocation = String.Format("{0},{1}", xCoord, yCoord);
                if(prevLocation == curLocation && firstLocationVisitedTwiceDistance == 0 && count != coordLog.Count)
                {
                    firstLocationVisitedTwiceDistance = CalculateDistance();
                    count++;
                    return;
                }
            }
        }
        List<string> coordLog = new List<string> { "0,0" };
        private void LogCoord()
        {
            int x = Int32.Parse(locationHistory.Last().Split(',')[0]);
            int y = Int32.Parse(locationHistory.Last().Split(',')[1]);
            //coordLog.Add(String.Format("{0},{1}", x, y));
            while (x != xCoord || y != yCoord)
            { 
                coordLog.Add(String.Format("{0},{1}", x, y));
                if (x < xCoord) { x++; }
                if(x > xCoord) { x--; }
                if (y < yCoord) { y++; }
                if(y > yCoord) { y--; }
            }
            coordLog.Add(String.Format("{0},{1}", x, y));
            locationHistory.Add(String.Format("{0},{1}", xCoord, yCoord));
        }
    }
}
