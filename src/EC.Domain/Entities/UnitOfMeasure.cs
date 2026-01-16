namespace EC.Domain.Entities;

public class UnitOfMeasure
{
    public short Id { get; set; }
    public required string Code { get; set; }    // kg, g, l, pcs
    public required string Name { get; set; }    // Kilogram, Gram
    public string? Symbol { get; set; }          // kg, g, l
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
}