using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FirstLaba
{
    class EasyIter
    {
        double[] b;
        double[] c;
        double[] d;

        double[] delta;
        double[] lambda;

        public double[] calc(double[,] A, double[] B, RichTextBox rtb, double[] x)
        {
            double[] delta = new double[A.GetLength(0)];
            double[] lambda = new double[A.GetLength(0)];
            return setCoefficients(A, B, rtb, x);
        }

        //chek for diagonal domination
        bool isDiagonalDomination(double[] b, double[] c, double[] d)
        {
            if (b.Length == c.Length && b.Length == d.Length)
            {
                int count = 0;
                for (int i = 0; i < b.Length; i++)
                {
                    if (Math.Abs(c[i]) >= Math.Abs(b[i]) + Math.Abs(d[i]))
                        count++;
                }
                if (count == b.Length)
                    return true;
            }
            return false;
        }

        public void setCoeff(double[,] A, out double[] b, out double[] c, out double[] d, RichTextBox rtb)
        {
            b = new double[A.GetLength(0)];
            c = new double[A.GetLength(0)];
            d = new double[A.GetLength(0)];
            b[0] = d[A.GetLength(0) - 1] = 0;
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    try
                    {
                        if (i - 1 >= 0)
                            b[i] = A[i, i - 1];
                        c[i] = A[i, i];
                        if (i + 1 < A.GetLength(1))
                            d[i] = A[i, i + 1];
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Something is bad in coefficients\n" + ex.Message + "\n" + ex.StackTrace);
                    }
                }
            }
            rtb.Text += "\n This is the b-array: ";
            writeArray(b, rtb);
            rtb.Text += "\n This is the c-array: ";
            writeArray(c, rtb);
            rtb.Text += "\n This is the d-array: ";
            writeArray(d, rtb);
        }

        //set diagonal-coefficient
        double[] setCoefficients(double[,] A, double[] B, RichTextBox rtb, double[] x)
        {
            setCoeff(A, out b, out c, out d, rtb);
            if (!isDiagonalDomination(b, c, d))
                rtb.Text += "\n Диагонального преобладания не обнаружено. Вычисление будет прервано. \n";
            else
            {
                rtb.Text += "\n Имеет место быть диагональное преобладание. \n";

                delta = new double[A.GetLength(0)];
                lambda = new double[A.GetLength(0)];

                try
                {
                    for (int i = 0; i < A.GetLength(0); i++)
                    {
                        if (i != 0)
                        {
                            delta[i] = -d[i] / (b[i] * delta[i - 1] + c[i]);
                            lambda[i] = (B[i] - b[i] * lambda[i - 1]) / (b[i] * delta[i - 1] + c[i]);
                        }
                        else
                        {
                            delta[i] = -d[i] / c[i];
                            lambda[i] = B[i] / c[i];
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Math Error" + ex.Message + "\n" + ex.StackTrace);
                }

                rtb.Text += "\n This is the delta-array: ";
                writeArray(delta, rtb);
                rtb.Text += "\n This is the lambda-array: ";
                writeArray(lambda, rtb);

                x = new double[A.GetLength(0)];
                for (int i = x.Length - 1; i >= 0; i--)
                {
                    if (i == x.Length - 1)
                        x[i] = lambda[i];
                    else
                        x[i] = delta[i] * x[i + 1] + lambda[i];
                }

                rtb.Text += "\n This is the x-array: ";
                writeArray(x, rtb);
            }
            return x;
        }

        
        //write matrix
        void writeMatrix(double[,] a, RichTextBox rtb)
        {
            rtb.Text += "";
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    rtb.Text += a[i, j].ToString() + " ";
                }
                rtb.Text += "";
            }
        }
        //write array
        public void writeArray(double[] a, RichTextBox rtb)
        {
            rtb.Text += "";
            for (int i = 0; i < a.Length; i++)
            {
                rtb.Text += a[i].ToString() + " ";
            }
            rtb.Text += "\n";
        }

    }
}
