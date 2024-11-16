namespace BandManager.Api.Resources.Models;

public class Song : Entity
{
    public string Title { get; set; }

    public string Genre { get; set; }

    public List<BookingSong> BookingSongs { get; set; }
}