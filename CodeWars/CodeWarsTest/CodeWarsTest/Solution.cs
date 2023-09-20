public class Solution
{
    public int[] PlusOne(int[] digits)
    {
        string digitString = String.Join("", digits);
        digitString.Replace("-", "");
        double number = double.Parse(digitString) + 1; 

        return Array.ConvertAll(number.ToString().ToCharArray(), c => (int)char.GetNumericValue(c));
    }
}
