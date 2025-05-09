using System;

namespace lab5
{
    internal class Methods
    {
        public delegate double Function(double x);

        private readonly Function f;
        private readonly double a;
        private readonly double b;
        private readonly double eps;

        public Methods(Function function, double a = 3, double b = 13, double eps = 1e-6)
        {
            this.f = function;
            this.a = a;
            this.b = b;
            this.eps = eps;
        }

        // =================== Правило Рунге (общая логика) ===================

        private (double, double) Runge(Func<double, double> method, int p)
        {
            int r = 4;
            double h = (b-a); // стартовый шаг
            double I1 = method(h);
            double I2 = method(h/r);

            while ((Math.Abs(I2 - I1) / (Math.Pow(r, p) - 1)) > eps)
            {
                h /= r;
                I1 = I2;
                I2 = method(h/r);
            }
            h /= r; // последний шаг, на котором была достигнута точность
            return (I2, h);
        }


        // =================== Методы интегрирования ===================

        private double RightRectangle(double h)
        {
            int n = (int)((b - a) / h); // Всегда округляем вверх
            h = (b - a) / n; // Пересчитываем h для точного разбиения интервала
            double sum = 0;

            for (int i = 1; i <= n; i++)
            {
                sum += f(a + i * h);
            }

            return h * sum;
        }

        private double Trapezoid(double h)
        {
            int n = (int)((b - a) / h); // Всегда округляем вверх
            h = (b - a) / n; // Пересчитываем h для точного разбиения интервала

            double sum = 0;
            for (int i = 1; i < n; i++)
            {
                sum += 2 * f(a + i * h);
            }

            return h * 0.5 * (f(a) + f(b) + sum);
        }

        private double Simpson(double h)
        {
            int n = (int)((b - a) / h); // Всегда округляем вверх
            if (n % 2 != 0) n--; // Симпсон требует чётное число разбиений
            h = (b - a) / n;     // пересчитываем h под корректное n

            double sum = 0;
            double coeff;
            for (int i = 1; i < n; i++)
            {
                coeff = (i % 2 == 0) ? 2 : 4;
                sum += coeff * f(a + i * h);
            }

            return h / 3.0 * (f(a) + f(b) + sum);
        }

        public override string ToString()
        {
            var (valR, stepR) = Runge(RightRectangle, 1);
            var (valT, stepT) = Runge(Trapezoid, 2);
            var (valS, stepS) = Runge(Simpson, 4);

            return $"Метод Правых прямоугольников:\n  Значение: {valR}, шаг: {stepR}\n" +
                   $"Метод Трапеций:\n  Значение: {valT}, шаг: {stepT}\n" +
                   $"Метод Симпсона:\n  Значение: {valS}, шаг: {stepS}";
        }
    }
}
