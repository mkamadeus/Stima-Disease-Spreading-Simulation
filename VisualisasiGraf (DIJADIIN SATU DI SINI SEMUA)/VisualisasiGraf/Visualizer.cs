﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualisasiGraf
{
    class Visualizer
    {
        private Graph G = new Graph();
        private List<Tuple<int, int>> infect = new List<Tuple<int, int>>();
        private int nodeCount, edgeCount, startingNode;
        private int[] populationCount;
        private List<Tuple<int, int>> uninfect = new List<Tuple<int, int>>();
        public Visualizer()
        {
            // Set config filename
            const string graphFile = @"\graphData.config";
            const string populationFile = @"\populationData.config";

            // Get config directory
            string path = Environment.CurrentDirectory + @"\config";

            // Setup FileReader
            FileReader f = new FileReader(path + graphFile, path + populationFile);

            // Convert to graph data
            G = f.convertToGraph();
            nodeCount = f.getNodeCount();
            populationCount = f.getPopulationCount();
            startingNode = f.getStartingNode();
            edgeCount = f.getEdgeCount();
            for (int i = 0; i < 26; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (G.getTravelProbability(i,j) != -1)
                    {
                        uninfect.Add(Tuple.Create(i, j));
                    }
                }
            }
        }
        public static double getInfected(int population, int day)
        {
            double I = population * day / 20;
            return I;
        }

        // Get days from infection
        // i.e get t(A)
        public static int getDaysFromInfection(int currentDay, int infectedDay)
        {
            return currentDay - infectedDay;
        }
        public void BFS(int day)
        {
            // Initialize graph datas
            Boolean[] infected = new Boolean[nodeCount]; // buat catat node yang udah di cek
            for (int i = 0; i < nodeCount; i++)
                infected[i] = false;

            // Stores P(A)
            int[] population = populationCount;

            // Stores T(A)
            int[] dayInfected = new int[nodeCount];
            for (int i = 0; i < nodeCount; i++)
                dayInfected[i] = -1;

            // Initialize BFS
            System.Collections.Queue neighbour = new System.Collections.Queue(); // mencatat tetangga vertex yang lagi diperiksa
            neighbour.Enqueue(startingNode);
            infected[startingNode] = true;
            dayInfected[startingNode] = 0;

            // While queue not empty...
            while (neighbour.Count != 0)
            {
                int currentNode = (int)neighbour.Peek();
                neighbour.Dequeue();

                for (int i = 0; i < nodeCount; i++)
                {
                    // If a path exists...
                    if (G.getTravelProbability(currentNode, i) != -1)
                    {
                        // Calculate S(currentNode)
                        double Tr = G.getTravelProbability(currentNode, i);
                        int t = getDaysFromInfection(day, dayInfected[currentNode]);
                        double S = getInfected(population[currentNode], t) * Tr;

                        Console.WriteLine($"S({currentNode}, {i}) = {S}");

                        // If transmission successful..
                        if (S > 1)
                        {
                            // Print status
                            Console.WriteLine($"Transmission from node {currentNode} to node {i} successful.");

                            // Set node status
                            if (!infected[i])
                            {
                                neighbour.Enqueue(i);
                                Console.WriteLine($"Pushed {i} to queue.");
                            }
                            infected[i] = true;

                            // Find first day infected
                            int d = 0;
                            while (getInfected(population[currentNode], d) * Tr <= 1) d++;

                            // Set day infected
                            dayInfected[i] = Math.Max(dayInfected[i], d + dayInfected[currentNode]);
                            Console.WriteLine($"Transmitted on day {dayInfected[i]}.");
                            infect.Add(Tuple.Create(currentNode, i));
                            uninfect.Remove(new Tuple<int, int>(currentNode, i));
                        }
                        else
                        {
                            // Print status
                            Console.WriteLine($"Transmission from node {currentNode} to node {i} failed.");
                        }

                    }
                }
            }
        }
        public void VisualizeGraph()
        {
            Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");
            for (int i = 0; i < infect.Count; i++)
            {
                graph.AddEdge(infect[i].Item1.ToString(), infect[i].Item2.ToString()).Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
                graph.FindNode(infect[i].Item1.ToString()).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Red;
                graph.FindNode(infect[i].Item2.ToString()).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Red;
            }
            for (int i = 0; i < uninfect.Count; i++)
            {
                graph.AddEdge(uninfect[i].Item1.ToString(), uninfect[i].Item2.ToString());
            }

            Form form = new Form();
            Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            viewer.Graph = graph;
            form.SuspendLayout();
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            form.Controls.Add(viewer);
            form.ResumeLayout();
            form.ShowDialog();
        }


    }
}