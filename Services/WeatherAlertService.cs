using Microsoft.Maui.Storage;
using Ruzgar.Models;

namespace Ruzgar.Services;

public class WeatherAlertService
{
    private const string LastAlertPrefix = "ruzgar_last_weather_alert_";

    public WeatherAlertResult? CreateAlert(WeatherInfo weather)
    {
        double temperatureCelsius = GetTemperatureAsCelsius(weather);

        if (weather.WeatherCode >= 95)
        {
            return new WeatherAlertResult
            {
                Type = "storm",
                Title = "Fırtına uyarısı",
                Message = $"{weather.City} için gök gürültülü hava riski var. Dışarı çıkarken dikkatli ol."
            };
        }

        if (weather.PrecipitationProbability >= 70)
        {
            return new WeatherAlertResult
            {
                Type = "rain",
                Title = "Yağmur bekleniyor",
                Message = $"{weather.City} için yağış ihtimali %{weather.PrecipitationProbability}. Şemsiye almayı unutma."
            };
        }

        if (weather.WindSpeed >= 35)
        {
            return new WeatherAlertResult
            {
                Type = "wind",
                Title = "Rüzgar kuvvetli",
                Message = $"{weather.City} için rüzgar {weather.WindSpeed:0} km/s civarında. Dışarıda dikkatli ol."
            };
        }

        if (weather.UvIndex >= 8)
        {
            return new WeatherAlertResult
            {
                Type = "uv",
                Title = "UV yüksek",
                Message = $"{weather.City} için UV seviyesi {weather.UvIndex:0.0}. Güneşte uzun kalmamaya dikkat et."
            };
        }

        if (temperatureCelsius >= 38)
        {
            return new WeatherAlertResult
            {
                Type = "heat",
                Title = "Aşırı sıcak",
                Message = $"{weather.City} için sıcaklık çok yüksek. Bol su içmeyi unutma."
            };
        }

        if (temperatureCelsius <= 2)
        {
            return new WeatherAlertResult
            {
                Type = "cold",
                Title = "Soğuk hava",
                Message = $"{weather.City} için hava oldukça soğuk. Dışarı çıkarken kalın giyin."
            };
        }

        return null;
    }

    public bool CanSendAlert(WeatherAlertResult alert, string city)
    {
        string key = CreateAlertKey(alert, city);

        string value = Preferences.Default.Get(key, "");

        return value != "sent";
    }

    public void MarkAlertAsSent(WeatherAlertResult alert, string city)
    {
        string key = CreateAlertKey(alert, city);

        Preferences.Default.Set(key, "sent");
    }

    private static string CreateAlertKey(WeatherAlertResult alert, string city)
    {
        string cleanCity = new string(
            city
                .Where(char.IsLetterOrDigit)
                .ToArray())
            .ToLowerInvariant();

        string date = DateTime.Now.ToString("yyyyMMdd");

        return $"{LastAlertPrefix}{cleanCity}_{alert.Type}_{date}";
    }

    private static double GetTemperatureAsCelsius(WeatherInfo weather)
    {
        if (weather.TemperatureText.Contains("°F", StringComparison.OrdinalIgnoreCase))
        {
            return (weather.Temperature - 32) * 5 / 9;
        }

        return weather.Temperature;
    }
}

public class WeatherAlertResult
{
    public string Type { get; set; } = "";

    public string Title { get; set; } = "";

    public string Message { get; set; } = "";
}