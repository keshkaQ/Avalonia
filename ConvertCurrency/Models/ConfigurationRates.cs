using System.Collections.Generic;
namespace ConvertСurrency.Models;
public class ConfigurationRates
{
    public static Dictionary<string, decimal> GetRates()
    {
        return new Dictionary<string, decimal>
        {
            ["USD"] = 1m,
            ["EUR"] = 0.93m,
            ["GBP"] = 0.8m,
            ["JPY"] = 151.5m,
            ["RUB"] = 92.5m
        };
    }
}