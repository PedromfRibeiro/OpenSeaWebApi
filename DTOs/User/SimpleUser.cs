using System.ComponentModel.DataAnnotations;

namespace OpenSeaWebApi.DTOs;

public class SimpleUserDto
{
    public int Id { get; set; }
    public string? UserName { get; set; }
    public string? Name { get; set; }
    public string? Contact { get; set; }
    public byte[]? ProfileImage { get; set; }
    public string? Observations { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }

    public string? Token { get; set; }
    // When was the last login
    public DateTime LastLogin { get; set; }
    public ConfigUserDto? UserConfig { get; set; }
}
