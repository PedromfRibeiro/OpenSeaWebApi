using AutoMapper;
using OpenSeaWebApi.Interfaces;
using OpenSeaWebApi.Models;
using RestSharp;

namespace OpenSeaWebApi.Data;

public class OpenSeaRepository : IOpenSeaRepository
{

    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public OpenSeaRepository(DataContext context, IMapper mapper)
    {
        _mapper = mapper;
        _context = context;
    }
    public DateTime GetLastAddedSale()
    {
        DateTime date = _context.db_AssetEvent.Max(date => (DateTime)date.EventTimestamp);
        if (date == null)
            date = DateTime.UtcNow.AddMinutes(-1);

        return date;

    }
    public List<StatsOutput> GetMinuteAddedSale(DateTime Start)
    {
        var x = _context.db_AssetEvent.GroupBy(x => new { x.CollectionSlug, x.EventTimestamp.Minute }).Select(x => new StatsOutput
        {
            CollectionSlug = x.Key.CollectionSlug,
            Minute = x.Key.Minute,
            NumResults = x.Count()
        })
            .ToList();
        return x;
    }

    public async Task<(string?,int, int)> OpenSeaSave(string? next, string occurred_after, string occurred_before)
    {
        Event? obj = await GetOpenSea(next, occurred_before, occurred_after);
        foreach (AssetEvent item in obj.AssetEvents)
        {
            await _context.db_AssetEvent.AddAsync(item);
        }
        int result = await _context.SaveChangesAsync();
        return (obj.Next, obj.AssetEvents.Count(), result);
    }
    public async Task<Event?> GetOpenSea(string? next, string occurred_before, string occurred_after)
    {
        var client = new RestClient("https://api.opensea.io/api/v1");

        var request = new RestRequest("events", Method.Get);
        request.AddHeader("Accept", "application/json");
        request.AddHeader("X-API-KEY", "564b70f8a92d4e97a39a68fdb2ab3b0a");
        request.AddQueryParameter("event_type", "successful");

        if (occurred_after != null)
        {
            request.AddQueryParameter("occurred_after", occurred_after);
        }
        if (occurred_before != null)
        {
            request.AddQueryParameter("occurred_before", occurred_before);
        }
        if (next != null)
        {
            request.AddQueryParameter("cursor", next);
        }
        Event? result = await client.GetAsync<Event>(request);

        return result;

    }
    public List<StatsOutput> GetMinuteAddedSale(int Minutes = 1)
    {
        Minutes = Minutes + 60;
        var x = _context.db_AssetEvent
            .Where(x => (x.EventTimestamp <= DateTime.UtcNow) & (x.EventTimestamp >= DateTime.UtcNow.AddMinutes(-Minutes)))
            .GroupBy(x => new { x.CollectionSlug })
            .Select(x => new StatsOutput
            {
                CollectionSlug = x.Key.CollectionSlug,
                mean_price = x.Average(a => Convert.ToDouble(a.TotalPrice)),
                total = x.Sum(a => Convert.ToDouble(a.Quantity)),
                NumResults = x.Count(),
                collection_image_url = x.Select(x => x.Asset.Collection.ImageUrl).FirstOrDefault(),
                collection_name = x.Select(x => x.Asset.Collection.Name).FirstOrDefault(),
                collection_discord_url = x.Select(x => x.Asset.Collection.DiscordUrl).FirstOrDefault(),
                collection_telegram_url = x.Select(x => x.Asset.Collection.TelegramUrl).FirstOrDefault(),
                collection_twitter_username = x.Select(x => x.Asset.Collection.TwitterUsername).FirstOrDefault(),
                collection_instagram_username = x.Select(x => x.Asset.Collection.InstagramUsername).FirstOrDefault(),
                collection_wiki_url = x.Select(x => x.Asset.Collection.WikiUrl).FirstOrDefault()
            })
            .OrderByDescending(x => x.total)
            .ToList();
        return x;
    }

    public List<StatsOutput> Get5Minutes(string collectionSlug, int Minutes = 1)
    {
        return _context.db_AssetEvent
            .Where(x => (x.CollectionSlug == collectionSlug) & (x.EventTimestamp <= DateTime.UtcNow) & (x.EventTimestamp >= DateTime.UtcNow.AddMinutes(-Minutes)))
            .GroupBy(x => new { x.CollectionSlug })
            .Select(x => new StatsOutput
            {
                CollectionSlug = x.Key.CollectionSlug,
                mean_price = x.Average(a => Convert.ToDouble(a.TotalPrice)),
                total = x.Sum(a => Convert.ToDouble(a.Quantity)),
                NumResults = x.Count(),
                collection_image_url = x.Select(x => x.Asset.Collection.ImageUrl).FirstOrDefault(),
                collection_name = x.Select(x => x.Asset.Collection.Name).FirstOrDefault(),
                collection_discord_url = x.Select(x => x.Asset.Collection.DiscordUrl).FirstOrDefault(),
                collection_telegram_url = x.Select(x => x.Asset.Collection.TelegramUrl).FirstOrDefault(),
                collection_twitter_username = x.Select(x => x.Asset.Collection.TwitterUsername).FirstOrDefault(),
                collection_instagram_username = x.Select(x => x.Asset.Collection.InstagramUsername).FirstOrDefault(),
                collection_wiki_url = x.Select(x => x.Asset.Collection.WikiUrl).FirstOrDefault()
            })
            .ToList();
    }



    public String TotalDuplicates()
    {        
        int asd = _context.db_AssetEvent.Select(x => new { x.Id, x.primary_key_Id }).GroupBy(a => new {a.Id}).Count();
        return ("Total: "+_context.db_AssetEvent.Count().ToString()+"\nTotal of groups: "+asd.ToString());
    }
    public async Task<(DateTime,String,String,int ,int)> OpenSeaUpdate (int minutes)
    {
        DateTime date = this.GetLastAddedSale();

        string occurred_after = ((DateTimeOffset)date).ToUnixTimeSeconds().ToString();
        string occurred_before  = ((DateTimeOffset)date.AddMinutes(minutes)).ToUnixTimeSeconds().ToString();

        (String? next,int counted, int result) = await this.OpenSeaSave(null, occurred_after, occurred_before);

        while (next != null)
        {
            (next, int counted2 , int result2) = await this.OpenSeaSave(next, occurred_after, occurred_before);
            counted = counted + counted2;
            result = result + result2;
        }
        return (date,occurred_after,occurred_before,result,counted);
    }
}
