using System;


namespace Disease_Transmission_Simulation
{
	public class Graf
	{
		private double[,] Tr;
		public Graf()
		{
			this.Tr = new double[26 ,26];
			for (int i = 0; i < 26; i++)
			{
				for (int j = 0; j < 26; j++)
				{
					this.Tr[i, j] = -1; // -1 berarti tidak terhubung ke mana2
				}
			}
		}
		public double GetTr(int i, int j) { return this.Tr[i,j]; }
		public void Set(int i, int j, double Tr)
		{
			this.Tr[i,j] = Tr;
		}
		public void addEdge(int i, int j, double Tr)
		{
			if (this.Tr[i,j] == -1)
			{
				Set(i, j, Tr);
			}
			else
			{
				Console.WriteLine("Sudah ada.");
			}
		}
		public void printGraf()
		{
			for (int i = 0; i<26; i++)
			{
				for (int j = 0; j < 26; j++)
				{
					if (GetTr(i,j)!=-1)
					{
						Console.WriteLine(i + " " + j + " " + this.Tr[i,j]);
					}
				}
			}
		}
	}
}
