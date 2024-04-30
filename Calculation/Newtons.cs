using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Calculation
{
    public class Newtons
    {
        public static double DividedDifference(double[] y, double[] x, int k, int i = 0)
        {
            if (k == 1)
                return (y[i + 1] - y[i]) / (x[i + 1] - x[i]);
            return (DividedDifference(y, x, k - 1, i + 1) - DividedDifference(y, x, k - 1, i)) /
                    (x[i + k] - x[i]);
        }
        public static string Format(double n)
        {
            return n.ToString().Contains("E") ? $"0.{new string('0', Math.Abs(int.Parse(n.ToString().Split('E')[1]) - 1))}1" : n.ToString();
        }
        public static (string, double, Dictionary<double, double>) NewtonsDividedDifferences(double[] x, double[] y, double target)
        {
            int n = x.Length;
            var interpolationNodes = new Dictionary<double, double>();
            for (int i = 0; i < n; i++)
                interpolationNodes[x[i]] = y[i];
            string polynomialString = Format(y[0]);
            double polynomialValue = y[0];

            for (int i = 1; i < n; i++)
            {
                string termString = "";
                double termValue = 1.0;
                for (int j = 0; j < i; j++)
                {
                    termString += $"(x - ({Format(x[j])}))";
                    termValue *= (target - x[j]);
                }
                double dividedDifference = DividedDifference(y, x, i);
                termString += $" * ({Format(dividedDifference)})";
                termValue *= dividedDifference;

                polynomialString += " + " + termString;
                polynomialValue += termValue;
            }

            return (polynomialString, polynomialValue, interpolationNodes);
        }

        public static (string, double) NewtonInterpolation(double[] x, double[] y, double target)
        {
            int n = x.Length;
            double h = x[1] - x[0];

            double[][] finiteDifferences = DifferencesCalculation.Delta(y);

            int index = 0;
            double minDiff = Double.PositiveInfinity;
            for(int i = 0; i < n; i++)
            {
                double diff = Math.Abs(x[i] - target);
                if(diff < minDiff)
                {
                    index = i;
                    minDiff = diff;
                }
            }

            double t = (target - x[index]) / h;
            string tex = $"((x - ({Format(x[index])}))/({Format(h)}))";

            string polynomial = Format(y[index]);
            double result = y[index];

            for (int i = 1; i < n && (t >= 0 ? finiteDifferences[i].Length > index : true); i++)
            {
                int backwards = t < 0 ? index - i : index;
                if (backwards < 0) break;
                double term = finiteDifferences[i][backwards];
                string termString = Format(finiteDifferences[i][backwards]);
                for (int j = 0; j < i; j++)
                {
                    term *= (t + (t < 0 ? j : -j)) / (j + 1);
                    termString += $"*({tex}{(t < 0 ? '+' : '-')}({j}))/({j + 1})";
                }
                result += term;
                polynomial += " + " + termString;
            }
            return (polynomial, result);
        }
    }
}
