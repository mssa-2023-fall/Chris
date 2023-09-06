using System.ComponentModel;
using System;
namespace ConsoleApp1
{
    internal class Program
    {
        public static void Swap(int[] array, int index0, int index1)
        {
            (array[index0], array[index1]) = (array[index1], array[index0]);
        }



        public static void Main(string[] args)
        {
            int[] arr = new int[5] { 85, 22, 63, 91, 24 };
            int max = 0;

            foreach (var item in arr)
            {
                if (item > max)
                    max = item;
            }
            Console.WriteLine(max);
            Swap(arr, Array.IndexOf(arr, max), arr.Length - 1);
        }
    }
}