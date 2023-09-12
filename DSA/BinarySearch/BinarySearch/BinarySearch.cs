using System.Runtime.CompilerServices;

public class BinarySearch
{
    public static void Main(string[] args)
    {
        int[] array = new int[1000000];
        int target = 777666;
        Console.WriteLine($"Searching for {target}. \n");
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = i;
        }

        int index = binarySearch(array, target);

        if (index == -1)
        {
            Console.WriteLine(target + " not found.");
        }
        else
        {
            Console.WriteLine($"Element found at: {index}");
        }

    }

    public static int binarySearch(int[] array, int target)
    {
        int low = 0;
        int high = array.Length - 1;

        if (array.Length == 0) return -1;
        if (array.Length == 1)
        {
            if (array[0] == target) return 0;
            else return -1;
        }
        while (low <= high)
        {
            int middle = low + (high - low) / 2;
            int value = array[middle];
            Console.WriteLine($"middle: {value}");

            if (value < target)
            {
                low = middle + 1;
                Console.WriteLine($"{value} is less than {target}, going left. \n");
            }

            else if (value > target)
            {
                high = middle - 1;
                Console.WriteLine($"{value} is greater than {target}, going right. \n");
            }

            else
            {
                Console.WriteLine($"{value} is the middle value. Search complete.");
                return middle;                
            }
        }
        return -1; //not found
    }
}