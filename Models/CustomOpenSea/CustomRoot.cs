using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenSeaWebApi.Models;
public class CustomRoot
{
    [Key]
    public int primary_key_Id { get; set; }
    [JsonPropertyName("event")]
    public CustomEvent? Event { get; set; }
}
