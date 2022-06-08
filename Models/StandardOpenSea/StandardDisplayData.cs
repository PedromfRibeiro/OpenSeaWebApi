using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenSeaWebApi.Models;
public class StandardDisplayData
{
    [Key]
    public int primary_key_Id { get; set; }
    [JsonPropertyName("card_display_style")]
    public string? CardDisplayStyle { get; set; }
    [JsonPropertyName("images")]
    public List<string>? Images { get; set; }
}