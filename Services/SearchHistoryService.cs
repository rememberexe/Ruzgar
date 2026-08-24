using System.Text.Json;
using Microsoft.Maui.Storage;
using Ruzgar.Models;

namespace Ruzgar.Services;

public class SearchHistoryService
{
    private const string StorageKey = "Ruzgar_SearchHistoryCities";
    private const int MaxHistoryCount = 8;

    public List<CitySearchResult> LoadHistory()
    {
        try
        {
            string json = Preferences.Default.Get(StorageKey, "");

            if (string.IsNullOrWhiteSpace(json))
                return new List<CitySearchResult>();

            return JsonSerializer.Deserialize<List<CitySearchResult>>(json)
                   ?? new List<CitySearchResult>();
        }
        catch
        {
            return new List<CitySearchResult>();
        }
    }

    public void SaveHistory(IEnumerable<CitySearchResult> cities)
    {
        try
        {
            var cleanList = cities
                .Where(x => !string.IsNullOrWhiteSpace(x.Name))
                .Take(MaxHistoryCount)
                .ToList();

            string json = JsonSerializer.Serialize(cleanList);

            Preferences.Default.Set(StorageKey, json);
        }
        catch
        {
        }
    }

    public void ClearHistory()
    {
        try
        {
            Preferences.Default.Remove(StorageKey);
        }
        catch
        {
        }
    }
}