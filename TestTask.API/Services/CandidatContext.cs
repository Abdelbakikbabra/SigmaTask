using Microsoft.EntityFrameworkCore;
using TestTask.API.Models;

namespace TestTask.API.Services
{
    public class CandidatContext : DbContext
    {
        public CandidatContext(DbContextOptions<CandidatContext> options) : base(options) { }

        // Define DbSet properties for your entities
        public DbSet<Candidat> Candidats { get; set; }
    }
}
