namespace BandManager.Api.Resources.Models;

public class BandUser : Entity
{
    public int BandId { get; set; }

    public int UserId { get; set; }

    [JsonIgnore]
    [ForeignKey("BandId")]
    public Band? Band { get; set; }

    [JsonIgnore]
    [ForeignKey("UserId")]
    public User? User { get; set; }
}