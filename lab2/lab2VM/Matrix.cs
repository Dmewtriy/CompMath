using System.Drawing;

namespace lab2VM
{
    public struct Matrix
    {
        private float[,] matrix;
        private readonly short _size;
        public static readonly int MAXSIZE = 7;

        public Matrix(short size) 
        {
            matrix = new float[size, size + 1];
            _size = size;
        }

        public int GetLength(int dimension)
        {
            return matrix.GetLength(dimension);
        }

        public Matrix DeepCopy() 
        {
            return new Matrix
            {
                matrix = (float[,])matrix.Clone(),
            };
        }

        public float this[int i, int j] 
        {
            get
            {
                if (i >= 0 && i < matrix.GetLength(0) && j >= 0 && j < matrix.GetLength(1))
                {
                    return matrix[i, j];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }

            set
            {
                if (i >= 0 && i < matrix.GetLength(0) && j >= 0 && j < matrix.GetLength(1))
                {
                    matrix[i, j] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        public void PrintMatrix()
        {
            for (int i = 0; i < GetLength(0); i++)
            {
                for (int j = 0; j < GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
        }
    }
}