using System;
using System.Collections;
using System.IO;
using static Disease_Transmission_Simulation.FileReader;

namespace Disease_Transmission_Simulation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            FileReader f = new FileReader("D:\\run.txt", "D:\\run2.txt");
            Graf G = new Graf();
            f.printAllLines();
            f.convertToGraphData(G);
            G.printGraf();
        }
    }
}
