using Microsoft.EntityFrameworkCore;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Data
{
    public class AgenziaViaggioContext : DbContext
    {
        public DbSet<Viaggio>? Viaggi { get; set;  }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Database=DatabaseAgenziaDiViaggi;Integrated Security=True");
        }
    }
}
