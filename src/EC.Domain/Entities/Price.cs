namespace EC.Domain.Entities;

public class Price
{
    public int Id { get; set; }
    public int PriceListId { get; set; }
    public int ProductVariantId { get; set; }
    public decimal Amount { get; set; }
    public int MinQuantity { get; set; }
    public int MaxQuantity { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public PriceList PriceList { get; set; } = null!;
    public ProductVariant ProductVariant { get; set; } = null!;
}