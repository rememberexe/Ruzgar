using Microsoft.Maui.Graphics;

namespace Ruzgar.Models;

public class WeatherInfo
{
    public string City { get; set; } = "";

    public double Temperature { get; set; }

    public string TemperatureText { get; set; } = "0°C";

    public double FeelsLike { get; set; }

    public string FeelsLikeText { get; set; } = "Hissedilen 0°C";

    public int Humidity { get; set; }

    public double WindSpeed { get; set; }

    public int WeatherCode { get; set; }

    public string Description { get; set; } = "";

    public string Icon { get; set; } = "☁️";

    public string UpdatedText { get; set; } = "";

    public string MoodText { get; set; } = "";

    public int PrecipitationProbability { get; set; }

    public double UvIndex { get; set; }

    public double Pressure { get; set; }

    public double Visibility { get; set; }

    public Color BackgroundStartColor { get; set; } = Color.FromArgb("#1E3A8A");

    public Color BackgroundMiddleColor { get; set; } = Color.FromArgb("#0F172A");

    public Color BackgroundEndColor { get; set; } = Color.FromArgb("#020617");

    public Color CardStartColor { get; set; } = Color.FromArgb("#1E3A8A");

    public Color CardEndColor { get; set; } = Color.FromArgb("#020617");

    public Color AccentColor { get; set; } = Color.FromArgb("#60A5FA");

    public List<HourlyWeatherInfo> HourlyForecasts { get; set; } = new();

    public List<DailyWeatherInfo> DailyForecasts { get; set; } = new();

    public bool IsSunnyEffectVisible => WeatherCode is 0 or 1;

    public bool IsCloudEffectVisible => WeatherCode is 2 or 3;

    public bool IsRainEffectVisible => WeatherCode is
        51 or 53 or 55 or
        61 or 63 or 65 or
        66 or 67 or
        80 or 81 or 82;

    public bool IsSnowEffectVisible => WeatherCode is
        71 or 73 or 75 or
        77 or
        85 or 86;

    public bool IsFogEffectVisible => WeatherCode is 45 or 48;

    public bool IsStormEffectVisible => WeatherCode is 95 or 96 or 99;
}

public class HourlyWeatherInfo
{
    public string TimeText { get; set; } = "";

    public double Temperature { get; set; }

    public string TemperatureText { get; set; } = "0°C";

    public int WeatherCode { get; set; }

    public string Icon { get; set; } = "☁️";

    public int PrecipitationProbability { get; set; }

    public string PrecipitationText { get; set; } = "%0";
}

public class DailyWeatherInfo
{
    public string DayText { get; set; } = "";

    public double MaxTemperature { get; set; }

    public string MaxTemperatureText { get; set; } = "0°C";

    public double MinTemperature { get; set; }

    public string MinTemperatureText { get; set; } = "0°C";

    public int WeatherCode { get; set; }

    public string Icon { get; set; } = "☁️";
}