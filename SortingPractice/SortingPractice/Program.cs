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

            for (int i = 0; i < arr.Length - 1; i++)
            {
                int maxIndex = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] > arr[maxIndex]) 
                        maxIndex = j;
                }
                Swap(arr, maxIndex, i);
            }
            Console.WriteLine(string.Join(", ", arr));

        }
    }
}
