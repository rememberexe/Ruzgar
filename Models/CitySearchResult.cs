namespace Ruzgar.Models;

public class CitySearchResult
{
    public string Name { get; set; } = "";

    public string Country { get; set; } = "";

    public string AdminArea { get; set; } = "";

    public double Latitude { get; set; }

    public double Longitude { get; set; }

    public string DisplayName
    {
        get
        {
            if (!string.IsNullOrWhiteSpace(AdminArea))
                return $"{Name}, {AdminArea}, {Country}";

            return $"{Name}, {Country}";
        }
    }
}