namespace BandManager.Api.Resources.Models;

public class BookingSong : Entity
{
    public int BookingId { get; set; }
    public int SongId { get; set; }

    [JsonIgnore]
    [ForeignKey("BookingId")]
    public Booking Booking { get; set; }

    [JsonIgnore]
    [ForeignKey("SongId")]
    public Song Song { get; set; }
}