using System;
using System.Collections;
using System.IO;
using static Disease_Transmission_Simulation.FileReader;

namespace Disease_Transmission_Simulation
{
    class Program
    {
        public int PopulationInfected(int population, int day)
        {
            int I = 0;
            I = population/(1+((population-1)*);
            return ;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            FileReader f = new FileReader("D:\\run.txt", "D:\\run2.txt");
            Graf G = new Graf();
            f.printAllLines();
            f.convertToGraphData(G);
            G.printGraf();
            
            Boolean[] visited = new Boolean[f.getNodeCount()]; // buat catat node yang udah di cek
            for(int i = 0; i < f.getNodeCount(); i++)
            {
                visited[i] = false;
            }

            Console.Write("Masukkan hari = ");
            int time = Convert.ToInt32(Console.ReadLine());
            int temp = time;

            Queue neighbour = new Queue(); // mencatat tetangga vertex yang lagi diperiksa
            neighbour.Enqueue(f.getStartingNode());
            while(neighbour.Count != 0)
            {
                int currentNode = (int)neighbour.Peek();
                neighbour.Dequeue();

                visited[currentNode] = true;
                for (int i = 0; i < f.getNodeCount(); i++)
                {
                    if (G.GetTr(currentNode, i) != -1 && !visited[currentNode])
                    {
                        // If Tr gmn gmn

                        neighbour.Enqueue(i);
                    }
                }
            }
        }
    }
}