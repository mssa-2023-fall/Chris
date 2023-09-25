using System;

public static class Kata
{
    public static bool IsPangram(string str)
    {
        str = str.ToLower();
        foreach (char letter in "abcdefghijklmnopqrstuvwxyz")
        {
            if (!str.Contains(letter))
            {
                return false;
            }
        }
        return true;
    }
}

/*
 public static class Kata
{
    public static bool IsPangram(string str)
    {
        str = str.ToLower();
        if (str.Contains('a') &&
            str.Contains('b') &&
            str.Contains('c') &&
            str.Contains('d') &&
            str.Contains('e') &&
            str.Contains('f') &&
            str.Contains('g') &&
            str.Contains('h') &&
            str.Contains('i') &&
            str.Contains('j') &&
            str.Contains('k') &&
            str.Contains('l') &&
            str.Contains('m') &&
            str.Contains('n') &&
            str.Contains('o') &&
            str.Contains('p') &&
            str.Contains('q') &&
            str.Contains('r') &&
            str.Contains('s') &&
            str.Contains('t') &&
            str.Contains('u') &&
            str.Contains('v') &&
            str.Contains('w') &&
            str.Contains('x') &&
            str.Contains('y') &&
            str.Contains('z')
            )
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
*/