using System;
using System.Windows.Forms;

namespace Tic_Tac_Toe_Game
{
    public partial class Form1 : Form
    {
        bool turn = true; //true = X turn, false= Y turn
        int turn_count = 0;
        private static string player1, player2;
        public static void setPlayerName(string n1, string n2)
        {
            player1=n1;
            player2=n2;
        }
        public  Form1()
        {
            InitializeComponent();
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Created By Temur Mikava", "TicTaToe Game About");
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
                b.Text = "X";
            else
                b.Text = "O";
            turn = !turn;
            b.Enabled = false;
            turn_count++;
            checkForWinner();
        }
        private void checkForWinner()
        {
            bool there_is_a_winner = false;
                //check for horizontal
            if (A1.Text == A2.Text && A2.Text == A3.Text && !A1.Enabled ||
                B1.Text == B2.Text && B2.Text == B3.Text && !B1.Enabled ||
                C1.Text == C2.Text && C2.Text == C3.Text && !C1.Enabled ||
                //check for vertical
                A1.Text == B1.Text && B1.Text == C1.Text && !A1.Enabled ||
                A2.Text == B2.Text && B2.Text == C2.Text && !A2.Enabled ||
                A3.Text == B3.Text && B3.Text == C3.Text && !A3.Enabled ||
                //check for diagonals
                A1.Text == B2.Text && B2.Text == C3.Text && !A1.Enabled ||
                A3.Text == B2.Text && B2.Text == C1.Text && !A3.Enabled)
            {
                there_is_a_winner = true;
            }

            if (there_is_a_winner)
            {
                disableButtons();
                string winner = "";
                if (turn)
                {
                    winner =player2;
                    o_win_count.Text = (Int32.Parse(o_win_count.Text) + 1).ToString();
                }
                else
                {
                    winner = player1;
                    x_win_count.Text = (Int32.Parse(x_win_count.Text) + 1).ToString();
                }
                MessageBox.Show($"Congratulation {winner}! you win!");
            }
            else
            {
                if (turn_count == 9)
                {
                    drow_count.Text = (Int32.Parse(drow_count.Text) + 1).ToString();
                    MessageBox.Show("Drow!");
                }
            }
        }
        private void disableButtons()
        {
            foreach (Control c in Controls)
            {
                if (c.GetType() == typeof(Button) && c.Name!="button1")
                {
                    c.Enabled = false;
                }
            }
        }
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turn_count = 0;
            foreach (Control c in Controls)
            {
                if (c.GetType() == typeof(Button) && c.Name!="button1")
                {
                    c.Enabled = true;
                    c.Text = "";
                }
            }
        }
        private void button_enter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                if (turn)
                    b.Text = "X";
                else
                    b.Text = "O";
            }
        }
        private void button_leave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
                b.Text = "";
        }
        private void resetWinCountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            o_win_count.Text = "0";
            x_win_count.Text = "0";
            drow_count.Text = "0";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            turn = true;
            turn_count = 0;
            foreach (Control c in Controls)
            {
                if (c.GetType() == typeof(Button)&& c.Name!="button1")
                {
                    c.Enabled = true;
                    c.Text = "";
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
            label1.Text = player1;
            label2.Text= player2;
        }
    }
}
