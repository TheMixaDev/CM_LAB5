using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2.Calculation
{
    public class DifferencesCalculation
    {
        public static double[][] Delta(double[] y)
        {
            List<double[]> dy = new List<double[]>{y};
            while (dy.Last().Length != 1)
            {
                double[] ddy = new double[dy.Last().Length - 1];
                for (int i = 0; i < dy.Last().Length - 1; i++)
                    ddy[i] = dy.Last()[i + 1] - dy.Last()[i];
                dy.Add(ddy);
            }
            return dy.ToArray();
        }

        public static void FillDataGridView(DataGridView dataGridView, double[][] dy)
        {
            dataGridView.Columns.Clear();
            dataGridView.Rows.Clear();
            for (int i = 0; i < dy.Length; i++)
            {
                dataGridView.Columns.Add($"dy{i}", $"dy{i}");
                dataGridView.Columns[i].Width = 50;
            }
            int maxRows = dy.Max(arr => arr.Length);
            for (int i = 0; i < maxRows; i++)
            {
                dataGridView.Rows.Add();
                for (int j = 0; j < dy.Length; j++)
                {
                    if (i < dy[j].Length)
                        dataGridView.Rows[i].Cells[j].Value = Math.Round(dy[j][i], 4);
                }
            }
        }
    }
}
