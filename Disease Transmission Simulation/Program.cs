using System;

namespace Disease_Transmission_Simulation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            FileReader f = new FileReader("D:\\run.txt", "D:\\run2.txt");

            f.printAllLines();
            f.convertToGraphData();
        }
    }
}
