using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Calculation
{
    public class Lagrange
    {
        public static (string, double) LagrangePolynomial(double[] x, double[] y, double target)
        {
            int n = x.Length;
            string[] lTerms = new string[n];
            for (int i = 0; i < n; i++)
            {
                List<string> factors = new List<string> { $"({y[i]})" };
                for (int j = 0; j < n; j++)
                {
                    if (i != j)
                        factors.Add($"(x-{x[j]})/({x[i] - x[j]})");
                }
                lTerms[i] = string.Join("*", factors);
            }
            string polynomialString = string.Join("+", lTerms);
            double result = 0;
            for (int i = 0; i < n; i++)
            {
                double term = y[i];
                for (int j = 0; j < n; j++)
                {
                    if (i != j)
                        term *= (target - x[j]) / (x[i] - x[j]);
                }
                result += term;
            }
            return (polynomialString, result);
        }
    }
}
