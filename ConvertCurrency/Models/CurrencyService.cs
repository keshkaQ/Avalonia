using System.Collections.Generic;
namespace ConvertСurrency.Models;

public class CurrencyService
{
    private readonly Dictionary<string, decimal> valueByRate = new();
    public CurrencyService()
    {
        valueByRate  = ConfigurationRates.GetRates();
    }
    public decimal Convert(decimal amount, string nameFrom, string nameTo)
    {
        // from.Rate - курс исходной валюты относительно USD 
        // to.Rate - курс целевой валюты относительно USD
        return amount * ((valueByRate[nameTo]/ valueByRate[nameFrom]));
    }
}