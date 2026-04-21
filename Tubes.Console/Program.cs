using Tubes.Core;

namespace Tubes.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Test test = new Test();
            Console.WriteLine(test.greet());
        }
    }
}