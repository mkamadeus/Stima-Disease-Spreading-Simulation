using System;
using System.Collections;
using System.IO;
using static Disease_Transmission_Simulation.FileReader;

namespace Disease_Transmission_Simulation
{
    class Program
    {
        // Get infected count on the 
        public double getInfected(int population, int day)
        {
            double I = population/(1+((population-1)*));
            return I;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // Set config filename
            const string graphFile = @"\graphData.config";
            const string populationFile = @"\populationData.config";

            // Get config directory
            string path = Environment.CurrentDirectory + @"\config";

            // Setup FileReader
            FileReader f = new FileReader(path + graphFile, path + populationFile);
            f.printAllLines();
            Graph g = f.convertToGraph();
            g.printGraph();
            
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
                    if (g.getTravelProbability(currentNode, i) != -1 && !visited[currentNode])
                    {
                        // If Tr gmn gmn

                        neighbour.Enqueue(i);
                    }
                }
            }
        }
    }
}