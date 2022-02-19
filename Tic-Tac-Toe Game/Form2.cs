using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe_Game
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (p1.Text == "" || p2.Text == "")
            {
                p1.Text = "Player 1";
                p2.Text = "Player 2";
            }
            else 
            {
                Form1.setPlayerName(p1.Text, p2.Text);
                this.Close();
            }
            
        }
    }
}
