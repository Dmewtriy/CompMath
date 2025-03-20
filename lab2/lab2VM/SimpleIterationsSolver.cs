using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2VM
{
    public class SimpleIterationsSolver
    {
        public float[] Solve(Matrix matrix, double epsilon = 1e-6, int maxIterations = 1000)
        {
            int n = matrix.GetLength();
            float[,] data = matrix.GetData();

            float[] solution = new float[n];
            for (int i = 0; i < n; i++)
            {
                solution[i] = data[i, n] / data[i, i];
            }
            float[] prevSolution = new float[n];
            int iterations = 0;

            do
            {
                Array.Copy(solution, prevSolution, n);
                for (int i = 0; i < n; i++)
                {
                    float sum = 0;
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
            Console.WriteLine($"Было произведено {iterations} итераций");
            return solution;
        }

        private float VectorNormDifference(float[] a, float[] b)
        {
            float maxDiff = 0;
            for (int i = 0; i < a.Length; i++)
            {
                maxDiff = Math.Max(maxDiff, Math.Abs(a[i] - b[i]));
            }
            return maxDiff;
        }
    }
}
