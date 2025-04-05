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
                //EnterMatrix enterMatrix = new EnterMatrix();
                //Matrix matrix = enterMatrix.Matrix;

                Matrix matrix = new Matrix(3);
                matrix[0] = new float[4] {2, 1, 0, 18};
                matrix[1] = new float[4] {1, 3, 1, 10};
                matrix[2] = new float[4] {0, 2, 4, 18};

                Console.WriteLine("\nИсходная матрица:");
                matrix.PrintMatrix();

                // Выбор метода решения
                Console.WriteLine("\nВыберите метод решения:");
                Console.WriteLine("1. Метод Гаусса с выбором главного элемента");
                Console.WriteLine("2. Метод Гаусса без выбора главного элемента");
                Console.Write("Введите номер метода: ");
                string choice = Console.ReadLine();

                GaussSolver gaussSolver = new GaussSolver();
                float[] solution;

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
                    float[] iterationSolution = iterationsSolver.SolveWithChecking(matrix);
                    PrintSolution(iterationSolution);
                }
                else
                {
                    Console.WriteLine("Матрица не удовлетворяет условию диагонального преобладания. Метод простых итераций может не сходиться.");
                    SimpleIterationsSolver iterationsSolver = new SimpleIterationsSolver();
                    float[] iterationSolution = iterationsSolver.SolveWithOutChecking(matrix);
                    PrintSolution(iterationSolution);
                }

                Console.WriteLine("\nМетод прогонки:");

                if (TriDiagonal.IsTridiagonal(matrix.GetData()))
                {
                    float[] triDiagonalSolution = TriDiagonal.Solve(matrix.GetData());
                    PrintSolution(triDiagonalSolution);
                }
                else
                {
                    Console.WriteLine("Матрица не трехдиагональная.");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        private static bool CheckDiagonalDominance(Matrix matrix)
        {
            int n = matrix.GetLength();
            float[,] data = matrix.GetData();
/*            bool f1 = false, f2 = false;*/

            // Проверка диагонального преобладания по строкам
            for (int i = 0; i < n; i++)
            {
                float diagonal = Math.Abs(data[i, i]);
                float rowSum = 0;
                for (int j = 0; j < n; j++)
                {
                    if (i != j)
                    {
                        rowSum += Math.Abs(data[i, j]);
                    }
                }
                if (diagonal <= rowSum)
                {
                    return false; // Нет диагонального преобладания в строке
                }
            }
            return true;

            /*// Проверка диагонального преобладания по столбцам
            for (int j = 0; j < n; j++)
            {
                float diagonal = Math.Abs(data[j, j]);
                float columnSum = 0;
                for (int i = 0; i < n; i++)
                {
                    if (i != j)
                    {
                        columnSum += Math.Abs(data[i, j]);
                    }
                }
                if (diagonal <= columnSum)
                {
                    return f2; // Нет диагонального преобладания в столбце
                }
            }
            f2 = true;

            return (f1 || f2); // Диагональное преобладание есть и по строкам, и по столбцам*/
        }

        private static void PrintSolution(float[] solution)
        {
            Console.WriteLine("Решение:");
            for (int i = 0; i < solution.Length; i++)
            {
                Console.WriteLine($"x{i + 1} = {solution[i]:F6}");
            }
        }
    }
}