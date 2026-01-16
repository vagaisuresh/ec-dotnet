namespace EC.Domain.Entities;

public class ProductVariant
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public required string SKU { get; set; }
    public required string Name { get; set; }
    public string? Barcode { get; set; }
    public decimal Quantity { get; set; }
    public short UnitOfMeasureId { get; set; }
    public string? Attributes { get; set; }
    public decimal Weight { get; set; }
    public short SortOrder { get; set; }
    public byte Status { get; set; }
    public bool IsDefault { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public Product Product { get; set; } = null!;
    public UnitOfMeasure UnitOfMeasure { get; set; } = null!;
}