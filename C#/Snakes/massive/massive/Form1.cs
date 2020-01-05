using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace massive
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int heigth, width;
            heigth = int.Parse(txtHeight.Text);
            width = int.Parse(txtWidth.Text);
            int[,] arr = new int[heigth, width];

            for (int i = 0; i < heigth; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    arr[i, j] = 0;
                }
            }
            arr[heigth - 1, 0] = 1;
            arr[0, width-1] = 2;
            int x = heigth-1, y = 0;
            label1.Text = "\r\n";
            int direction,stypki;
            Random rnd = new Random();
            direction  = rnd.Next(1, 3);
            if (direction==1)
            {
                x = x - 1;
                stypki = rnd.Next(1, heigth);
                MessageBox.Show("1");
                for (int i =heigth; i > heigth - stypki; i--)
                {
                    arr[x, y] = 1;
                    x = x - 1;
                }
            }
            else
            {
                y = y + 1;
                MessageBox.Show("2");
                stypki = rnd.Next(1, width);
                for (int i = 0; i <stypki; i++)
                {
                    arr[x,y ] = 1;
                    y = y + 1;
                }
            }

            for (int i = 0; i < heigth; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    label1.Text=label1.Text+ "  "+ arr[i, j];
                }
                label1.Text = label1 + "\r\n";
                label1.Text = label1 + "\r\n";
            }
        }
    }
}
