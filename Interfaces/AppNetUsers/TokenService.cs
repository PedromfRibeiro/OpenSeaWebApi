using System.Threading.Tasks;
using OpenSeaWebApi.Models;

namespace OpenSeaWebApi.Interfaces;

public interface ITokenService
{
    string CreateToken(AppUser user, string id);
    string ReadToken(string jwt);

}
