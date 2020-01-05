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
        Button buttonZar;
        Random rnd = new Random();
        PictureBox firstPlayer = new PictureBox();
        PictureBox secontPlayer = new PictureBox();
        Label lblPlayerRow = new Label();
        int firstPlayerPosition, secontPlayerPosition,playersRow;
        int elementWidth, elementHeight;
        string firstPlayeDirection, secontPlayeDirection;

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
            //ToDo: изчисляване на брой змии
            int snakersCount = rnd.Next((elementHeight * elementWidth) / 20, (elementHeight * elementWidth) / 10);
            int[] snakersArr = new int[snakersCount];
            int element;
            // ToDo: изчисляване къде да са змиите според техния брой
            for (int i = 0; i < snakersCount; i++)
            {

                element = rnd.Next(3, elementHeight * elementWidth - 1);
                Boolean flag = true;
                for (int j = 0; j < i; j++)
                {
                    if (snakersArr[j] == element)
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag == true) snakersArr[i] = element;
                else i = i - 1;
            }

            int[,] arr = new int[elementHeight, elementWidth];
            string path = "";
            //ToDo:  създаване на карата за игра, като на позиция с кординати в масива arr[elementWidth - 1,0] е страта            
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

            //ToDo: изграждане на игралното поле на база на масива arr
            PictureBox picture = new PictureBox();
            Label nameNewLabel;
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
                            break;
                        }
                    }

                    //ToDo: взимане на път на картинката за дадената позиция
                    if (br == 1) path = "images/picture4.bmp";
                    else if (br == elementHeight * elementWidth) path = "images/picture3.bmp";
                    else if (br != -1) path = "images/picture2.bmp";
                    else path = "images/picture1.bmp";
                    br = arr[i, j];
                    //ToDo: добавяне на картинката на екана
                    picture = new PictureBox();
                    picture = createPicture(path, x - 15, y - 30, 70, 70);
                    picture.Name = "pct" + br;
                    picture.Tag = path;
                    picture.Parent = pboxMain;
                    picture.BackColor = Color.Transparent;
                    picture.SendToBack();
                    picture.Refresh();

                    nameNewLabel = createLabel(br + "", x, y, 30,20);
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
            //ToDo: добавяне на играчи

            //ToDo: първи играч
            playersRow = 1;
            firstPlayeDirection = "right";
            path = "images/pleyer1.bmp";
            firstPlayer = createPicture(path, 50, bottamY + 15, 25, 25);
            this.Controls.Add(firstPlayer);
            firstPlayerPosition = 1;
            firstPlayer.BringToFront();
            firstPlayer.Refresh();

            //ToDo: вточи играч
            path = "images/pleyer2.bmp";
            secontPlayer = createPicture(path, 80, bottamY + 15, 25, 25);
         
            this.Controls.Add(secontPlayer);
            secontPlayer.BringToFront();
            secontPlayer.Refresh();
            secontPlayerPosition = 1;
            secontPlayeDirection = "right";
            maxX = maxX - 50;
            Panel myPanel = new Panel();
            myPanel.Location = new Point(maxX, maxY-5);
            myPanel.Name = "myPanel";
            myPanel.Width = pboxMain.Width- maxX;
            myPanel.Height = ((pboxMain.Height - maxY)/3)*2;
            this.Controls.Add(myPanel);


            String plaeyString = "Име на първия играч:";
            plaeyString = plaeyString + '\n'+ '\n' + '\n' + '\n' + "Име на втория играч:";
            plaeyString = plaeyString + '\n' + '\n' + '\n' + '\n' + "Име на третия играч:";
            plaeyString = plaeyString + '\n'+ '\n' +'\n' + '\n' + "Име на четвъртия играч:";
            plaeyString = plaeyString + '\n' + '\n' + '\n' + '\n';
            int width = pboxMain.Width - maxX;
            int height = 56000 / width;
            x = 5;
            y = 5;

            nameNewLabel = createLabel(plaeyString, x, y, width, height);
            nameNewLabel.BringToFront();
            nameNewLabel.Refresh();
            myPanel.Controls.Add(nameNewLabel);

            y = y + height+10;
            lblPlayerRow = createLabel("На ход е: 1", x, y, 80, 20);
            myPanel.Controls.Add(lblPlayerRow);

            y = y + 20;
            lblzar= createLabel("Зар ", x, y, 100, 20);
            myPanel.Controls.Add(lblzar);
            buttonZar = createButton("Зар", maxX + 60, bottamY - 80);
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
            string path = "images/zar"+step+".bmp";
            buttonZar.Image= Image.FromFile(path);
            
            buttonZar.BackgroundImageLayout = ImageLayout.Zoom;
            if(( playersRow == 1) ||(firstPlayerPosition==0))
            {
                if ((firstPlayerPosition == 1) && (step == 6))
                {
                    playersRow = 1;
                    firstPlayerPosition = 0;
                }
                else if (firstPlayerPosition == 0) firstPlayerPosition = 1;

                if (firstPlayerPosition > 0)
                {
                    firstPlayer = movePlayer(firstPlayer, firstPlayerPosition, firstPlayeDirection, step, 1);

                    firstPlayer.Refresh();
                    playersRow = 2;
                }
                lblPlayerRow.Text = "На ход е: " + playersRow;
                if (firstPlayerPosition > 1)
                {
                    PictureBox pic = (PictureBox)(this.Controls.Find("pct" + firstPlayerPosition, true))[0];
                    path = pic.Tag.ToString();
                    if (path == "images/picture1.bmp")
                    {
                        MessageBox.Show("zmiq 1");
                        firstPlayeDirection = "right";
                        pic = (PictureBox)(this.Controls.Find("pct" + 1, true))[0];
                        Point newLocation = new Point(50, pic.Location.Y+65);
                        firstPlayer.Location = newLocation;
                        firstPlayer.Refresh();
                        firstPlayerPosition = 1;

                    }
                }

            }
            else if((playersRow==2)|| (secontPlayerPosition==0))
            {
                if ((secontPlayerPosition == 1) && (step == 6))
                {
                    playersRow = 2;
                    secontPlayerPosition = 0;
                }
                else if (secontPlayerPosition == 0) secontPlayerPosition = 1;
                if (secontPlayerPosition > 0)
                {
                    secontPlayer = movePlayer(secontPlayer, secontPlayerPosition, secontPlayeDirection, step, 2);
                    secontPlayer.Refresh();
                    playersRow = 1;
                }
                lblPlayerRow.Text = "На ход е: " + playersRow;
                if (secontPlayerPosition > 1)
                {
                    /*PictureBox pic = (PictureBox)(this.Controls.Find("pct" + 1, true))[0];
                    Point newLocation = new Point(80, pic.Location.Y + 65);
                    secontPlayer = checkSnake(secontPlayer, secontPlayerPosition, newLocation);
                    if(secontPlayer.Location== newLocation)
                    {
                        MessageBox.Show("2 2 2 secontPlayerPosition= "+ secontPlayerPosition);
                        secontPlayeDirection = "left";
                        secontPlayerPosition = 1;

                    }*/

                    PictureBox pic = (PictureBox)(this.Controls.Find("pct" + (secontPlayerPosition -1), true))[0];
                    path = pic.Tag.ToString();
                    if(path == "images/picture1.bmp")
                    {
                        MessageBox.Show("zmiq 2");
                        secontPlayeDirection = "right";
                        pic = (PictureBox)(this.Controls.Find("pct"+ 1, true))[0];
                        Point newLocation = new Point(80, pic.Location.Y + 65);
                        secontPlayer.Location = newLocation;
                        secontPlayer.Refresh();
                        secontPlayerPosition = 1;

                    }
                }
            }

        }
        public PictureBox checkSnake(PictureBox player, int playerPosion, Point location)
        {
            PictureBox pic = (PictureBox)(this.Controls.Find("pct" + playerPosion, true))[0];
            string path = pic.Tag.ToString();
            if (path == "images/picture1.bmp") player.Location = location;
            return player;
        }
        //ToDo: Местене на играч
        public PictureBox movePlayer(PictureBox player ,int playerPosition, string playerDirection,int step, int playerNumber)
        {
            if (playerPosition + step <= elementWidth * elementWidth)
            {
                for (int i = 0; i < step; i++)
                {
                    if (playerDirection == "up") player = movePlayerUp(player);
                    else
                    {
                        if (playerDirection == "right") player = movePlayerRigth(player);
                        else if (playerDirection == "left") player = movePlayerLeft(player);

                    }
                    playerPosition = playerPosition + 1;
                    /*if (playerPosition % elementWidth == 0) playerDirection = "up";
                    else if ((playerPosition / elementWidth) % 2 == 0) playerDirection = "right";*/
                    if (playerPosition % (elementHeight-1) == 0) playerDirection = "up";
                    else if ((playerPosition / (elementHeight-1)) % 2 == 0) playerDirection = "right";
                    else playerDirection = "left";
                }
                if (playerNumber == 1)
                {
                    firstPlayeDirection = playerDirection;
                    firstPlayerPosition = firstPlayerPosition + step;
                }
                else if (playerNumber == 2)
                {
                    secontPlayerPosition = secontPlayerPosition + step;
                    secontPlayeDirection = playerDirection;
                }

            }
            return player;
        }

        //ToDo: местена на играча на дясно
        static PictureBox movePlayerRigth(PictureBox player)
        {
            player.Location = new Point(player.Location.X + 140, player.Location.Y);
            return player;
        }
        //ToDo: местена на играча на нагоре
        static PictureBox movePlayerUp(PictureBox player)
        {
            player.Location = new Point(player.Location.X, player.Location.Y - 80);
            return player;
        }

        //ToDo: местена на играча на ляво
        static PictureBox movePlayerLeft(PictureBox player)
        {
            player.Location = new Point(player.Location.X-140, player.Location.Y);
            return player;
        }

        //ToDo: създавне на каринка
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

        //ToDo: създаване на label
        static Label createLabel(string text, int x, int y, int Width, int height)
        {
            Label newLabel = new Label();
            newLabel.Location = new Point(x, y);
            newLabel.Text = text;
            newLabel.Name = "lbl"+text;
            newLabel.Width = Width;
            newLabel.Height = height;
            return newLabel;
        }

        //ToDo: създаване на button
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
    }
}
