using Microsoft.EntityFrameworkCore;
using webapi.Core;

namespace webapi
{
    public class SqlServerContext : DbContext
    {
        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options) { }

        public DbSet<Client> Client { get; set; }

        public DbSet<Store> Store { get; set; }
        public DbSet<Item> Item { get; set; }



    }
}
