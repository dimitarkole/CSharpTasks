using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace createElementWithCode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Label namelabel = new Label();
            namelabel.Location = new Point(100,100);
            namelabel.Text = "sajkd";
            namelabel.Name = "label";
            this.Controls.Add(namelabel);
        }
    }
}
