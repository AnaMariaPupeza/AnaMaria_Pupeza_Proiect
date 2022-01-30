using Microsoft.EntityFrameworkCore;

namespace AnaMaria_Pupeza_Proiect.Data
{
    public class AnaMaria_Pupeza_ProiectContext : DbContext
    {
        public AnaMaria_Pupeza_ProiectContext(DbContextOptions<AnaMaria_Pupeza_ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<AnaMaria_Pupeza_Proiect.Models.Product> Product { get; set; }

        public DbSet<AnaMaria_Pupeza_Proiect.Models.Manufacturer> Manufacturer { get; set; }

        public DbSet<AnaMaria_Pupeza_Proiect.Models.Category> Category { get; set; }
    }
}
