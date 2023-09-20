using System;

internal class Program
{
    private static void Main(string[] args)
    {
        string myString = "Reverse a string";
        char[] myCharArray = myString.ToCharArray();
        char[] myReversedArray = new char[myCharArray.Length];

        for(int i = 0; i < myCharArray.Length; i++)
        {
            myReversedArray[i] = myCharArray[myCharArray.Length - i - 1];
        }
        string reversedString = new string(myReversedArray);
        Console.WriteLine(reversedString);
    }
}