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
        
        // ����������� ������� f(x)
        static float Function(float x)
        {
            float x2 = x * x;
            return 7 * x2;
        }

        // ������������� ����������� f'(x)
        static float AnalyticalDerivative(float x)
        {
            return 14 * x;
        }

        // ��������� �����������������
        static float NumericalDerivative(float x, float h)
        {
            float xh = x + h;
            float f1 = Function(xh);
            float f2 = Function(x);
            return (f1 - f2) / h;
        }

        static void Main()
        {
            // ����� ��� ���������� �����������
            float[] points = { 1e-2f, 1e-1f, 1f, 10f, 100f };


            Console.WriteLine("�����\t���\t���������\t�������������\t�����������");

            foreach (float x in points)
            {
                float optimalH = 0;
                float minError = float.MaxValue;

                for (int i = 1; i <= 8; i++)
                {
                    float h = (float)Math.Pow(10, -i);
                    float numericalDerivative = NumericalDerivative(x, h);
                    float analyticalDerivative = AnalyticalDerivative(x);

                    // ���������� �����������
                    float error = Math.Abs(numericalDerivative - analyticalDerivative);

                    // ���������� ������������ ����
                    if (error < minError)
                    {
                        minError = error;
                        optimalH = h;
                    }

                    // ����� �����������
                    Console.WriteLine($"{x}\t{h}\t{numericalDerivative:F6}\t{analyticalDerivative:F6}\t{error:F6}");
                }

                // ����� ������������ ����
                Console.WriteLine($"����������� ��� ��� ����� {x}: {optimalH}, ����������� �����������: {minError:F6}\n");
            }
        }
        */


        static void Main()
        {
            float[] x = {-1, 0, 1, 2, 3, 4};
            float[] y = {-2, -2, -7, 1, 14, -2};

            Spline spline = new Spline(x, y);

            List<SplineInterpreter> splines = spline.Phi_fun();
            Console.WriteLine("��������\t\td_i\t\tc_i\t\tb_i\t\ta_i");
            for (int i = 0; i < x.Length - 1; i++)
            {
                Console.WriteLine(
                    $"[{x[i],3}, {x[i + 1],-3}]\t" +
                    $"{spline.D[i],-10:F6}\t" +
                    $"{spline.C[i],-10:F6}\t" +
                    $"{spline.B[i],-10:F6}\t" +
                    $"{spline.A[i],-10:F6}"
                );
            }

        }
    }
}