using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenSeaWebApi.Models;
public class StandardAssetEvent
{
    [Key]
    public int primary_key_Id { get; set; }
    [JsonPropertyName("asset")]
    public StandardAsset? Asset { get; set; }
    [JsonIgnore]
    [JsonPropertyName("asset_bundle")]
    public string? AssetBundle { get; set; }

    [JsonPropertyName("event_type")]
    public string? EventType { get; set; }

    [JsonPropertyName("event_timestamp")]
    public DateTime EventTimestamp { get; set; }

    [JsonPropertyName("auction_type")]
    public string? AuctionType { get; set; }

    [JsonPropertyName("total_price")]
    public string? TotalPrice { get; set; }

    [JsonPropertyName("payment_token")]
    public StandardPaymentToken? PaymentToken { get; set; }

    [JsonIgnore]
    //[JsonPropertyName("transaction")]
    public string? Transaction { get; set; }

    [JsonPropertyName("created_date")]
    public DateTime CreatedDate { get; set; }

    [JsonPropertyName("quantity")]
    public string? Quantity { get; set; }

    [JsonPropertyName("approved_account")]
    public string? ApprovedAccount { get; set; }

    [JsonPropertyName("bid_amount")]
    public string? BidAmount { get; set; }

    [JsonPropertyName("collection_slug")]
    public string? CollectionSlug { get; set; }

    [JsonPropertyName("contract_address")]
    public string? ContractAddress { get; set; }

    [JsonPropertyName("custom_event_name")]
    public string? CustomEventName { get; set; }

    [JsonPropertyName("dev_fee_payment_event")]
    public string? DevFeePaymentEvent { get; set; }

    [JsonPropertyName("dev_seller_fee_basis_points")]
    public int? DevSellerFeeBasisPoints { get; set; }

    [JsonPropertyName("duration")]
    public string? Duration { get; set; }

    [JsonPropertyName("ending_price")]
    public string? EndingPrice { get; set; }

    [JsonPropertyName("from_account")]
    public StandardFromAccount? FromAccount { get; set; }

    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("is_private")]
    public bool? IsPrivate { get; set; }

    [JsonPropertyName("owner_account")]
    public string? OwnerAccount { get; set; }

    [JsonPropertyName("seller")]
    public StandardSeller? Seller { get; set; }

    [JsonPropertyName("starting_price")]
    public string? StartingPrice { get; set; }

    [JsonPropertyName("to_account")]
    public StandardToAccount? ToAccount { get; set; }
    [JsonIgnore]
    [JsonPropertyName("winner_account")]
    public string? WinnerAccount { get; set; }

    [JsonPropertyName("listing_time")]
    public DateTime? ListingTime { get; set; }
}
