using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FirstLaba
{
    class RungeKutt
    {
        Methods m;
        string func = "";
        double nu1, nu2, nu3, nu4;
        public string errors = "";
        public double[] x, y, deltaY, trueRes;
        //step
        double h;

        public RungeKutt(string func, double h)
        {
            this.h = h;
            this.func = func;
            calc();
            m = new Methods(func, h);
            
        }

        //надо подцепить парсер математических выражений
        double f(double x, double y)
        {
            //return prop.Evalute(func, x, y);
            //return 0.000000000001;
            //return 2 * (x * x + y);
            return x + y;
        }

        //точное решение 
        double trueResult(double x)
        {
            //return (3.0 / 2.0) * Math.Exp(2 * x) - x * x - x - 1.0 / 2.0;
            return 2 * Math.Exp(x) - x - 1;
        }

        //ядро 
        void calc()
        {
            try
            {
                int n = 10;
                x = new double[n];
                y = new double[n];
                deltaY = new double[n];
                trueRes = new double[n];
                for (int i = 0; i < x.Length; i++)
                {
                    x[i] = h * i;
                }

                y[0] = 1;
                for (int i = 0; i < y.Length; i++)
                {
                    nu1 = f(x[i], y[i]);
                    nu2 = f(x[i] + h / 2, y[i] + (h / 2) * nu1);
                    nu3 = f(x[i] + h / 2, y[i] + (h / 2) * nu2);
                    nu4 = f(x[i] + h, y[i] + h * nu3);
                    deltaY[i] = (h / 6) * (nu1 + 2 * nu2 + 2 * nu3 + nu4);
                    if (i + 1 < y.Length)
                    {
                        y[i + 1] = y[i] + deltaY[i];
                        trueRes[i] = trueResult(x[i]);
                    }

                }
            }
            catch (Exception e)
            {
                errors += e.Message + "\n" + e.StackTrace;
            }
        }

        public void writeArray(double[] a, RichTextBox rtb)
        {
            rtb.Text += "";
            for (int i = 0; i < a.Length; i++)
            {
                rtb.Text += a[i].ToString() + " ";
            }
            rtb.Text += "\n";

        }

        public string beautyWrite()
        {
            try{
                string result = "\nМетод Рунге-Кутта\t\t\tТочное решение\t\t\tМетод Эйлера\n";
                double[] newY = m.ChangeEiler(x);
                for (int i = 0; i < y.Length; i++)
                {
                    result += y[i].ToString() + "\t\t\t" + trueRes[i].ToString() + "\t\t\t" + newY[i] + "\n";
                }
                return result;

            }
            catch (Exception e)
            {
                errors += e.Message + "\n" + e.StackTrace;
                return errors;
            }
        }


    }
}
