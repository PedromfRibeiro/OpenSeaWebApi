using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenSeaWebApi.Models;
public class StandardPaymentToken
{
    [Key]
    public int primary_key_Id { get; set; }
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    [JsonPropertyName("address")]
    public string? Address { get; set; }

    [JsonPropertyName("image_url")]
    public string? ImageUrl { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("decimals")]
    public int Decimals { get; set; }

    [JsonPropertyName("eth_price")]
    public string? EthPrice { get; set; }

    [JsonPropertyName("usd_price")]
    public string? UsdPrice { get; set; }
}
