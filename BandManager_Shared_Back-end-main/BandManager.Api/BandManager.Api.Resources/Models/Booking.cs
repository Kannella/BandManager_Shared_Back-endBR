using System.ComponentModel.DataAnnotations.Schema;

namespace BandManager.Api.Resources.Models
{
	public class Booking : Entity
	{
		#warning Not sure what a medium blob would be as a c# data type
		public string Planning {  get; set; }
		public Enums.StatusType Status { get; set; }
		public string PaymentDetails { get; set; }
		public string BookingNumber { get; set; }
		public string StageNumber { get; set; }
		public DateTime SoundCheckTime { get; set; }
		public DateTime ArrivalTime { get; set; }
		public DateTime TourbusLeaveTime { get; set; }
		public DateTime DinnerTime { get; set; }
		public DateTime ChangeOverTime { get; set; }
		public DateTime ShowStartTime { get; set; }
		public DateTime ShowEndTime { get; set; }
		public string ParkingDetails { get; set; }
		public string BookingNotes { get; set; }
		public bool IsPublicEvent { get; set; }
		public List<File> Files { get; set; }
	}
}
