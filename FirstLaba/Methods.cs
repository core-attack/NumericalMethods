using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstLaba
{
    class Methods
    {
        
        string f = "";
        string result = "";
        double h = 0;
        double a = 0;
        double b = 0.3;
        string temp = "y0 = {0}\ty1 = {1}\ty2 = {2}\ty3 = {3}\tr = {4}\t";
        double[] y = new double[0];
        //
        double func(double x, double y)
        {
            //return 2 * x - 3 * y; /*чтобы точное решение не было нулевым, эту строку нужно раскомментрировать*/
            return 2 * (x * x + y); /*а эту закомментировать*/
        }

        public double[] getY()
        {
            return y;
        }

        double func_diff(double x, double y, char osn)
        {
            if (osn.Equals('x'))
                return 2 - 3 * y;
            return 2 * x - 3;
        }

        double real_otv(double x)
        {
            //return 1 - 3 * x + (double)(11.0 / 2.0) * x * x - (double)(11.0 / 2.0) * x * x * x + (double)(33.0 / 8.0) * x * x * x * x; /*чтобы точное решение не было нулевым, эту строку нужно раскомментрировать*/
            return 0;/*а эту закомментировать*/
        }
        //
        public Methods(string func, double h)
        {
            this.h = h;
            f = func;
        }

        //Метод Эйлера
        public void Eiler()
        {
            y = new double[4];
            double[] x = new double[4];
            for (int i = 0; i < y.Length; i++)
            {
                x[i] = x[0] + i*h;
            }
            y[0] = 1;
            double[] r = new double[4];
            for (int i = 0; i < x.Length; i++)
            {
                r[i] = real_otv(x[i]);
            }
            for (int i = 0; i < y.Length; i++)
            {
                if (i + 1 < y.Length)
                    y[i + 1] = y[i] + func(x[i], y[i]) * h;
            }
            result += String.Format(temp + "Метод Эйлера\n", String.Format("{0:0.000000}", y[0]), String.Format("{0:0.000000}", y[1]), String.Format("{0:0.000000}", y[2]), String.Format("{0:0.000000}", y[3]), String.Format("{0:0.000000}", y[3] - r[3]));
        }
        //Исправленный метод Эйлера
        public void ChangeEiler()
        {
            y = new double[4];
            double[] x = new double[4];
            for (int i = 0; i < y.Length; i++)
            {
                x[i] = x[0] + i*h;
            }
            double[] r = new double[4];
            for (int i = 0; i < x.Length; i++)
            {
                r[i] = real_otv(x[i]);
            }
            y[0] = 1;
            for (int i = 0; i < y.Length; i++)
            {
                if (i + 1 < y.Length)
                    y[i + 1] = y[i] + h * func(x[i], y[i]) + 0.5 * h * h * (func_diff(x[i], y[i], 'x') + func_diff(x[i], y[i], 'y') * func(x[i], y[i]));
            }
            result += String.Format(temp + "Исправленный метод Эйлера\n", String.Format("{0:0.000000}", y[0]), String.Format("{0:0.000000}", y[1]), String.Format("{0:0.000000}", y[2]), String.Format("{0:0.000000}", y[3]), String.Format("{0:0.000000}", y[3] - r[3]));
        }

        public double[] ChangeEiler(double[] x)
        {
            double[] y = new double[x.Length];
            for (int i = 0; i < y.Length; i++)
            {
                x[i] = x[0] + i * h;
            }
            double[] r = new double[x.Length];
            for (int i = 0; i < x.Length; i++)
            {
                r[i] = real_otv(x[i]);
            }
            y[0] = 1;
            for (int i = 0; i < y.Length; i++)
            {
                if (i + 1 < y.Length - 1)
                    y[i + 1] = y[i] + h * func(x[i], y[i]) + 0.5 * h * h * (func_diff(x[i], y[i], 'x') + func_diff(x[i], y[i], 'y') * func(x[i], y[i]));
            }
            //result += String.Format(temp + "Исправленный метод Эйлера\n", String.Format("{0:0.000000}", y[0]), String.Format("{0:0.000000}", y[1]), String.Format("{0:0.000000}", y[2]), String.Format("{0:0.000000}", y[3]), String.Format("{0:0.000000}", y[3] - r[3]));
            return y;
        }

        //Метод Хейна
        public void Hein()
        {
            y = new double[4];
            double[] x = new double[4];
            for (int i = 0; i < y.Length; i++)
            {
                x[i] = x[0] + i*h;
            }
            double[] r = new double[4];
            for (int i = 0; i < x.Length; i++)
            {
                r[i] = real_otv(x[i]);
            }
            y[0] = 1;
            for (int i = 0; i < y.Length; i++)
            {
                if (i + 1 < y.Length)
                    y[i + 1] = y[i] + 0.5 * h * (func(x[i], y[i]) + func(x[i] + h, y[i] + h * func(x[i], y[i])));
            }
            result += String.Format(temp + "Метод Хайна\n", String.Format("{0:0.000000}", y[0]), String.Format("{0:0.000000}", y[1]), String.Format("{0:0.000000}", y[2]), String.Format("{0:0.000000}", y[3]), String.Format("{0:0.000000}", y[3] - r[3]));
        }

        public string write()
        {
            Eiler();
            ChangeEiler();
            Hein();
            double[] x = new double[4];
            for (int i = 0; i < x.Length; i++)
            {
                x[i] = x[0] + i*h;
            }
            double[] r = new double[4];
            for (int i = 0; i < x.Length; i++)
            {
                r[i] = real_otv(x[i]);
            }
            return result + String.Format("r0 = {0}\tr1 = {1}\tr2 = {2}\tr3 = {3}\tТочное решение\n", String.Format("{0:0.000000}", r[0]), String.Format("{0:0.000000}", r[1]), String.Format("{0:0.000000}", r[2]), String.Format("{0:0.000000}", r[3]));
        }
    }
}
