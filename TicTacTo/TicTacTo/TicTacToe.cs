namespace TicTacTo
{
    using System;
    using System.Windows.Forms;

    public partial class TicTacToe : Form
    {
        bool turn = true;// true = X turn; false = Y turn
        int turnCount = 0;

        public TicTacToe()
        {
            InitializeComponent();
        } 

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By Stoycho Mihaylov, Tic Tac Too About");
        }

        private void exitGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
            {
                b.Text = "X";
            }
            else
            {
                b.Text = "O";
            }
            turn = !turn;
            b.Enabled = false;
            turnCount++;
            CheckForWinnder();
        }

        private void CheckForWinnder()
        {
            bool thereIsAWinner = false;

            if (A1.Text == A2.Text && A2.Text == A3.Text && !A1.Enabled && A1.Text != "")
            {
                thereIsAWinner = true;
            }
            else if (B1.Text == B2.Text && B2.Text == B3.Text && !B1.Enabled && B1.Text != "")
            {
                thereIsAWinner = true;
            }
            else if (C1.Text == C2.Text && C2.Text == C3.Text && !C1.Enabled && C1.Text != "")
            {
                thereIsAWinner = true;
            }
            else if (A1.Text == B1.Text && B1.Text == C1.Text && !A1.Enabled && A1.Text != "")
            {
                thereIsAWinner = true;
            }
            else if (A2.Text == B2.Text && B2.Text == C2.Text && !A2.Enabled && A2.Text != "")
            {
                thereIsAWinner = true;
            }
            else if (A3.Text == B3.Text && B3.Text == C3.Text && !A3.Enabled && A3.Text != "")
            {
                thereIsAWinner = true;
            }
            else if (C1.Text == B2.Text && B2.Text == A3.Text && !C1.Enabled && C1.Text != "")
            {
                thereIsAWinner = true;
            }
            else if (A1.Text == B2.Text && B2.Text == C3.Text && !A1.Enabled && A1.Text != "")
            {
                thereIsAWinner = true;
            }

            if (thereIsAWinner)
            {
                DisableButtons();
                string winner = "";
                if (turn)
                {
                    winner = "O";
                    o_win_count.Text = (int.Parse(o_win_count.Text) + 1).ToString();
                }
                else
                {
                    winner = "X";
                    x_win_count.Text = (int.Parse(x_win_count.Text) + 1).ToString();
                }
                MessageBox.Show(winner + " Wins!!!");
            }
            else
            {
                if (turnCount == 9)
                {
                    equal_count.Text = (int.Parse(equal_count.Text) + 1).ToString();
                    MessageBox.Show("Equal play");
                }
            }
        }

        private void DisableButtons()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }
            catch { }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turnCount = 0;

            foreach (Control c in Controls)
            {
                try
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }
                catch { }
            }
        }

        private void button_enter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                if (turn)
                {
                    b.Text = "X";
                }
                else
                {
                    b.Text = "O";
                }
            }
        }

        private void button_leave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                b.Text = "";
            }

        }

        private void resetWinCountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            x_win_count.Text = "0";
            o_win_count.Text = "0";
            equal_count.Text = "0";
        }

        private void TicTacToe2_Load(object sender, EventArgs e)
        {

        }
    }
}
