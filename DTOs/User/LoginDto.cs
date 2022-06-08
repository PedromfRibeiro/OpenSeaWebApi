using System.ComponentModel.DataAnnotations;

namespace OpenSeaWebApi.DTOs;

    public class LoginDto
{
    public string? Username { get; set; }
    public string? password { get; set; }
}
