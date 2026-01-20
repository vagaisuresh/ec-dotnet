using System.ComponentModel.DataAnnotations;

namespace EC.Application.DTOs;

public class UserRegisterDto
{
    [Required]
    [StringLength(50)]
    public string FullName { get; set; } = null!;

    [Required]
    [StringLength(100)]
    public string EmailAddress { get; set; } = null!;

    [Required]
    [StringLength(16, MinimumLength = 8)]
    public string Password { get; set; } = null!;

    [Required]
    [StringLength(15)]
    public string MobileNumber { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    [StringLength(50)]
    public string? ProfilePicture { get; set; }
}