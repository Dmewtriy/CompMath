using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    internal class Methods
    {
        public delegate double Function(double x);

        private readonly Function f;
        private double h;

        private double[] fValues;
        private int n;

        public Methods(Function function, double a = 3, double b = 13, int n = 550)
        {
            f = function;
            this.n = n;

            fValues = new double[n + 1];

            h = (b - a) / (double)n;

            for (int i = 0; i <= n; i++)
            {
                fValues[i] = f.Invoke(a + i * h);
            }
        }


        private void FindStep()
        {

        }

        public double RightRectangle()
        {
            double result = 0;

            for (int i = 1; i <= n; i++)
            {
                result += h * fValues[i];
            }

            return result;
        }

        public double Trapezoid()
        {
            double result = 0;

            for (int i = 1; i <= n - 1; i++)
            {
                result += 2 * fValues[i];
            }

            return h * 0.5f * (result + fValues[0] + fValues[fValues.Length - 1]);
        }

        public double Simpson()
        {
            double result = 0;

            for (int i = 1; i <= n - 1; i++)
            {
                if (i % 2 == 0)
                {
                    result += 2 * fValues[i];

                }
                else
                {
                    result += 4 * fValues[i];

                }
            }

            return h / 3.0f * (fValues[0] + result + fValues[fValues.Length - 1]);
        }


        public override string ToString()
        {
            return $"Метод Правых прямоугольников: {RightRectangle()}\n" +
                $"Метод Трапеций: {Trapezoid()}\n" +
                $"Метод Симпсона: {Simpson()}";
        }

    }
}
