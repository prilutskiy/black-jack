using System;
using System.Collections.Generic;
using System.Linq;
using BlackJack.Common;
using DevExpress.XtraPrinting.Native;

namespace BlackJack.Server
{
    class User : IUser
    {
        public int Id { get; set; }
        public PlayerType PlayerType { get; set; }
        public int Cash { get; set; }
        public string Username { get; set; }
        public string  Password { get; set; }
    }
    public class BlackJackRepository
    {
        private BlackJackDbContext _db;

        public BlackJackRepository()
        {
            _db = new BlackJackDbContext();
        }

        public void AddPlayer(string username, string pass)
        {
            var u = new User()
            {
                Cash = 1000,
                Username = username,
                Password = pass,
                PlayerType = PlayerType.Player
            };
            _db.Users.Add(u);
            _db.SaveChanges();
        }

        public bool UserExists(string user)
        {
            return _db.Users.Any(u => u.Username == user);
        }
        public bool CheckCredentials(string user, string pass)
        {
            return _db.Users.Any(u => u.Username == user && u.Password == pass);
        }
        public IUser GetPlayer(string username, string pass)
        {
            if (!CheckCredentials(username, pass))
                return null;
            return _db.Users.Single(u => u.Username == username && u.Password == pass);
        }

        public ICollection<IUser> GetAllPlayers()
        {
            var list = new List<IUser>();
            _db.Users.ForEach(u => list.Add(u));
            return list;
        }

        public void UpdatePlayer(IUser userPlayer)
        {
            var user = _db.Users.Single(u => u.Username == userPlayer.Username);
            user.Cash = userPlayer.Cash;
            _db.SaveChanges();
        }

        public List<KeyValuePair<string, int>> GetLeaderboard(int count)
        {
            var table = new List<KeyValuePair<string, int>>();
            var users = _db.Users.OrderByDescending(u => u.Cash).Take(count);
            users.ForEach(u => table.Add(new KeyValuePair<string, int>(u.Username, u.Cash)));
            return table;
        }

        public IUser GetPlayer(string username)
        {
            return _db.Users.Single(u => u.Username == username);
        }
    }
}
