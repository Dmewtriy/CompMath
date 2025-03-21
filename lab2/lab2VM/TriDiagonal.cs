using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2VM
{
    internal class TriDiagonal
    {
        public static bool IsTridiagonal(float[,] matrix)
        {
            int n = matrix.GetLength(0);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (Math.Abs(i - j) > 1 && matrix[i, j] != 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static float[] Solve(float[,] augmentedMatrix)
        {
            int n = augmentedMatrix.GetLength(0);
            float[] x = new float[n];
            float[] alpha = new float[n];
            float[] beta = new float[n];

            alpha[0] = augmentedMatrix[0, 1] / augmentedMatrix[0, 0];
            beta[0] = augmentedMatrix[0, n] / augmentedMatrix[0, 0];

            for (int i = 0; i < n; i++)
            {
                float c = (i > 0) ? augmentedMatrix[i, i - 1] : 0;
                float d = augmentedMatrix[i, i];
                float e = (i < n - 1) ? augmentedMatrix[i, i + 1] : 0;
                float b = augmentedMatrix[i, n];

                float denom = d - c * alpha[i - 1];
                alpha[i] = e / denom;
                beta[i] = (b - c * beta[i - 1]) / denom;
            }

            x[n - 1] = beta[n - 1];
            for (int i = n - 2; i >= 0; i--)
            {
                x[i] = alpha[i] * x[i + 1] + beta[i];
            }

            return x;
        }
    }
}
