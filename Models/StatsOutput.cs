namespace OpenSeaWebApi.Models
{

    public class StatsOutput
    {
        public string? CollectionSlug { get; set; }
        public int Minute { get; set; }
        public double mean_price { get; set; }
        public double total { get; set; }
        public double NumResults { get; set; }
        public string? collection_image_url { get; set; }
        public string? collection_name { get; set; }
        public string? collection_discord_url { get; set; }
        public string? collection_telegram_url { get; set; }
        public string? collection_twitter_username { get; set; }
        public string? collection_instagram_username { get; set; }
        public string? collection_wiki_url { get; set; }


    }
}