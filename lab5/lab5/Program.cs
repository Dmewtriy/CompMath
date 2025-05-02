using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Methods methods = new Methods(x => (2.5f * x * x - 0.1f) / (Math.Log(x) + 1));
            Console.WriteLine(methods.ToString());
        }1 4
    }
}
