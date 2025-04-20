using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    public class Derivative
    {
        private int n;
        private double[] x;
        private double[] y;

        public Derivative(double[] x, double[] y)
        {
            if (x.Length != y.Length)
            {
                throw new ArgumentException("Опа! Ошибка: количество точек не равное");
            }

            this.x = x;
            this.y = y;
            n = x.Length;
        }

        /*public (double[] x, double[] y) FirstDerivative()
        {
            float a,b,c,d, x_start;
            for (int i = 0; i < n; i++)
            {

            }
        }*/
    }
}
