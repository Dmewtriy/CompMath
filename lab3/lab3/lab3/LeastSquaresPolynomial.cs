using System;

namespace lab3
{
    /// <summary>
    /// Аппроксимация методом наименьших квадратов (многочлен заданной степени)
    /// </summary>
    public class LeastSquaresPolynomial : AbstractPolynomial
    {
        private readonly double[] _x;
        private readonly double[] _y;
        private readonly int _degree;

        /// <summary>
        /// Создает многочлен наименьших квадратов заданной степени
        /// </summary>
        /// <param name="x">Массив X-координат опорных точек</param>
        /// <param name="y">Массив Y-координат опорных точек</param>
        /// <param name="degree">Степень аппроксимирующего многочлена</param>
        public LeastSquaresPolynomial(double[] x, double[] y, int degree) 
            : base(CalculateCoefficients(x, y, degree))
        {
            if (degree < 0)
                throw new ArgumentException("Степень должна быть неотрицательной");

            if (x == null)
                throw new ArgumentNullException(nameof(x), "Массив X не может быть null");

            if (y == null)
                throw new ArgumentNullException(nameof(y), "Массив Y не может быть null");

            if (x.Length != y.Length)
                throw new ArgumentException("Количество значений X и Y должно совпадать");

            if (x.Length <= degree)
                throw new ArgumentException($"Для построения многочлена степени {degree} необходимо минимум {degree + 1} точек");

            // Сохраняем копии массивов
            _x = new double[x.Length];
            _y = new double[y.Length];
            Array.Copy(x, _x, x.Length);
            Array.Copy(y, _y, y.Length);
            _degree = degree;
        }

        /// <summary>
        /// Вычисляет коэффициенты многочлена методом наименьших квадратов
        /// </summary>
        private static double[] CalculateCoefficients(double[] x, double[] y, int degree)
        {
            if (x == null || y == null)
                throw new ArgumentNullException("Массивы точек не могут быть null");

            if (x.Length != y.Length)
                throw new ArgumentException("Массивы x и y должны иметь одинаковую длину");

            if (x.Length <= degree)
                throw new ArgumentException($"Для построения многочлена степени {degree} необходимо минимум {degree + 1} точек");

            // Построение матрицы системы уравнений 
            int k = degree;
            double[,] matrix = new double[k + 1, k + 2];

            // Заполнение матрицы
            for (int i = 0; i <= k; i++)
            {
                for (int j = 0; j <= k; j++)
                {
                    matrix[i, j] = 0;
                    for (int l = 0; l < x.Length; l++)
                    {
                        matrix[i, j] += Math.Pow(x[l], i + j);
                    }
                }

                matrix[i, k + 1] = 0;
                for (int l = 0; l < x.Length; l++)
                {
                    matrix[i, k + 1] += Math.Pow(x[l], i) * y[l];
                }
            }

            // Решение системы уравнений методом Гаусса
            double[] coefficients = GaussianElimination(matrix, k + 1);
            return coefficients;
        }

        private static double[] GaussianElimination(double[,] matrix, int n)
        {
            // n - размер квадратной матрицы (без столбца свободных членов)
            // matrix - расширенная матрица системы [n x (n+1)]

            // Прямой ход с выбором главного элемента
            for (int k = 0; k < n; k++)
            {
                // Находим максимальный элемент в текущем столбце
                int maxRow = k;
                double maxValue = Math.Abs(matrix[k, k]);

                for (int i = k + 1; i < n; i++)
                {
                    if (Math.Abs(matrix[i, k]) > maxValue)
                    {
                        maxValue = Math.Abs(matrix[i, k]);
                        maxRow = i;
                    }
                }

                // Меняем строки местами, если нашли максимальный элемент не на диагонали
                if (maxRow != k)
                {
                    for (int j = k; j <= n; j++)
                    {
                        double temp = matrix[k, j];
                        matrix[k, j] = matrix[maxRow, j];
                        matrix[maxRow, j] = temp;
                    }
                }

                // Проверка на вырожденность
                if (Math.Abs(matrix[k, k]) < 1e-10)
                {
                    throw new InvalidOperationException("Матрица системы вырождена");
                }

                // Обнуляем элементы под диагональю
                for (int i = k + 1; i < n; i++)
                {
                    double factor = matrix[i, k] / matrix[k, k];
                    for (int j = k; j <= n; j++)
                    {
                        matrix[i, j] -= factor * matrix[k, j];
                    }
                }
            }

            // Обратный ход
            double[] solution = new double[n];
            for (int i = n - 1; i >= 0; i--)
            {
                solution[i] = matrix[i, n];
                for (int j = i + 1; j < n; j++)
                {
                    solution[i] -= matrix[i, j] * solution[j];
                }
                solution[i] /= matrix[i, i];
            }

            return solution;
        }
    }
} 