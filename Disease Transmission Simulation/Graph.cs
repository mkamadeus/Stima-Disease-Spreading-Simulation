using System;


namespace Disease_Transmission_Simulation
{
	public class Graf
	{
		private int[,] matrix;
		private double[] Tr;
		public Graf()
		{
			this.matrix = new int[26, 26];
			this.Tr = new double[26 * 26];
			for (int i = 0; i < 26; i++)
			{
				for (int j = 0; j < 26; j++)
				{
					this.matrix[i, j] = 0;
					this.Tr[26 * i + j] = 0;
				}
			}
		}
		public int GetKetetanggaan(int i, int j) { return this.matrix[i, j]; }
		public double GetTr(int i, int j) { return this.Tr[26 * i + j]; }
		public void Set(int i, int j, int baru, double Tr)
		{
			this.matrix[i, j] = baru;
			this.Tr[26 * i + j] = Tr;
		}
		public void addEdge(int i, int j, double Tr)
		{
			if (GetKetetanggaan(i,j)==0)
			{
				Set(i, j, 1,Tr);
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
					if (GetKetetanggaan(i,j)==1)
					{
						Console.WriteLine(i + " " + j + " " + this.Tr[26 * i + j]);
					}
				}
			}
		}
	}
}
