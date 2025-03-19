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
            // Запрос размерности системы уравнений
            Console.WriteLine("Введите размерность системы (n): ");
            int n = int.Parse(Console.ReadLine());

            // Создание матрицы размера n x (n+1) для хранения коэффициентов и свободных членов
            double[,] matrix = new double[n, n + 1];

            // Ввод коэффициентов матрицы и свободных членов
            Console.WriteLine("Введите коэффициенты матрицы и свободные члены:");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введите {n + 1} чисел для строки {i + 1}:");
                string[] input = Console.ReadLine().Split(' ');
                for (int j = 0; j <= n; j++)
                {
                    matrix[i, j] = double.Parse(input[j]);
                }
            }

            // Решение системы методом Гаусса
            Console.WriteLine("\nМетод Гаусса:");
            double[] gaussSolution = SolveByGauss(matrix);
            PrintSolution(gaussSolution);

            // Проверка условия диагонального преобладания для метода простых итераций
            Console.WriteLine("\nМетод простых итераций:");
            if (CheckDiagonalDominance(matrix))
            {
                // Если условие выполняется, решаем систему методом простых итераций
                double[] iterationSolution = SolveBySimpleIterations(matrix, n);
                PrintSolution(iterationSolution);
            }
            else
            {
                // Если условие не выполняется, выводим предупреждение
                Console.WriteLine("Матрица не удовлетворяет условию диагонального преобладания. Метод простых итераций может не сходиться.");
            }
        }

        // Метод Гаусса для решения системы линейных уравнений
        static double[] SolveByGauss(double[,] matrix)
        {
            int n = matrix.GetLength(0); // Размерность системы

            // Прямой ход метода Гаусса
            for (int i = 0; i < n; i++)
            {
                // Выбор главного элемента по столбцу
                int maxRow = i;
                for (int k = i + 1; k < n; k++)
                {
                    if (Math.Abs(matrix[k, i]) > Math.Abs(matrix[maxRow, i]))
                    {
                        maxRow = k;
                    }
                }

                // Перестановка строк, чтобы главный элемент был на диагонали
                for (int k = i; k <= n; k++)
                {
                    double temp = matrix[maxRow, k];
                    matrix[maxRow, k] = matrix[i, k];
                    matrix[i, k] = temp;
                }

                // Обнуление элементов ниже главной диагонали
                for (int k = i + 1; k < n; k++)
                {
                    double factor = matrix[k, i] / matrix[i, i];
                    for (int j = i; j <= n; j++)
                    {
                        matrix[k, j] -= factor * matrix[i, j];
                    }
                }
            }

            // Обратный ход метода Гаусса
            double[] solution = new double[n];
            for (int i = n - 1; i >= 0; i--)
            {
                solution[i] = matrix[i, n] / matrix[i, i];
                for (int k = i - 1; k >= 0; k--)
                {
                    matrix[k, n] -= matrix[k, i] * solution[i];
                }
            }

            return solution;
        }

        // Проверка условия диагонального преобладания
        static bool CheckDiagonalDominance(double[,] matrix)
        {
            int n = matrix.GetLength(0); // Размерность системы

            // Для каждой строки проверяем, больше ли диагональный элемент суммы остальных элементов
            for (int i = 0; i < n; i++)
            {
                double diagonal = Math.Abs(matrix[i, i]); // Диагональный элемент
                double sum = 0; // Сумма модулей недиагональных элементов
                for (int j = 0; j < n; j++)
                {
                    if (i != j)
                    {
                        sum += Math.Abs(matrix[i, j]);
                    }
                }
                if (diagonal <= sum)
                {
                    return false; // Условие не выполнено
                }
            }
            return true; // Условие выполнено
        }

        // Метод простых итераций для решения системы линейных уравнений
        static double[] SolveBySimpleIterations(double[,] matrix, int n)
        {
            double[] solution = new double[n]; // Текущее приближение решения
            double[] prevSolution = new double[n]; // Предыдущее приближение решения
            double epsilon = 1e-6; // Точность решения
            int maxIterations = 1000; // Максимальное количество итераций
            int iterations = 0; // Счетчик итераций

            // Итерационный процесс
            do
            {
                Array.Copy(solution, prevSolution, n); // Сохраняем текущее решение
                for (int i = 0; i < n; i++)
                {
                    double sum = 0; // Сумма произведений недиагональных элементов на предыдущее решение
                    for (int j = 0; j < n; j++)
                    {
                        if (i != j)
                        {
                            sum += matrix[i, j] * prevSolution[j];
                        }
                    }
                    solution[i] = (matrix[i, n] - sum) / matrix[i, i]; // Новое приближение
                }
                iterations++;
            } while (VectorNormDifference(solution, prevSolution) > epsilon && iterations < maxIterations);

            return solution;
        }

        // Вычисление нормы разности векторов (максимум модуля разности)
        static double VectorNormDifference(double[] a, double[] b)
        {
            double maxDiff = 0;
            for (int i = 0; i < a.Length; i++)
            {
                maxDiff = Math.Max(maxDiff, Math.Abs(a[i] - b[i]));
            }
            return maxDiff;
        }

        // Вывод решения на экран
        static void PrintSolution(double[] solution)
        {
            Console.WriteLine("Решение:");
            for (int i = 0; i < solution.Length; i++)
            {
                Console.WriteLine($"x{i + 1} = {solution[i]:F6}");
            }
        }
    }
}
