namespace BandManager.Api.Resources.Models;

public class Task : Entity
{
    public int BookingId { get; set; }

    public int? UserId { get; set; }

    public string Name { get; set; }

    public string? Description { get; set; }

    public bool IsCompleted { get; set; }

    [JsonIgnore]
    public Booking Booking { get; set; }

    [JsonIgnore]
    public User? User { get; set; }
}