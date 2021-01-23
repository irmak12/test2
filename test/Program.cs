using System;

namespace test
{
    class Program
    {
        static int[,] rectangle;
        static void Main(string[] args)
        {
            string[] valueRectangle = Console.ReadLine().Split(' ');
            int rX, rY;
            while (!int.TryParse(valueRectangle[0], out rX) || !int.TryParse(valueRectangle[1], out rY))
            {
                Console.WriteLine("enter integer values");
                valueRectangle = Console.ReadLine().Split(' ');
            }
            rectangle = new int[,] { { rX, rY } };

            //get gezgin1 values
            string[] values1 = Console.ReadLine().ToUpper().Split(' ');
            int gez1, gez2;
            while (!Int32.TryParse(values1[0], out gez1) || !Int32.TryParse(values1[1], out gez2) || checkRotate(values1[2]) != true)
            {
                Console.WriteLine("enter integer values and enter either N, W, E or S");
                values1 = Console.ReadLine().ToUpper().Split(' ');
            }

            //set gezgin1 values
            Gezgin gezgin1 = new Gezgin();
            gezgin1.cX = gez1;
            gezgin1.cY = gez2;
            gezgin1.R = values1[2];

            //get gezgin1 movement
            string directives = Console.ReadLine().ToUpper();

            //check directive
            while (!checkDirective(directives)) { Console.WriteLine("Enter either M, R or L"); directives = Console.ReadLine().ToUpper(); };

            //get gezgin2
            string[] values2 = Console.ReadLine().ToUpper().Split(' ');
            while (!Int32.TryParse(values2[0], out gez1) || !Int32.TryParse(values2[1], out gez2) || checkRotate(values2[2]) != true)
            {
                Console.WriteLine("enter integer values and enter either N, W, E or S");
                values2 = Console.ReadLine().ToUpper().Split(' ');
            }

            //set gezgin2 values
            Gezgin gezgin2 = new Gezgin();
            gezgin2.cX = gez1;
            gezgin2.cY = gez2;
            gezgin2.R = values2[2];

            string directives2 = Console.ReadLine().ToUpper();
            while (!checkDirective(directives2)) { Console.WriteLine("Enter either M, R or L"); directives2 = Console.ReadLine().ToUpper(); };

            //last pozition
            gezgin1 = GetPosition(gezgin1, directives);
            gezgin2 = GetPosition(gezgin2, directives2);

            Console.WriteLine("{0} {1} {2}", gezgin1.cX, gezgin1.cY, gezgin1.R);
            Console.WriteLine("{0} {1} {2}", gezgin2.cX, gezgin2.cY, gezgin2.R);
        }

        public static bool checkRotate(string R)
        {
            switch (R)
            {
                case "N":
                case "W":
                case "E":
                case "S":
                    return true;
                default:
                    return false;
            }
        }
        public static bool checkDirective(string d)
        {
            int j = 0;
            bool result = true;

            while (j < d.Length)
            {
                switch (d[j].ToString())
                {
                    case "L":
                    case "M":
                    case "R":
                       // result = true;
                        break;
                    default:
                        result = false;
                        break;
                        //return false;
                }
                j++;
            }
            return result;
        }
        public static Gezgin GetPosition(Gezgin gezgin, string directive)
        {
            for (int i = 0; i < directive.Length; i++)
            {
                Operations operation = new Operations();
                switch (directive[i].ToString())
                {
                    case "L":
                        gezgin = operation.RotateLeft(gezgin);
                        break;
                    case "M":
                        gezgin = operation.Move(gezgin, rectangle);
                        break;
                    case "R":
                        gezgin = operation.RotateRight(gezgin);
                        break;
                    default:
                        break;
                }
                // Console.WriteLine("{0},{1},{2}, STEP : {3}", gezgin.cX, gezgin.cY, gezgin.R, i+1);
            }
            return gezgin;
        }
    }
}
