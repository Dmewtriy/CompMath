using System;

namespace lab3
{
    /// <summary>
    /// Интерполяционный многочлен в форме Ньютона
    /// </summary>
    public class NewtonPolynomial : AbstractInterpolationMethod
    {
        private double[] _dividedDifferences;

        /// <summary>
        /// Создает интерполяционный многочлен в форме Ньютона по набору опорных точек
        /// </summary>
        /// <param name="x">Массив X-координат опорных точек</param>
        /// <param name="y">Массив Y-координат опорных точек</param>
        public NewtonPolynomial(double[] x, double[] y) : base(x, y)
        {
            CalculateDividedDifferences();
        }

        /// <summary>
        /// Вычисляет разделенные разности для многочлена Ньютона
        /// </summary>
        private void CalculateDividedDifferences()
        {
            int n = Count;
            _dividedDifferences = new double[n];

            // Копируем значения Y для использования в качестве разделенных разностей 0-го порядка
            for (int i = 0; i < n; i++)
                _dividedDifferences[i] = Y[i];

            // Вычисляем разделенные разности высших порядков
            for (int j = 1; j < n; j++)
            {
                for (int i = n - 1; i >= j; i--)
                {
                    _dividedDifferences[i] = (_dividedDifferences[i] - _dividedDifferences[i - 1]) / (X[i] - X[i - j]);
                }
            }
        }

        /// <summary>
        /// Вычисляет значение многочлена Ньютона в точке x
        /// </summary>
        /// <param name="x">Точка, в которой вычисляется значение</param>
        /// <returns>Значение многочлена</returns>
        public override double Calculate(double x)
        {
            double result = _dividedDifferences[0];

            double product = 1.0;
            for (int i = 1; i < Count; i++)
            {
                product *= (x - X[i - 1]);
                result += _dividedDifferences[i] * product;
            }

            return result;
        }
    }
} 