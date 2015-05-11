using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Common;

namespace BlackJack.Client
{
    class ClientGameManager : IBjGameManager
    {
        #region Private members

        private bool isAuthenticated;
        private void Clear()
        {
            EndGame = false;
            doubleFactor = 1.0;
            Winner = null;
            if (Dealer != null)
                Dealer.Clear();
            if (UserPlayer != null)
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
            var p = new Player(PlayerType.Draw, "Draw");
            return p;
        }
        private void CalculateWinner()
        {
            if (!EndGame)
            {
                if (IsBlackJack(Dealer) && IsBlackJack(UserPlayer))
                {
                    Winner = CreateDraftPlayer();
                    EndGame = true;
                }
                else
                {
                    if (IsBlackJack(Dealer))
                    {
                        Winner = Dealer;
                        EndGame = true;
                    }
                    if (IsBlackJack(UserPlayer))
                    {
                        Winner = UserPlayer;
                        EndGame = true;
                    }
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
                return;
            }
            if (IsBlackJack(Winner))
                doubleFactor *= 1.5;
            if (Winner.PlayerType == PlayerType.Player)
                UserPlayer.ChangeCash((int)(prize * doubleFactor));
            else
                UserPlayer.ChangeCash(-((int)(prize * doubleFactor)));
            isRunning = false;
        }
        private Int32 Bet { get; set; }

        private Player UserPlayer;
        private Player Dealer;
        #endregion

        #region Public members
        public ClientGameManager()
        {
            Initialize();
        }

        public GameState Initialize()
        {
            doubleFactor = 1.0;
            Winner = null;
            UserPlayer = null;
            Dealer = null;
            Bet = 100;
            isAuthenticated = false;
            return new GameState(UserPlayer,Dealer,EndGame,Winner,Bet,doubleFactor,null);
        }
        public GameState IncreaseBet(int value = 50)
        {
            if (!isAuthenticated)
                return new GameState(UserPlayer, Dealer, EndGame, Winner, Bet, doubleFactor, "You cannot play while not authenticated.", "auth");
            if (!canDouble)
                return new GameState(UserPlayer, Dealer, EndGame, Winner, Bet, doubleFactor, "Game is already running. You cannot change your bet.");
            if (EndGame)
                return new GameState(UserPlayer, Dealer, EndGame, Winner, Bet, doubleFactor, "Game is over. You can change bets when the game starts.");
            Bet += value;
            return new GameState(UserPlayer, Dealer, EndGame, Winner, Bet, doubleFactor, null);
        }
        public GameState DecreaseBet(int value = 50)
        {
            if (!isAuthenticated)
                return new GameState(UserPlayer, Dealer, EndGame, Winner, Bet, doubleFactor, "You cannot play while not authenticated.", "auth");
            if (Bet - value < 1)
                return new GameState(UserPlayer, Dealer, EndGame, Winner, Bet, doubleFactor, "Your bet cannot be less then 1$.");
            if (!canDouble)
                return new GameState(UserPlayer, Dealer, EndGame, Winner, Bet, doubleFactor, "Game is already running. You cannot change your bet.");
            if (EndGame)
                return new GameState(UserPlayer, Dealer, EndGame, Winner, Bet, doubleFactor, "Game is over. You can change bets when the game starts.");
            Bet -= value;
            return new GameState(UserPlayer, Dealer, EndGame, Winner, Bet, doubleFactor, null);
        }
        public GameState Start()
        {
            if (!isAuthenticated)
                return new GameState(UserPlayer, Dealer, EndGame, Winner, Bet, doubleFactor, "You cannot play while not authenticated.", "auth");
            Clear();
            isRunning = true;
            Dealer.TakeCard(2);

            UserPlayer.TakeCard(2);
            CalculateWinner();
            return new GameState(UserPlayer, Dealer, EndGame, Winner, Bet, doubleFactor, null);
        }
        public GameState Stop()
        {
            if (!isAuthenticated)
                return new GameState(UserPlayer, Dealer, EndGame, Winner, Bet, doubleFactor, "You cannot play while not authenticated.", "auth");
            Clear();
            return new GameState(UserPlayer, Dealer, EndGame, Winner, Bet, doubleFactor, null);
        }
        public GameState Double()
        {
            if (!isAuthenticated)
                return new GameState(UserPlayer, Dealer, EndGame, Winner, Bet, doubleFactor, "You cannot play while not authenticated.", "auth");
            if (!isRunning)
                return new GameState(UserPlayer, Dealer, EndGame, Winner, Bet, doubleFactor, "Game is not running yet");
            if (EndGame)
                return new GameState(UserPlayer, Dealer, EndGame, Winner, Bet, doubleFactor, "Game is over");
            if (!canDouble)
                return new GameState(UserPlayer, Dealer, EndGame, Winner, Bet, doubleFactor, "Cannot double after any card has been hit");
            doubleFactor = 2.0;
            EndGame = true;
            UserPlayer.TakeCard(1);
            if (UserPlayer.CardScore > 21)
            {
                CalculateWinner();
                return new GameState(UserPlayer, Dealer, EndGame, Winner, Bet, doubleFactor, null);
            }
            while (Dealer.CardScore < 16)
                Dealer.TakeCard(1);
            CalculateWinner();
            return new GameState(UserPlayer, Dealer, EndGame, Winner, Bet, doubleFactor, null);
        }
        public GameState Stand()
        {
            if (!isAuthenticated)
                return new GameState(UserPlayer, Dealer, EndGame, Winner, Bet, doubleFactor, "You cannot play while not authenticated.", "auth");
            if (!isRunning)
                return new GameState(UserPlayer, Dealer, EndGame, Winner, Bet, doubleFactor, "Game is not running yet");
            if (EndGame)
                return new GameState(UserPlayer, Dealer, EndGame, Winner, Bet, doubleFactor, "Game is over");
            EndGame = true;
            while (Dealer.CardScore < 16)
                Dealer.TakeCard(1);
            CalculateWinner();
            return new GameState(UserPlayer, Dealer, EndGame, Winner, Bet, doubleFactor, null);
        }
        public GameState Hit()
        {
            if (!isAuthenticated)
                return new GameState(UserPlayer, Dealer, EndGame, Winner, Bet, doubleFactor, "You cannot play while not authenticated.", "auth");
            if (!isRunning)
                return new GameState(UserPlayer, Dealer, EndGame, Winner, Bet, doubleFactor, "Game is not running yet");
            if (EndGame)
                return new GameState(UserPlayer, Dealer, EndGame, Winner, Bet, doubleFactor, "Game is over");
            UserPlayer.TakeCard(1);
            canDouble = false;
            if (UserPlayer.CardScore >= 21)
            {
                EndGame = true;
                CalculateWinner();
            }
            return new GameState(UserPlayer, Dealer, EndGame, Winner, Bet, doubleFactor, null);
        }
        public GameState Login(string username, string pass)
        {
            var result = username.ToLower() == "admin" && pass.ToLower() == "admin";
            isAuthenticated = result;
            if (isAuthenticated)
            {
                UserPlayer = new Player(PlayerType.Player, username);
                Dealer = new Player(PlayerType.Dealer);
            }
            return new GameState(UserPlayer, Dealer, EndGame, Winner, Bet, doubleFactor, result ? null : "Username or password is incorrect", "auth", result ? "Login successful" : null);
        }
        public GameState Logoff()
        {
            if (!isAuthenticated)
                return new GameState(UserPlayer, Dealer, EndGame, Winner, Bet, doubleFactor, "You cannot play while not authenticated.", "auth");
            isAuthenticated = false;
            UserPlayer = null;
            Dealer = null;
            return Stop();
        }
        public GameState GetState()
        {
            return new GameState(UserPlayer, Dealer, EndGame, Winner, Bet, doubleFactor, null);
        }
        public bool IsAuthenticated()
        {
            return isAuthenticated;
        }
        public GameState GetLeaderboard()
        {
            var dict = new Dictionary<string, int>();
            dict.Add("Admin", 5400);
            dict.Add("John Doe", 3000);
            var state = new GameState(null, null, false, null, -1, -1, null, "leaderboard")
            {
                Leaderboard = dict.OrderByDescending(a => a.Value).ToList()
            };
            return state;
        }
        #endregion

    }

}
