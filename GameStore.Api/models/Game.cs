namespace GameStore.Api.models;

public class Game
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string Genre { get; set; }
    public decimal Price { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string required ImageUri { get; set; }

}