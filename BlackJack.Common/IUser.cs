using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Common
{
    public interface IUser
    {
        Guid Id { get; set; }
        PlayerType PlayerType { get;  set; }
        Int32 Cash { get; set; }
        String Username { get;  set; }
    }
}
