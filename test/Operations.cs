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
        //public string SurfaceR(string s)
        //{
        //    string result = "";
        //    switch (s)
        //    {
        //        case "N":
        //            result = "E";
        //            break;
        //        case "W":
        //            result = "N";
        //            break;
        //        case "S":
        //            result = "W";
        //            break;
        //        case "E":
        //            result = "S";
        //            break;
        //        default:
        //            break;
        //    }
        //    return result;
        //}
        //public string SurfaceL(string s)
        //{
        //    string result = "";
        //    switch (s)
        //    {
        //        case "N":
        //            result = "W";
        //            break;
        //        case "W":
        //            result = "S";
        //            break;
        //        case "S":
        //            result = "E";
        //            break;
        //        case "E":
        //            result = "N";
        //            break;
        //        default:
        //            break;
        //    }
        //    return result;
        //}

        public Gezgin Move(Gezgin gezgin)
        {
            int[,] x = new int[,] { { 5, 5 } };
            Gezgin temp = new Gezgin();
            temp.cX = gezgin.cX;
            temp.cY = gezgin.cY;
            temp.R = gezgin.R;
            
           switch (temp.R)
            {
                case "N":
                    temp.cY += 1;
                    temp = Location(temp, x);
                    break;
                case "S":
                    temp.cY -= 1;
                    temp = Location(temp, x);
                    break;
                case "E":
                    temp.cX += 1;
                    temp = Location(temp, x);
                    break;
                case "W":
                    temp.cX -= 1;
                    temp = Location(temp, x);
                    break;
                default:
                    break;
            }
            return temp;
        }
        public Gezgin Location(Gezgin gezgin, int[,] y)
        {
            if (gezgin.cX > y[0, 0])
            {
                gezgin.cX = y[0, 0];
            }
            if (gezgin.cY > y[0, 1])
            {
                gezgin.cY = y[0, 1];
            }
            return gezgin;
        }
    }
}
