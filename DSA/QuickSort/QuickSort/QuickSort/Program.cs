using System;

public class Program
{
    public static void Main()
    {
        int[] array = { 8, 2, 5, 3, 9, 4, 7, 6, 1 };

        QuickSort(array, 0, array.Length - 1);

        foreach (int i in array)
        {
            Console.Write(i);
        }
    }

    private static void QuickSort(int[] array, int start, int end)
    {
        if (end <= start) return;

        int pivot = Partition(array, start, end);
        QuickSort(array, start, pivot - 1);
        QuickSort(array, pivot + 1, end);
    }

    private static int Partition(int[] array, int start, int end)
    {
        int pivot = array[end];
        int i = start - 1;

        for (int j = start; j <= end; j++)
        {
            if (array[j] < pivot)
            {
                i++;
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }

        i++;
        int temp2 = array[i];
        array[i] = array[end];
        array[end] = temp2;

        return i;
    }
}
