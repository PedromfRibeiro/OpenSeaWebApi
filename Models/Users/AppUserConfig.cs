namespace OpenSeaWebApi.Models;

public class AppUserConfig
{
    public int id { get; set; }
    public int itemsPerPage { get; set; }
    public bool isDarkTheme { get; set; }
    //Add more...
    public int? AppUser_id { get; set; }
    public AppUser? AppUser { get; set; }
}

