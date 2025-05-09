using System;

namespace lab5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Methods methods = new Methods(x => (2.5f * x * x - 0.1f) / (Math.Log(x) + 1), 3, 13, 0.1);
            Console.WriteLine(methods.ToString());
        }
    }
}
