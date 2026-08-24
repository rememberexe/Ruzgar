namespace Ruzgar.Models;

public class AppSettings
{
    public bool UseFahrenheit { get; set; } = false;

    public bool UseCurrentLocationOnStartup { get; set; } = false;

    public bool UseDynamicTheme { get; set; } = true;

    public bool EnableWeatherNotifications { get; set; } = false;

    public bool HasDefaultCity { get; set; } = true;

    public string DefaultCityName { get; set; } = "Adana";

    public string DefaultCityCountry { get; set; } = "Türkiye";

    public string DefaultCityAdminArea { get; set; } = "Adana";

    public double DefaultCityLatitude { get; set; } = 37.0000;

    public double DefaultCityLongitude { get; set; } = 35.3213;

    public string DefaultCityDisplayName
    {
        get
        {
            if (!string.IsNullOrWhiteSpace(DefaultCityAdminArea) &&
                !string.IsNullOrWhiteSpace(DefaultCityCountry) &&
                !string.Equals(DefaultCityAdminArea, DefaultCityName, StringComparison.OrdinalIgnoreCase))
            {
                return $"{DefaultCityName}, {DefaultCityAdminArea}, {DefaultCityCountry}";
            }

            if (!string.IsNullOrWhiteSpace(DefaultCityCountry))
                return $"{DefaultCityName}, {DefaultCityCountry}";

            return DefaultCityName;
        }
    }
}