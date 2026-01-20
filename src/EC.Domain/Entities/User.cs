using System.ComponentModel.DataAnnotations.Schema;
using EC.Domain.Enums;

namespace EC.Domain.Entities;

[Table("User")]
public class User
{
    public int Id { get; set; }
    public required string FullName { get; set; }
    public required string EmailAddress { get; set; }
    public required string PasswordHash { get; set; }
    public UserRole RoleId { get; set; }
    public required string MobileNumber { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string? ProfilePicture { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public short? CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
}