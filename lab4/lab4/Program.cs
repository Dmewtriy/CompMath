namespace lab4
{
    /*internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }*/
    using System;

    class Program
    {
        // Определение функции f(x)
        static float Function(float x)
        {
            float x2 = x * x;
            return 7 * x2;
        }

        // Аналитическая производная f'(x)
        static float AnalyticalDerivative(float x)
        {
            return 14 * x;
        }

        // Численное дифференцирование
        static float NumericalDerivative(float x, float h)
        {
            float xh = x + h;
            float f1 = Function(xh);
            float f2 = Function(x);
            return (f1 - f2) / h;
        }

        static void Main()
        {
            // Точки для вычисления производной
            float[] points = { 1e-2f, 1e-1f, 1f, 10f, 100f };


            Console.WriteLine("Точка\tШаг\tЧисленная\tАналитическая\tПогрешность");

            foreach (float x in points)
            {
                float optimalH = 0;
                float minError = float.MaxValue;

                for (int i = 1; i <= 8; i++)
                {
                    float h = (float)Math.Pow(10, -i);
                    float numericalDerivative = NumericalDerivative(x, h);
                    float analyticalDerivative = AnalyticalDerivative(x);

                    // Вычисление погрешности
                    float error = Math.Abs(numericalDerivative - analyticalDerivative);

                    // Сохранение оптимального шага
                    if (error < minError)
                    {
                        minError = error;
                        optimalH = h;
                    }

                    // Вывод результатов
                    Console.WriteLine($"{x}\t{h}\t{numericalDerivative:F6}\t{analyticalDerivative:F6}\t{error:F6}");
                }

                // Вывод оптимального шага
                Console.WriteLine($"Оптимальный шаг для точки {x}: {optimalH}, минимальная погрешность: {minError:F6}\n");
            }
        }
    }
}