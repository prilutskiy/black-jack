using System;
using System.Collections.Generic;
using System.Data.Entity;
using BlackJack.Common;

namespace BlackJack.DataStorage
{
    class BlackJackDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}
