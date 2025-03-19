using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2VM
{

    class LinearEquationsSolver
    {
        static void Main()
        {
            try
            {
                // Ввод матрицы
                EnterMatrix enterMatrix = new EnterMatrix();
                Matrix matrix = enterMatrix.Matrix;

                Console.WriteLine("\nИсходная матрица:");
                matrix.PrintMatrix();

                // Решение методом Гаусса
                Console.WriteLine("\nМетод Гаусса:");
                GaussSolver gaussSolver = new GaussSolver();
                double[] gaussSolution = gaussSolver.Solve(matrix);
                PrintSolution(gaussSolution);

                // Решение методом простых итераций
                Console.WriteLine("\nМетод простых итераций:");
                if (CheckDiagonalDominance(matrix))
                {
                    SimpleIterationsSolver iterationsSolver = new SimpleIterationsSolver();
                    double[] iterationSolution = iterationsSolver.Solve(matrix);
                    PrintSolution(iterationSolution);
                }
                else
                {
                    Console.WriteLine("Матрица не удовлетворяет условию диагонального преобладания. Метод простых итераций может не сходиться.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
        private static bool CheckDiagonalDominance(Matrix matrix)
        {
            int n = matrix.GetLength(0);
            float[,] data = matrix.GetData();

            for (int i = 0; i < n; i++)
            {
                float diagonal = Math.Abs(data[i, i]);
                float sum = 0;
                for (int j = 0; j < n; j++)
                {
                    if (i != j)
                    {
                        sum += Math.Abs(data[i, j]);
                    }
                }
                if (diagonal <= sum)
                {
                    return false;
                }
            }
            return true;
        }

        private static void PrintSolution(double[] solution)
        {
            Console.WriteLine("Решение:");
            for (int i = 0; i < solution.Length; i++)
            {
                Console.WriteLine($"x{i + 1} = {solution[i]:F6}");
            }
        }
    }
}
