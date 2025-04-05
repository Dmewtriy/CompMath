using System;

namespace lab3
{
    /// <summary>
    /// Интерполяционный многочлен в форме Лагранжа
    /// </summary>
    public class LagrangePolynomial : AbstractInterpolationMethod
    {
        /// <summary>
        /// Создает интерполяционный многочлен в форме Лагранжа по набору опорных точек
        /// </summary>
        /// <param name="x">Массив X-координат опорных точек</param>
        /// <param name="y">Массив Y-координат опорных точек</param>
        public LagrangePolynomial(double[] x, double[] y) : base(x, y) { }

        /// <summary>
        /// Вычисляет значение многочлена Лагранжа в точке x
        /// </summary>
        /// <param name="x">Точка, в которой вычисляется значение</param>
        /// <returns>Значение многочлена</returns>
        public override double Calculate(double x)
        {
            double result = 0;

            for (int i = 0; i < Count; i++)
            {
                double term = Y[i];
                for (int j = 0; j < Count; j++)
                {
                    if (j != i)
                    {
                        term *= (x - X[j]) / (X[i] - X[j]);
                    }
                }
                result += term;
            }

            return result;
        }
    }
} 