using System;
using System.IO;
using static Disease_Transmission_Simulation.FileReader;

namespace Disease_Transmission_Simulation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            FileReader f = new FileReader();

            f.printAllLines();
        }
    }
}
