using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlackJack.Common;

namespace BlackJack.Client
{
    public partial class MainWindow : Form
    {
        private ClientGameManager gm = new ClientGameManager();
        public MainWindow()
        {
            InitializeComponent();
            gm.UserPlayer.CardTaken += OnCardTaken;
            gm.Dealer.CardTaken += OnCardTaken;
            gm.GameOver += GmOnGameOver;
        }

        private void OnCardTaken(object sender, CardEventArgs e)
        {
            listBox1.Items.Add(String.Format("{0} takes {2}({4}) of {1}. {0}'s card score: {3}",
                         e.Player.PlayerType == PlayerType.Dealer ? "Dealer" : "Player",
                         e.Card.Suit.ToString(),
                         e.Card.Value.ToString(),
                         e.CardScore,
                         e.Card.GetWeight()));
            label3.Text = gm.Dealer.CardScore.ToString();
            label4.Text = gm.UserPlayer.CardScore.ToString();
            label5.Text = gm.UserPlayer.Cash.ToString();
        }

        private void GmOnGameOver(object sender, CardEventArgs e)
        {
            MessageBox.Show(String.Format("{0} won the game with {1} points",
                e.Player.PlayerType == PlayerType.NotSet && e.Player.Username == "Draw" ? "Draw" : e.Player.PlayerType == PlayerType.Dealer ? "Dealer" : "Player",
                     e.CardScore));
            label5.Text = gm.UserPlayer.Cash.ToString();
        }

        private void newGameButon_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            gm.StartGame();
        }

        private void hitButton_Click(object sender, EventArgs e)
        {
            try
            {
                gm.Hit();
            }
            catch (InvalidOperationException ex)
            {
                listBox1.Items.Add(ex.Message);
            }
        }

        private void doubleButton_Click(object sender, EventArgs e)
        {
            try
            {
                gm.DoubleBet();
            }
            catch (InvalidOperationException ex)
            {
                listBox1.Items.Add(ex.Message);
            }
        }

        private void standButton_Click(object sender, EventArgs e)
        {
            try
            {
                gm.Stand();
            }
            catch (InvalidOperationException ex)
            {
                listBox1.Items.Add(ex.Message);
            }
        }



    }
}
