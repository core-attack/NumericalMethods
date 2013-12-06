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
    public partial class Form1 : Form
    {
        System.Globalization.NumberFormatInfo format;
        //matrix
        double[,] A;
        //free coefficients
        double[] B;

        double[] x;

        double EPSILON = 0;

        public Form1()
        {
            format = new System.Globalization.NumberFormatInfo();
            format.NumberDecimalSeparator = ".";

            InitializeComponent();
            comboBoxLabs.Items.Add("Метод простых итераций");
            comboBoxLabs.Items.Add("Метод Зейделя");
            comboBoxLabs.Items.Add("Методы Эйлера и их модификации");
            comboBoxLabs.Items.Add("Метод Рунге-Кутта 4-го порядка");
            comboBoxLabs.Items.Add("Уравнения матфизики");
            comboBoxLabs.SelectedIndex = 4;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            EPSILON = Convert.ToDouble(textBoxE.Text, format);
            switch (comboBoxLabs.SelectedIndex)
            {
                case 0:{
                    readMatrix(richTextBoxGeneral.Text, textBoxN.Text, textBoxM.Text);
                    EasyIter ei = new EasyIter();
                    ei.calc(A, B, richTextBoxGeneral, x);
                } 
                break;
                case 1:{
                    readMatrix(richTextBoxGeneral.Text, textBoxN.Text, textBoxM.Text);
                    Zeydel z = new Zeydel();
                    List<double[]> list;
                    double[] answer = z.calc(A, B, EPSILON, out list);
                    foreach (double[] a in list)
                    {
                        richTextBoxGeneral.Text += "\n x[] = ";
                        writeArray(a, richTextBoxGeneral);
                    }
                    writeArray(answer, richTextBoxGeneral);
                    richTextBoxGeneral.Text += "\n Count of iterations = " + z.COUNT_ITER; 
                }
                break;
                case 2:{
                    Methods m = new Methods(richTextBoxGeneral.Text.Split('=')[1].ToString().Trim(), Convert.ToDouble(textBoxN.Text, format));
                    richTextBoxGeneral.Text += "\n " + m.write();
                }
                break;
                case 3: {
                    string[] separators = { "=" };
                    RungeKutt rk = new RungeKutt(richTextBoxGeneral.Lines[0].Split(separators, StringSplitOptions.RemoveEmptyEntries)[1], Convert.ToDouble(textBoxN.Text, format));
                    //richTextBoxGeneral.Text += "\ny[i] = \n";
                    //rk.writeArray(rk.y, richTextBoxGeneral);
                    //richTextBoxGeneral.Text += "\nТочное решение\n";
                    //rk.writeArray(rk.trueRes, richTextBoxGeneral);
                    richTextBoxGeneral.Text += rk.beautyWrite();
                }
                break;
                case 4: {
                    string result = "";
                    ThernalConductivity tc = new ThernalConductivity(richTextBoxGeneral.Text, richTextBoxGeneral, out result);
                    if (tc.errors != "")
                        richTextBoxGeneral.Text += tc.errors;
                    else
                        writeArray(tc.y, richTextBoxGeneral);
                }
                break;
            }
        }

        void readMatrix(string text, string N, string M)
        {
            A = new double[0, 0];
            B = new double[0];
            int n = 0;
            try
            {
                n = Convert.ToInt16(N);
            }
            catch(Exception e)
            {
                MessageBox.Show("n have wrong value!");
                n = -1;
                textBoxN.Text = "-1";
            }
            int m = 0;
            try
            {
                m = Convert.ToInt16(M);
            }
            catch(Exception ex)
            {
                MessageBox.Show("m have wrong value!\n" + ex.Message + "\n" + ex.StackTrace);
                m = -1;
                textBoxM.Text = "-1";
            }
            if (n > 0 && m > 0)
            {
                A = new double[n, m];
                B = new double[m];
                string[] x = new string[n];
                List<string[]> y = new List<string[]>();
                for (int i = 0; i < richTextBoxGeneral.Lines.Length; i++)
                {
                    if (richTextBoxGeneral.Lines[i] != "")
                    {
                        try
                        {
                            B[i] = Convert.ToDouble(richTextBoxGeneral.Lines[i].Split('=')[1].ToString().Trim());
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Something is wrong in matrix B elements\n" + ex.Message + "\n" + ex.StackTrace);
                        }
                        if (i < n)
                        {
                            //элементы одной строки отделяются друг от друга пробелом
                            x = new string[n];
                            x = richTextBoxGeneral.Lines[i].Split('=')[0].Split(' ');
                            y.Add(x);

                        }
                    }
                }
                for (int i = 0; i < y.Count; i++)
                {
                    for (int j = 0; j < y[i].Length; j++ )
                    {
                        try
                        {
                            if (y[i][j] != "")
                                A[i, j] = Convert.ToDouble(y[i][j].Trim(), format);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Something is wrong in matrix A elements\n" + ex.Message + "\n" + ex.StackTrace);
                        }
                    }
                }
            }
            //write matrix A
            //writeMatrix(A, richTextBoxGeneral);
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
        void writeArray(double[] a, RichTextBox rtb)
        {
            rtb.Text += "";
            for (int i = 0; i < a.Length; i++)
            {
                rtb.Text += a[i].ToString() + " ";
            }
            rtb.Text += "";

        }

        private void textBoxE_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                //запрет на ввод более одной десятичной точки и тире
                if (
                    (e.KeyChar != ',' || textBoxE.Text.IndexOf(",") != -1)
                   )
                {
                    e.Handled = true;
                }

            }
        }

        private void textBoxM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (sender is TextBox)
                if (!((TextBox)sender).Name.Equals("textBoxN"))
                {
                    if (comboBoxLabs.SelectedIndex != 2)
                        if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b') { e.Handled = true; }
                }
                else if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b') { e.Handled = true; }
        }

        private void comboBoxLabs_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void comboBoxLabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxLabs.SelectedIndex == 4)
            {
                richTextBoxGeneral.Text = "N=10, gamma=1, tau=0.1, alpha=0.9*x + 1, beta= 0.9* x + 1, f =- 2 * x + 1";
                textBoxN.Visible = labelN.Visible = labelE.Visible = textBoxE.Visible = textBoxM.Visible = labelM.Visible = false;
            }
            else if (comboBoxLabs.SelectedIndex == 2)
            {
                richTextBoxGeneral.Text = "y' = 2*x - 3*y";
                labelN.Text = "h =";
                textBoxN.Text = "0,1";
                labelE.Visible = textBoxE.Visible = textBoxM.Visible = labelM.Visible = false;
            }
            else if (comboBoxLabs.SelectedIndex == 3)
            {
                richTextBoxGeneral.Text = "y' = 2 * (x^2 + y)";
                labelN.Text = "h =";
                textBoxN.Text = "0,1";
                labelE.Visible = textBoxE.Visible = textBoxM.Visible = labelM.Visible = false;
            }
            else
            {
                labelN.Text = "n =";
                labelE.Visible = textBoxE.Visible = textBoxM.Visible = labelM.Visible = true;
                richTextBoxGeneral.Text = "1 0,1 0,1 = 1,2\n0,2 1 0,1 = 1,3\n0,2 0,2 1 = 1,4";
                textBoxN.Text = "3";
            }
        }

        private void textBoxN_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
