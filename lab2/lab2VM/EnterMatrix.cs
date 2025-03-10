using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2VM
{
    public class EnterMatrix
    {
        private Matrix _matrix;

        public Matrix Matrix { get { return _matrix.DeepCopy(); } }
        public int MatrixSize
        {
            get { return _matrix.GetLength(0); }
        }
        public EnterMatrix()
        {
            Console.WriteLine("Введите размер матрицы. Не более 7.");
            if (!Int16.TryParse(Console.ReadLine(), out short size))
            {
                throw new ArgumentException("Некорректные данные.");
            }
            if (size > Matrix.MAXSIZE || size <= 0)
            {
                throw new ArgumentException("Неверный размер матрицы");
            }
            _matrix = new Matrix(size);
            Init();
        }

        private void Init()
        {
            for (int i = 0; i < MatrixSize; i++)
            {
                for (int j = 0; j < MatrixSize + 1; j++)
                {
                    Console.WriteLine($"Введите {j + 1} элемент {i + 1} строки");
                    _matrix[i, j] = EnterNumber();
                }
            }
        }

        private float EnterNumber()
        {
            if (!float.TryParse(Console.ReadLine(), out float x))
            {
                throw new ArgumentException("Некорректные данные");
            }
            return x;
        }

        /*private void Transformation()
        {
            bool found;
            for (int i = 0; i < MatrixSize; i++)
            {
                if (_matrix[i, i] == 0)
                {
                    found = false;
                    for (int j = i + 1; j < MatrixSize; j++)
                    {
                        if (_matrix[j, i] != 0)
                        {
                            SwapRows(_matrix, i, j);
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        throw new Exception("Невозможно избавиться от нулей на главной диагонали");
                    }
                }
            }
        }*/
    }
}
