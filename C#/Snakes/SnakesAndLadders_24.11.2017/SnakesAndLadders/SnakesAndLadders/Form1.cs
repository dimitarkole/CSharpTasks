using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakesAndLadders
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pboxMain.Height = this.Height - 75;
            pboxMain.Width = this.Width - 35;
            int elementWidth = (this.Width - 70) / 115;
            int elementHeight = (this.Height - 150) / 70;
            short[,] map= new short[elementHeight, elementWidth];
            int x=50, y=50,maxX,maxY;
            maxX = x;
            maxY = y;
            int br=1;
            Random rnd = new Random();
            int snakersCount = rnd.Next(1, (elementHeight * elementWidth) / 10);
            int[] snakersArr = new int[snakersCount];
            int element;
            for (int i = 0; i < snakersCount; i++)
            {

                element = rnd.Next(1,elementHeight * elementWidth);
                Boolean flag = true;
                for (int j = 0; j <i; j++)
                {
                    if(snakersArr[j]==element)flag= false;
                }
                if (flag == true) snakersArr[i] = element;
                else i = i - 1;
            }
            int[,] arr = new int[elementHeight, elementWidth];
            for (int i = 0; i < snakersCount; i++)
            {
                for (int j = 1; j < snakersCount; j++)
                {
                    if (snakersArr[j - 1] > snakersArr[j])
                    {
                        int buf = snakersArr[j - 1];
                        snakersArr[j - 1] = snakersArr[j];
                        snakersArr[j] = buf;
                    }
                }
            }
            int count=0;
            string path = "";
            element = snakersArr[count];
            for (int j = elementWidth - 1; j >= 0; j--)
            {
                for (int i = 0; i < elementHeight; i++)
                {
                    if (element == br)
                    {
                        arr[i, j] = -1;
                        if (count < snakersCount-1)
                        {

                            count = count + 1;
                            element = snakersArr[count];
                        }
                    }
                    else arr[i, j] = br;
                    br = br + 1;
                }
                if (j > 1)
                {
                    j = j - 1;
                    for (int i = elementHeight-1; i >=0; i--)
                    {
                        if (element == br)
                        {
                            arr[i, j] = -1;
                            if (count < snakersCount-1)
                            {

                                count = count + 1;
                                element = snakersArr[count];
                            }
                        }
                        else arr[i, j] = br;
                        br = br + 1;
                    }
                }
            }

            PictureBox picture = new PictureBox();
            for (int i = 0; i < elementHeight; i++)
            {
                for (int j = 0; j < elementWidth; j++)
                {
                    Label nameNewLabel = new Label();
                    nameNewLabel.Location = new Point(x, y);
                    br = arr[i, j];
                    nameNewLabel.Text = br.ToString();
                    nameNewLabel.Name = "lbl" + br;
                    nameNewLabel.Width = 30;
                    nameNewLabel.Parent = pboxMain;
                    nameNewLabel.BackColor = Color.Transparent;
                    this.Controls.Add(nameNewLabel);

                    picture = new PictureBox();
                    picture.Location = new Point(x,y);
                    
                    if (br!=-1)  path = "images/picture2.bmp";
                    else  path = "images/picture1.bmp";
                    picture.Image = Image.FromFile(path);
                    picture.Height=50;
                    picture.Width = 50;
                    picture.SizeMode = PictureBoxSizeMode.StretchImage;
                    this.Controls.Add(picture);

                    picture.SendToBack();
                    y = y + 60;
                }
                
                
                y = 50;
                x = x + 140;
                maxX = x;
            }
            x = 50;
            y = 50;
            picture = new PictureBox();
            picture.Location = new Point(x, y);
            path = "images/pleyer1.bmp";
            picture.Image = Image.FromFile(path);
            picture.Height = 50;
            picture.Width = 50;
            picture.SizeMode = PictureBoxSizeMode.StretchImage;
            picture.BringToFront();
            this.Controls.Add(picture);
            MessageBox.Show("x=  " + x + "   y= " + y);

            Label namelabel = new Label();
            maxX = maxX - 50;
            namelabel.Location = new Point(maxX, maxY);
            namelabel.Text = "max";

            namelabel.Name = "lblbr";
            namelabel.Width = 30;
            this.Controls.Add(namelabel);
            pboxMain.SendToBack();
        }

   

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Show();
        }
    }
}
