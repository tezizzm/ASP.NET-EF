using System.Data.Entity;
using EntityFramework6.Models;

namespace EntityFramework6
{
    public class TeamContext : DbContext
    {
        public TeamContext(string connectionString) 
            : base(connectionString)
        {

        }

        public DbSet<Team> Teams { get; set; }
    }
}