namespace lab6
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
            xStartTextBox = new TextBox();
            xEndTextBox = new TextBox();
            yStartTextBox = new TextBox();
            startPointLabel = new Label();
            x0Label = new Label();
            y0Label = new Label();
            xnLabel = new Label();
            hTextBox = new TextBox();
            hLabel = new Label();
            EulerMethodButton = new Button();
            RKMButton = new Button();
            ModEulerButton = new Button();
            AdamsButton = new Button();
            ClearButton = new Button();
            chart = new ScottPlot.WinForms.FormsPlot();
            TrueSolutionButton = new Button();
            SuspendLayout();
            // 
            // xStartTextBox
            // 
            xStartTextBox.Location = new Point(27, 46);
            xStartTextBox.Name = "xStartTextBox";
            xStartTextBox.Size = new Size(42, 23);
            xStartTextBox.TabIndex = 0;
            // 
            // xEndTextBox
            // 
            xEndTextBox.Location = new Point(27, 107);
            xEndTextBox.Name = "xEndTextBox";
            xEndTextBox.Size = new Size(42, 23);
            xEndTextBox.TabIndex = 0;
            // 
            // yStartTextBox
            // 
            yStartTextBox.Location = new Point(119, 46);
            yStartTextBox.Name = "yStartTextBox";
            yStartTextBox.Size = new Size(42, 23);
            yStartTextBox.TabIndex = 0;
            // 
            // startPointLabel
            // 
            startPointLabel.AutoSize = true;
            startPointLabel.Location = new Point(27, 9);
            startPointLabel.Name = "startPointLabel";
            startPointLabel.Size = new Size(173, 15);
            startPointLabel.TabIndex = 1;
            startPointLabel.Text = "Координаты начальной точки";
            // 
            // x0Label
            // 
            x0Label.AutoSize = true;
            x0Label.Location = new Point(27, 28);
            x0Label.Name = "x0Label";
            x0Label.Size = new Size(19, 15);
            x0Label.TabIndex = 1;
            x0Label.Text = "x0";
            // 
            // y0Label
            // 
            y0Label.AutoSize = true;
            y0Label.Location = new Point(119, 28);
            y0Label.Name = "y0Label";
            y0Label.Size = new Size(19, 15);
            y0Label.TabIndex = 1;
            y0Label.Text = "y0";
            // 
            // xnLabel
            // 
            xnLabel.AutoSize = true;
            xnLabel.Location = new Point(27, 89);
            xnLabel.Name = "xnLabel";
            xnLabel.Size = new Size(20, 15);
            xnLabel.TabIndex = 1;
            xnLabel.Text = "xn";
            // 
            // hTextBox
            // 
            hTextBox.Location = new Point(119, 107);
            hTextBox.Name = "hTextBox";
            hTextBox.Size = new Size(42, 23);
            hTextBox.TabIndex = 0;
            // 
            // hLabel
            // 
            hLabel.AutoSize = true;
            hLabel.Location = new Point(119, 89);
            hLabel.Name = "hLabel";
            hLabel.Size = new Size(14, 15);
            hLabel.TabIndex = 1;
            hLabel.Text = "h";
            // 
            // EulerMethodButton
            // 
            EulerMethodButton.Location = new Point(30, 174);
            EulerMethodButton.Name = "EulerMethodButton";
            EulerMethodButton.Size = new Size(131, 23);
            EulerMethodButton.TabIndex = 2;
            EulerMethodButton.Text = "Метод Эйлера";
            EulerMethodButton.UseVisualStyleBackColor = true;
            EulerMethodButton.Click += EulerMethodButton_Click;
            // 
            // RKMButton
            // 
            RKMButton.Location = new Point(30, 219);
            RKMButton.Name = "RKMButton";
            RKMButton.Size = new Size(131, 23);
            RKMButton.TabIndex = 2;
            RKMButton.Text = "Метод РКМ";
            RKMButton.UseVisualStyleBackColor = true;
            RKMButton.Click += RKMButton_Click;
            // 
            // ModEulerButton
            // 
            ModEulerButton.Location = new Point(30, 263);
            ModEulerButton.Name = "ModEulerButton";
            ModEulerButton.Size = new Size(131, 23);
            ModEulerButton.TabIndex = 2;
            ModEulerButton.Text = "Мод. метод Эйлера";
            ModEulerButton.UseVisualStyleBackColor = true;
            ModEulerButton.Click += ModEulerButton_Click;
            // 
            // AdamsButton
            // 
            AdamsButton.Location = new Point(30, 305);
            AdamsButton.Name = "AdamsButton";
            AdamsButton.Size = new Size(131, 43);
            AdamsButton.TabIndex = 2;
            AdamsButton.Text = "Метод Адамса 2-го порядка";
            AdamsButton.UseVisualStyleBackColor = true;
            AdamsButton.Click += AdamsButton_Click;
            // 
            // ClearButton
            // 
            ClearButton.Location = new Point(27, 447);
            ClearButton.Name = "ClearButton";
            ClearButton.Size = new Size(131, 23);
            ClearButton.TabIndex = 2;
            ClearButton.Text = "Очистить график";
            ClearButton.UseVisualStyleBackColor = true;
            ClearButton.Click += ClearButton_Click;
            // 
            // chart
            // 
            chart.DisplayScale = 1F;
            chart.Location = new Point(234, 9);
            chart.Name = "chart";
            chart.Size = new Size(927, 764);
            chart.TabIndex = 3;
            // 
            // TrueSolutionButton
            // 
            TrueSolutionButton.Location = new Point(30, 370);
            TrueSolutionButton.Name = "TrueSolutionButton";
            TrueSolutionButton.Size = new Size(131, 43);
            TrueSolutionButton.TabIndex = 2;
            TrueSolutionButton.Text = "Точное решение";
            TrueSolutionButton.UseVisualStyleBackColor = true;
            TrueSolutionButton.Click += TrueSolutionButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1183, 820);
            Controls.Add(chart);
            Controls.Add(TrueSolutionButton);
            Controls.Add(AdamsButton);
            Controls.Add(ModEulerButton);
            Controls.Add(RKMButton);
            Controls.Add(ClearButton);
            Controls.Add(EulerMethodButton);
            Controls.Add(y0Label);
            Controls.Add(hLabel);
            Controls.Add(xnLabel);
            Controls.Add(x0Label);
            Controls.Add(hTextBox);
            Controls.Add(startPointLabel);
            Controls.Add(xEndTextBox);
            Controls.Add(yStartTextBox);
            Controls.Add(xStartTextBox);
            Name = "Form1";
            Text = "Решение ДУ";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox xStartTextBox;
        private TextBox xEndTextBox;
        private TextBox yStartTextBox;
        private Label startPointLabel;
        private Label x0Label;
        private Label y0Label;
        private Label xnLabel;
        private TextBox hTextBox;
        private Label hLabel;
        private Button EulerMethodButton;
        private Button RKMButton;
        private Button ModEulerButton;
        private Button AdamsButton;
        private Button ClearButton;
        private ScottPlot.WinForms.FormsPlot chart;
        private Button TrueSolutionButton;
    }
}
