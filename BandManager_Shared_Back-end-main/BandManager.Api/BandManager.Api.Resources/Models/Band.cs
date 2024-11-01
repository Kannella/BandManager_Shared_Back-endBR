using System.ComponentModel.DataAnnotations.Schema;

namespace BandManager.Api.Resources.Models
{
	public class Band : Entity
	{
		public string Name { get; set; } = null!;
		public List<User> Users { get; set; }
		public List<Booking> Bookings { get; set; }
	}
}
