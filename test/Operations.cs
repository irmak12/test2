using System;
using System.Collections.Generic;
using System.Text;

namespace test
{
    public class Operations
    {
        public Gezgin RotateLeft(Gezgin gezgin)
        {
            Gezgin temp = new Gezgin();
            temp.R = gezgin.R;
            switch (gezgin.R)
            {
                case "N":
                    temp.R = "W";
                    break;
                case "W":
                    temp.R = "S";
                    break;
                case "S":
                    temp.R = "E";
                    break;
                case "E":
                    temp.R = "N";
                    break;
                default:
                    break;
            }
            gezgin.R = temp.R;
            return gezgin;
        }

        public Gezgin RotateRight(Gezgin gezgin)
        {
            Gezgin temp = new Gezgin();
            temp.R = gezgin.R;
            switch (gezgin.R)
            {
                case "N":
                    temp.R = "E";
                    break;
                case "W":
                    temp.R = "N";
                    break;
                case "S":
                    temp.R = "W";
                    break;
                case "E":
                    temp.R = "S";
                    break;
                default:
                    break;
            }
            gezgin.R = temp.R;
            return gezgin;
        }

        public Gezgin Move(Gezgin gezgin, int[,] rectangle)
        {
            Gezgin temp = new Gezgin();
            temp.cX = gezgin.cX;
            temp.cY = gezgin.cY;
            temp.R = gezgin.R;
            
           switch (temp.R)
            {
                case "N":
                    temp.cY += 1;
                    temp = Position(temp, rectangle);
                    break;
                case "S":
                    temp.cY -= 1;
                    temp = Position(temp,rectangle);
                    break;
                case "E":
                    temp.cX += 1;
                    temp = Position(temp, rectangle);
                    break;
                case "W":
                    temp.cX -= 1;
                    temp = Position(temp,rectangle);
                    break;
                default:
                    break;
            }
            return temp;
        }

        public Gezgin Position(Gezgin gezgin, int[,] y)
        {
            if (gezgin.cX > y[0, 0])
            {
                gezgin.cX = y[0, 0];
            }
            if (gezgin.cY > y[0, 1])
            {
                gezgin.cY = y[0, 1];
            }
            if (gezgin.cX < 0) gezgin.cX = 0;
            if (gezgin.cY < 0) gezgin.cY = 0;
            return gezgin;
        }

    }
}
