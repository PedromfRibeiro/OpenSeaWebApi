using System.Text.RegularExpressions;

namespace OpenSeaWebApi.Helpers;

public static class DotEnv
{
    public static void Load(string filePath)
    {
        if (!File.Exists(filePath))
            return;
        var regex = new Regex("\"(.*?)\"");

        foreach (var line in File.ReadAllLines(filePath))
        {
            var parts = line.Split(
                '=',
                StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length != 2)
                continue;
            var match = regex.Match(parts[1]);

            Environment.SetEnvironmentVariable(parts[0], match.Groups[1].Value);
            Console.WriteLine($"Variable Name: '{parts[0]}', Variable Value: '{match.Groups[1]}'");
        }
    }
}
