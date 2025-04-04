using System;

namespace lab3
{
    /// <summary>
    /// Интерфейс для методов аппроксимации
    /// </summary>
    public interface IApproximationMethod : IFunction
    {
        /// <summary>
        /// Коэффициенты аппроксимирующей функции
        /// </summary>
        double[] Coefficients { get; }
    }
} 