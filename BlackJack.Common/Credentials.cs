using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Common
{
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
