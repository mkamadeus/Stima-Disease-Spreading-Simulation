using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using static Disease_Transmission_Simulation.FileReader;

namespace Disease_Transmission_Simulation
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //FileReader f = new FileReader();

            //f.printAllLines();
            Graf G = new Graf();
            G.addEdge(0, 1, 0.02);
            G.addEdge(0, 2, 0.005);
            G.addEdge(1, 0, 0.005);
            G.addEdge(1, 3, 0.005);
            G.addEdge(2, 0, 0.1);
            G.addEdge(2, 1, 0.1);
            G.addEdge(3, 0, 0.05);
            G.addEdge(3, 2, 0.1);
            G.printGraf();

        }
    }
}
