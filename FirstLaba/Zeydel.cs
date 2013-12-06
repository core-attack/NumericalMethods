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
    class Zeydel
    {
        public int COUNT_ITER = 0;
        public double[] x;
        EasyIter ei = new EasyIter();
        double[,] L;
        double[,] U;

        void setMatrix(out double[,] L, out double[,] U, double[,] A)
        {
            L = new double[A.GetLength(0), A.GetLength(1)];
            U = new double[A.GetLength(0), A.GetLength(1)];

            for (int i = 0; i < L.GetLength(0); i++)
            {
                for (int j = 0; j < L.GetLength(1); j++)
                {
                    if (i > j)
                        L[i, j] = - A[i, j];
                    else
                        U[i, j] = - A[i, j];
                }
            }
        }

        //summary of vectors
        double[] SumVect(double[] v1, double[] v2)
        {
            double[] result = new double[v1.Length];
            if (v1.Length == v2.Length)
            {
                for (int i = 0; i < result.Length; i++)
                    result[i] = v1[i] + v2[i];
            }
            return result;
        }

        //matrix-vector production
        double[] ProdVect(double[,] matr, double[] vect)
        {
            double[] result = new double[vect.Length];
            for (int i = 0; i < matr.GetLength(0); i++)
            {
                for (int j = 0; j < matr.GetLength(1); j++)
                {
                    result[i] += matr[i, j] * vect[i];     
                }
            } 
            return result;
        }

        //find norm (maximal difference relevant components)
        double norm(double[] old, double[] current)
        {
            if (old.Length != current.Length)
            {
                MessageBox.Show("Lengths of array is differ");
                return -1;
            }
            double[] maxDiff = new double[old.Length];
            for (int i = 0; i < maxDiff.Length; i++)
                maxDiff[i] = Math.Abs(current[i] - old[i]);
            return maxDiff.Min();
        }

        void setArray(out double[] a1, double[] a2)
        {
            a1 = new double[a2.Length];
            if (a1.Length == a2.Length)
                for (int i = 0; i < x.Length; i++)
                    a1[i] = a2[i];
        }

        public double[] calc(double[,] A, double[] B, double eps, out List<double[]> allIterations)
        {
            allIterations = new List<double[]>();
            x = new double[A.GetLength(0)];
            //начальное значение
            x[0] = B[0];
            setMatrix(out L, out U, A);
            //норма
            double n = 100;
            double temp = 0;
            do
            {
                for (int i = 0; i < A.GetLength(0); i++)
                {
                    for (int j = 0; j < A.GetLength(1); j++) 
                    {
                        if (i > j)
                            temp += L[i, j] * x[j];
                        else if (i <= j)
                            temp += U[i, j] * x[j];
                    }
                    x[i] += B[i] + temp;
                    temp = 0;
                }
                COUNT_ITER++;
                if (allIterations.Count != 0)
                    n = norm(x, allIterations[allIterations.Count - 1]);
                double[] y;
                setArray(out y, x);
                allIterations.Add(y);
                
            }
            while (n > eps);
            return x;
        }
    }
}
