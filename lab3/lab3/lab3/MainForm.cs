using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace lab3
{
    public partial class MainForm : Form
    {
        private DataTable dataTable;
        private Chart chart;
        private List<IFunction> functions = new List<IFunction>();
        private string[] functionLabels = new string[0];
        private TextBox txtMinX;
        private TextBox txtMaxX;
        private TextBox txtSteps;
        private TextBox txtCoefficients;

        public MainForm()
        {
            InitializeComponent();
            SetupDataTable();
            SetupChart();
        }

        private void InitializeComponent()
        {
            this.Text = "Аппроксимация функций";
            this.Size = new Size(1024, 768);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Создаем разделитель для размещения элементов
            SplitContainer splitContainer = new SplitContainer
            {
                Dock = DockStyle.Fill,
                Orientation = Orientation.Vertical,
                SplitterDistance = 300
            };
            this.Controls.Add(splitContainer);

            // Левая панель - ввод данных и управление
            Panel leftPanel = new Panel { Dock = DockStyle.Fill };
            splitContainer.Panel1.Controls.Add(leftPanel);

            // Правая панель - для графика
            Panel rightPanel = new Panel { Dock = DockStyle.Fill };
            splitContainer.Panel2.Controls.Add(rightPanel);

            // DataGridView для ввода таблицы значений
            DataGridView dataGridView = new DataGridView
            {
                Dock = DockStyle.Top,
                Height = 200,
                AllowUserToDeleteRows = true,
                AllowUserToAddRows = true,
                Name = "dataGridView"
            };

            // Инициализация таблицы
            dataTable = new DataTable();
            dataTable.Columns.Add("X", typeof(double));
            dataTable.Columns.Add("Y", typeof(double));

            // Значения из варианта пользователя
            dataTable.Rows.Add(-1, -2);
            dataTable.Rows.Add(0, -2);
            dataTable.Rows.Add(1, -7);
            dataTable.Rows.Add(2, 1);
            dataTable.Rows.Add(3, 14);

            dataGridView.DataSource = dataTable;
            leftPanel.Controls.Add(dataGridView);

            // Панель для кнопок
            Panel buttonPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 40,
                BorderStyle = BorderStyle.FixedSingle
            };
            leftPanel.Controls.Add(buttonPanel);

            Button btnAddRow = new Button
            {
                Text = "Добавить строку",
                Location = new Point(10, 10),
                Width = 120
            };
            btnAddRow.Click += (s, e) => dataTable.Rows.Add();
            buttonPanel.Controls.Add(btnAddRow);

            Button btnClearTable = new Button
            {
                Text = "Очистить таблицу",
                Location = new Point(140, 10),
                Width = 120
            };
            btnClearTable.Click += (s, e) => {
                dataTable.Rows.Clear();
                ClearChart();
            };
            buttonPanel.Controls.Add(btnClearTable);

            Button btnClearChart = new Button
            {
                Text = "Очистить график",
                Location = new Point(270, 10),
                Width = 120
            };
            btnClearChart.Click += (s, e) => ClearChart();
            buttonPanel.Controls.Add(btnClearChart);

            Button btnSaveTable = new Button
            {
                Text = "Сохранить",
                Location = new Point(490, 10),
                Width = 80
            };
            btnSaveTable.Click += (s, e) => SaveTableToFile();
            buttonPanel.Controls.Add(btnSaveTable);

            Button btnLoadTable = new Button
            {
                Text = "Загрузить",
                Location = new Point(400, 10),
                Width = 80
            };
            btnLoadTable.Click += (s, e) => LoadTableFromFile();
            buttonPanel.Controls.Add(btnLoadTable);

            // Панель для выбора метода аппроксимации
            GroupBox gbMethods = new GroupBox
            {
                Text = "Методы аппроксимации",
                Dock = DockStyle.Top,
                Height = 160,
                Padding = new Padding(10),
                Margin = new Padding(10)
            };
            leftPanel.Controls.Add(gbMethods);

            // Кнопки для различных методов
            Button btnLagrange = new Button
            {
                Text = "Многочлен Лагранжа",
                Location = new Point(10, 20),
                Width = 260,
                Height = 30
            };
            btnLagrange.Click += (s, e) => BuildLagrangePolynomial();
            gbMethods.Controls.Add(btnLagrange);

            Button btnNewton = new Button
            {
                Text = "Многочлен Ньютона",
                Location = new Point(10, 55),
                Width = 260,
                Height = 30
            };
            btnNewton.Click += (s, e) => BuildNewtonPolynomial();
            gbMethods.Controls.Add(btnNewton);

            Button btnLeastSquares1 = new Button
            {
                Text = "МНК (степень 1)",
                Location = new Point(10, 90),
                Width = 260,
                Height = 30
            };
            btnLeastSquares1.Click += (s, e) => BuildLeastSquaresPolynomial(1);
            gbMethods.Controls.Add(btnLeastSquares1);

            Button btnLeastSquares2 = new Button
            {
                Text = "МНК (степень 2)",
                Location = new Point(10, 125),
                Width = 128,
                Height = 30
            };
            btnLeastSquares2.Click += (s, e) => BuildLeastSquaresPolynomial(2);
            gbMethods.Controls.Add(btnLeastSquares2);

            Button btnLeastSquares3 = new Button
            {
                Text = "МНК (степень 3)",
                Location = new Point(142, 125),
                Width = 128,
                Height = 30
            };
            btnLeastSquares3.Click += (s, e) => BuildLeastSquaresPolynomial(3);
            gbMethods.Controls.Add(btnLeastSquares3);

            // Панель для произвольного многочлена 4-й степени
            GroupBox gbCustomPolynomial = new GroupBox
            {
                Text = "Произвольный многочлен 4-й степени",
                Dock = DockStyle.Top,
                Height = 140,
                Padding = new Padding(10),
                Margin = new Padding(10)
            };
            leftPanel.Controls.Add(gbCustomPolynomial);

            // Поля для ввода коэффициентов многочлена
            Label lblA0 = new Label { Text = "a₀:", Location = new Point(10, 25), Width = 30 };
            TextBox txtA0 = new TextBox { Text = "0", Location = new Point(40, 22), Width = 60 };
            gbCustomPolynomial.Controls.Add(lblA0);
            gbCustomPolynomial.Controls.Add(txtA0);

            Label lblA1 = new Label { Text = "a₁:", Location = new Point(110, 25), Width = 30 };
            TextBox txtA1 = new TextBox { Text = "0", Location = new Point(140, 22), Width = 60 };
            gbCustomPolynomial.Controls.Add(lblA1);
            gbCustomPolynomial.Controls.Add(txtA1);

            Label lblA2 = new Label { Text = "a₂:", Location = new Point(210, 25), Width = 30 };
            TextBox txtA2 = new TextBox { Text = "0", Location = new Point(240, 22), Width = 60 };
            gbCustomPolynomial.Controls.Add(lblA2);
            gbCustomPolynomial.Controls.Add(txtA2);

            Label lblA3 = new Label { Text = "a₃:", Location = new Point(10, 55), Width = 30 };
            TextBox txtA3 = new TextBox { Text = "0", Location = new Point(40, 52), Width = 60 };
            gbCustomPolynomial.Controls.Add(lblA3);
            gbCustomPolynomial.Controls.Add(txtA3);

            Label lblA4 = new Label { Text = "a₄:", Location = new Point(110, 55), Width = 30 };
            TextBox txtA4 = new TextBox { Text = "0", Location = new Point(140, 52), Width = 60 };
            gbCustomPolynomial.Controls.Add(lblA4);
            gbCustomPolynomial.Controls.Add(txtA4);

            Label lblFormula = new Label 
            { 
                Text = "P(x) = a₀ + a₁·x + a₂·x² + a₃·x³ + a₄·x⁴", 
                Location = new Point(10, 85), 
                Width = 300 
            };
            gbCustomPolynomial.Controls.Add(lblFormula);

            Button btnCustomPolynomial = new Button
            {
                Text = "Построить график",
                Location = new Point(10, 110),
                Width = 260,
                Height = 25
            };
            btnCustomPolynomial.Click += (s, e) => 
            {
                try 
                {
                    double[] coefficients = new double[5];
                    
                    if (!double.TryParse(txtA0.Text, out coefficients[0]) ||
                        !double.TryParse(txtA1.Text, out coefficients[1]) ||
                        !double.TryParse(txtA2.Text, out coefficients[2]) ||
                        !double.TryParse(txtA3.Text, out coefficients[3]) ||
                        !double.TryParse(txtA4.Text, out coefficients[4]))
                    {
                        MessageBox.Show("Пожалуйста, введите корректные значения для коэффициентов многочлена.", 
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    
                    // Удаляем существующие функции с такой же меткой
                    RemoveFunctionsWithLabel("Многочлен 4-й степени");
                    
                    CustomPolynomial polynomial = new CustomPolynomial(coefficients);
                    polynomial.Label = "Многочлен 4-й степени";
                    AddFunction(polynomial);
                    
                    // Определяем диапазон графика
                    double minX = -5;
                    double maxX = 5;
                    
                    if (double.TryParse(txtMinX.Text, out double customMinX) && 
                        double.TryParse(txtMaxX.Text, out double customMaxX))
                    {
                        minX = customMinX;
                        maxX = customMaxX;
                    }
                    
                    UpdateChart(minX, maxX, 100);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при построении многочлена: {ex.Message}", 
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            gbCustomPolynomial.Controls.Add(btnCustomPolynomial);

            // Панель для настройки графика
            GroupBox gbChartSettings = new GroupBox
            {
                Text = "Настройки графика",
                Dock = DockStyle.Top,
                Height = 100,
                Padding = new Padding(10),
                Margin = new Padding(10)
            };
            leftPanel.Controls.Add(gbChartSettings);

            Label lblMinX = new Label { Text = "Min X:", Location = new Point(10, 25), Width = 50 };
            txtMinX = new TextBox { Text = "-5", Location = new Point(60, 22), Width = 60 };
            gbChartSettings.Controls.Add(lblMinX);
            gbChartSettings.Controls.Add(txtMinX);

            Label lblMaxX = new Label { Text = "Max X:", Location = new Point(140, 25), Width = 50 };
            txtMaxX = new TextBox { Text = "5", Location = new Point(190, 22), Width = 60 };
            gbChartSettings.Controls.Add(lblMaxX);
            gbChartSettings.Controls.Add(txtMaxX);

            Label lblSteps = new Label { Text = "Шагов:", Location = new Point(10, 55), Width = 50 };
            txtSteps = new TextBox { Text = "100", Location = new Point(60, 52), Width = 60 };
            gbChartSettings.Controls.Add(lblSteps);
            gbChartSettings.Controls.Add(txtSteps);

            Button btnUpdateChart = new Button
            {
                Text = "Обновить график",
                Location = new Point(140, 52),
                Width = 110,
                Height = 23
            };
            btnUpdateChart.Click += (s, e) =>
            {
                if (double.TryParse(txtMinX.Text, out double minX) &&
                    double.TryParse(txtMaxX.Text, out double maxX) &&
                    int.TryParse(txtSteps.Text, out int steps) &&
                    functions.Count > 0)
                {
                    UpdateChart(minX, maxX, steps);
                }
                else
                {
                    MessageBox.Show("Пожалуйста, введите корректные значения для настроек графика.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            gbChartSettings.Controls.Add(btnUpdateChart);

            // Настройка графика
            chart = new Chart { Dock = DockStyle.Fill };
            rightPanel.Controls.Add(chart);

            // Панель для отображения коэффициентов
            GroupBox gbCoefficients = new GroupBox
            {
                Text = "Коэффициенты многочленов",
                Dock = DockStyle.Bottom,
                Height = 100,
                Padding = new Padding(10)
            };
            rightPanel.Controls.Add(gbCoefficients);

            txtCoefficients = new TextBox
            {
                Dock = DockStyle.Fill,
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical
            };
            gbCoefficients.Controls.Add(txtCoefficients);
        }

        private void SetupDataTable()
        {
            // Уже реализовано в InitializeComponent
        }

        private void SetupChart()
        {
            ChartArea chartArea = new ChartArea("MainChartArea");
            chartArea.AxisX.Title = "X";
            chartArea.AxisY.Title = "Y";
            chartArea.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
            
            // Включаем возможность масштабирования
            chartArea.CursorX.IsUserEnabled = true;
            chartArea.CursorY.IsUserEnabled = true;
            chartArea.CursorX.IsUserSelectionEnabled = true;
            chartArea.CursorY.IsUserSelectionEnabled = true;
            chartArea.AxisX.ScaleView.Zoomable = true;
            chartArea.AxisY.ScaleView.Zoomable = true;
            
            // Настраиваем целые значения на осях
            chartArea.AxisX.Interval = 1;
            chartArea.AxisY.Interval = 1;
            
            // Добавляем линии осей
            chartArea.AxisX.LineWidth = 1;
            chartArea.AxisY.LineWidth = 1;
            chartArea.AxisX.LineColor = Color.Black;
            chartArea.AxisY.LineColor = Color.Black;
            
            // Отображаем ось Y в нуле по оси X
            chartArea.AxisY.Crossing = 0;
            chartArea.AxisX.Crossing = 0;
            
            // Добавляем вспомогательные линии для целых значений
            chartArea.AxisX.MajorTickMark.Enabled = true;
            chartArea.AxisY.MajorTickMark.Enabled = true;
            chartArea.AxisX.MinorTickMark.Enabled = true;
            chartArea.AxisY.MinorTickMark.Enabled = true;
            
            chart.ChartAreas.Add(chartArea);

            // Легенда для отображения методов аппроксимации
            Legend legend = new Legend("MainLegend");
            chart.Legends.Add(legend);
            
            // Добавляем кнопки для масштабирования
            chart.MouseWheel += Chart_MouseWheel;
            
            // Создаем панель для кнопок масштабирования
            Panel zoomPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 30,
                Parent = chart.Parent
            };
            
            Button btnZoomIn = new Button
            {
                Text = "Увеличить",
                Width = 80,
                Location = new Point(10, 5),
                Parent = zoomPanel
            };
            
            Button btnZoomOut = new Button
            {
                Text = "Уменьшить",
                Width = 80,
                Location = new Point(100, 5),
                Parent = zoomPanel
            };
            
            Button btnResetZoom = new Button
            {
                Text = "Сбросить",
                Width = 80,
                Location = new Point(190, 5),
                Parent = zoomPanel
            };
            
            btnZoomIn.Click += (s, e) => ZoomChart(0.8);
            btnZoomOut.Click += (s, e) => ZoomChart(1.2);
            btnResetZoom.Click += (s, e) => ResetChartZoom();
        }

        private void Chart_MouseWheel(object sender, MouseEventArgs e)
        {
            try
            {
                if (chart.ChartAreas.Count > 0)
                {
                    ChartArea chartArea = chart.ChartAreas[0];
                    
                    // Определяем центр масштабирования (позиция мыши)
                    double xPos = chartArea.AxisX.PixelPositionToValue(e.X);
                    double yPos = chartArea.AxisY.PixelPositionToValue(e.Y);
                    
                    // Вычисляем коэффициент масштабирования в зависимости от направления прокрутки
                    double zoomFactor = e.Delta > 0 ? 0.8 : 1.2;
                    
                    // Применяем масштабирование с центром по позиции мыши
                    ApplyZoom(chartArea.AxisX, xPos, zoomFactor);
                    ApplyZoom(chartArea.AxisY, yPos, zoomFactor);
                }
            }
            catch
            {
                // Игнорируем ошибки при масштабировании
            }
        }

        private void ApplyZoom(Axis axis, double position, double factor)
        {
            if (!axis.ScaleView.IsZoomed)
            {
                // Если масштабирование еще не применялось, используем весь диапазон оси
                double min = axis.Minimum;
                double max = axis.Maximum;
                double range = max - min;
                
                // Новый диапазон вокруг позиции мыши
                double newMin = position - range * factor / 2;
                double newMax = position + range * factor / 2;
                
                // Ограничиваем новый диапазон, чтобы он не выходил за пределы допустимых значений
                newMin = Math.Max(newMin, axis.Minimum);
                newMax = Math.Min(newMax, axis.Maximum);
                
                axis.ScaleView.Zoom(newMin, newMax);
            }
            else
            {
                // Если масштабирование уже применялось, исходим из текущего диапазона
                double min = axis.ScaleView.ViewMinimum;
                double max = axis.ScaleView.ViewMaximum;
                double range = max - min;
                
                // Вычисляем, где находится позиция относительно текущего диапазона (от 0 до 1)
                double positionRatio = (position - min) / range;
                
                // Новый диапазон
                double newRange = range * factor;
                double newMin = position - newRange * positionRatio;
                double newMax = newMin + newRange;
                
                // Ограничиваем новый диапазон
                newMin = Math.Max(newMin, axis.Minimum);
                newMax = Math.Min(newMax, axis.Maximum);
                
                // Применяем новый диапазон
                axis.ScaleView.Zoom(newMin, newMax);
            }
        }

        private void ZoomChart(double factor)
        {
            try
            {
                if (chart.ChartAreas.Count > 0)
                {
                    ChartArea chartArea = chart.ChartAreas[0];
                    
                    // Для осей X и Y применяем масштабирование из центра
                    foreach (Axis axis in new[] { chartArea.AxisX, chartArea.AxisY })
                    {
                        if (!axis.ScaleView.IsZoomed)
                        {
                            // Если масштабирование еще не применялось
                            double center = (axis.Maximum + axis.Minimum) / 2;
                            double range = axis.Maximum - axis.Minimum;
                            double newRange = range * factor;
                            
                            double newMin = center - newRange / 2;
                            double newMax = center + newRange / 2;
                            
                            // Ограничиваем новый диапазон
                            newMin = Math.Max(newMin, axis.Minimum);
                            newMax = Math.Min(newMax, axis.Maximum);
                            
                            axis.ScaleView.Zoom(newMin, newMax);
                        }
                        else
                        {
                            // Если масштабирование уже применялось
                            double center = (axis.ScaleView.ViewMaximum + axis.ScaleView.ViewMinimum) / 2;
                            double range = axis.ScaleView.ViewMaximum - axis.ScaleView.ViewMinimum;
                            double newRange = range * factor;
                            
                            double newMin = center - newRange / 2;
                            double newMax = center + newRange / 2;
                            
                            // Ограничиваем новый диапазон
                            newMin = Math.Max(newMin, axis.Minimum);
                            newMax = Math.Min(newMax, axis.Maximum);
                            
                            axis.ScaleView.Zoom(newMin, newMax);
                        }
                    }
                }
            }
            catch
            {
                // Игнорируем ошибки при масштабировании
            }
        }

        private void ResetChartZoom()
        {
            try
            {
                if (chart.ChartAreas.Count > 0)
                {
                    ChartArea chartArea = chart.ChartAreas[0];
                    chartArea.AxisX.ScaleView.ZoomReset();
                    chartArea.AxisY.ScaleView.ZoomReset();
                }
            }
            catch
            {
                // Игнорируем ошибки при сбросе масштабирования
            }
        }

        private void ClearChart()
        {
            functions.Clear();
            functionLabels = new string[0];
            chart.Series.Clear();
        }
        private void BuildLagrangePolynomial()
        {
            if (dataTable.Rows.Count < 2)
            {
                MessageBox.Show("Для построения многочлена Лагранжа необходимо как минимум 2 точки.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Удаляем существующие функции с такой же меткой
            RemoveFunctionsWithLabel("Многочлен Лагранжа");

            double[] xValues = new double[dataTable.Rows.Count];
            double[] yValues = new double[dataTable.Rows.Count];

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                xValues[i] = Convert.ToDouble(dataTable.Rows[i]["X"]);
                yValues[i] = Convert.ToDouble(dataTable.Rows[i]["Y"]);
            }

            IFunction lagrangePolynomial = new LagrangePolynomial(xValues, yValues);
            lagrangePolynomial.Label = "Многочлен Лагранжа";
            AddFunction(lagrangePolynomial);
        }

        private void BuildNewtonPolynomial()
        {
            if (dataTable.Rows.Count < 2)
            {
                MessageBox.Show("Для построения многочлена Ньютона необходимо как минимум 2 точки.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Удаляем существующие функции с такой же меткой
            RemoveFunctionsWithLabel("Многочлен Ньютона");

            double[] xValues = new double[dataTable.Rows.Count];
            double[] yValues = new double[dataTable.Rows.Count];

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                xValues[i] = Convert.ToDouble(dataTable.Rows[i]["X"]);
                yValues[i] = Convert.ToDouble(dataTable.Rows[i]["Y"]);
            }

            IFunction newtonPolynomial = new NewtonPolynomial(xValues, yValues);
            newtonPolynomial.Label = "Многочлен Ньютона";
            AddFunction(newtonPolynomial);
        }

        private void BuildLeastSquaresPolynomial(int degree)
        {
            if (dataTable.Rows.Count <= degree)
            {
                MessageBox.Show($"Для построения многочлена степени {degree} необходимо минимум {degree + 1} точек.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Удаляем существующие функции с такой же меткой
            RemoveFunctionsWithLabel($"МНК (степень {degree})");

            double[] xValues = new double[dataTable.Rows.Count];
            double[] yValues = new double[dataTable.Rows.Count];

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                xValues[i] = Convert.ToDouble(dataTable.Rows[i]["X"]);
                yValues[i] = Convert.ToDouble(dataTable.Rows[i]["Y"]);
            }

            try
            {
                IFunction leastSquaresPolynomial = new LeastSquaresPolynomial(xValues, yValues, degree);
                leastSquaresPolynomial.Label = $"МНК (степень {degree})";
                AddFunction(leastSquaresPolynomial);
                
                // Вывод коэффициентов в текстовое поле, если оно существует
                if (txtCoefficients != null)
                {
                    AbstractPolynomial polynomial = (AbstractPolynomial)leastSquaresPolynomial;
                    string coefficientsText = $"Коэффициенты многочлена МНК степени {degree}:\r\n";
                    for (int i = 0; i <= degree; i++)
                    {
                        coefficientsText += $"a{i} = {polynomial.Coefficients[i]:F6}\r\n";
                    }
                    
                    txtCoefficients.Text = coefficientsText;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при построении многочлена: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RemoveFunctionsWithLabel(string label)
        {
            if (functions == null)
                return;

            for (int i = functions.Count - 1; i >= 0; i--)
            {
                if (functions[i].Label == label)
                {
                    functions.RemoveAt(i);
                }
            }
            
            // Обновляем список функций
            UpdateFunctionsList();
        }

        private void AddFunction(IFunction function)
        {
            functions.Add(function);
        }

        private void UpdateFunctionsList()
        {
            // Обновляем график после изменения списка функций
            if (double.TryParse(txtMinX.Text, out double minX) &&
                double.TryParse(txtMaxX.Text, out double maxX) &&
                int.TryParse(txtSteps.Text, out int steps))
            {
                UpdateChart(minX, maxX, steps);
            }
            else
            {
                UpdateChart();
            }
        }

        private void UpdateChart(double minX, double maxX, int steps)
        {
            chart.Series.Clear();

            // Добавляем серию для исходных точек
            Series originalPoints = new Series("Исходные точки")
            {
                ChartType = SeriesChartType.Point,
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 8,
                Color = Color.Black
            };

            foreach (DataRow row in dataTable.Rows)
            {
                if (row.RowState != DataRowState.Deleted && row[0] != DBNull.Value && row[1] != DBNull.Value)
                {
                    double x = Convert.ToDouble(row[0]);
                    double y = Convert.ToDouble(row[1]);
                    originalPoints.Points.AddXY(x, y);
                }
            }
            chart.Series.Add(originalPoints);

            // Добавляем графики функций
            Color[] colors = { Color.Red, Color.Blue, Color.Green, Color.Orange, Color.Purple };

            for (int i = 0; i < functions.Count; i++)
            {
                string seriesName = functions[i].Label ?? $"Функция {i+1}";
                
                // Проверяем, есть ли уже серия с таким именем, если да - добавляем номер к имени
                int counter = 1;
                string originalName = seriesName;
                while (chart.Series.Any(s => s.Name == seriesName))
                {
                    seriesName = $"{originalName} ({counter})";
                    counter++;
                }

                Series series = new Series(seriesName)
                {
                    ChartType = SeriesChartType.Line,
                    BorderWidth = 2,
                    Color = colors[i % colors.Length]
                };

                try
                {
                    double step = (maxX - minX) / steps;
                    for (double x = minX; x <= maxX; x += step)
                    {
                        try
                        {
                            double y = functions[i].Calculate(x);
                            if (!double.IsNaN(y) && !double.IsInfinity(y))
                            {
                                series.Points.AddXY(x, y);
                            }
                        }
                        catch
                        {
                            // Пропускаем точки, где функция не определена
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при вычислении функции {seriesName}: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                chart.Series.Add(series);
            }
        }

        private void UpdateChart()
        {
            chart.Series.Clear();

            // Добавляем серию для исходных точек
            Series originalPoints = new Series("Исходные точки")
            {
                ChartType = SeriesChartType.Point,
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 8,
                Color = Color.Black
            };

            foreach (DataRow row in dataTable.Rows)
            {
                if (row.RowState != DataRowState.Deleted && row[0] != DBNull.Value && row[1] != DBNull.Value)
                {
                    double x = Convert.ToDouble(row[0]);
                    double y = Convert.ToDouble(row[1]);
                    originalPoints.Points.AddXY(x, y);
                }
            }
            chart.Series.Add(originalPoints);

            // Находим диапазон для отрисовки функций
            double minX = double.MaxValue;
            double maxX = double.MinValue;

            foreach (DataRow row in dataTable.Rows)
            {
                if (row.RowState != DataRowState.Deleted && row[0] != DBNull.Value)
                {
                    double x = Convert.ToDouble(row[0]);
                    minX = Math.Min(minX, x);
                    maxX = Math.Max(maxX, x);
                }
            }

            // Расширяем диапазон для более полного отображения
            double range = maxX - minX;
            if (range > 0)
            {
                minX -= range * 0.2;
                maxX += range * 0.2;
            }
            else
            {
                // Если все точки имеют одинаковую X-координату, установим произвольный диапазон
                minX -= 1;
                maxX += 1;
            }

            // Устанавливаем количество шагов по умолчанию
            int steps = 100;
            if (int.TryParse(txtSteps.Text, out int customSteps) && customSteps > 0)
            {
                steps = customSteps;
            }

            // Добавляем графики функций
            Color[] colors = { Color.Red, Color.Blue, Color.Green, Color.Orange, Color.Purple };

            for (int i = 0; i < functions.Count; i++)
            {
                string seriesName = functions[i].Label ?? $"Функция {i+1}";
                
                // Проверяем, есть ли уже серия с таким именем, если да - добавляем номер к имени
                int counter = 1;
                string originalName = seriesName;
                while (chart.Series.Any(s => s.Name == seriesName))
                {
                    seriesName = $"{originalName} ({counter})";
                    counter++;
                }

                Series series = new Series(seriesName)
                {
                    ChartType = SeriesChartType.Line,
                    BorderWidth = 2,
                    Color = colors[i % colors.Length]
                };

                try
                {
                    double step = (maxX - minX) / steps;
                    for (double x = minX; x <= maxX; x += step)
                    {
                        try
                        {
                            double y = functions[i].Calculate(x);
                            if (!double.IsNaN(y) && !double.IsInfinity(y))
                            {
                                series.Points.AddXY(x, y);
                            }
                        }
                        catch
                        {
                            // Пропускаем точки, где функция не определена
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при вычислении функции {seriesName}: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                chart.Series.Add(series);
            }
        }

        private void SaveTableToFile()
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog
                {
                    Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*",
                    DefaultExt = "txt",
                    Title = "Сохранить таблицу значений"
                };

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.StreamWriter writer = new System.IO.StreamWriter(saveDialog.FileName))
                    {
                        // Сохраняем количество точек
                        int validRows = 0;
                        foreach (DataRow row in dataTable.Rows)
                        {
                            if (row.RowState != DataRowState.Deleted && row[0] != DBNull.Value && row[1] != DBNull.Value)
                            {
                                validRows++;
                            }
                        }
                        writer.WriteLine(validRows);

                        // Сохраняем сами точки
                        foreach (DataRow row in dataTable.Rows)
                        {
                            if (row.RowState != DataRowState.Deleted && row[0] != DBNull.Value && row[1] != DBNull.Value)
                            {
                                double x = Convert.ToDouble(row[0]);
                                double y = Convert.ToDouble(row[1]);
                                writer.WriteLine($"{x}\t{y}");
                            }
                        }
                    }

                    MessageBox.Show("Таблица успешно сохранена.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении таблицы: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTableFromFile()
        {
            try
            {
                OpenFileDialog openDialog = new OpenFileDialog
                {
                    Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*",
                    Title = "Загрузить таблицу значений"
                };

                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    dataTable.Rows.Clear();
                    ClearChart();

                    using (System.IO.StreamReader reader = new System.IO.StreamReader(openDialog.FileName))
                    {
                        // Читаем количество точек
                        string line = reader.ReadLine();
                        if (int.TryParse(line, out int pointsCount))
                        {
                            // Читаем сами точки
                            for (int i = 0; i < pointsCount; i++)
                            {
                                line = reader.ReadLine();
                                if (line != null)
                                {
                                    string[] parts = line.Split(new[] { '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                                    if (parts.Length >= 2 && 
                                        double.TryParse(parts[0], out double x) && 
                                        double.TryParse(parts[1], out double y))
                                    {
                                        dataTable.Rows.Add(x, y);
                                    }
                                }
                            }
                        }
                    }

                    MessageBox.Show("Таблица успешно загружена.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке таблицы: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
} 