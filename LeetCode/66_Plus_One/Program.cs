public class Solution
{
    public int[] PlusOne(int[] digits)
    {
        if (digits != null)
        {
            string numStr = string.Join("", digits);
            double d = double.Parse(numStr);
            double e = d + 1;
            char[] charResult = e.ToString().ToCharArray();

            int[] result = new int[charResult.Length];
            for (int i = 0; i < charResult.Length; i++)
            {
                result[i] = int.Parse(charResult[i].ToString());
            }
            return result;
        }
        else
        {
            return digits;
        }
    }
}


/*
 * You are given a large integer represented as an integer array digits, where each digits[i] is the ith digit of the integer. The digits are ordered from most significant to least significant in left-to-right order. The large integer does not contain any leading 0's.

Increment the large integer by one and return the resulting array of digits.

 

Example 1:

Input: digits = [1,2,3]
Output: [1,2,4]
Explanation: The array represents the integer 123.
Incrementing by one gives 123 + 1 = 124.
Thus, the result should be [1,2,4].
*/
