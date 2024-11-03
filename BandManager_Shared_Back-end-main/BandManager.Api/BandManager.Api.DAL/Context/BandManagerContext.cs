using BandManager.Api.DAL.Configuration;
using BandManager.Api.Resources.Models;
using Microsoft.EntityFrameworkCore;

namespace BandManager.Api.DAL.Context
{
	public class BandManagerContext : DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Venue> Venues { get; set; }
		public DbSet<Resources.Models.File> Files { get; set; }
		public DbSet<Booking> Bookings { get; set; }
		public DbSet<Band> bands { get; set; }

		private readonly string _connectionString;

		public BandManagerContext(AppConfiguration configuration)
		{
			_connectionString = configuration.GetConnectionString();
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseMySQL(_connectionString);
		}
	}
}
