using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FirstLaba
{
    class ThernalConductivity
    {
        public string param = //"N=10, teta=1, alpha=x + 1, beta= 3 * x + 1, function=x^2 + x + 1";
        "N=10, gamma=1, tau=0.1, alpha=0.9*t + 1, beta= 0.9* t + 1, f =- 2 * x + 1";
        System.Globalization.NumberFormatInfo format;
        Parser p = new Parser();
        EasyIter ei = new EasyIter();
        int n = 0;
        double gamma = 0;
        double tau = 0;
        double teta = 0;
        string alpha = "";
        string beta = "";
        string func = "";
        double h = 0;
        double[,] u;
        double[] x;
        public double[] y;
        public string errors = "";

        public ThernalConductivity(string param, RichTextBox rtb, out string result) {
            format = new System.Globalization.NumberFormatInfo();
            format.NumberDecimalSeparator = ".";
            this.param = param;
            setParam(param, out n, out gamma, out tau, out alpha, out beta, out func);
            h = 1.0 / n;
            teta = gamma * gamma * tau / (h * h);
            teta = 1;
            x = new double[n + 1];
            u = new double[2, n + 1];
            setU();
            double[] B = new double[n + 1];
            x = ei.calc(u, B, rtb, x);
            calc(rtb);
            result = rtb.Text; 
        }


        double f(double x)
        {
            return p.Evaluate(func, x, format);
        }

        double a(double x)
        {
            return p.Evaluate(alpha, x, format);
        }

        double b(double x)
        {
            return p.Evaluate(beta, x, format);
        }

        void setParam(string s, out int n, out double gamma, out double tau, out string alpha, out string beta, out string func)
        {
            s = s.ToLower();
            string[] arr = s.Split(',');
            n = 0;
            gamma = 0;
            tau = 0;
            alpha = "";
            beta = "";
            func = "";
            for (int i = 0; i < arr.Length; i++)
            {
                string left = arr[i].Split('=')[0].Trim();
                string right = arr[i].Split('=')[1].Trim();
                switch (left)
                {
                    case "n": { n = int.Parse(right); }
                        break;
                    case "gamma": { gamma = double.Parse(right, format); }
                        break;
                    case "tau": { tau = double.Parse(right, format); }
                        break;
                    case "alpha": { alpha = right; }
                        break;
                    case "beta": { beta = right; }
                        break;
                    case "f": { func = right; }
                        break;
                }
            }
        }


        void setU()
        {
            for (int i = 0; i < u.GetLength(0); i++)
            {
                for (int j = 0; j < u.GetLength(1); j++)
                {
                    if (j == 0)
                        u[i, j] = a(i);
                    else if (j == 1)
                        u[i, j] = b(i);
                    else if (i == 0)
                        u[0, j] = f(j);
                    else {
                        u[i, j] = 0;
                    }
                }
            }
        }

        public void calc(RichTextBox rtb)
        {
            try
            {
                y = new double[x.Length];
                writeMatrix(u, rtb);
                for (int i = 1; i < y.Length; i++)
                {
                    y[i] = u[1, i + 1] - ((2 * teta + 1) / teta) * u[1, i] + u[1, i - 1] + u[0, i] / teta;
                }
                writeArray(y, rtb);
            }
            catch (Exception e)
            {
                errors += e.Message + "\n" + e.StackTrace;
            }
        }

        void writeMatrix(double[,] a, RichTextBox rtb)
        {
            rtb.Text += "";
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    rtb.Text += a[i, j].ToString() + " ";
                }
                rtb.Text += "/n";
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
