using System;

namespace BlackJack.Common
{
    [Serializable]
    public class Credentials
    {
        public Credentials(string user, string pass)
        {
            Password = pass;
            Username = user;
        }

        public String Password { get; set; }
        public String Username { get; set; }
    }
}