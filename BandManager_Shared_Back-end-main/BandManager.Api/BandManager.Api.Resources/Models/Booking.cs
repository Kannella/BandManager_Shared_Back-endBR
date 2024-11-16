using BandManager.Api.Resources.Enums;

namespace BandManager.Api.Resources.Models;

public class Booking : Entity
{
    public int BandId { get; set; }
    
    public string Name { get; set; }
    
    public string? Description { get; set; }
    
    [JsonIgnore]
    [ForeignKey("BandId")]
    public Band Band { get; set; }

    public int? AgentId { get; set; }

    [JsonIgnore]
    [ForeignKey("AgentId")]
    public Agent Agent { get; set; }

    public int? VenueId { get; set; }

    [JsonIgnore]
    [ForeignKey("VenueId")]
    public Venue Venue { get; set; }

    public string? Planning { get; set; }

    public StatusType Status { get; set; }

    public string? PaymentDetails { get; set; }

    public string? BookingNumber { get; set; }

    public string? StageNumber { get; set; }

    public string? FoodDetails { get; set; }

    public DateTime? SoundCheckTime { get; set; }

    public DateTime? ArrivalTime { get; set; }

    public DateTime? TourbusLeaveTime { get; set; }

    public DateTime? DinnerTime { get; set; }

    public DateTime? ChangeOverTime { get; set; }

    public DateTime? ShowStartTime { get; set; }

    public DateTime? ShowEndTime { get; set; }

    public string? ParkingDetails { get; set; }

    public string? BookingNotes { get; set; }

    public bool IsPublicEvent { get; set; }

    public List<File> Files { get; set; }


    public List<BookingSong> BookingSong { get; set; }
}