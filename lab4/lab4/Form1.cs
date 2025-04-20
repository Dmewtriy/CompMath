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
            // ��������, ������� �� ���� �� ���� ������
            if (tableData.SelectedCells.Count > 0)
            {
                // �������� ������ ������, � ������� ���� ������� ������
                int selectedRowIndex = tableData.SelectedCells[0].RowIndex;

                // ������� ��� ������, � ������� ���� ������� ������
                tableData.Rows.RemoveAt(selectedRowIndex);
            }
            else
            {
                MessageBox.Show("����������, �������� ������ � ������, ������� ������ �������.");
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
                    MessageBox.Show("����������, ������� ���������� ������ ��� ���������.");
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
            var series123 = new Series($"���. ������")
            {
                ChartType = SeriesChartType.Line,
                ChartArea = "areaSpline"
            };
            chart1.Series.Add(series123);

            foreach (SplineInterpreter interpreter in splineInterpreters)
            {
                int i = 1;
               
                for (int point = 0; point < interpreter.x.Length; point++)
                {
                    series123.Points.AddXY(interpreter.x[point], interpreter.phi[point]);
                }               
                

                i++;
            }

        }
    }
}