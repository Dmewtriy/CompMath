using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    internal class Spline
    {
        private double[] a;
        private double[] b;
        private double[] c;
        private double[] d;

        private int n;
        private double[] x;
        private double[] y;

        private double[] h;

        public Spline(double[] x, double[] y)
        {
            if (x.Length != y.Length)
            {
                throw new ArgumentException("Опа! Ошибка: количество точек не равное");
            }

            n = x.Length;

            a = new double[n - 1];
            b = new double[n - 1];
            c = new double[n - 1];
            d = new double[n - 1];

            h = new double[n - 1];

            SetIntervals();

        }

        private void SetIntervals()
        {
            for (int i = 0; i < n - 1; i++)
            {
                h[i] = x[i + 1] - x[i];
            }
        }
    }
}
