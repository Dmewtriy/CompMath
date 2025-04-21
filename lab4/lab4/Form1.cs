using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace lab4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            float[] xArg = { -1, 0, 1, 2, 3 };
            float[] yArg = { -2, -2, -7, 1, 14 };

            for (int i = 0; i < xArg.Length; i++)
            {
                tableData.Rows.Add(xArg[i], yArg[i]);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            tableData.Rows.Add(null, null);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            // Проверка, выбрана ли хотя бы одна ячейка
            if (tableData.SelectedCells.Count > 0)
            {
                // Получаем индекс строки, в которой была выбрана ячейка
                int selectedRowIndex = tableData.SelectedCells[0].RowIndex;

                // Удаляем всю строку, в которой была выбрана ячейка
                tableData.Rows.RemoveAt(selectedRowIndex);
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите ячейку в строке, которую хотите удалить.");
            }

        }

        private void btnSecondDerivative_Click(object sender, EventArgs e)
        {

        }

        private void btnFirstDerivative_Click(object sender, EventArgs e)
        {

        }

        private void btnSpline_Click(object sender, EventArgs e)
        {
            float[] x = new float[tableData.Rows.Count];
            float[] y = new float[tableData.Rows.Count];
            for (int i = 0; i < tableData.Rows.Count; i++)
            {
                float xArg;
                float yArg;
                if (!(float.TryParse(tableData.Rows[i].Cells[0].Value.ToString(), out xArg) && 
                    float.TryParse(tableData.Rows[i].Cells[1].Value.ToString(), out yArg)))
                {
                    MessageBox.Show("Пожалуйста, введите корректные данные для координат.");
                    break;
                }
                else
                {
                    x[i] = xArg;
                    y[i] = yArg;
                }
            }

            Spline spline = new Spline(x, y);
            List<SplineInterpreter> splineInterpreters = spline.Phi_fun();

            chart1.Series["Spline"].Points.Clear();       
            int phiMax = int.MinValue;
            int phiMin = int.MaxValue;

            AddCoeff(spline);
            
            foreach (SplineInterpreter interpreter in splineInterpreters)
            {
                for (int point = 0; point < interpreter.x.Length; point++)
                {
                    chart1.Series["Spline"].Points.AddXY(interpreter.x[point], interpreter.phi[point]);
                }

                phiMax = (int)Math.Ceiling(Math.Max(phiMax, interpreter.phi.Max()));
                phiMin = (int)Math.Ceiling(Math.Min(phiMin, interpreter.phi.Min()));
            }
            chart1.ChartAreas["area"].AxisX.Minimum = (int)Math.Ceiling(x.Min()) - 1;  // Минимальное значение оси X
            chart1.ChartAreas["area"].AxisX.Maximum = (int)Math.Ceiling(x.Max()) + 1; // Максимальное значение оси X
            chart1.ChartAreas["area"].AxisY.Minimum = phiMin - 1;  // Минимальное значение оси X
            chart1.ChartAreas["area"].AxisY.Maximum = phiMax + 1; // Максимальное значение оси X
        }
        private void AddCoeff(Spline spline)
        {
            tableCoefficients.Rows.Clear();
            for (int i = 0; i < spline.A.Length - 1; i++) 
            {
                tableCoefficients.Rows.Add($"[{spline.X[i]}, {spline.X[i + 1]}]", spline.A[i], spline.B[i], spline.C[i], spline.D[i]);
            }
        }
    }
}