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
        internal string  Password { get; set; }
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
    }
}
