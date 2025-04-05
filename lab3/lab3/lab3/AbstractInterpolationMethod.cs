using System;

namespace lab3
{
    /// <summary>
    /// Абстрактный класс для методов интерполяции
    /// </summary>
    public abstract class AbstractInterpolationMethod : AbstractFunction, IInterpolationMethod
    {
        /// <summary>
        /// Массив X-координат опорных точек
        /// </summary>
        public double[] X { get; }

        /// <summary>
        /// Массив Y-координат опорных точек
        /// </summary>
        public double[] Y { get; }

        /// <summary>
        /// Количество опорных точек
        /// </summary>
        public int Count => X.Length;

        /// <summary>
        /// Конструктор для создания метода интерполяции по опорным точкам
        /// </summary>
        /// <param name="x">Массив X-координат опорных точек</param>
        /// <param name="y">Массив Y-координат опорных точек</param>
        protected AbstractInterpolationMethod(double[] x, double[] y)
        {
            // Проверяем аргументы
            ValidateArguments(x, y);

            // Сохраняем копии массивов для предотвращения их изменения извне
            X = new double[x.Length];
            Y = new double[y.Length];
            Array.Copy(x, X, x.Length);
            Array.Copy(y, Y, y.Length);
        }

        /// <summary>
        /// Проверяет корректность входных аргументов
        /// </summary>
        private void ValidateArguments(double[] x, double[] y)
        {
            if (x == null)
                throw new ArgumentNullException(nameof(x), "Массив X не может быть null");

            if (y == null)
                throw new ArgumentNullException(nameof(y), "Массив Y не может быть null");

            if (x.Length != y.Length)
                throw new ArgumentException("Количество значений X и Y должно совпадать");

            if (x.Length < 2)
                throw new ArgumentException("Необходимо минимум две точки для интерполяции");
        }
    }
} 