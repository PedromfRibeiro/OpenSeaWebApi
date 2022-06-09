using OpenSeaWebApi.Models;
using OpenSeaWebApi.Interfaces;
using AutoMapper;
using RestSharp;
using OpenSeaWebApi.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace OpenSeaWebApi.Controllers;

public class OpenSeaController : BaseApiController
{
    private readonly IMapper _mapper;
    private readonly DataContext _dataContext;
    private readonly IOpenSeaRepository _openSeaRepository;


    public OpenSeaController(IMapper mapper, DataContext dataContext, IOpenSeaRepository openSeaRepository)
    {
        _mapper = mapper;
        _dataContext = dataContext;
        _openSeaRepository = openSeaRepository;
    }
    [HttpGet]
    public async Task<ActionResult<string>> GetCollection(int minutes = 1)
    {
        //DateTime LastReceived = _openSeaRepository.GetLastAddedSale();
        //
        //if (DateTime.Equals(LastReceived, DateTime.Parse("01/01/0001 01:00:00")))
        //{
        //    LastReceived = DateTime.UtcNow.AddMinutes(-1);
        //}
        string occurred_after = ((DateTimeOffset)DateTime.UtcNow.AddMinutes(-minutes)).ToUnixTimeSeconds().ToString();
        string occurred_before = ((DateTimeOffset)DateTime.UtcNow).ToUnixTimeSeconds().ToString();

        (Event obj, int result) = await OpenSeaSave(null, occurred_after, occurred_before);

        while (obj.Next != null)
        {
            (obj, int result2) = await OpenSeaSave(obj.Next, occurred_after, occurred_before);
            result = result + result2;
        }

        return Ok("occurred_after: " + occurred_after + "\noccurred_before: " + occurred_before + "\nAdded:  " + result.ToString());
    }
    [HttpGet, Route("GetTimeZone")]
    public async Task<ActionResult<string>> GetTimeZone( )
    {
        TimeZoneInfo localZone = TimeZoneInfo.Local;
        return Ok(localZone);
    }
    [NonAction]
    public async Task<(Event, int)> OpenSeaSave(string? next, string occurred_after, string occurred_before)
    {
        Event? obj = await GetOpenSea(next, occurred_before, occurred_after);
        foreach (AssetEvent item in obj.AssetEvents)
        {
            await _dataContext.db_AssetEvent.AddAsync(item);
        }
        int result = await _dataContext.SaveChangesAsync();
        return (obj, result);
    }

    [NonAction]
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


    public class teste
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
    [HttpGet, Route("x_minutesByMinutes")]
    public List<teste> GetMinuteAddedSale(int Minutes=1)
    {
        Minutes = Minutes + 60;
        var x = _dataContext.db_AssetEvent
            .Where(x => (x.EventTimestamp <=  DateTime.UtcNow) & (x.EventTimestamp >= DateTime.UtcNow.AddMinutes(-Minutes)) )
            .GroupBy(x => new {x.CollectionSlug})
            .Select(x => new teste
            {
                CollectionSlug = x.Key.CollectionSlug,
                mean_price = x.Average(a=> Convert.ToDouble(a.TotalPrice)),
                total = x.Sum(a=>Convert.ToDouble(a.Quantity)),
                NumResults = x.Count(),
                collection_image_url =   x.Select(x => x.Asset.Collection.ImageUrl).FirstOrDefault(),
                collection_name    =   x.Select(x => x.Asset.Collection.Name).FirstOrDefault() ,
                collection_discord_url = x.Select(x=>x.Asset.Collection.DiscordUrl).FirstOrDefault(),
                collection_telegram_url = x.Select(x=>x.Asset.Collection.TelegramUrl).FirstOrDefault(),
                collection_twitter_username = x.Select(x=>x.Asset.Collection.TwitterUsername).FirstOrDefault(),
                collection_instagram_username = x.Select(x=>x.Asset.Collection.InstagramUsername).FirstOrDefault(),
                collection_wiki_url = x.Select(x=>x.Asset.Collection.WikiUrl).FirstOrDefault()
                
                
            })
            .OrderByDescending(x=>x.total)
            .ToList();
        return x;

    }
    [HttpGet, Route("GetCollection")]
    public List<teste> Get5Minutes(string collectionSlug)
    {
        var x = _dataContext.db_AssetEvent
            .Where(x=>x.CollectionSlug == collectionSlug)
            .GroupBy(x => new { x.CollectionSlug})
            //.Join(_dataContext.db_Collection,)
            .Select(x => new teste
            {
                CollectionSlug = x.Key.CollectionSlug,
                mean_price = x.Average(a=> Convert.ToDouble(a.TotalPrice)),
                total = x.Sum(a=>Convert.ToDouble(a.Quantity)),
                NumResults = x.Count(),
                collection_image_url =   x.Select(x => x.Asset.Collection.ImageUrl).FirstOrDefault(),
                collection_name    =   x.Select(x => x.Asset.Collection.Name).FirstOrDefault() 

            })
            .ToList();


        return x;

    }
}