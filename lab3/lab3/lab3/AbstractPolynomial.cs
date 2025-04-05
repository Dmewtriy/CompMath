using System;

namespace lab3
{
    /// <summary>
    /// Абстрактный класс для многочленов с коэффициентами
    /// </summary>
    public abstract class AbstractPolynomial : AbstractFunction, IApproximationMethod
    {
        /// <summary>
        /// Коэффициенты многочлена (a0, a1, a2, ..., an)
        /// </summary>
        public double[] Coefficients { get; protected set; }

        /// <summary>
        /// Степень многочлена
        /// </summary>
        public int Degree => Coefficients.Length - 1;

        /// <summary>
        /// Конструктор многочлена с заданными коэффициентами
        /// </summary>
        /// <param name="coefficients">Коэффициенты многочлена</param>
        protected AbstractPolynomial(double[] coefficients)
        {
            ValidateCoefficients(coefficients);

            // Сохраняем копию массива коэффициентов для предотвращения изменения извне
            Coefficients = new double[coefficients.Length];
            Array.Copy(coefficients, Coefficients, coefficients.Length);
        }

        /// <summary>
        /// Проверяет корректность коэффициентов
        /// </summary>
        private void ValidateCoefficients(double[] coefficients)
        {
            if (coefficients == null)
                throw new ArgumentNullException(nameof(coefficients), "Коэффициенты не могут быть null");

            if (coefficients.Length == 0)
                throw new ArgumentException("Должен быть хотя бы один коэффициент", nameof(coefficients));
        }

        /// <summary>
        /// Вычисляет значение многочлена в точке x
        /// </summary>
        /// <param name="x">Точка, в которой вычисляется значение</param>
        /// <returns>Значение многочлена</returns>
        public override double Calculate(double x)
        {
            // P(x) = a_0 + a_1*x + a_2*x^2 + ... + a_n*x^n
            // P(x) = a_0 + x*(a_1 + x*(a_2 + ... + x*(a_{n-1} + x*a_n)...))
            double result = Coefficients[Degree];
            for (int i = Degree - 1; i >= 0; i--)
            {
                result = result * x + Coefficients[i];
            }
            return result;
        }
    }
} 