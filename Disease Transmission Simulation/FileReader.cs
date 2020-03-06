using System;
using System.Text;
using System.IO;

namespace Disease_Transmission_Simulation
{
    public class FileReader
    {
        private string[] graphData;
        private string[] populationData;
        private int[] populationCount;
        private int nodeCount;
        private int edgeCount;
        private int startingNode;

        // Constructor for FileReader
        public FileReader(string graphFileDir, string populationFileDir)
        {
            // Read file from specified directory
            graphData = File.ReadAllLines(graphFileDir);
            populationData = File.ReadAllLines(populationFileDir);
        }

        // Output file contents
        public void printAllLines()
        {
            foreach (string s in graphData)
                Console.WriteLine($"{s}");
            
            foreach(string s in populationData)
                Console.WriteLine($"{s}");
        }

        // Convert read file to graph
        public Graph convertToGraph()
        {
            // Initialize graph
            Graph g = new Graph();

            // Read population file
            string[] city = populationData[0].Split(' ');
            nodeCount = city[0][0] - '0';
            startingNode = city[1][0] - 'A';

            populationCount = new int[nodeCount];
            Array.Clear(populationCount, 0, populationCount.Length);
            for(int i=1;i<=nodeCount;i++)
            {
                // Input population count to respective nodes
                string[] node = populationData[i].Split(' ');
                int nodeNumber = node[0][0] - 'A';
                int popCount = int.Parse(node[1]);

                populationCount[nodeNumber] = popCount;
            }
               
            // Read graph file
            edgeCount = graphData[0][0] - '0';
            for (int i = 1; i <= edgeCount; i++)
            {
                // Create edges for graph
                string[] edge = graphData[i].Split(' ');
                g.addEdge(edge[0][0] - 'A', edge[1][0] - 'A', double.Parse(edge[2]));   
            }

            return g;

        }
    }
}
