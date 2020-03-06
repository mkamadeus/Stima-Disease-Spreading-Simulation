using System;
using System.Collections;
using System.IO;
using static Disease_Transmission_Simulation.FileReader;

namespace Disease_Transmission_Simulation
{
    class Program
    {
        // Get infected rate
        // i.e get I(P(A), t(A))
        public int getInfected(int population, int day)
        {
            int I = population*day/20;
            return I;
        }

        // Get days from infection
        // i.e get t(A)
        public int getDaysFromInfection(int currentDay, int infectedDay)
        {
            return currentDay - infectedDay;
        }

        // Get disease transfer rate
        // i.e get S(A,B)
        public double getDiseaseTranferRate(int i, int j)
        {
            float rate = I()
            return 
        }

        static void Main(string[] args)
        {

            // Set config filename
            const string graphFile = @"\graphData.config";
            const string populationFile = @"\populationData.config";

            // Get config directory
            string path = Environment.CurrentDirectory + @"\config";

            // Setup FileReader
            FileReader f = new FileReader(path + graphFile, path + populationFile);
            f.printAllLines();

            // Convert to graph data
            Graph g = f.convertToGraph();
            g.printGraph();
            
            // Initialize graph datas
            Boolean[] infected = new Boolean[f.getNodeCount()]; // buat catat node yang udah di cek
            for(int i = 0; i < f.getNodeCount(); i++)
                infected[i] = false;
            
            // Stores T(A)
            int[] dayInfected = new int[f.getNodeCount()];
            for(int i = 0; i < f.getNodeCount(); i++)
                dayInfected[i] = -1;

            // Input day input
            Console.Write("Masukkan hari : ");
            int time = Convert.ToInt32(Console.ReadLine());
            int temp = time;

            // Initialize BFS
            Queue neighbour = new Queue(); // mencatat tetangga vertex yang lagi diperiksa
            neighbour.Enqueue(f.getStartingNode());
            dayInfected[f.getStartingNode()] = 0;

            // While queue not empty...
            while(neighbour.Count != 0)
            {
                int currentNode = (int)neighbour.Peek();
                neighbour.Dequeue();

                for (int i = 0; i < f.getNodeCount(); i++)
                {
                    // If a path exists and not destination node not infected yet...
                    if (g.getTravelProbability(currentNode, i) != -1 && !infected[i])
                    {
                        // If Tr gmn gmn

                        neighbour.Enqueue(i);
                    }
                }
            }
        }
    }
}