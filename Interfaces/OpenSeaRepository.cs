using OpenSeaWebApi.Models;

namespace OpenSeaWebApi.Interfaces;

public interface IOpenSeaRepository
{
public DateTime GetLastAddedSale();
public AssetEvent GetListOneMinute();
}
