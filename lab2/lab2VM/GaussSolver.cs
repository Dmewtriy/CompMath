using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2VM
{
    public class GaussSolver
    {
        public double[] Solve(Matrix matrix)
        {
            int n = matrix.GetLength(0);
            float[,] data = matrix.GetData(); // Получаем данные матрицы

            // Прямой ход метода Гаусса
            for (int i = 0; i < n; i++)
            {
                // Выбор главного элемента по столбцу
                int maxRow = i;
                for (int k = i + 1; k < n; k++)
                {
                    if (Math.Abs(data[k, i]) > Math.Abs(data[maxRow, i]))
                    {
                        maxRow = k;
                    }
                }

                // Перестановка строк
                for (int k = i; k <= n; k++)
                {
                    float temp = data[maxRow, k];
                    data[maxRow, k] = data[i, k];
                    data[i, k] = temp;
                }

                // Обнуление элементов ниже главной диагонали
                for (int k = i + 1; k < n; k++)
                {
                    float factor = data[k, i] / data[i, i];
                    for (int j = i; j <= n; j++)
                    {
                        data[k, j] -= factor * data[i, j];
                    }
                }
            }

            // Обратный ход метода Гаусса
            double[] solution = new double[n];
            for (int i = n - 1; i >= 0; i--)
            {
                solution[i] = data[i, n] / data[i, i];
                for (int k = i - 1; k >= 0; k--)
                {
                    data[k, n] -= data[k, i] * (float)solution[i];
                }
            }

            return solution;
        }
    }
}
