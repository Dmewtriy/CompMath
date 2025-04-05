using System;

namespace lab3
{
    /// <summary>
    /// Абстрактный класс, реализующий базовую функциональность для всех функций
    /// </summary>
    public abstract class AbstractFunction : IFunction
    {
        /// <summary>
        /// Метка функции для отображения в легенде
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Абстрактный метод для вычисления значения функции
        /// </summary>
        public abstract double Calculate(double x);

        /// <summary>
        /// Получает точки для построения графика функции
        /// </summary>
        public double[,] GetPoints(double minX, double maxX, int pointsCount = 100)
        {
            if (minX >= maxX)
                throw new ArgumentException("Минимальное значение X должно быть меньше максимального");

            if (pointsCount <= 1)
                throw new ArgumentException("Количество точек должно быть больше 1");

            double[,] points = new double[pointsCount, 2];
            double step = (maxX - minX) / (pointsCount - 1);

            for (int i = 0; i < pointsCount; i++)
            {
                points[i, 0] = minX + step * i;
                points[i, 1] = Calculate(points[i, 0]);
            }

            return points;
        }
    }
} 