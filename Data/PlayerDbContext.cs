using İleri_Veri_tabani.Models;
using Microsoft.EntityFrameworkCore;

namespace İleri_Veri_tabani.Data
{
    public class PlayerDbContext : DbContext
    {
        public DbSet<Player> Players { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=İleriVeriTabani;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
