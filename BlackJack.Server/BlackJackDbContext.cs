using System;
using System.Data.Entity;
using System.IO;
using System.Windows.Forms;

namespace BlackJack.Server
{
    class BlackJackDbContext : DbContext
    {
        public static String BlackJackConnectionString = GenerateConnectionString();
        public BlackJackDbContext()
            : base(BlackJackConnectionString)
        {
            Database.CreateIfNotExists();
        }

        public static String GenerateConnectionString()
        {
            return String.Format(@"Data Source=(LocalDb)\v11.0;AttachDbFilename={0};Trusted_Connection=True;MultipleActiveResultSets=true;",
                Path.Combine(Application.StartupPath, "bj.mdf"));
        }
        public DbSet<User> Users { get; set; }
    }
}
