using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenSeaWebApi.Models;
public class AssetEvent
{
    [Key]
    public int primary_key_Id { get; set; }

    [JsonPropertyName("asset")]
    public Asset? Asset { get; set; }

    [JsonPropertyName("event_type")]
    public string? EventType { get; set; }

    [JsonPropertyName("event_timestamp")]
    public DateTime EventTimestamp { get; set; }

    [JsonPropertyName("total_price")]
    public string? TotalPrice { get; set; }
    [JsonPropertyName("quantity")]
    public string? Quantity { get; set; }

    [JsonPropertyName("collection_slug")]
    public string? CollectionSlug { get; set; }

    [JsonPropertyName("contract_address")]
    public string? ContractAddress { get; set; }
    [JsonPropertyName("id")]
    public long Id { get; set; }

}
