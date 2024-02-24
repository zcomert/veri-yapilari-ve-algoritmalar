namespace Libs.Entities;

public class Car
{
    public int CarId { get; set; }

    public string Brand { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; }
    public decimal Price { get; set; }

    public int? EngineId { get; set; }
    public virtual Engine? Engine { get; set; }
}


