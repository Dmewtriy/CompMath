using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    internal class Program
    {
        static double f (double x)
        {
            return (2.5f * x * x - 0.1f) / (Math.Log(x) + 1);
        }
        static void Main(string[] args)
        {
            Methods methods = new Methods(f);

            Console.WriteLine(methods.ToString());
        
        }
    }
}
