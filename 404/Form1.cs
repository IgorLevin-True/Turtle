﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _404
{
    public partial class Form1 : Form
    {
 
        private double x1, x2, x3, z1, z2, z3;
        private double[,] arr = new double[3, 4];
        private double[,] arr2 = new double[3, 3];
        public Form1()
        {
           
            InitializeComponent();
            Read(); // Заполняем матрицу вводными данными
            Read2();
            SelectX(); // Находим наше Х0

            #region Заполнение формы нашим Х0
            valueX1.Text = x1.ToString();
            valueX2.Text = x2.ToString();
            valueX3.Text = x3.ToString();
            #endregion

            

            #region Заполням формы нашим Х1
            valueX12.Text = z1.ToString();
            value22.Text = z2.ToString();
            value32.Text = z3.ToString();
            #endregion

            for (int i = 0; i < 10; i++)
            {
                x1 = z1;
                x2 = z2;
                x3 = z3;
                NextX();
            }
        
            valueX12.Text = z1.ToString();
            value22.Text = z2.ToString();
            value32.Text = z3.ToString();
        }

        public void SelectX()
        {
            x1 =Math.Round(arr[0,3] /arr[0,0],4);
            x2 =Math.Round( arr[1,3] / arr[1,1],4);
            x3 =Math.Round(arr[2,3] / arr[2,2],4);
        }
        public void NextX()
        {
            z1 =Math.Round(arr2[0,0]-arr2[0,1]*x2-arr2[0,2]*x3,4);
            z2= Math.Round(arr2[1,1]-arr2[1,0]*x1-arr2[1,2]*x3,4);
            z3=Math.Round(arr2[2,2]-arr2[2,0]*x1-arr2[2,1]*x2,4);
        }
        private void Read() 
        {
            arr[0, 0] = double.Parse(m1.Text);
            arr[0, 1] = double.Parse(m2.Text);
            arr[0, 2] = double.Parse(m3.Text);
            arr[0, 3] = double.Parse(m4.Text);
            arr[1, 0] = double.Parse(m5.Text);
            arr[1, 1] = double.Parse(m6.Text);
            arr[1, 2] = double.Parse(m7.Text);
            arr[1, 3] = double.Parse(m8.Text);
            arr[2, 0] = double.Parse(m9.Text);
            arr[2, 1] = double.Parse(m10.Text);
            arr[2, 2] = double.Parse(m11.Text);
            arr[2, 3] = double.Parse(m12.Text);
        }
        private void Read2() 
        {
            arr2[0, 0] = arr[0, 3] / arr[0, 0];
            arr2[0, 1] = arr[0, 1] / arr[0, 0];
            arr2[0, 2] = arr[0, 2] / arr[0, 0];
            
            arr2[1, 0] = arr[1, 0] / arr[1, 1];
            arr2[1, 1] = arr[1, 3] / arr[1, 1];
            arr2[1, 2] = arr[1, 2] / arr[1, 1];
            
            arr2[2, 0] = arr[2, 0] / arr[2, 2];
            arr2[2, 1] = arr[2, 1] / arr[2, 2];
            arr2[2, 2] = arr[2, 3] / arr[2, 2];
         
        }

       
    }
}
