using ImpactaWebcrawler.Domain;
using Microsoft.EntityFrameworkCore;

namespace ImpactaWebcrawler.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Resposta> Respostas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder       
                .EnableSensitiveDataLogging()
                .UseSqlServer("Server=.\\SQLEXPRESS;Database=webcrawler; UID=sa; PWD=ed123456; MultipleActiveResultSets=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RespostaMapping());
        }

    }
}
