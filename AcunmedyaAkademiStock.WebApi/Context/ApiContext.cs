using AcunmedyaAkademiStock.WebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace AcunmedyaAkademiStock.WebApi.Context
{
    public class ApiContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=HAMZA;initial catalog=AcunmedyaApiDb;integrated Security=true");
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
