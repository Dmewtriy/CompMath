using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace lab4
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            ChartArea chartArea2 = new ChartArea();
            Legend legend2 = new Legend();
            Series series4 = new Series();
            Series series5 = new Series();
            Series series6 = new Series();
            Series points = new Series();
            Title title2 = new Title();
            splitContainer1 = new SplitContainer();
            tableLayoutPanel1 = new TableLayoutPanel();
            lblTitle = new Label();
            tableCoefficients = new DataGridView();
            interval = new DataGridViewTextBoxColumn();
            coefficientA = new DataGridViewTextBoxColumn();
            CoefficientB = new DataGridViewTextBoxColumn();
            coefficientC = new DataGridViewTextBoxColumn();
            coefficientD = new DataGridViewTextBoxColumn();
            btnSecondDerivative = new Button();
            btnSpline = new Button();
            btnFirstDerivative = new Button();
            btnRemove = new Button();
            btnAdd = new Button();
            tableData = new DataGridView();
            xColumn = new DataGridViewTextBoxColumn();
            yColumn = new DataGridViewTextBoxColumn();
            btnClear = new Button();
            chart1 = new Chart();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tableCoefficients).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tableData).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(tableLayoutPanel1);
            splitContainer1.Panel1.Controls.Add(tableCoefficients);
            splitContainer1.Panel1.Controls.Add(btnSecondDerivative);
            splitContainer1.Panel1.Controls.Add(btnSpline);
            splitContainer1.Panel1.Controls.Add(btnFirstDerivative);
            splitContainer1.Panel1.Controls.Add(btnRemove);
            splitContainer1.Panel1.Controls.Add(btnAdd);
            splitContainer1.Panel1.Controls.Add(tableData);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(btnClear);
            splitContainer1.Panel2.Controls.Add(chart1);
            splitContainer1.Size = new Size(1343, 587);
            splitContainer1.SplitterDistance = 372;
            splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(lblTitle, 1, 0);
            tableLayoutPanel1.Location = new Point(12, 378);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(348, 36);
            tableLayoutPanel1.TabIndex = 7;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblTitle.Location = new Point(0, 7);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(348, 21);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Коэффициенты функции кубического сплайна ";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableCoefficients
            // 
            tableCoefficients.AllowUserToAddRows = false;
            tableCoefficients.AllowUserToDeleteRows = false;
            tableCoefficients.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableCoefficients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tableCoefficients.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Control;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            tableCoefficients.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            tableCoefficients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tableCoefficients.Columns.AddRange(new DataGridViewColumn[] { interval, coefficientA, CoefficientB, coefficientC, coefficientD });
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Window;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            tableCoefficients.DefaultCellStyle = dataGridViewCellStyle6;
            tableCoefficients.Location = new Point(12, 420);
            tableCoefficients.Name = "tableCoefficients";
            tableCoefficients.RowHeadersVisible = false;
            tableCoefficients.RowTemplate.Height = 25;
            tableCoefficients.Size = new Size(348, 150);
            tableCoefficients.TabIndex = 6;
            // 
            // interval
            // 
            interval.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            interval.FillWeight = 253.807114F;
            interval.HeaderText = "Интервал";
            interval.Name = "interval";
            interval.Width = 95;
            // 
            // coefficientA
            // 
            coefficientA.FillWeight = 61.54822F;
            coefficientA.HeaderText = "aᵢ";
            coefficientA.Name = "coefficientA";
            // 
            // CoefficientB
            // 
            CoefficientB.FillWeight = 61.54822F;
            CoefficientB.HeaderText = "bᵢ";
            CoefficientB.Name = "CoefficientB";
            // 
            // coefficientC
            // 
            coefficientC.FillWeight = 61.54822F;
            coefficientC.HeaderText = "cᵢ";
            coefficientC.Name = "coefficientC";
            // 
            // coefficientD
            // 
            coefficientD.FillWeight = 61.54822F;
            coefficientD.HeaderText = "dᵢ";
            coefficientD.Name = "coefficientD";
            // 
            // btnSecondDerivative
            // 
            btnSecondDerivative.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnSecondDerivative.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnSecondDerivative.Location = new Point(12, 116);
            btnSecondDerivative.Name = "btnSecondDerivative";
            btnSecondDerivative.Size = new Size(348, 46);
            btnSecondDerivative.TabIndex = 5;
            btnSecondDerivative.Text = "Вторая производная";
            btnSecondDerivative.UseVisualStyleBackColor = true;
            btnSecondDerivative.Click += btnSecondDerivative_Click;
            // 
            // btnSpline
            // 
            btnSpline.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnSpline.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnSpline.Location = new Point(12, 12);
            btnSpline.Name = "btnSpline";
            btnSpline.Size = new Size(348, 46);
            btnSpline.TabIndex = 4;
            btnSpline.Text = "Кубический сплайн";
            btnSpline.UseVisualStyleBackColor = true;
            btnSpline.Click += btnSpline_Click;
            // 
            // btnFirstDerivative
            // 
            btnFirstDerivative.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnFirstDerivative.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnFirstDerivative.Location = new Point(12, 64);
            btnFirstDerivative.Name = "btnFirstDerivative";
            btnFirstDerivative.Size = new Size(348, 46);
            btnFirstDerivative.TabIndex = 3;
            btnFirstDerivative.Text = "Первая производная";
            btnFirstDerivative.UseVisualStyleBackColor = true;
            btnFirstDerivative.Click += btnFirstDerivative_Click;
            // 
            // btnRemove
            // 
            btnRemove.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRemove.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnRemove.Location = new Point(215, 326);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(145, 46);
            btnRemove.TabIndex = 2;
            btnRemove.Text = "Удалить точку";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnAdd
            // 
            btnAdd.AutoSize = true;
            btnAdd.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnAdd.Location = new Point(12, 326);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(145, 46);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Добавить точу";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // tableData
            // 
            tableData.AllowUserToAddRows = false;
            tableData.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = SystemColors.Control;
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle7.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            tableData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            tableData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tableData.Columns.AddRange(new DataGridViewColumn[] { xColumn, yColumn });
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = SystemColors.Window;
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle8.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            tableData.DefaultCellStyle = dataGridViewCellStyle8;
            tableData.Location = new Point(12, 168);
            tableData.Name = "tableData";
            tableData.RowHeadersVisible = false;
            tableData.RowTemplate.Height = 25;
            tableData.Size = new Size(348, 150);
            tableData.TabIndex = 0;
            // 
            // xColumn
            // 
            xColumn.FillWeight = 134.771576F;
            xColumn.HeaderText = "X";
            xColumn.Name = "xColumn";
            // 
            // yColumn
            // 
            yColumn.FillWeight = 134.771576F;
            yColumn.HeaderText = "Y";
            yColumn.Name = "yColumn";
            // 
            // btnClear
            // 
            btnClear.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClear.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnClear.Location = new Point(642, 472);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(275, 46);
            btnClear.TabIndex = 6;
            btnClear.Text = "Очистить график";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // chart1
            // 
            chart1.BackColor = SystemColors.Control;
            chart1.BorderlineColor = SystemColors.Control;
            chartArea2.AxisX.Crossing = 0D;
            chartArea2.AxisX.Interval = 1D;
            chartArea2.AxisX.LineWidth = 2;
            chartArea2.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea2.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            chartArea2.AxisY.Crossing = 0D;
            chartArea2.AxisY.Interval = 1D;
            chartArea2.AxisY.LineWidth = 2;
            chartArea2.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea2.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dot;
            chartArea2.Name = "area";
            chart1.ChartAreas.Add(chartArea2);
            chart1.Dock = DockStyle.Fill;
            legend2.BackColor = SystemColors.Control;
            legend2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            legend2.IsTextAutoFit = false;
            legend2.Name = "legend";
            chart1.Legends.Add(legend2);
            chart1.Location = new Point(0, 0);
            chart1.Name = "chart1";
            series4.BorderWidth = 2;
            series4.ChartArea = "area";
            series4.ChartType = SeriesChartType.Line;
            series4.Color = Color.Green;
            series4.Legend = "legend";
            series4.LegendText = "Кубический сплайн";
            series4.Name = "Spline";
            series5.BorderWidth = 2;
            series5.ChartArea = "area";
            series5.ChartType = SeriesChartType.Line;
            series5.Color = Color.Magenta;
            series5.Legend = "legend";
            series5.LegendText = "Первая производная";
            series5.Name = "Der1";
            series6.BorderWidth = 2;
            series6.ChartArea = "area";
            series6.ChartType = SeriesChartType.Line;
            series6.Legend = "legend";
            series6.LegendText = "Вторая производная производная";
            series6.Name = "Der2";
            points.BorderWidth = 2;
            points.ChartArea = "area";
            points.Name = "Points";
            points.ChartType = SeriesChartType.Point;
            points.Color = Color.Magenta;
            points.MarkerStyle = MarkerStyle.Circle;
            chart1.Series.Add(series4);
            chart1.Series.Add(series5);
            chart1.Series.Add(series6);
            chart1.Series.Add(points);
            chart1.Size = new Size(967, 587);
            chart1.TabIndex = 0;
            chart1.Text = "chart1";
            title2.Name = "Title1";
            chart1.Titles.Add(title2);
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1343, 587);
            Controls.Add(splitContainer1);
            Name = "Form1";
            Text = "Form1";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tableCoefficients).EndInit();
            ((System.ComponentModel.ISupportInitialize)tableData).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private DataGridView tableData;
        private Button btnSecondDerivative;
        private Button btnSpline;
        private Button btnFirstDerivative;
        private Button btnRemove;
        private Button btnAdd;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private DataGridView tableCoefficients;
        private TableLayoutPanel tableLayoutPanel1;
        private Label lblTitle;
        private DataGridViewTextBoxColumn xColumn;
        private DataGridViewTextBoxColumn yColumn;
        private DataGridViewTextBoxColumn interval;
        private DataGridViewTextBoxColumn coefficientA;
        private DataGridViewTextBoxColumn CoefficientB;
        private DataGridViewTextBoxColumn coefficientC;
        private DataGridViewTextBoxColumn coefficientD;
        private ChartArea areaAll;
        private Button btnClear;
    }
}