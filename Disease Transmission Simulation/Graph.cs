using System;

namespace Disease_Transmission_Simulation
{
	public class Graph
	{
		// Graph representation using adjacency matrix
		private double[,] Tr;

		public Graph()
		{
			this.Tr = new double[26 ,26];
			for (int i = 0; i < 26; i++)
			{
				for (int j = 0; j < 26; j++)
				{
					// -1 for not connected edges
					this.Tr[i, j] = -1; 
				}
			}
		}

		// Get travelling probability from node i to node j
		// i.e returns Tr(i,j)
		public double getTravelProbability(int i, int j)
		{
			return this.Tr[i,j];
		}

		// Set travelling probability
		public void setTravelProbability(int i, int j, double Tr)
		{
			this.Tr[i,j] = Tr;
		}

		// Add new edge from node i to node j with weight Tr
		public void addEdge(int i, int j, double Tr)
		{
			if (this.Tr[i,j] == -1)
			{
				setTravelProbability(i, j, Tr);
			}
			else
			{
				Console.WriteLine("Edge already exists.");
			}
		}

		// Output graph contents
		public void printGraph()
		{
			for (int i = 0; i<26; i++)
			{
				for (int j = 0; j < 26; j++)
				{
					if (getTravelProbability(i,j)!=-1)
					{
						Console.WriteLine(i + " " + j + " " + this.Tr[i,j]);
					}
				}
			}
		}
		
	}
}
