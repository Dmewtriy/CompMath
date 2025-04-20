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
                tableData.Rows.Add(i + 1, xArg[i], yArg[i]);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
           
            tableData.Rows.Add(tableData.Rows.Count + 1, null, null);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            // ��������, ������� �� ������
            if (tableData.SelectedRows.Count > 0)
            {
                // ������� ��������� ������
                foreach (DataGridViewRow row in tableData.SelectedRows)
                {
                    // ���������, ��� �� ��������� ������� ������, ������� �������� ����� (������).
                    if (!row.IsNewRow)
                    {
                        tableData.Rows.RemoveAt(row.Index);
                    }
                }
            }
            else
            {
                MessageBox.Show("����������, �������� ������ ��� ��������.");
            }

        }
    }
}