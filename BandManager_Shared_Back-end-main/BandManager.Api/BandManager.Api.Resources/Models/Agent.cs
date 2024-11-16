namespace BandManager.Api.Resources.Models;

public class Agent : Entity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public List<Booking> Bookings { get; set; }
}