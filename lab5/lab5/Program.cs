// f(x) = (2.5x^2 - 0.1) / (ln(x) + 1 )

int n = 550;

double h = 10f / n;

double I = 0f;
int a = 3, b = 13;

double Func(double x)
{
    double a = 2.5 * x * x - 0.1;
    double b = Math.Log(x) + 1;
    return (double)(a / b);
}
double f = a + h;
for (int i = 1; i <= n; i++)
{
    I += Func(f);
    f += h;
}

Console.WriteLine(I * h);