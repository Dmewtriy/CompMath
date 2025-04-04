using System;

namespace lab3
{
    /// <summary>
    /// Интерфейс для функций, которые могут быть вычислены и отображены
    /// </summary>
    public interface IFunction
    {
        /// <summary>
        /// Вычисляет значение функции в точке x
        /// </summary>
        /// <param name="x">Аргумент функции</param>
        /// <returns>Значение функции</returns>
        double Calculate(double x);

        /// <summary>
        /// Получает набор точек для построения графика функции
        /// </summary>
        /// <param name="minX">Минимальное значение X</param>
        /// <param name="maxX">Максимальное значение X</param>
        /// <param name="pointsCount">Количество точек</param>
        /// <returns>Массив точек [pointsCount, 2], где [i, 0] - координата X, [i, 1] - координата Y</returns>
        double[,] GetPoints(double minX, double maxX, int pointsCount = 100);

        /// <summary>
        /// Метка функции для отображения в легенде
        /// </summary>
        string Label { get; set; }
    }
} 