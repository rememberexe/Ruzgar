using System.Text.Json;
using System.Text.Json.Serialization;
using Ruzgar.Models;

namespace Ruzgar.Services;

public class CitySearchService
{
    private static readonly HttpClient HttpClient = new()
    {
        Timeout = TimeSpan.FromSeconds(10)
    };

    public async Task<List<CitySearchResult>> SearchCitiesAsync(
        string query,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(query) || query.Trim().Length < 2)
            return new List<CitySearchResult>();

        string encodedQuery = Uri.EscapeDataString(query.Trim());

        string url =
            $"https://geocoding-api.open-meteo.com/v1/search" +
            $"?name={encodedQuery}" +
            $"&count=8" +
            $"&language=tr" +
            $"&format=json";

        using var response = await HttpClient.GetAsync(url, cancellationToken);
        response.EnsureSuccessStatusCode();

        string json = await response.Content.ReadAsStringAsync(cancellationToken);

        var data = JsonSerializer.Deserialize<OpenMeteoCitySearchResponse>(json);

        if (data?.Results == null)
            return new List<CitySearchResult>();

        return data.Results
            .Where(x => !string.IsNullOrWhiteSpace(x.Name))
            .Select(x => new CitySearchResult
            {
                Name = x.Name ?? "",
                Country = x.Country ?? "",
                AdminArea = x.Admin1 ?? "",
                Latitude = x.Latitude,
                Longitude = x.Longitude
            })
            .ToList();
    }
}

public class OpenMeteoCitySearchResponse
{
    [JsonPropertyName("results")]
    public List<OpenMeteoCityResult>? Results { get; set; }
}

public class OpenMeteoCityResult
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("country")]
    public string? Country { get; set; }

    [JsonPropertyName("admin1")]
    public string? Admin1 { get; set; }

    [JsonPropertyName("latitude")]
    public double Latitude { get; set; }

    [JsonPropertyName("longitude")]
    public double Longitude { get; set; }
}
