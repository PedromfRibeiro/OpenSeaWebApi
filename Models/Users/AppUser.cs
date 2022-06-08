using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace OpenSeaWebApi.Models;

public class AppUser : IdentityUser<int>
{
    // IdentityUser Brings:
    //     username
    //     password
    //     password_salt
    //     email

    public string? name { get; set; }
    public string? contact { get; set; }
    public byte[]? image { get; set; }
    public byte[]? image_small { get; set; }
    public string? observations { get; set; }
    public int? company_id { get; set; }
    public bool FirstLogin { get; set; } = true;
    public DateTime CreateTime { get; set; }
    public DateTime LastLogin { get; set; }
    public virtual AppUserConfig? UserConfigs { get; set; }

}
