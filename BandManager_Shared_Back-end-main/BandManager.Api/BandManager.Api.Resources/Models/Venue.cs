namespace BandManager.Api.Resources.Models;

public class Venue : Entity
{
    public string Name { get; set; }

    public string Address { get; set; }

    public string ContactName { get; set; }

    public string ContactPhoneNumber { get; set; }

    public string ContactEmail { get; set; }

    public List<Booking> Bookings { get; set; }
}