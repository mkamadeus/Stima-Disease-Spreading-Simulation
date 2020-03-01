using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Disease_Transmission_Simulation
{
    public class FileReader
    {
        private string[] graphData;
        private string[] populationData;
        private int nodeCount;
        private int edgeCount;
        private int startingNode;
        private int[] populationCount;

        public FileReader(string graphFileDir, string populationFileDir)
        {
            graphData = File.ReadAllLines(graphFileDir);
            populationData = File.ReadAllLines(populationFileDir);
        }

        public void printAllLines()
        {
            foreach(string s in graphData)
            {
                Console.WriteLine($"{s}");
            }
            foreach(string s in populationData)
            {
                Console.WriteLine($"{s}");
            }
        }

        public void convertToGraphData()
        {
            string[] node = populationData[0].Split(' ');
            nodeCount = node[0][0] - '0';
            startingNode = node[1][0] - 'A';
            Console.WriteLine($"There are {nodeCount} nodes, with disease starting at node {startingNode}.");
            for(int i=1;i<=nodeCount;i++)
            {
                node = populationData[i].Split(' ');
                int people = int.Parse(node[1]);
                Console.WriteLine($"Node {node[0][0]-'A'} has {people} people.");
            }

            edgeCount = graphData[0][0] - '0';
            for(int i=1;i<=edgeCount;i++)
            {
                string[] edge = graphData[i].Split(' ');
                int incomingNode = edge[0][0] - 'A';
                int outgoingNode = edge[1][0] - 'A';
                float trValue =float.Parse(edge[2]);

                Console.WriteLine($"Node {incomingNode} to Node {outgoingNode} with T({incomingNode},{outgoingNode}) = {trValue}");
                
            }
            Console.WriteLine(this.nodeCount);
        }
    }
}
