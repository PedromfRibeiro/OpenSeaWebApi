using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using OpenSeaWebApi.Interfaces;
using OpenSeaWebApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;


namespace OpenSeaWebApi.Extensions;

public class TokenService : ITokenService
{
    private readonly UserManager<AppUser> _userManager;

    private readonly SymmetricSecurityKey _key;
    public TokenService(IConfiguration config, UserManager<AppUser> userManager)
    {
        _userManager = userManager;

        _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
    }

    public string CreateToken(AppUser user,string id)
    {
        var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Name,user.UserName),
                new Claim(JwtRegisteredClaimNames.NameId,id)
            };
        var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(7),
            SigningCredentials = creds
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public string ReadToken(string jwt)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        JwtSecurityToken token = tokenHandler.ReadJwtToken(jwt);

        JObject json = JObject.Parse(token.Payload.SerializeToJson());
        
        return (string)json["nameid"];
    }
    
}