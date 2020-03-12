using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualisasiGraf
{
    class Visualizer
    {
        public Microsoft.Msagl.GraphViewerGdi.GViewer viewer;
        public Graph G = new Graph();

        public int nodeCount, edgeCount, startingNode;
        
        public List<Tuple<int, int>> infectedEdge = new List<Tuple<int, int>>();
        public List<Tuple<int, int>> uninfectedEdge = new List<Tuple<int, int>>();

        public int[] populationCount;
        public Boolean[] infected;
        public string printed = "Process: \n";

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

            // Initialize graph datas
            infected = new Boolean[nodeCount]; // buat catat node yang udah di cek
            for (int i = 0; i < nodeCount; i++)
                infected[i] = false;


            for (int i = 0; i < 26; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (G.getTravelProbability(i,j) != -1)
                    {
                        uninfectedEdge.Add(Tuple.Create(i, j));
                    }
                }
            }
        }
        public static double getInfected(int population, int day)
        {
            double I;
            I = population / (1 + (population - 1)*Math.Pow(Math.E, -0.25 * day));
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
                //VisualizeGraph();

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
                        printed += $"S({currentNode}, {i}) = {S}\n";
                        // If transmission successful..
                        if (S > 1)
                        {
                            // Print status
                            Console.WriteLine($"Transmission from node {currentNode} to node {i} successful.");
                            printed += $"Transmission from node {currentNode} to node {i} successful.\n";
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
                            printed += $"Transmitted on day {dayInfected[i]}.\n";
                            infectedEdge.Add(Tuple.Create(currentNode, i));
                            uninfectedEdge.Remove(new Tuple<int, int>(currentNode, i));
                        }
                        else
                        {
                            // Print status
                            Console.WriteLine($"Transmission from node {currentNode} to node {i} failed.");
                            printed += $"Transmission from node {currentNode} to node {i} failed.\n";                       }

                    }
                }
            }
        }

        public void VisualizeGraph()
        {
            // Inititalize MSAGL graph
            Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");


            // For each infected edges draw red edge
            foreach(Tuple<int,int> edge in infectedEdge)
                graph.AddEdge(edge.Item1.ToString(), edge.Item2.ToString()).Attr.Color = Microsoft.Msagl.Drawing.Color.Red;

            // For each uninfected edges draw black edge
            foreach(Tuple<int, int> edge in uninfectedEdge)
            {
                graph.AddEdge(edge.Item1.ToString(), edge.Item2.ToString());
            }

            // If node infected, set node color to red
            for(int i = 0; i < nodeCount;i++)
            {
                if (infected[i])
                    graph.FindNode(i.ToString()).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Red;
                else
                    graph.FindNode(i.ToString());

            }

            // Wrap graph in the graphWindow
            viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            viewer.Graph = graph;

            Form graphForm = new Form();

            graphForm.SuspendLayout();
            graphForm.Controls.Add(viewer);
            graphForm.ResumeLayout();

            graphForm.ShowDialog();
        }


    }
}
