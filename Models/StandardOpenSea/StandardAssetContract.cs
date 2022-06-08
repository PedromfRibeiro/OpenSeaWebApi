using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenSeaWebApi.Models;
public class StandardAssetContract
{
    [Key]
    public int primary_key_Id { get; set; }
    [JsonPropertyName("address")]
    public string? Address { get; set; }

    [JsonPropertyName("asset_contract_type")]
    public string? AssetContractType { get; set; }

    [JsonPropertyName("created_date")]
    public DateTime CreatedDate { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("nft_version")]
    public string? NftVersion { get; set; }

    [JsonPropertyName("opensea_version")]
    public string? OpenseaVersion { get; set; }

    [JsonPropertyName("owner")]
    public int? Owner { get; set; }

    [JsonPropertyName("schema_name")]
    public string? SchemaName { get; set; }

    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    [JsonPropertyName("total_supply")]
    public string? TotalSupply { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("external_link")]
    public string? ExternalLink { get; set; }

    [JsonPropertyName("image_url")]
    public string? ImageUrl { get; set; }

    [JsonPropertyName("default_to_fiat")]
    public bool DefaultToFiat { get; set; }

    [JsonPropertyName("dev_buyer_fee_basis_points")]
    public int DevBuyerFeeBasisPoints { get; set; }

    [JsonPropertyName("dev_seller_fee_basis_points")]
    public int DevSellerFeeBasisPoints { get; set; }

    [JsonPropertyName("only_proxied_transfers")]
    public bool OnlyProxiedTransfers { get; set; }

    [JsonPropertyName("opensea_buyer_fee_basis_points")]
    public int OpenseaBuyerFeeBasisPoints { get; set; }

    [JsonPropertyName("opensea_seller_fee_basis_points")]
    public int OpenseaSellerFeeBasisPoints { get; set; }

    [JsonPropertyName("buyer_fee_basis_points")]
    public int BuyerFeeBasisPoints { get; set; }

    [JsonPropertyName("seller_fee_basis_points")]
    public int SellerFeeBasisPoints { get; set; }

    [JsonPropertyName("payout_address")]
    public string? PayoutAddress { get; set; }
}
