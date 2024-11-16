using System.ComponentModel.DataAnnotations;
using BandManager.Api.Resources.Enums;

namespace BandManager.Api.Resources.DTOs;

public class BookingDTO
{
    [Required]
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    [Required]
    public int BandId { get; set; }
    public int? AgentId { get; set; }
    public int? VenueId { get; set; }
    public string? Planning { get; set; } = string.Empty;
    [Required]
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
    [Required]
    public bool IsPublicEvent { get; set; }

    public Booking ToEntity()
    {
        return new Booking()
        {
            Name = this.Name,
            Description = this.Description,
            BandId = this.BandId,
            AgentId = this.AgentId,
            VenueId = this.VenueId,
            Planning = this.Planning,
            Status = this.Status,
            PaymentDetails = this.PaymentDetails,
            BookingNumber = this.BookingNumber,
            StageNumber = this.StageNumber,
            FoodDetails = this.FoodDetails,
            SoundCheckTime = this.SoundCheckTime,
            ArrivalTime = this.ArrivalTime,
            TourbusLeaveTime = this.TourbusLeaveTime,
            DinnerTime = this.DinnerTime,
            ChangeOverTime = this.ChangeOverTime,
            ShowStartTime = this.ShowStartTime,
            ShowEndTime = this.ShowEndTime,
            ParkingDetails = this.ParkingDetails,
            BookingNotes = this.BookingNotes,
            IsPublicEvent = this.IsPublicEvent
        };
    }
}