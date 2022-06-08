using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenSeaWebApi.Models;
public class StandardCollection
{
    [Key]
    public int primary_key_Id { get; set; }    
    [JsonPropertyName("banner_image_url")]
    public string? BannerImageUrl { get; set; }
    [JsonPropertyName("chat_url")]
    public string? ChatUrl { get; set; }
    [JsonPropertyName("created_date")]
    public DateTime CreatedDate { get; set; }
    [JsonPropertyName("default_to_fiat")]
    public bool DefaultToFiat { get; set; }
    [JsonPropertyName("description")]
    public string? Description { get; set; }
    [JsonPropertyName("dev_buyer_fee_basis_points")]
    public string? DevBuyerFeeBasisPoints { get; set; }
    [JsonPropertyName("dev_seller_fee_basis_points")]
    public string? DevSellerFeeBasisPoints { get; set; }
    [JsonPropertyName("discord_url")]
    public string? DiscordUrl { get; set; }
    [JsonPropertyName("display_data")]
    //public StandardDisplayData? DisplayData { get; set; }
    //[JsonPropertyName("external_url")]
    public string? ExternalUrl { get; set; }
    [JsonPropertyName("featured")]
    public bool Featured { get; set; }
    [JsonPropertyName("featured_image_url")]
    public string? FeaturedImageUrl { get; set; }
    [JsonPropertyName("hidden")]
    public bool Hidden { get; set; }
    [JsonPropertyName("safelist_request_status")]
    public string? SafelistRequestStatus { get; set; }
    [JsonPropertyName("image_url")]
    public string? ImageUrl { get; set; }
    [JsonPropertyName("is_subject_to_whitelist")]
    public bool IsSubjectToWhitelist { get; set; }
    [JsonPropertyName("large_image_url")]
    public string? LargeImageUrl { get; set; }
    [JsonPropertyName("medium_username")]
    public string? MediumUsername { get; set; }
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    [JsonPropertyName("only_proxied_transfers")]
    public bool OnlyProxiedTransfers { get; set; }
    [JsonPropertyName("opensea_buyer_fee_basis_points")]
    public string? OpenseaBuyerFeeBasisPoints { get; set; }
    [JsonPropertyName("opensea_seller_fee_basis_points")]
    public string? OpenseaSellerFeeBasisPoints { get; set; }
    [JsonPropertyName("payout_address")]
    public string? PayoutAddress { get; set; }
    [JsonPropertyName("require_email")]
    public bool RequireEmail { get; set; }
    [JsonPropertyName("short_description")]
    public string? ShortDescription { get; set; }
    [JsonPropertyName("slug")]
    public string? Slug { get; set; }
    [JsonPropertyName("telegram_url")]
    public string? TelegramUrl { get; set; }
    [JsonPropertyName("twitter_username")]
    public string? TwitterUsername { get; set; }
    [JsonPropertyName("instagram_username")]
    public string? InstagramUsername { get; set; }
    [JsonPropertyName("wiki_url")]
    public string? WikiUrl { get; set; }
    [JsonPropertyName("is_nsfw")]
    public bool IsNsfw { get; set; }
}
