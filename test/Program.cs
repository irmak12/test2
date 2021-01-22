using System;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] values1 = Console.ReadLine().Split(' ');
            string r1 = Console.ReadLine();
            string[] values2 = Console.ReadLine().Split(' ');
            string r2 = Console.ReadLine();

            Gezgin gezgin1 = new Gezgin();
            gezgin1.cX =Convert.ToInt32 (values1[0].ToString());
            gezgin1.cY =Convert.ToInt32 (values1[1].ToString());
            gezgin1.R =values1[2].ToString();

            Gezgin gezgin2 = new Gezgin();
            gezgin2.cX =Convert.ToInt32 (values2[0].ToString());
            gezgin2.cY =Convert.ToInt32 (values2[1].ToString());
            gezgin2.R =values2[2].ToString();
           
            for (int i = 0; i < r1.Length; i++)
            {
                Operations operation = new Operations();
                switch (r1[i].ToString())
                {
                    case "L":
                        gezgin1 = operation.RotateLeft(gezgin1);
                        break;
                    case "M":
                        gezgin1= operation.Move(gezgin1);
                        break;
                    case "R":
                        gezgin1 = operation.RotateRight(gezgin1);
                        break;
                    default:
                        break;
                }
               // Console.WriteLine("{0},{1},{2}, STEP : {3}", gezgin.cX, gezgin.cY, gezgin.R, i+1);
            }

            for (int i = 0; i < r2.Length; i++)
            {
                Operations operation = new Operations();
                switch (r2[i].ToString())
                {
                    case "L":
                        gezgin2 = operation.RotateLeft(gezgin2);
                        break;
                    case "M":
                        gezgin2= operation.Move(gezgin2);
                        break;
                    case "R":
                        gezgin2 = operation.RotateRight(gezgin2);
                        break;
                    default:
                        break;
                }
               // Console.WriteLine("{0},{1},{2}, STEP : {3}", gezgin.cX, gezgin.cY, gezgin.R, i+1);
            }
            Console.WriteLine("{0} {1} {2}", gezgin1.cX, gezgin1.cY, gezgin1.R);
            Console.WriteLine("{0} {1} {2}", gezgin2.cX, gezgin2.cY, gezgin2.R);
        }
    }
}
