using System.Threading.Tasks;
using BandManager.Api.Resources.Models;
using Microsoft.EntityFrameworkCore;

namespace BandManager.Api.DAL.Context
{
    public class BandManagerContext : DbContext
    {
        public BandManagerContext(DbContextOptions<BandManagerContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Venue> venues { get; set; }
        public DbSet<Resources.Models.File> files { get; set; }
        public DbSet<Booking> bookings { get; set; }
        public DbSet<Band> bands { get; set; }
        public DbSet<Agent> agents { get; set; }
        public DbSet<BandUser> band_user { get; set; }
        public DbSet<BookingSong> set_song { get; set; }
        public DbSet<Song> songs { get; set; }

        // Novo DbSet para a entidade Availability
        public DbSet<Availability> Availability { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração de relacionamentos
            modelBuilder.Entity<Agent>()
                .Navigation(a => a.Bookings)
                .AutoInclude();

            modelBuilder.Entity<Band>()
                .Navigation(b => b.BandUsers)
                .AutoInclude();
            modelBuilder.Entity<Band>()
                .Navigation(b => b.Bookings)
                .AutoInclude();

            modelBuilder.Entity<Booking>()
                .Navigation(b => b.Files)
                .AutoInclude();
            modelBuilder.Entity<Booking>()
                .Navigation(b => b.BookingSong)
                .AutoInclude();
            modelBuilder.Entity<Booking>()
                .Navigation(b => b.Agent)
                .AutoInclude();

            modelBuilder.Entity<Song>()
                .Navigation(s => s.BookingSongs)
                .AutoInclude();

            modelBuilder.Entity<User>()
                .Navigation(u => u.BandUsers)
                .AutoInclude();

            modelBuilder.Entity<Venue>()
                .Navigation(v => v.Bookings)
                .AutoInclude();

            // Configuração da relação entre User e Availability
            modelBuilder.Entity<Availability>()
                .HasOne(a => a.User)
                .WithMany()
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}