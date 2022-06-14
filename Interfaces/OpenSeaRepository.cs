using OpenSeaWebApi.Models;

namespace OpenSeaWebApi.Interfaces;

public interface IOpenSeaRepository
{
    public DateTime GetLastAddedSale();
    public List<StatsOutput> GetMinuteAddedSale(DateTime Start);
    public Task<(string?, int, int)> OpenSeaSave(string? next, string occurred_after, string occurred_before);
    public Task<Event?> GetOpenSea(string? next, string occurred_before, string occurred_after);
    public List<StatsOutput> GetMinuteAddedSale(int Minutes = 1);
    public List<StatsOutput> Get5Minutes(string collectionSlug, int Minutes = 1);
    public String TotalDuplicates();
    public Task<(DateTime,String,String,int ,int)> OpenSeaUpdate (int minutes);
}