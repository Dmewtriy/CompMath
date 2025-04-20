using System;


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

    class Program
    {/*
        
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
       


        static void Main()
        {
            float[] x = {-1, 0, 1, 2, 3};
            float[] y = {-2, -2, -7, 1, 14};

            Spline spline = new Spline(x, y);

            List<SplineInterpreter> splines = spline.Phi_fun();
            Console.WriteLine("Интервал\t\td_i\t\tc_i\t\tb_i\t\ta_i");
            for (int i = 0; i < x.Length - 1; i++)
            {
                Console.WriteLine(
                    $"[{x[i],3}, {x[i + 1],-3}]\t" +
                    $"{spline.D[i],-10:F3}\t" +
                    $"{spline.C[i],-10:F3}\t" +
                    $"{spline.B[i],-10:F3}\t" +
                    $"{spline.A[i],-10:F3}"
                );
            }
            Console.WriteLine("f");
            for (int i = 0; i < splines[0].x.Length; i++)
            {
                Console.Write("(" + splines[0].x[i] + ", " + splines[0].phi[i] + ")");
            }
            Console.WriteLine();

            float[] der = splines[0].ComputeFirstDerivative();

        } */
        /*/// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            *//*// To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());*/
            /*float[] x = { -1, 0, 1, 2, 3 };
            float[] y = { -2, -2, -7, 1, 14 };

            Spline spline = new Spline(x, y);

            List<SplineInterpreter> splines = spline.Phi_fun();

            Console.WriteLine("f");
            for (int i = 0; i < splines[0].x.Length; i++)
            {
                Console.Write("(" + $"{splines[0].x[i]:F3}" + ", " + $"{splines[0].phi[i]:F3}" + ")");
            }
            Console.WriteLine();

            float[] der1 = splines[0].ComputeFirstDerivative();
            Console.WriteLine("f`");
            for (int i = 0; i < der1.Length; i++)
            {
                Console.Write("(" + $"{splines[0].x[i]:F3}" + ", " + $"{der1[i]:F3}" + ")");
            }
            Console.WriteLine();

            float[] der2 = splines[0].ComputeSecondDerivative();
            Console.WriteLine("f``");
            for (int i = 0; i < der2.Length; i++)
            {
                Console.Write("(" + $"{splines[0].x[i]:F3}" + ", " + $"{der2[i]:F3}" + ")");
            }
            Console.WriteLine();*/
            /*
                        Console.WriteLine("f");
                        for (int i = 0; i < splines[0].x.Length; i++)
                        {
                            float x_ = splines[0].x[i];
                            Console.Write($"({splines[0].phi[i]:F3}, {(-2 + 2.179 * (x_ + 1) - 2.179 * Math.Pow(x_+1, 3)):F3}) ");
                        }
                        Console.WriteLine();

                        float[] der1 = splines[0].ComputeFirstDerivative();
                        Console.WriteLine("f`");
                        for (int i = 0; i < der1.Length; i++)
                        {
                            float x_ = splines[0].x[i];
                            Console.Write($"({der1[i]:F3}, {(2.179 - 6.537 * Math.Pow(x_ + 1, 2)):F3}) ");
                        }
                        Console.WriteLine();

                        float[] der2 = splines[0].ComputeSecondDerivative();
                        Console.WriteLine("f``");
                        for (int i = 0; i < der2.Length; i++)
                        {
                            float x_ = splines[0].x[i];
                            Console.Write($"({der2[i]:F3}, {(-13.074 * (x_ + 1)):F3}) ");
                        }
                        Console.WriteLine();*//*
        }*/

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
        }
    }