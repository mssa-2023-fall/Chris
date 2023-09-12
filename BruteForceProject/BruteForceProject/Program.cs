internal class Program
{
    private static void Main(string[] args)
    {
        string password = "abc123";
        string abc123 = "abcdefghijklmnopqrstuvwxyz1234567890";

        //Nested loop probably isn't super efficient but I wanted to try.
        for (int a = 0; a < abc123.Length; a++)
        {
            for (int b = 0; b < abc123.Length; b++)
            {
                for (int c = 0; c < abc123.Length; c++)
                {
                    for (int d = 0; d < abc123.Length; d++)
                    {
                        for (int e = 0; e < abc123.Length; e++)
                        {
                            for (int f = 0; f < abc123.Length; f++)
                            {
                                string candidatePassword = $"{abc123[a]}{abc123[b]}{abc123[c]}{abc123[d]}{abc123[e]}{abc123[f]}";

                                if (candidatePassword == password)
                                {
                                    Console.WriteLine($"Password cracked: {candidatePassword}");
                                    return;
                                }
                            }
                        }
                    }
                }
            }
        }

        Console.WriteLine("Password not cracked");
    }
}
