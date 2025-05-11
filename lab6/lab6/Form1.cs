namespace lab6
{
    public partial class Form1 : Form
    {
        private int x0, xn, y0;
        private double h;
        private SolveDU solver;
        public Form1()
        {
            InitializeComponent();
        }

        private void TakeValues()
        {
            x0 = int.Parse(xStartTextBox.Text);
            y0 = int.Parse(yStartTextBox.Text);
            xn = int.Parse(xEndTextBox.Text);
            h = double.Parse(hTextBox.Text);
            solver = new SolveDU(x0, y0, xn, h);

        }

        private void EulerMethodButton_Click(object sender, EventArgs e)
        {
            try
            {
                TakeValues();
                (double[] x, double[] y) = solver.EulerMethod();
                chart.Plot.Add.SignalXY(x, y, ScottPlot.Color.FromColor(Color.Green));
                chart.Plot.Axes.AutoScale();
                chart.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка чтения входной информации");
            }
        }

        private void RKMButton_Click(object sender, EventArgs e)
        {
            try
            {
                TakeValues();
                (double[] x, double[] y) = solver.RKMMethod(h);
                chart.Plot.Add.SignalXY(x, y, ScottPlot.Color.FromColor(Color.Red));
                chart.Plot.Axes.AutoScale();
                chart.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка чтения входной информации");
            }
        }

        private void ModEulerButton_Click(object sender, EventArgs e)
        {
            try
            {
                TakeValues();
                (double[] x, double[] y) = solver.ModifiedEulerMethod();
                chart.Plot.Add.SignalXY(x, y, ScottPlot.Color.FromColor(Color.Yellow));
                chart.Plot.Axes.AutoScale();
                chart.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка чтения входной информации");
            }
        }

        private void AdamsButton_Click(object sender, EventArgs e)
        {
            try
            {
                TakeValues();
                (double[] x, double[] y) = solver.AdamsMethod2order();
                chart.Plot.Add.SignalXY(x, y, ScottPlot.Color.FromColor(Color.Blue));
                chart.Plot.Axes.AutoScale();
                chart.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка чтения входной информации");
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            chart.Plot.Clear();
            chart.Refresh();
        }

        private void TrueSolutionButton_Click(object sender, EventArgs e)
        {
            try
            {
                TakeValues();
                double[] x = new double[(int)Math.Ceiling((xn - x0) / h) + 1];
                double[] y = new double[x.Length];
                x[0] = x0;
                y[0] = y0;
                for (int i = 1; i < x.Length; i++)
                {
                    x[i] = x[i - 1] + h;
                    y[i] = solver.TrueSolut(x[i]);
                }
                chart.Plot.Add.SignalXY(x, y, ScottPlot.Color.FromColor(Color.Black));
                chart.Plot.Axes.AutoScale();
                chart.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка чтения входной информации");
            }
        }
    }
}
