using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2VM
{
    public class SimpleIterationsSolver
    {
        public double[] Solve(Matrix matrix, double epsilon = 1e-6, int maxIterations = 1000)
        {
            int n = matrix.GetLength(0);
            float[,] data = matrix.GetData();

            double[] solution = new double[n];
            double[] prevSolution = new double[n];
            int iterations = 0;

            do
            {
                Array.Copy(solution, prevSolution, n);
                for (int i = 0; i < n; i++)
                {
                    double sum = 0;
                    for (int j = 0; j < n; j++)
                    {
                        if (i != j)
                        {
                            sum += data[i, j] * prevSolution[j];
                        }
                    }
                    solution[i] = (data[i, n] - sum) / data[i, i];
                }
                iterations++;
            } while (VectorNormDifference(solution, prevSolution) > epsilon && iterations < maxIterations);

            return solution;
        }

        private double VectorNormDifference(double[] a, double[] b)
        {
            double maxDiff = 0;
            for (int i = 0; i < a.Length; i++)
            {
                maxDiff = Math.Max(maxDiff, Math.Abs(a[i] - b[i]));
            }
            return maxDiff;
        }
    }
}
