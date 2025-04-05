using System;

namespace lab3
{
    /// <summary>
    /// Интерфейс для методов интерполяции
    /// </summary>
    public interface IInterpolationMethod : IFunction
    {
        /// <summary>
        /// Массив X-координат опорных точек
        /// </summary>
        double[] X { get; }

        /// <summary>
        /// Массив Y-координат опорных точек
        /// </summary>
        double[] Y { get; }

        /// <summary>
        /// Количество опорных точек
        /// </summary>
        int Count { get; }
    }
} 