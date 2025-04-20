using System.Windows.Forms;

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
            // ѕроверка, выбрана ли хот€ бы одна €чейка
            if (tableData.SelectedCells.Count > 0)
            {
                // ѕолучаем индекс строки, в которой была выбрана €чейка
                int selectedRowIndex = tableData.SelectedCells[0].RowIndex;

                // ”дал€ем всю строку, в которой была выбрана €чейка
                tableData.Rows.RemoveAt(selectedRowIndex);
            }
            else
            {
                MessageBox.Show("ѕожалуйста, выберите €чейку в строке, которую хотите удалить.");
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

        }
    }
}