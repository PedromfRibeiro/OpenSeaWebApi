using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenSeaWebApi.Models;
public class StandardRoot
{
    [Key]
    public int primary_key_Id { get; set; }
    [JsonPropertyName("event")]
    public StandardEvent? Event { get; set; }
}
