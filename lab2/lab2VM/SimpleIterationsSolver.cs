﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2VM
{
    public class SimpleIterationsSolver
    {
        public float[] Solve(Matrix matrix, double epsilon = 1e-3, int maxIterations = 10000)
        {
            int n = matrix.GetLength();
            float[,] data = matrix.GetData();

            double alpha = 0;

            float[] solution = new float[n];
            for (int i = 0; i < n; i++)
            {
                solution[i] = data[i, n] / data[i, i];
            }
            float[] prevSolution = new float[n];
            int iterations = 0;

            float[,] dataCopy = matrix.GetData();

            for(int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    dataCopy[i, j] = -data[i, j] / data[i, i];
                }
            }

            alpha = MatrixNorm(dataCopy);
            if (alpha > 1) Console.WriteLine("Норма матрицы больше или равна 1. Сходимость не гарантирована.");
            Console.WriteLine(alpha.ToString());

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
                if (iterations > maxIterations) break;
            } while (VectorNorm(VectorDifference(prevSolution, solution)) > Math.Abs(1 - alpha) / alpha * epsilon);
            Console.WriteLine($"Было произведено {iterations} итераций");
            return solution;
        }


        private double MatrixNorm(float[,] matrix)
        {
            int size = matrix.GetLength(0);
            double norm = 0;
            for (int i = 0; i < size; i++)
            {
                for(int j = 0; j < size; j++)
                {
                    norm += matrix[i, j] * matrix[i, j];
                }
            }
            return Math.Sqrt(norm);
        }

        private double VectorNorm(float[] vector)
        {
            double norm = 0;
            int size = vector.GetLength(0);
            for (int i = 0; i < size; i++)
            {
                norm += vector[i] * vector[i];
            }
            return Math.Sqrt(norm);
        }

        private float[] VectorDifference(float[] a, float[] b) 
        {
            int aSize = a.Length; int bSize = b.Length;
            if (aSize != bSize) throw new Exception("Размеры векторов разные");

            float[] result = new float[aSize];
            
            for (int i = 0; i < aSize; i++) 
            {
                result[i] = a[i] - b[i];
            }
            return result;
        }
    }
}
