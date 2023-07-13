using Microsoft.EntityFrameworkCore;

namespace ManagerCVAPI.Model
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Sede> Sedi { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sede>()
            .HasKey(s => s.Id);

            modelBuilder.Entity<Sede>().HasData(
                new Sede
                {
                    Id = 1,
                    Città = "Napoli",
                    Indirizzo = "Via Taddeo da Sessa - Centro direzionale isola F10",
                    Provincia = "Napoli",
                    Cap = "80143",
                    RecapitoTel = "0815536002",
                    Email = "info.napoli@bcsoft.net"
                },
                new Sede
                {
                    Id = 2,
                    Città = "Roma",
                    Indirizzo = "Viale della Tecnica, 245",
                    Provincia = "Roma",
                    Cap = "00144",
                    RecapitoTel = "068080237",
                    Email = "info.roma@bcsoft.net"
                },
                new Sede
                {
                    Id = 3,
                    Città = "Firenze",
                    Indirizzo = "Via Borgo Ognissanti 54",
                    Provincia = "Firenze",
                    Cap = "50123",
                    RecapitoTel = "0559861922",
                    Email = "info.firenze@bcsoft.net"
                },
                new Sede
                {
                    Id = 4,
                    Città = "Bologna",
                    Indirizzo = "Via Majani 2",
                    Provincia = "Bologna",
                    Cap = "40121",
                    RecapitoTel = "0519921991",
                    Email = "info.bologna@bcsoft.net"
                }
            );
        }
    }
}
