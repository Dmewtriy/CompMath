using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    internal class SolveDU
    {
        private int x0;
        private int y0;
        private int xn;
        private double h;

        public delegate double Function(double x, double y);
        private readonly Function f;

        private delegate double TrueSolution(double x);
        private readonly TrueSolution solution;
        public SolveDU(int x0, int y0, int xn, double h)
        {
            this.x0 = x0;
            this.y0 = y0;
            this.xn = xn;
            this.h = h;

            f = (x, y) => (y - 2 * y * x);
            solution = x => Math.Pow(Math.E, x - Math.Pow(x, 2));
        }

        public (double[] x, double[] y) EulerMethod()
        {
            double[] x = new double[(int)Math.Ceiling((xn - x0) / h) + 1];
            double[] y = new double[x.Length];
            x[0] = x0;
            y[0] = y0;

            for (int i = 1; i < x.Length; i++)
            {
                x[i] = x[i - 1] + h;
                y[i] = y[i - 1] + h * f(x[i - 1], y[i - 1]);
                y[i] = Math.Round(y[i], 6);
            }
            return (x, y);
        }

        public (double[] x, double[] y) ModifiedEulerMethod()
        {
            double[] x = new double[(int)Math.Ceiling((xn - x0) / h) + 1];
            double[] y = new double[x.Length];
            x[0] = x0;
            y[0] = y0;
            double h_2 = h / 2.0;
            double f_xy = 0;

            for (int i = 1; i < x.Length; i++)
            {
                f_xy = f(x[i - 1], y[i - 1]);
                x[i] = x[i - 1] + h;
                y[i] = y[i - 1] + h * f(x[i - 1] + h_2, y[i - 1] + h_2 * f_xy);
                y[i] = Math.Round(y[i], 6);
            }
            return (x, y);
        }

        public (double[] x, double[] y) RKMMethod(double h, double epsilon = 0.01)
        {
            List<double> xList = new List<double>();
            List<double> yList = new List<double>();

            double x = x0;
            double y = y0;

            double k1, k2, k3, k4, k5;
            double localError;

            xList.Add(x);
            yList.Add(y);

            while (x < xn)
            {
                if (x + h > xn)
                    h = xn - x;

                k1 = h * f(x, y);
                k2 = h * f(x + h / 3.0, y + k1 / 3.0);
                k3 = h * f(x + h / 3.0, y + k1 / 6.0 + k2 / 6.0);
                k4 = h * f(x + h / 2.0, y + k1 / 8.0 + k3 * 3 / 8.0);
                k5 = h * f(x + h, y + k1 / 2.0 - 3 * k3 / 2.0 + 2 * k4);

                localError = (2 * k1 - 9 * k3 + 8 * k4 - k5) / 30.0;

                if (Math.Abs(localError) >= epsilon)
                {
                    h /= 2; // Уменьшаем шаг и пробуем снова
                    continue;
                }

                // Шаг подходит — делаем шаг
                y = y + k1 / 6.0 + k4 * 2 / 3.0 + k5 / 6.0;
                x += h;

                xList.Add(x);
                yList.Add(y);

                // Увеличиваем шаг, если погрешность мала
                if (Math.Abs(localError) <= epsilon / 32.0 && h * 2 <= xn - x)
                {
                    h *= 2;
                }
            }

            return (xList.ToArray(), yList.ToArray());
        }

        public (double[] x, double[] y) AdamsMethod2order()
        {
            (double[] x, double[] y) = ModifiedEulerMethod();

            double[] F = new double[2];
            F[0] = f(x[0], y[0]);
            F[1] = f(x[1], y[1]);

            for (int i = 2; i < x.Length; i++)
            {
                y[i] = y[i - 1] + h / 2.0 * (3 * F[1] - F[0]);
                F[0] = F[1];
                F[1] = f(x[i], y[i]);
            }
            return (x, y);

        }
    }
}
