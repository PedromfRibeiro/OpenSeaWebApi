using System.ComponentModel.DataAnnotations;

namespace OpenSeaWebApi.DTOs;

    public class UpdatePasswordDto
{
    [Required]
    public string? UserName { get; set; }
    [Required]
    public string? password { get; set; }
    [Required]
    public string? confirmPassword { get; set; }
}
