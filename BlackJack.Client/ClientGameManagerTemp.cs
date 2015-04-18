using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Common;

namespace BlackJack.Client
{
    class ClientGameManagerTemp
    {
        #region Private members
        private void Clear()
        {
            EndGame = false;
            doubleFactor = 1.0;
            Winner = null;
            Dealer.Clear();
            UserPlayer.Clear();
            canDouble = true;
            isRunning = false;
        }
        private Player Winner;
        private Double doubleFactor = 1.0;
        private bool EndGame = false;
        private bool canDouble;
        private bool isRunning;
        private static Player CreateDraftPlayer()
        {
            var p = new Player(PlayerType.NotSet, "Draw");
            return p;
        }
        private void CalculateWinner()
        {
            if (!EndGame)
            {
                if (IsBlackJack(Dealer) && IsBlackJack(UserPlayer))
                    Winner = CreateDraftPlayer();
                else
                {
                    if (IsBlackJack(Dealer))
                        Winner = Dealer;
                    if (IsBlackJack(UserPlayer))
                        Winner = UserPlayer;
                }
            }
            else
            {
                if (Dealer.CardScore == 21)
                    if (UserPlayer.CardScore == 21)
                        Winner = CreateDraftPlayer();
                    else
                        Winner = Dealer;
                else if (UserPlayer.CardScore == 21)
                    if (Dealer.CardScore == 21)
                        Winner = CreateDraftPlayer();
                    else
                        Winner = UserPlayer;
                else if (UserPlayer.CardScore > 21)
                    Winner = Dealer;
                else if (Dealer.CardScore > 21)
                    Winner = UserPlayer;
                else if (UserPlayer.CardScore > Dealer.CardScore)
                    Winner = UserPlayer;
                else if (Dealer.CardScore > UserPlayer.CardScore)
                    Winner = Dealer;
                else
                    Winner = CreateDraftPlayer();
            }

            /*
            if (dealer.CardScore == 21)
                Winner = dealer;
            else if (userPlayer.CardScore > 21)
                Winner = dealer;
            else if (dealer.CardScore > 21)
                Winner = userPlayer;
            else if (userPlayer.CardScore == dealer.CardScore)
            {
                Winner = new Player();
                Winner.Username = "Draw";
            }
            */
            CalculatePrize();
        }
        private bool IsBlackJack(Player player)
        {
            if (player.Cards.Count == 2 && player.CardScore == 21)
                return true;
            return false;
        }
        private void CalculatePrize()
        {
            int prize = Bet;
            if (Winner == null)
                return;
            if (Winner.Username == "Draw")
            {
                GameOver(this, new CardEventArgs(Winner, null, Winner.CardScore));
                return;
            }
            if (IsBlackJack(Winner))
                doubleFactor *= 1.5;
            if (Winner.PlayerType == PlayerType.Player)
                UserPlayer.ChangeCash((int)(prize * doubleFactor));
            else
                UserPlayer.ChangeCash(-((int)(prize * doubleFactor)));
            if (GameOver != null)
                GameOver(this, new CardEventArgs(Winner, null, Winner.CardScore));
            isRunning = false;
        }
        #endregion

        #region Public members
        public ClientGameManagerTemp()
        {
            doubleFactor = 1.0;
            Winner = null;
            UserPlayer = new Player(PlayerType.Player);
            Dealer = new Player(PlayerType.Dealer);
            Bet = 100;
        }

        public void IncreaseBet(int value)
        {
            Bet += value;
        }
        public void DecreaseBet(int value)
        {
            Bet -= value;
        }
        public Int32 Bet { get; private set; }
        public event EventHandler<CardEventArgs> GameOver;
        public void DoNothing()
        {
            throw new NotImplementedException();
        }
        public Player UserPlayer;
        public Player Dealer;

        public void TerminateGame()
        {
            Clear();
        }
        public void StartGame()
        {
            Clear();
            isRunning = true;
            Dealer.TakeCard(2);

            UserPlayer.TakeCard(2);
            CalculateWinner();
        }

        public bool TryDoubleBet()
        {
            try
            {
                DoubleBet();
                return true;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }
        public void DoubleBet()
        {
            if (!isRunning)
                throw new InvalidOperationException("Game is not running yet");
            if (EndGame)
                throw new InvalidOperationException("Game is over");
            if (!canDouble)
                throw new InvalidOperationException("Cannot double after any card has been hit");
            doubleFactor = 2.0;
            EndGame = true;
            UserPlayer.TakeCard(1);
            if (UserPlayer.CardScore > 21)
            {
                CalculateWinner();
                return;
            }
            while (Dealer.CardScore < 16)
                Dealer.TakeCard(1);
            CalculateWinner();
        }

        public bool TryStand()
        {
            try
            {
                Stand();
                return true;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }
        public void Stand()
        {
            if (!isRunning)
                throw new InvalidOperationException("Game is not running yet");
            if (EndGame)
                throw new InvalidOperationException("Game is over");
            EndGame = true;
            while (Dealer.CardScore < 16)
                Dealer.TakeCard(1);
            CalculateWinner();
        }

        public bool TryHit()
        {
            try
            {
                Hit();
                return true;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }
        public void Hit()
        {
            if (!isRunning)
                throw new InvalidOperationException("Game is not running yet");
            if (EndGame)
                throw new InvalidOperationException("Game is over");
            UserPlayer.TakeCard(1);
            canDouble = false;
            if (UserPlayer.CardScore >= 21)
            {
                EndGame = true;
                CalculateWinner();
            }
        }
        #endregion
    }

    class GameManager : IBjGameManager
    {
        public void Start()
        {
            throw new NotImplementedException();
        }

        public void Hit()
        {
            throw new NotImplementedException();
        }

        public void Stand()
        {
            throw new NotImplementedException();
        }

        public void Double()
        {
            throw new NotImplementedException();
        }

        public void Exit()
        {
            throw new NotImplementedException();
        }
    }
}
