using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenSeaWebApi.Models;
public class StandardEvent
{
    [Key]
    public int primary_key_Id { get; set; }
    [JsonPropertyName("next")]
    public string? Next { get; set; }

    [JsonPropertyName("previous")]
    public string? Previous { get; set; }

    [JsonPropertyName("asset_events")]
    public ICollection<StandardAssetEvent>? AssetEvents { get; set; }
}
