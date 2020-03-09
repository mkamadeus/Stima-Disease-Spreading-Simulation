using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualisasiGraf
{
    public class GraphVisualizated
    {
        private Graph G = new Graph();
        // set up graph that will be visualizated
        public GraphVisualizated(Graph g)
        {
            for (int i = 0; i < 26; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    G.setTravelProbability(i, j, g.getTravelProbability(i, j));
                }
            }
        }
        // make a graph based on known graph
        public Microsoft.Msagl.Drawing.Graph GraphVisualizing()
        {
            Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");
            for (int i = 0; i < 26; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (G.getTravelProbability(i, j) != -1)
                    {
                        graph.AddEdge(i.ToString(), j.ToString());
                        graph.FindNode(i.ToString()).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Green;
                        graph.FindNode(j.ToString()).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Green;
                    }
                }
            }
            return graph;
        }

        // display the graph
        public void Visualizate(Microsoft.Msagl.Drawing.Graph graph)
        {
            Form form = new Form();
            Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            viewer.Graph = graph;
            form.SuspendLayout();
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            form.Controls.Add(viewer);
            form.ResumeLayout();
            form.ShowDialog();

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
            for (int i = 0; i < f.getNodeCount(); i++)
                infected[i] = false;

            // Stores P(A)
            int[] population = f.getPopulationCount();

            // Stores T(A)
            int[] dayInfected = new int[f.getNodeCount()];
            for (int i = 0; i < f.getNodeCount(); i++)
                dayInfected[i] = -1;

            // Input day input
            Console.Write("Masukkan harie : ");
            int day = 5;

            Console.WriteLine("Pisang");
            // Initialize graph that used to be visualized
            GraphVisualizated G = new GraphVisualizated(g);
            Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");
            graph = G.GraphVisualizing();

            // Initialize BFS
            Queue neighbour = new Queue(); // mencatat tetangga vertex yang lagi diperiksa
            neighbour.Enqueue(f.getStartingNode());
            infected[f.getStartingNode()] = true;
            dayInfected[f.getStartingNode()] = 0;

            // While queue not empty...
            while (neighbour.Count != 0)
            {
                int currentNode = (int)neighbour.Peek();
                neighbour.Dequeue();

                for (int i = 0; i < f.getNodeCount(); i++)
                {
                    // If a path exists...
                    if (g.getTravelProbability(currentNode, i) != -1)
                    {
                        // Calculate S(currentNode)
                        double Tr = g.getTravelProbability(currentNode, i);
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

                            // Colorize the infected node and infected edge
                            
                            graph.FindNode(i.ToString()).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Red;
                            graph.FindNode(currentNode.ToString()).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Red;
                        }
                        else
                        {
                            // Print status
                            Console.WriteLine($"Transmission from node {currentNode} to node {i} failed.");
                        }

                    }
                }
            }
            G.Visualizate(graph);
        }
    }
}
