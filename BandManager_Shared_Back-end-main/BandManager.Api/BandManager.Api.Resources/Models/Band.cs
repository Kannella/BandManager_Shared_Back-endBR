namespace BandManager.Api.Resources.Models;

public class Band : Entity
{
    public string Name { get; set; } = null!;
    public List<BandUser>? BandUsers { get; set; }
    public List<Booking>? Bookings { get; set; }
}