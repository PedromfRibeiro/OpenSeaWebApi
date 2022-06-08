using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenSeaWebApi.Models;
public class CustomUser
{
    [Key]
    public int primary_key_Id { get; set; }
    [JsonPropertyName("username")]
    public string? Username { get; set; }
}
