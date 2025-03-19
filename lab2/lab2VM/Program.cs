using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2VM
{

    class Program
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

                // Выбор метода решения
                Console.WriteLine("\nВыберите метод решения:");
                Console.WriteLine("1. Метод Гаусса с выбором главного элемента");
                Console.WriteLine("2. Метод Гаусса без выбора главного элемента");
                Console.Write("Введите номер метода: ");
                string choice = Console.ReadLine();

                GaussSolver gaussSolver = new GaussSolver();
                double[] solution;

                if (choice == "1")
                {
                    Console.WriteLine("\nМетод Гаусса с выбором главного элемента:");
                    solution = gaussSolver.SolveWithPivoting(matrix);
                }
                else if (choice == "2")
                {
                    Console.WriteLine("\nМетод Гаусса без выбора главного элемента:");
                    solution = gaussSolver.SolveWithoutPivoting(matrix);
                }
                else
                {
                    Console.WriteLine("Некорректный выбор метода.");
                    return;
                }

                PrintSolution(solution);

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