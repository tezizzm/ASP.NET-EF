using EntityFrameworkCore.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore
{
    public class TeamContext : DbContext
    {
        public TeamContext(DbContextOptions options) 
            : base(options)
        {

        }

        public DbSet<Team> Teams { get; set; }
    }
}