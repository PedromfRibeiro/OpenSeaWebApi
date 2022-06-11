using AutoMapper;
using OpenSeaWebApi.Interfaces;
using OpenSeaWebApi.Models;

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
    public DateTime? GetLastAddedSale()
    {
        DateTime? date = _context.db_AssetEvent.Max(date => (DateTime?)date.EventTimestamp);
        if(date == null)
            date = DateTime.UtcNow.AddMinutes(-1);
            
        return date;

    }
    public class teste
    {
        public string? CollectionSlug {get;set;}
        public int Minute {get;set;}
        public int NumResults {get;set;}
    }
        public List<teste> GetMinuteAddedSale(DateTime Start)
    {
        var x = _context.db_AssetEvent.GroupBy(x=>new {x.CollectionSlug, x.EventTimestamp.Minute}).Select(x => new teste
            {
                CollectionSlug = x.Key.CollectionSlug,
                Minute      = x.Key.Minute,
                NumResults   = x.Count()
            })
            .ToList();


        return x;

    }

}
