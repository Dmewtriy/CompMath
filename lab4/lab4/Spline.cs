using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    public class SplineInterpreter
    {
        public float[] x;
        public float[] phi;
        public float[] limits = new float[2];

        private float[] firstDerY;

        public SplineInterpreter(float[] x, float[] phi, float[] limits)
        {
            this.x = x;
            this.phi = phi;
            this.limits = limits;
        }

        public SplineInterpreter(int n)
        {
            x = new float[n];
            phi = new float[n];
        }

        public SplineInterpreter()
        {

        }
        // Метод для вычисления первой производной
        public float[] ComputeFirstDerivative()
        {
            int n = x.Length;
            float[] derivative = new float[n];

            for (int i = 0; i < n; i++)
            {
                if (i == 0) // Левая граница
                {
                    float deltaX = x[1] - x[0];
                    derivative[i] = (phi[1] - phi[0]) / (deltaX);
                }
                else if (i == n - 1) // Правая граница
                {
                    float deltaX = x[n - 1] - x[n - 2];
                    derivative[i] = (phi[n - 1] - phi[n - 2]) / (deltaX);
                }
                else // Внутренние точки
                {
                    float deltaX = x[i + 1] - x[i - 1];
                    derivative[i] = (phi[i + 1] - phi[i - 1]) / deltaX;
                }
            }

            return derivative;
        }

        public float[] ComputeSecondDerivative()
        {
            firstDerY = ComputeFirstDerivative();
            int n = x.Length;
            float[] derivative = new float[n];

            for (int i = 0; i < n; i++)
            {
                if (i == 0) // Левая граница
                {
                    float deltaX = x[1] - x[0];
                    derivative[i] = (firstDerY[1] - firstDerY[0]) / (deltaX);
                }
                else if (i == n - 1) // Правая граница
                {
                    float deltaX = x[n - 1] - x[n - 2];
                    derivative[i] = (firstDerY[n - 1] - firstDerY[n - 2]) / (deltaX);
                }
                else // Внутренние точки
                {
                    float deltaX = x[i + 1] - x[i - 1];
                    derivative[i] = (firstDerY[i + 1] - firstDerY[i - 1]) / deltaX;
                }
            }

            return derivative;
        }
    }

    public class Spline
    {
        private const float step = 0.02f;

        private float[] a;
        private float[] b;
        private float[] c;
        private float[] d;

        private readonly int n;
        private float[] x;
        private float[] y;

        private float[] h;

        public float[] A => a;
        public float[] B => b;
        public float[] C => c;
        public float[] D => d;

        public Spline(float[] x, float[] y)
        {
            if (x.Length != y.Length)
            {
                throw new ArgumentException("Ошибка: количество точек не равное.");
            }

            n = x.Length;

            this.x = x;
            this.y = y;

            Array.Sort(this.x, this.y);

            a = new float[n];
            b = new float[n];
            c = new float[n];
            d = new float[n];

            h = new float[n];

            SetIntervals();
            FindCoefficients();

        }

        private void FindCoefficients()
        {
            FindCoeffC();

            for (int i = 0; i < n - 1; i++) 
            {
                a[i] = FindCoeffA(i);
                b[i] = FindCoeffB(i);
                d[i] = FindCoeffD(i);
            }
        }

        private float FindCoeffA(int index)
        {
            return y[index];
        }
        private float FindCoeffB(int index)
        {
            return (y[index + 1] - y[index]) / h[index] - ((c[index + 1] + 2 * c[index]) * h[index]) / 3;
        }
        private void FindCoeffC()
        {
            
            Matrix matrix = new Matrix(n - 2);
            for (int i = 1; i < n - 1; i++) 
            {
                for (int j = 0; j < matrix.GetLength(); j++)
                {
                    if (j == i - 2)
                    {
                        matrix[i - 1, j] = h[i - 1];
                    }
                    else if (j == i - 1)
                    {
                        matrix[i - 1, j] = 2 * (h[i - 1] + h[i]);
                    }
                    else if (j == i)
                    {
                        matrix[i - 1, j] = h[i];
                    }
                }
                matrix[i - 1, n - 2] = 3 * ((y[i + 1] - y[i]) / h[i] - (y[i] - y[i - 1]) / h[i - 1]);
                //h[i - 1] * c[i - 1] + 2 * (h[i - 1] + h[i]) * c[i] + h[i] * c[i + 1]
                // = 3 * ((y[i + 1] - y[i]) / h[i] - (y[i] - y[i - 1]) / h[i - 1])
            }

            if (TriDiagonal.IsTridiagonal(matrix.GetData()))
            {
                float[] coefficients = TriDiagonal.Solve(matrix.GetData());
                for (int i = 1; i < n - 1; i++)
                {
                    c[i] = coefficients[i - 1];
                }
            }
            else
            {
                throw new Exception("Некорректная матрица. Матрица не трехдиагональная");
            }

        }
        private float FindCoeffD(int index)
        {
            return (c[index + 1] - c[index]) / (3 * h[index]);
        }


        public List<SplineInterpreter> Phi_fun()
        {

            List<SplineInterpreter> splineData = new List<SplineInterpreter>();


            for (int i = 0; i < n - 1; i++)
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

        private float GetPhi(float arg, int numberSpline)
        {
            return a[numberSpline] + b[numberSpline] * (arg - x[numberSpline]) + c[numberSpline] * (float)Math.Pow(arg - x[numberSpline], 2) 
                + d[numberSpline] * (float)Math.Pow(arg - x[numberSpline], 3);
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
