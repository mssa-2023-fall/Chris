// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
File.Create("test.txt");
try
{
    File.WriteAllText("test.txt", "Hello World");
}
catch (Exception)
{
    Console.WriteLine("Didn't work.");
    throw;
}