namespace BandManager.Api.Resources.Models;

public class File : Entity
{
    public int BookingId { get; set; }

    public string DataLink { get; set; }

    [JsonIgnore]
    [ForeignKey("BookingId")]
    public Booking Booking { get; set; }
}