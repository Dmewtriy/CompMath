using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    public class GaussSolver
    {
        // Функция для перестановки строк
        private static void SwapRows(float[,] matrix, int row1, int row2)
        {
            int n = matrix.GetLength(1); // Количество столбцов
            for (int j = 0; j < n; j++)
            {
                float temp = matrix[row1, j];
                matrix[row1, j] = matrix[row2, j];
                matrix[row2, j] = temp;
            }
        }

        // Прямой ход с выбором главного элемента
        private static void ForwardEliminationWithPivoting(float[,] matrix)
        {
            int n = matrix.GetLength(0);
            float factor = 0.0f;
            // Перебор столбцов
            for (int k = 0; k < n; k++)
            {
                // Выбор главного элемента
                int maxRow = k;
                for (int i = k; i < n; i++)
                {
                    if (Math.Abs(matrix[i, k]) > Math.Abs(matrix[maxRow, k]))
                    {
                        maxRow = i;
                    }
                }

                // Перестановка строк, если нужно
                if (maxRow != k)
                {
                    SwapRows(matrix, k, maxRow);
                }

                if (matrix[k, k] == 0)
                {
                    throw new InvalidOperationException("Ведущий элемент равен нулю. Решение невозможно.");
                }

                // Обнуление элементов под главной диагональю
                for (int m = k + 1; m < n; m++)
                {
                    factor = matrix[m, k] / matrix[k, k];
                    for (int l = k; l < n + 1; l++) // n + 1, так как включаем вектор B
                    {
                        matrix[m, l] -= factor * matrix[k, l];
                    }
                }
            }
        }

        // Прямой ход без выбора главного элемента
        private static void ForwardEliminationWithoutPivoting(float[,] matrix)
        {
            int n = matrix.GetLength(0);

            for (int k = 0; k < n - 1; k++)
            {
                if (matrix[k, k] == 0)
                {
                    throw new InvalidOperationException("Ведущий элемент равен нулю. Решение невозможно.");
                }

                // Обнуление элементов под главной диагональю
                for (int m = k + 1; m < n; m++)
                {
                    float factor = matrix[m, k] / matrix[k, k];
                    for (int l = k; l < n + 1; l++) // n + 1, так как включаем вектор B
                    {
                        matrix[m, l] -= factor * matrix[k, l];
                    }
                }
            }
        }

        // Обратный ход
        private static float[] BackSubstitution(float[,] matrix)
        {
            int n = matrix.GetLength(0);
            float[] X = new float[n];

            for (int i = n - 1; i >= 0; i--)
            {
                float sum = 0;
                for (int j = i + 1; j < n; j++)
                {
                    sum += matrix[i, j] * X[j];
                }
                X[i] = (matrix[i, n] - sum) / matrix[i, i]; // matrix[i, n] — это элемент вектора B
            }

            return X;
        }

        // Основной метод решения системы методом Гаусса с выбором главного элемента
        public float[] SolveWithPivoting(Matrix matrix)
        {
            int n = matrix.GetLength();
            float[,] data = matrix.GetData(); // Получаем данные матрицы

            try
            {
                // Прямой ход с выбором главного элемента
                ForwardEliminationWithPivoting(data);

                // Обратный ход
                return BackSubstitution(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при решении методом Гаусса с выбором главного элемента: {ex.Message}");
                throw;
            }
        }

        // Основной метод решения системы методом Гаусса без выбора главного элемента
        public float[] SolveWithoutPivoting(Matrix matrix)
        {
            int n = matrix.GetLength();
            float[,] data = matrix.GetData(); // Получаем данные матрицы

            try
            {
                // Прямой ход без выбора главного элемента
                ForwardEliminationWithoutPivoting(data);

                // Обратный ход
                return BackSubstitution(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при решении методом Гаусса без выбора главного элемента: {ex.Message}");
                throw;
            }
        }
    }
}
