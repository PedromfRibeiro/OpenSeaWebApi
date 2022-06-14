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
        (DateTime date, String occurred_after, String occurred_before, int result, int counted) = await _openSeaRepository.OpenSeaUpdate(minutes);
        
        return Ok(
            "[ "+date+ "  ,  " + date.AddMinutes(minutes) + " ]"+
            "\nTimeStamp occurred_after: "   + occurred_after + 
            "\nTimeStamp occurred_before: " + occurred_before + 
            "\nTimeStamp occurred_after: "   + date + 
            "\nTimeStamp occurred_before: " + date.AddMinutes(minutes) + 
            "\nSave dInto Database:  " + result.ToString()+
            "\nNumber of events inside array:  " + counted.ToString());

    }
    [HttpGet, Route("GetLastAddedSale")]
    public ActionResult<DateTime> LastAddedSale()
    {
        DateTime? LastReceived = _openSeaRepository.GetLastAddedSale();
        return Ok(LastReceived);
    }
    
    [HttpGet, Route("GetTimeZone")]
    public async Task<ActionResult<string>> GetTimeZone()
    {
        TimeZoneInfo localZone = TimeZoneInfo.Local;
        return Ok(localZone);
    }

    [HttpGet, Route("TotalDuplicates")]
    public ActionResult<String> TotalDuplicates()
    {
        return Ok(_openSeaRepository.TotalDuplicates());
    }

    [HttpGet, Route("XMinutes")]
    public List<StatsOutput> GetMinuteAddedSale(int Minutes = 1)
    {
        return _openSeaRepository.GetMinuteAddedSale(Minutes);
    }
    
    [HttpGet, Route("GetCollection")]
    public List<StatsOutput> Get5Minutes(string collectionSlug, int Minute=1)
    {
        return _openSeaRepository.Get5Minutes(collectionSlug,Minute);
    }
}