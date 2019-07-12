using System.Data.Entity;
using System.Linq;
using EntityFramework6.Models;

namespace EntityFramework6
{
    public static class TeamContextExtensions
    {
        public static void InitializeData(this TeamContext teamContext)
        {
            teamContext.Database.CreateIfNotExists();

            if (teamContext.Teams.Any()) return;

            teamContext.Entry(new Team {Mascot = "Bears", TeamName = "Chicago", Location = "Chicago, IL"}).State =EntityState.Added;
            teamContext.Entry(new Team {Mascot = "Knicks", TeamName = "New York", Location = "New York, NY"}).State =EntityState.Added;
            teamContext.Entry(new Team {Mascot = "Rams", TeamName = "Los Angeles", Location = "Los Angeles, CA"}).State = EntityState.Added;
            teamContext.Entry(new Team{Mascot = "49ers", TeamName = "San Francisco", Location = "San Francisco"}).State =EntityState.Added;
            teamContext.Entry(new Team {Mascot = "Mariners", TeamName = "Seattle", Location = "Seattle, WA"}).State =EntityState.Added;
            teamContext.Entry(new Team {Mascot = "Golden Knights", TeamName = "Las Vegas", Location = "Las Vegas, NV"}).State = EntityState.Added;
            teamContext.Entry(new Team {Mascot = "Broncos", TeamName = "Denver", Location = "Denver, CO"}).State = EntityState.Added;
            teamContext.Entry(new Team {Mascot = "Mavericks", TeamName = "Dallas", Location = "Dallas, TX"}).State = EntityState.Added;

            teamContext.SaveChanges();
        }
    }
}