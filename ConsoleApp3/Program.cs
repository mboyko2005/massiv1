using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace ConsoleApp3
{
	class Program
	{
		static void Main(string[] args)
		{
			const int N = 1000;
			int[] array = new int[1000000];
			HashSet<int> hashSet = new HashSet<int>();
			Random rnd = new Random();

			for (int i = 0; i < array.Length; i++)
			{
				int value = rnd.Next(1000000);
				array[i] = value;
				hashSet.Add(value);
			}
			long arrayElapsedTicksTotal = 0;
			for (int i = 0; i < N; i++)
			{
				Stopwatch arrayStopwatch = Stopwatch.StartNew();
				int lastElement = array[array.Length - 1];
				int arrayIndex = Array.LastIndexOf(array, lastElement);
				arrayStopwatch.Stop();
				arrayElapsedTicksTotal += arrayStopwatch.ElapsedTicks;
			}
			long arrayAverageTicks = arrayElapsedTicksTotal / N;
			Console.WriteLine("Среднее время поиска последнего элемента в массиве (в тиках): " + arrayAverageTicks);
			long hashSetElapsedTicksTotal = 0;
			for (int i = 0; i < N; i++)
			{
				Stopwatch hashSetStopwatch = Stopwatch.StartNew();
				bool contains = hashSet.Contains(array[array.Length - 1]);
				hashSetStopwatch.Stop();
				hashSetElapsedTicksTotal += hashSetStopwatch.ElapsedTicks;
			}
			long hashSetAverageTicks = hashSetElapsedTicksTotal / N;
			Console.WriteLine("Среднее время поиска последнего элемента в HashSet (в тиках): " + hashSetAverageTicks);
		}
	}
}
