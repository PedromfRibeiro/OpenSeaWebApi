using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenSeaWebApi.Models;
public class CustomToAccount
{
    [Key]
    public int primary_key_Id { get; set; }
    [JsonPropertyName("user")]
    public CustomUser? User { get; set; }

    [JsonPropertyName("profile_img_url")]
    public string? ProfileImgUrl { get; set; }

    [JsonPropertyName("address")]
    public string? Address { get; set; }

    [JsonPropertyName("config")]
    public string? Config { get; set; }
}
