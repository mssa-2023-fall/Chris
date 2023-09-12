using System.Collections;
using System.Security.Cryptography.X509Certificates;


internal class Program
{
    public static void Main(string[] args)
    {
        Stack<string> myStack = new Stack<string>(4);

    

        void testOne()
        {
            myStack.Push("apple");
            myStack.Push("banana");
            myStack.Push("cherry");
            myStack.Pop();
            Console.WriteLine(myStack.Peek());
        }
    }
}