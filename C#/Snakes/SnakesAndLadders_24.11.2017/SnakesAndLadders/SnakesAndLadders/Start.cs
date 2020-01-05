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
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
        }

        private void Start_Load(object sender, EventArgs e)
        {

        }

      

 

        private void rbtnTwo_CheckedChanged(object sender, EventArgs e)
        {
            txtPlayer3.Enabled = false;
            label4.Enabled = false;
            txtPlayer4.Enabled = false;
            label5.Enabled = false;
        }

        private void rbtnTree_CheckedChanged(object sender, EventArgs e)
        {
            txtPlayer3.Enabled = true;
            label4.Enabled = true;
            txtPlayer4.Enabled = false;
            label5.Enabled = false;
        }

        private void rbtnFour_CheckedChanged(object sender, EventArgs e)
        {
            txtPlayer3.Enabled = true;
            label4.Enabled = true;
            txtPlayer4.Enabled = true;
            label5.Enabled = true;

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            String player1=txtPlayer1.Text;
            String player2 = txtPlayer2.Text;
            String player3 = txtPlayer3.Text;
            String player4 = txtPlayer4.Text;
            int flag = 0;
            if (player1 == "")
            {
                MessageBox.Show("Моля поставете име на играч 1!", "Змии и стълби");
                flag = 1;
            }
            if(flag==0)
            {

                Form1 frm1 = new Form1();
                this.Hide();
                frm1.Show();
            }
           
        }
       
    }
}
