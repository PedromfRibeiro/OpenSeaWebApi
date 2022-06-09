using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenSeaWebApi.Models;
public class Asset
{
    [Key]
    public int primary_key_Id { get; set; } 
    [JsonPropertyName("collection")]
    public Collection? Collection { get; set; }
    [JsonPropertyName("token_id")]
    public string? TokenId { get; set; }
    [JsonPropertyName("id")]
    public int Id { get; set; }

//     [JsonPropertyName("num_sales")]
//     public int NumSales { get; set; }

//     [JsonPropertyName("background_color")]
//     public string? BackgroundColor { get; set; }

//     [JsonPropertyName("image_url")]
//     public string? ImageUrl { get; set; }

//     [JsonPropertyName("image_preview_url")]
//     public string? ImagePreviewUrl { get; set; }

//     [JsonPropertyName("image_thumbnail_url")]
//     public string? ImageThumbnailUrl { get; set; }

//     [JsonPropertyName("image_original_url")]
//     public string? ImageOriginalUrl { get; set; }

//     [JsonPropertyName("animation_url")]
//     public string? AnimationUrl { get; set; }

//     [JsonPropertyName("animation_original_url")]
//     public string? AnimationOriginalUrl { get; set; }

//     [JsonPropertyName("name")]
//     public string? Name { get; set; }

//     [JsonPropertyName("description")]
//     public string? Description { get; set; }
//     [JsonPropertyName("external_link")]
//     public string? ExternalLink { get; set; }
//     [JsonPropertyName("permalink")]
//     public string? Permalink { get; set; }

//     [JsonPropertyName("decimals")]
//     public int? Decimals { get; set; }

//     [JsonPropertyName("token_metadata")]
//     public string? TokenMetadata { get; set; }

//     [JsonPropertyName("is_nsfw")]
//     public bool? IsNsfw { get; set; }
}
