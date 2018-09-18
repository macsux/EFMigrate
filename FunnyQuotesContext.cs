using Microsoft.EntityFrameworkCore;

namespace EFMigrate
{
    public class FunnyQuotesContext : DbContext
    {
        protected FunnyQuotesContext()
        {
        }

        public FunnyQuotesContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<FunnyQuote> Quotes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FunnyQuote>().HasData(
                new FunnyQuote {Id = 1, Message = "Hello"},
                new FunnyQuote {Id = 2, Message = "There"}
            );
        }
    }
}