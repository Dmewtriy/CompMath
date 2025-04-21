using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    public class Function
    {
        private float a, b, c, d;
        //private float x_start;

        public Function(float a, float b, float c, float d)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
            //this.x_start = x_start;
        }

        public (float[] x, float[] y) GetFuncPoints(float start, float end, float x_start=0)
        {
            int n = (int)((end - start) / 0.02);
            float[] x = new float[n];
            float[] y = new float[n];
            for (int i = 0; i < n; i++)
            {
                x[i] = start;
                y[i] = (float)(d * Math.Pow((x[i] - x_start), 3) + c * Math.Pow((x[i] - x_start), 2) + b * (x[i] - x_start) + a);
                start += 0.02f;
            }
            return (x, y);
        }
    }
}
