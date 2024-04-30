using Lab2.Calculation;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Lab2.UI
{
    public partial class InputForm : Form
    {
        public InputForm()
        {
            InitializeComponent();
        }

        private async void InputForm_Load(object sender, EventArgs e)
        {
            BackColor = Color.White;
            MinimumSize = Size;
            MaximumSize = Size;
            MaximizeBox = false;
            await graph.EnsureCoreWebView2Async();
            string indexPath = System.IO.Path.Combine(Application.StartupPath, "UI", "Desmos", "index.html");
            graph.Source = new Uri(indexPath);
            functionBox.SelectedIndex = 0;
        }

        private void inputGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            RerenderButton();
        }

        private void RerenderButton()
        {
            calculateButton.Enabled = CheckCalculability();
        }
        private bool CheckCalculability()
        {
            if (inputGrid.Rows.Count < 3) return false;
            return true;
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            openFileDialog.Title = "Открыть файл";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filePath = openFileDialog.FileName;
                    string[] lines = File.ReadAllLines(filePath);
                    inputGrid.Rows.Clear();
                    foreach (string line in lines)
                    {
                        string[] splitted = line.Split(' ');
                        inputGrid.Rows.Add(new object[] { splitted[0], splitted[1] });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при чтении файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void calculateButton_Click(object sender, EventArgs e)
        {
            if(!IsDoubleValid(targetBox.Text))
            {
                MessageBox.Show($"Неверное значение целевого X");
                return;
            }
            double target = ParseDouble(targetBox.Text);
            Dictionary<double, double> input = new Dictionary<double, double>();
            double h = Double.NaN;
            foreach(DataGridViewRow row in inputGrid.Rows)
            {
                if (row.Cells[0].Value == null || row.Cells[1].Value == null)
                    continue;
                string x = row.Cells[0].Value.ToString();
                string y = row.Cells[1].Value.ToString();
                if(!IsDoubleValid(x) || !IsDoubleValid(y))
                {
                    MessageBox.Show($"Обнаружено неверное значение в строке {row.Index + 1}");
                    return;
                }
                if(input.ContainsKey(ParseDouble(x)))
                {
                    MessageBox.Show($"Дубликат значения X в строке №{row.Index + 1}");
                    return;
                }
                if (!Double.IsNaN(h))
                {
                    h = input.Values.Last() - ParseDouble(x);
                } else if (input.Keys.Count > 0)
                {
                    if(Math.Abs(input.Values.Last() - ParseDouble(x) - h) > 0.00001)
                    {
                        MessageBox.Show($"Нестабильный шаг X");
                        return;
                    }
                }
                input.Add(ParseDouble(x), ParseDouble(y));
            }
            if(target < input.Keys.Min() || target > input.Keys.Max())
            {
                MessageBox.Show($"Требуемое значение выходит за границы интервала");
                return;
            }
            DifferencesCalculation.FillDataGridView(outputGrid, DifferencesCalculation.Delta(input.Values.ToArray()));
            (string lagrangeLatex, double lagrangeResult) = Lagrange.LagrangePolynomial(input.Keys.ToArray(), input.Values.ToArray(), target);
            (string newtonsLatex, double newtonsResult, Dictionary<double, double> newtonsDots) = Newtons.NewtonsDividedDifferences(input.Keys.ToArray(), input.Values.ToArray(), target);
            (string newtonsInterpolationLatex, double newtonsInterpolationResult) = Newtons.NewtonInterpolation(input.Keys.ToArray(), input.Values.ToArray(), target);
            await graph.CoreWebView2.ExecuteScriptAsync($"clear()");
            await graph.CoreWebView2.ExecuteScriptAsync($"expression('{lagrangeLatex.Replace(',','.')}', 0)");
            await graph.CoreWebView2.ExecuteScriptAsync($"expression('{newtonsLatex.Replace(',', '.')}', 1)");
            await graph.CoreWebView2.ExecuteScriptAsync($"expression('{newtonsInterpolationLatex.Replace(',', '.')}', 2)");
            int i = 0;
            foreach(double x in newtonsDots.Keys)
            {
                i++;
                await graph.CoreWebView2.ExecuteScriptAsync($"expression('A_{{{i}}}=({x.ToString().Replace(',','.')}, {newtonsDots[x].ToString().Replace(',', '.')})', 'd{i}')");
            }
            string result = "Результат:\n" +
                $"Лагранж: {FormatNumber(lagrangeResult)}\n" +
                $"Ньютон разделенные разности: {FormatNumber(newtonsResult)}\n" +
                $"Ньютон конечные разности: {FormatNumber(newtonsInterpolationResult)}\n";
            resultLabel.Text = result;
        }
        public bool IsDoubleValid(string text)
        {
            return double.TryParse(text.Replace(".", ","), out double result);
        }
        private double ParseDouble(string text)
        {
            return double.Parse(text.Replace(".", ","));
        }
        public static string FormatNumber(double number)
        {
            if (number.ToString().Contains("E"))
            {
                string[] parts = number.ToString().Split('E');
                double coefficient = double.Parse(parts[0]);
                int exponent = int.Parse(parts[1]);

                return $"{coefficient} · 10^({exponent})";
            }

            return number.ToString();
        }

        private void inputGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            RerenderButton();
        }
        private void inputGrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            RerenderButton();
        }
        private void inputGrid_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            RerenderButton();
        }
        private void inputGrid_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            RerenderButton();
        }
        private void inputGrid_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            RerenderButton();
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            if(!IsDoubleValid(intervalStartBox.Text) || !IsDoubleValid(intervalEndBox.Text))
            {
                MessageBox.Show($"Введен неверный интервал");
                return;
            }
            double intervalStart = ParseDouble(intervalStartBox.Text);
            double intervalEnd = ParseDouble(intervalEndBox.Text);
            if(intervalStart >= intervalEnd)
            {
                MessageBox.Show($"Начало интервало должно быть до его конца");
                return;
            }
            int dots = 1;
            if(!int.TryParse(dotsBox.Text, out dots))
            {
                MessageBox.Show($"Указано неверное количество точек");
                return;
            }
            if(dots < 3)
            {
                MessageBox.Show($"Количество точек должно быть от 3");
                return;
            }
            F function = (x) => Math.Sin(x);
            if(functionBox.SelectedIndex != 0)
                function = (x) => Math.Cos(x) + x;
            double h = (intervalEnd - intervalStart) / dots;
            inputGrid.Rows.Clear();
            for(int i = 0; i < dots; i++)
            {
                inputGrid.Rows.Add(new object[] { intervalStart + h * i, function(intervalStart + h * i) });
            }

        }

        private delegate double F(double x);
    }
}
