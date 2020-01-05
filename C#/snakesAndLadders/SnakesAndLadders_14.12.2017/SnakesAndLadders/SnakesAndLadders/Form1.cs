using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;    
namespace SnakesAndLadders
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class Player
        {
            private string PlayerName;
            private int playerPosition;
            private string PlayeDirection;
            private PictureBox playerPicture;

            public Player(string name, int position, string direction, string path , int height, int width, Point location)
            {
                this.PlayerName = name;
                this.playerPosition = position;
                this.PlayeDirection = name;
                PictureBox picture = new PictureBox();
                picture.Image = Image.FromFile(path);
                picture.Height = height;
                picture.Width = width;
                picture.Location = location;
                this.playerPicture = picture;

            }
            public PictureBox changePictureLocation( Point location)
            {
                this.playerPicture.Location = location;
                return this.playerPicture;

            }
        }

        Random rnd = new Random();
        Player player1;
        PictureBox firstPlayer = new PictureBox();
        PictureBox secontPlayer = new PictureBox();
        PictureBox treePlayer = new PictureBox();
        PictureBox fourthPlayer = new PictureBox();
        int firstPlayerPosition, secontPlayerPosition, treePlayerPosition, fourthPlayerPositio;
        int elementWidth, elementHeight;
        string firstPlayeDirection;

        Label lblzar = new Label();
        private void Form1_Load(object sender, EventArgs e)
        {
            pboxMain.Height = this.Height - 75;
            pboxMain.Width = this.Width - 35;

            elementWidth = (this.Width - 70) / 155;
            elementHeight = (this.Height - 150) / 70;
            int x = 50, y = 50, maxX, maxY, bottamY;
            bottamY = y;
            maxX = x;            
            maxY = y;
            int br = 1;
            //изчисляване на брой змии
            int snakersCount = rnd.Next((elementHeight * elementWidth) / 20, (elementHeight * elementWidth) / 10);
            int[] snakersArr = new int[snakersCount];
            int element;
            // изчисляване къде да са змиите според техния брой
            for (int i = 0; i < snakersCount; i++)
            {

                element = rnd.Next(3, elementHeight * elementWidth - 1);
                Boolean flag = true;
                for (int j = 0; j < i; j++)
                {
                    if (snakersArr[j] == element) flag = false;
                }
                if (flag == true) snakersArr[i] = element;
                else i = i - 1;
            }
            int[,] arr = new int[elementHeight, elementWidth];
            string path = "";

            // създаване на карата за игра, като на позиция с кординати в масива arr[elementWidth - 1,0] е страта
            
            for (int j = elementWidth - 1; j >= 0; j--)
            {
                for (int i = 0; i < elementHeight; i++)
                {
                    arr[i, j] = br;
                    br = br + 1;
                }
                if (j > 0)
                {
                    j = j - 1;
                    for (int i = elementHeight-1; i >=0; i--)
                    {
                         arr[i, j] = br;
                        br = br + 1;
                    }
                }
            }
              
              
            //изграждане на игралното поле на база на масива arr
            PictureBox picture = new PictureBox();
            int count = 0;
            for (int i = 0; i < elementHeight ; i++)
            {
                for (int j = 0; j < elementWidth; j++)
                {
                    br = arr[i, j];
                    for (int p = 0; p < snakersCount; p++)
                    {
                        element = snakersArr[p];
                        if (element == br)
                        {
                            br = -1;
                            if (count < snakersCount - 1)
                            {
                                count = count + 1;
                                element = snakersArr[count];
                            }
                            break;
                        }
                    }
                    
                    //взимане на път на картинката за дадената позиция
                    if (br == 1) path = "images/picture4.bmp";
                    else if (br == elementHeight * elementWidth) path = "images/picture3.bmp";
                    else if (br != -1) path = "images/picture2.bmp";
                    else path = "images/picture1.bmp";
                    br = arr[i, j];
                    picture = createPicture(path, x - 15, y - 30, 70, 70);
                    picture.Name = "pct" + br;
                    picture.Parent = pboxMain;
                    picture.BackColor = Color.Transparent;
                    picture.SendToBack();
                    picture.Refresh();

                    Label nameNewLabel = createLabel(br + "", x, y, 30);
                    nameNewLabel.Parent = picture;
                    nameNewLabel.BackColor = Color.Transparent;
                    nameNewLabel.Refresh();
                    this.Controls.Add(nameNewLabel);

                    y = y + 80;
                }
                bottamY = y - 60;
                y = 50;
                x = x + 140;
                maxX = x;
            }
            //добавяне на играчи

            //първи играч
            firstPlayeDirection = "right";
            path = "images/pleyer1.bmp";
            firstPlayer = createPicture(path, 50, bottamY + 15, 25, 25);
            firstPlayer.BringToFront();
            this.Controls.Add(firstPlayer);
            firstPlayerPosition = 1;
       
            //вточи играч
            path = "images/pleyer2.bmp";
            secontPlayer = createPicture(path, 80, bottamY + 15, 25, 25);
            secontPlayer.BringToFront();
            this.Controls.Add(secontPlayer);
            secontPlayerPosition = 1;

            maxX = maxX - 50;
            lblzar = createLabel("Зар: ", maxX, maxY, 40);
            this.Controls.Add(lblzar);
            Button buttonZar = createButton("Зар", maxX + 60, bottamY - 80);
            buttonZar.Click += new EventHandler(this.buttonZar_Click);
            this.Controls.Add(buttonZar);
            pboxMain.SendToBack();
           
        }

        // функция, която се извикава при кликване на бутон "buttonZar"
        private void buttonZar_Click(object sender, EventArgs e)
        {
            // ичисляване на произволно число в интервала от [1;7) за зар
            int step = rnd.Next(1, 7);
            lblzar.Text = "Зар: " + step;
            if ((firstPlayerPosition == 1) && (step == 6))
            {
                firstPlayer = movePlayerRigth(firstPlayer);
                firstPlayer.Refresh();
                firstPlayerPosition = firstPlayerPosition + 1;
            }
            else if (firstPlayerPosition != 1)
            {
                if (firstPlayerPosition + step <= elementWidth * elementWidth)
                {
                    for (int i = 0; i < step; i++)
                    {
                        if (firstPlayeDirection == "up") firstPlayer = movePlayerUp(firstPlayer);
                        else
                        {
                            if (firstPlayeDirection == "right") firstPlayer = movePlayerRigth(firstPlayer);
                            else if (firstPlayeDirection == "left") firstPlayer = movePlayerLeft(firstPlayer);
                            
                        }
                        firstPlayer.Refresh();
                        firstPlayerPosition = firstPlayerPosition + 1;
                        if (firstPlayerPosition % elementWidth == 0) firstPlayeDirection = "up";
                        else if ((firstPlayerPosition / elementWidth) % 2 == 0) firstPlayeDirection = "right";
                        else firstPlayeDirection = "left";
                    }
                }
            }
            firstPlayer.Refresh();

            GetAllControls(this);

        }

        public static IEnumerable<Control> GetAllControls(Control root)
        {
            var stack = new Stack<Control>();
            stack.Push(root);
            while (stack.Any())
            {
                var next = stack.Pop();
                foreach (Control child in next.Controls)
                    stack.Push(child);
                MessageBox.Show(next.Name);

                yield return next;
            }
        }

        static PictureBox movePlayer(PictureBox player ,int playerPosition, string playerDirection, int height,int width)
        {
            Random rnd = new Random();
            int step = rnd.Next(1, 7);
            //lblzar.Text = "Зар: " + step;
            if ((playerPosition == 1) && (step == 6))
            {

                player = movePlayerRigth(player);
                player.Refresh();
                playerPosition = playerPosition + 1;
            }
            else if (playerPosition != 1)
            {
                Boolean flagRow = false;
                if (playerPosition + step <= height * width)
                {
                    for (int i = 0; i < step; i++)
                    {
                        flagRow = false;
                        if (playerDirection == "up")
                        {
                            player = movePlayerUp(player);
                            flagRow = true;
                        }
                        else
                        {
                            if (playerDirection == "right") player = movePlayerRigth(player);
                            else if (playerDirection == "left") player = movePlayerLeft(player);
                            player.Refresh();
                            flagRow = true;
                        }
                        playerPosition = playerPosition + 1;
                        if (playerPosition % width == 0) playerDirection = "up";
                        else if (flagRow == true)
                        {
                            if ((playerPosition / width) % 2 == 0) playerDirection = "right";
                            else playerDirection = "left";
                        }
                    }
                }
            }
            player.Location = new Point(player.Location.X + 140, player.Location.Y);
            return player;
        }

        //местена на играча на дясно
        static PictureBox movePlayerRigth(PictureBox player)
        {
            
            player.Location = new Point(player.Location.X + 140, player.Location.Y);
            return player;
        }

        //местена на играча на нагоре
        static PictureBox movePlayerUp(PictureBox player)
        {
            player.Location = new Point(player.Location.X, player.Location.Y - 80);
            return player;
        }

        //местена на играча на ляво
        static PictureBox movePlayerLeft(PictureBox player)
        {
            player.Location = new Point(player.Location.X-140, player.Location.Y);
            return player;
        }

        //създавне на каринка
        static PictureBox createPicture(string path,int x, int y, int Height, int Width)
        {
            PictureBox picture = new PictureBox();
            picture.Image = Image.FromFile(path);
            picture.Height = Height;
            picture.Width = Width;
            picture.Location = new Point(x, y);
            picture.SizeMode = PictureBoxSizeMode.StretchImage;
            return picture;

           
        }

        //създаване на label
        static Label createLabel(string text, int x, int y, int Width)
        {
            Label newLabel = new Label();
            newLabel.Location = new Point(x, y);
            newLabel.Text = text;
            newLabel.Name = "lbl"+text;
            newLabel.Width = Width;
            return newLabel;
        }
        
        //създаване на button
        static Button createButton(string text, int x,int y)
        {
            Button newButton = new Button();
            newButton.Location = new Point(x, y);
            newButton.Text = text;
            newButton.Name = "lbl" + text;
            newButton.Width = 80;
            newButton.Height = 80;
            return newButton;
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Show();
        }


    }
}
