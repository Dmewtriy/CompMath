using System;

namespace lab3
{
    /// <summary>
    /// Многочлен заданной степени с известными коэффициентами
    /// </summary>
    public class CustomPolynomial : AbstractPolynomial
    {
        /// <summary>
        /// Создает многочлен с заданными коэффициентами
        /// </summary>
        /// <param name="coefficients">Коэффициенты многочлена (a0, a1, a2, ..., an)</param>
        public CustomPolynomial(double[] coefficients) : base(coefficients)
        {
            if (coefficients == null)
                throw new ArgumentNullException(nameof(coefficients), "Коэффициенты не могут быть null");
                
            if (coefficients.Length < 1)
                throw new ArgumentException("Должен быть хотя бы один коэффициент", nameof(coefficients));
        }
    }
} 