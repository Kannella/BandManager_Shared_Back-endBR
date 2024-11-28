namespace BandManager.Api.Resources.Models;

public class Band : Entity
{
    public string Name { get; set; } = null!;
    public string? BandUsers { get; set; }
    public string? Bookings { get; set; }
}