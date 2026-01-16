namespace EC.Domain.Entities;

public class ProductCategory
{
    public int ProductId { get; set; }
    public short CategoryId { get; set; }
    public bool IsPrimary { get; set; }
    public short SortOrder { get; set; }

    public Category Category { get; set; } = null!;
}