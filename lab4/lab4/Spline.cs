using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    public class SplineInterpreter
    {
        public double[] x;
        public double[] phi;
        public double[] limits = new double[2];

        public SplineInterpreter(double[] x, double[] phi, double[] limits)
        {
            this.x = x;
            this.phi = phi;
            this.limits = limits;
        }

        public SplineInterpreter(int n)
        {
            x = new double[n];
            phi = new double[n];
        }

        public SplineInterpreter()
        {

        }
    }

    public class Spline
    {
        private const double step = 0.02;

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

            this.x = x;
            this.y = y;

            a = new double[n - 1];
            b = new double[n - 1];
            c = new double[n - 1];
            d = new double[n - 1];

            h = new double[n - 1];

            SetIntervals();


        }

        public List<SplineInterpreter> Phi_fun(int numSpline)
        {

            List<SplineInterpreter> splineData = new List<SplineInterpreter>();


            for (int i = 0; i < n; i++)
            {
                // Определяем число точек как интервал деленный на шаг
                int numPoint = (int)Math.Ceiling(h[i] / step);
                SplineInterpreter splineElement = new SplineInterpreter(numPoint);

                splineElement.limits[0] = x[i];
                splineElement.limits[1] = x[i + 1];               

                for (int j = 0; j < numPoint; j++)
                {
                    splineElement.x[j] = x[i] + step * j;
                    splineElement.phi[j] = GetPhi(splineElement.x[j], i);
                }
                splineData.Add(splineElement);
            }
            return splineData;
        }

        private double GetPhi(double arg, int numberSpline)
        {
            return a[numberSpline] + b[numberSpline] * (arg - x[numberSpline]) + c[numberSpline] * Math.Pow(arg - x[numberSpline], 2) 
                + d[numberSpline] * Math.Pow(arg - x[numberSpline], 3);
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
