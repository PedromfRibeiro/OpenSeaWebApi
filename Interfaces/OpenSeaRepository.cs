using OpenSeaWebApi.Models;

namespace OpenSeaWebApi.Interfaces;

    public class teste
    {
        public string? CollectionSlug {get;set;}
        public int Minute {get;set;}
        public int NumResults {get;set;}
    }
public interface IOpenSeaRepository
{
public DateTime? GetLastAddedSale();
//public List<Teste> GetMinuteAddedSale();
}