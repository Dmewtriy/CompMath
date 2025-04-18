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
    }
}