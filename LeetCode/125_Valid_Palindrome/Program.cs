using System;
using System.Linq;
using System.Text.RegularExpressions;

public class Solution
{
    public bool IsPalindrome(string s)
    {
        s = s.ToLower();
        s = Regex.Replace(s, @"[^a-z0-9]", "");
        string reversed = string.Concat(s.Reverse());

        return s == reversed;
    }
}