using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _404
{
    public partial class Form1 : Form
    {
        private double x1, x2, x3, z1, z2, z3;
        private double[,] arr2 = new double[3, 3];
        private string path = "C:\\Users\\lytgh\\OneDrive\\Рабочий стол\\Информация про итерации.txt";
        private int iteration = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            #region Проверка на вводные данные матрицы
            try
            {
            FillArray();
            }
            catch (Exception)
            {
                label4.Visible = true;
            }
            #endregion
            #region Вычисление Х - нулевого.
            x1 = Math.Round(arr2[0, 0], 4);
            x2 = Math.Round(arr2[1, 1], 4);
            x3 = Math.Round(arr2[2, 2], 4);
            #endregion

            for (int i = 0; i < 20; i++)
            {
                x1 = z1;
                x2 = z2;
                x3 = z3;
                NextX();
            }

            #region Заполняем ячейки на форме, нашим Х1, Х2, Х3.
            valueX12.Text = z1.ToString();
            value22.Text = z2.ToString();
            value32.Text = z3.ToString();
            #endregion
        }


        public Form1()
        {
            InitializeComponent();   
        }

        
        public void NextX()
        {
            z1 =Math.Round(arr2[0,0]-arr2[0,1]*x2-arr2[0,2]*x3,4);
            z2= Math.Round(arr2[1,1]-arr2[1,0]*x1-arr2[1,2]*x3,4);
            z3=Math.Round(arr2[2,2]-arr2[2,0]*x1-arr2[2,1]*x2,4);

            // Записываем в файл на рабочем столе информацию про данные в каждой итерации,
            // если файла нет - он создаётся, иначе записывает в существующий.
            using (StreamWriter stream = new StreamWriter(path, true))
            {
                stream.WriteLineAsync
                   ($" X1={z1.ToString()}, X2={z2.ToString()},X3={z3.ToString()}. Итерация - {iteration++.ToString()}. E={Math.Round(z1-x1,7)} ");
            }
        }
        
        private void FillArray() 
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
         
        }

       
    }
}
