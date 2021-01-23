using System;

namespace test
{
    class Program
    {
        static int[,] rectangle;
        static void Main(string[] args)
        {
            string[] valueRectangle = Console.ReadLine().Split(' ');
            int R1, R2;
            while (!int.TryParse(valueRectangle[0], out R1) || !int.TryParse(valueRectangle[1], out R2))
            {
                Console.WriteLine("please enter int values");
                valueRectangle = Console.ReadLine().Split(' ');
            }
            rectangle = new int[,] { { R1, R2 } };

            //get gezgin1 values
            string[] values1 = Console.ReadLine().ToUpper().Split(' ');
            int gez1, gez2;
            while (!Int32.TryParse(values1[0], out gez1) || !Int32.TryParse(values1[1], out gez2) || checkRotate(values1[2]) != true)
            {
                Console.WriteLine("please enter int values and enter either N, W, E or S");
                values1 = Console.ReadLine().ToUpper().Split(' ');
            }

            //set gezgin1 values
            Gezgin gezgin1 = new Gezgin();
            gezgin1.cX = gez1;
            gezgin1.cY = gez2;
            gezgin1.R = values1[2];

            //get gezgin1 movement
            string r1 = Console.ReadLine().ToUpper();

            //check directive
            while (!checkDirective(r1)) { Console.WriteLine("Enter either M, R or L"); r1 = Console.ReadLine().ToUpper(); };

            //get gezgin2
            string[] values2 = Console.ReadLine().ToUpper().Split(' ');
            while (!Int32.TryParse(values2[0], out gez1) || !Int32.TryParse(values2[1], out gez2) || checkRotate(values2[2]) != true)
            {
                Console.WriteLine("please enter int values and enter either N, W, E or S");
                values2 = Console.ReadLine().ToUpper().Split(' ');
            }

            //set gezgin2 values
            Gezgin gezgin2 = new Gezgin();
            gezgin2.cX = gez1;
            gezgin2.cY = gez2;
            gezgin2.R = values2[2];

            string r2 = Console.ReadLine().ToUpper();
            while (!checkDirective(r2)) { Console.WriteLine("Enter either M, R or L"); r2 = Console.ReadLine().ToUpper(); };

            //last pozition
            gezgin1 = GetPosition(gezgin1, r1);
            gezgin2 = GetPosition(gezgin2, r2);

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
            bool result = false;

            while (j < d.Length)
            {
                switch (d[j].ToString())
                {
                    case "L":
                    case "M":
                    case "R":
                        result = true;
                        break;
                    default:
                        result = false;
                        break;
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
