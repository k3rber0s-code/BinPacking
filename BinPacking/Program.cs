
using System;
using System.Collections.Generic;
using System.IO;

class BinPacking
{

	static int nextFit(int[] weight, int n, int c)
	{

		int res = 1, bin_rem = c;

		for (int i = 0; i < n; i++)
		{
			// If this item can't fit in current bin
			if (weight[i] > bin_rem)
			{
				res++; // Use a new bin
				bin_rem = c - weight[i];
			}
			else
				bin_rem -= weight[i];
		}
		return res;
	}

	public static void Main(String[] args)
	{
		var orders = new List<int>();
		int processed = 0;
		
		using (var sr = new StreamReader(@"vstup.txt")) //@"C:\Users\toman\source\repos\Pizza\Pizza\vstup.txt"
		{
			string line = sr.ReadLine();
			string[] nums = line.Split(" ");
			foreach (string s in nums)
			{
				orders.Add(int.Parse(s));
			}
		}

		int c = 6;
		for (int i = 0; i < orders.Count; i++)
        {
			processed += (orders[i] / c);
			orders[i] = orders[i] % c;
        }

		int[] weight = orders.ToArray();
		int n = weight.Length;
		Console.WriteLine(nextFit(weight, n, c)+processed);
	}
}

