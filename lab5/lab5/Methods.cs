using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    internal class Methods
    {
        private int n = 100;
        
        private void FindStep()
        {

        }

        public float RightRectangle(float[] f)
        {
            float result = 0;
            float h = f[1] - f[0];

            for (int i = 1; i < f.Length; i++) 
            {
                result += h * f[i];
            }

            return result;
        }

        public float Trapezoid(float[] f)
        {
            float result = 0;
            float h = f[1] - f[0];

            for (int i = 1; i < f.Length - 2; i++)
            {
                result += 2 * f[i];
            }

            return h * 0.5f * (result + f[0] + f[f.Length - 1]);
        }

        public float Simpson(float[] f)
        {
            float result = 0;
            float h = f[1] - f[0];

            for (int i = 1; i < f.Length - 2; i++)
            {
                if (i % 2 == 0)
                {
                    result += 2 * f[i];

                }
                else
                {
                    result += 4 * f[i];

                }
            }

            return h / 3.0f * (f[0] + result + f[f.Length - 1]);
        }

    }
}
