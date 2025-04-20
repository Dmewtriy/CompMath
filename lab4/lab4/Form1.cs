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


    }
}