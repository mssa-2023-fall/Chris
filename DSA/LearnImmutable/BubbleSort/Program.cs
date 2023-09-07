using System;

internal class Program
{
    private static void Main(string[] args)
    {

        static void BubbleSort(int[] unsortedArray)
        {
            bool sorted;
            for (int i = 0; i < unsortedArray.Length - 1; i++)
            {    sorted = false;

            for (int j = 0; j < unsortedArray.Length-i-1; j++)
            {
                    if (unsortedArray[j] > unsortedArray[j + 1])
                    {
                        (unsortedArray[j], unsortedArray[j + 1]) = (unsortedArray[j + 1], unsortedArray[j]);
                        sorted = true;
                    }
                }
                if (sorted == false) break;
            }
        }

    }
}