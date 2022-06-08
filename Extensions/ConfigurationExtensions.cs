namespace OpenSeaWebApi.Extensions;

public static class ConfigurationExtensions
{
    public static string GetTwillioString(this IConfiguration config, string name)
    {
        return config.GetSection("Twillio")[name];
    }
    public static string GetMailString(this IConfiguration config, string name)
    {
        return config.GetSection("Mail")[name];
    }
}