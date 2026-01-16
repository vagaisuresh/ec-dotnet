namespace EC.Domain.Entities;

public class PriceList
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public short CurrencyId { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public Currency Currency { get; set; } = null!;
    public ICollection<Price> Prices { get; set; } = new List<Price>();
}