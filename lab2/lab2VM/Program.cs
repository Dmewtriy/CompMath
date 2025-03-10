using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2VM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EnterMatrix m = new EnterMatrix();
            Matrix m1 = m.Matrix;
            Matrix m2 = m.Matrix;
            m1[0, 0] = 5.5f;
            m1.PrintMatrix();
            Console.WriteLine("---------------");
            m2.PrintMatrix();

            
        }
    }
}
