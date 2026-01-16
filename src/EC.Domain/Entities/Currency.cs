namespace EC.Domain.Entities;

public class Currency
{
    public short Id { get; set; }
    public required string Code { get; set; }
    public required string Name { get; set; }
    public string? Symbol { get; set; }
    public required string MainUnit { get; set; }
    public required string Subunit { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
}