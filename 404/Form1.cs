using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _404
{
    public partial class Form1 : Form
    {
        private double x1, x2, x3, z1, z2, z3;
        private double[,] arr2 = new double[3, 3];
        private double[,] startArray = new double[3, 4];
        private int iteration = 0, N=3;

        private double[,] ArrayGaus = new double[3, 3];
        private double[] RightM = new double[3];

        private void button1_Click(object sender, EventArgs e)
        {
            #region Проверка на вводные данные матрицы
            try
            {
            fillArrayEasy();
            }
            catch (Exception)
            {
                label4.Visible = true;
            }
            #endregion

            if (radioButton1.Checked==true) 
            {
                iteration = 1;
                textBox1.Clear();
                ClearAnswer();
                z1 = z2 = z3 = 1;

                #region Метод простых итераций

            for(int i = 0; i< numericUpDown1.Value; i++)
            {     
                x1 = z1;
                x2 = z2;
                x3 = z3;
                NextToEasy();
            }

                fillAnswer();

            #endregion
            }// Если выбран Метод простых итераций

            if (radioButton2.Checked==true)
            {
                iteration = 1;
                textBox1.Clear();
                ClearAnswer();

                z1 = z2 = z3=1;
                x1 = Math.Round(arr2[0, 0], 4);
                x2 = Math.Round(arr2[1, 1], 4);
                x3 = Math.Round(arr2[2, 2], 4);


                for (int i = 0; i < numericUpDown1.Value; i++)
                {
                    x1 = z1;
                    x2 = z2;
                    x3 = z3;
                    NextToZeydel();
                }

                fillAnswer();

            }// Если выбран Метод Зейделя

            if (radioButton3.Checked == true)
            {
                iteration = 1;
                textBox1.Clear();
                ClearAnswer();
                fillArrayGaus();
                double[] answer = new double[3];
                answer = Gauss(ArrayGaus,RightM);
               
                    textBox1.Text += $"X1 = {Math.Round(answer[0],4).ToString()}, X2 = {Math.Round(answer[1], 4).ToString()}, X3 = {Math.Round(answer[2], 4).ToString()}";
                valueX12.Text = Math.Round(answer[0], 4).ToString();
                value22.Text = Math.Round(answer[1], 4).ToString();
                value32.Text = Math.Round(answer[2], 4).ToString();


            }// Если выбран Метод Гауса

        }

      
        public Form1()
        {
            InitializeComponent();
        }

        
        public void NextToEasy()
        {
            z1 =Math.Round(arr2[0,0]-arr2[0,1]*x2-arr2[0,2]*x3,4);
            z2= Math.Round(arr2[1,1]-arr2[1,0]*x1-arr2[1,2]*x3,4);
            z3=Math.Round(arr2[2,2]-arr2[2,0]*x1-arr2[2,1]*x2,4);

            textBox1.Text = textBox1.Text + $"I={iteration}\t X1 = {z1},\t X2 = {z2},\t X3 = {z3}\t E={Math.Round(z1-x1,4)}\r\n";
            iteration++;


        } // Следующий шаг для Метода простых итераций
        public void NextToZeydel()
        {
            z1 = Math.Round(arr2[0, 0] - arr2[0, 1] * z2 - arr2[0, 2] * z3, 4);
            z2 = Math.Round(arr2[1, 1] - arr2[1, 0] * z1 - arr2[1, 2] * z3, 4);
            z3 = Math.Round(arr2[2, 2] - arr2[2, 0] * z1 - arr2[2, 1] * z2, 4);

            textBox1.Text = textBox1.Text + $"I={iteration}\t X1 = {z1},\t X2 = {z2},\t X3 = {z3}\t E={Math.Round(z1 - x1, 4)} \r\n";
            iteration++;
        }// Следующий шаг для Метода Зейделя
        private void fillArrayEasy() 
        {
            arr2[0, 0] = double.Parse(m4.Text) / double.Parse(m1.Text);
            arr2[0, 1] = double.Parse(m2.Text) / double.Parse(m1.Text);
            arr2[0, 2] = double.Parse(m3.Text) / double.Parse(m1.Text);
            
            arr2[1, 0] = double.Parse(m5.Text) / double.Parse(m6.Text);
            arr2[1, 1] = double.Parse(m8.Text) / double.Parse(m6.Text);
            arr2[1, 2] = double.Parse(m7.Text) / double.Parse(m6.Text);
            
            arr2[2, 0] = double.Parse(m9.Text) / double.Parse(m11.Text);
            arr2[2, 1] = double.Parse(m10.Text) / double.Parse(m11.Text);
            arr2[2, 2] = double.Parse(m12.Text) / double.Parse(m11.Text);

           
            label4.Visible = false;
         
        }// Заполняем масив для Метода простых итераций
        private void fillArrayGaus()
        {
            ArrayGaus[0, 0] = double.Parse(m1.Text);
            ArrayGaus[0, 1] = double.Parse(m2.Text);
            ArrayGaus[0, 2] = double.Parse(m3.Text);

            ArrayGaus[1, 0] = double.Parse(m5.Text);
            ArrayGaus[1, 1] = double.Parse(m6.Text);
            ArrayGaus[1, 2] = double.Parse(m7.Text);

            ArrayGaus[2, 0] = double.Parse(m9.Text);
            ArrayGaus[2, 1] = double.Parse(m10.Text);
            ArrayGaus[2, 2] = double.Parse(m11.Text);

            RightM[0] = double.Parse(m4.Text);
            RightM[1] = double.Parse(m8.Text);
            RightM[2] = double.Parse(m12.Text);
        }
        private void fillArray()
        {
            startArray[0, 0] = double.Parse(m1.Text);
            startArray[0, 1] = double.Parse(m2.Text);
            startArray[0, 2] = double.Parse(m3.Text);
            startArray[0, 3] = double.Parse(m4.Text);

            startArray[1, 0] = double.Parse(m4.Text);
            startArray[1, 1] = double.Parse(m6.Text);
            startArray[1, 2] = double.Parse(m7.Text);
            startArray[1, 3] = double.Parse(m8.Text);

            startArray[2, 0] = double.Parse(m9.Text);
            startArray[2, 1] = double.Parse(m10.Text);
            startArray[2, 2] = double.Parse(m11.Text);
            startArray[2, 3] = double.Parse(m12.Text);
            
        }// Заполняем массив данными из вводных полей
        private void fillAnswer()
        {
            valueX12.Text = z1.ToString();
            value22.Text = z2.ToString();
            value32.Text = z3.ToString();
        }
        private void ClearAnswer()
        {
            value22.Text = "";
            value32.Text = "";
            valueX12.Text = "";
        }
        private double[] Gauss(double[,] B, double[] RightPart)
            {
                double[] x = new double[N];
                double R;
                try
                {
                    // Прямой ход
                    for (int q = 0; q < N; q++)
                    {
                        R = 1 / B[q, q];
                        B[q, q] = 1;
                        for (int j = q + 1; j < N; j++)
                            B[q, j] *= R;
                        RightPart[q] *= R;
                        for (int k = q + 1; k < N; k++)
                        {
                            R = B[k, q];
                            B[k, q] = 0;
                            for (int j = q + 1; j < N; j++)
                                B[k, j] = B[k, j] - B[q, j] * R;
                            RightPart[k] = RightPart[k] - RightPart[q] * R;
                        }
                    }
                }
                catch (DivideByZeroException)
                {
                    return x;
                }
                // Обратный ход
                for (int q = N - 1; q >= 0; q--)
                {
                    R = RightPart[q];
                    for (int j = q + 1; j < N; j++)
                        R -= B[q, j] * x[j];
                    x[q] = R;
                }
                return x;
            }
        
        
    }

   
}
