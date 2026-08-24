using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Maui.Graphics;
using Ruzgar.Models;

namespace Ruzgar.Services;

public class WeatherService
{
    private static readonly HttpClient HttpClient = new()
    {
        Timeout = TimeSpan.FromSeconds(12)
    };

    public async Task<WeatherInfo> GetWeatherAsync(
        double latitude,
        double longitude,
        string city,
        CancellationToken cancellationToken = default)
    {
        string url =
            $"https://api.open-meteo.com/v1/forecast" +
            $"?latitude={latitude.ToString(CultureInfo.InvariantCulture)}" +
            $"&longitude={longitude.ToString(CultureInfo.InvariantCulture)}" +
            $"&current=temperature_2m,relative_humidity_2m,apparent_temperature,weather_code,wind_speed_10m" +
            $"&hourly=temperature_2m,weather_code,precipitation_probability,uv_index,pressure_msl,visibility" +
            $"&daily=weather_code,temperature_2m_max,temperature_2m_min" +
            $"&forecast_days=7" +
            $"&timezone=auto";

        using var response = await HttpClient.GetAsync(url, cancellationToken);
        response.EnsureSuccessStatusCode();

        string json = await response.Content.ReadAsStringAsync(cancellationToken);

        var data = JsonSerializer.Deserialize<OpenMeteoResponse>(json);

        if (data?.Current == null)
            throw new Exception("Hava durumu verisi alınamadı.");

        int currentHourIndex = FindCurrentHourlyIndex(data);

        var weather = new WeatherInfo
        {
            City = city,
            Temperature = Math.Round(data.Current.Temperature, 0),
            FeelsLike = Math.Round(data.Current.ApparentTemperature, 0),
            Humidity = data.Current.Humidity,
            WindSpeed = Math.Round(data.Current.WindSpeed, 1),
            WeatherCode = data.Current.WeatherCode,
            Description = GetDescription(data.Current.WeatherCode),
            Icon = GetIcon(data.Current.WeatherCode),
            UpdatedText = $"Güncellendi: {DateTime.Now:HH:mm}",
            MoodText = GetMoodText(data.Current.WeatherCode, data.Current.Temperature, data.Current.WindSpeed),

            PrecipitationProbability = GetIntValue(data.Hourly?.PrecipitationProbability, currentHourIndex),
            UvIndex = Math.Round(GetDoubleValue(data.Hourly?.UvIndex, currentHourIndex), 1),
            Pressure = Math.Round(GetDoubleValue(data.Hourly?.Pressure, currentHourIndex), 0),
            Visibility = Math.Round(GetDoubleValue(data.Hourly?.Visibility, currentHourIndex) / 1000.0, 1),

            HourlyForecasts = BuildHourlyForecasts(data),
            DailyForecasts = BuildDailyForecasts(data)
        };

        ApplyTheme(weather);

        return weather;
    }

    private static int FindCurrentHourlyIndex(OpenMeteoResponse data)
    {
        if (data.Hourly?.Time == null || data.Hourly.Time.Count == 0)
            return 0;

        var now = DateTime.Now;

        for (int i = 0; i < data.Hourly.Time.Count; i++)
        {
            if (!DateTime.TryParse(data.Hourly.Time[i], out DateTime forecastTime))
                continue;

            if (forecastTime >= now.AddMinutes(-30))
                return i;
        }

        return 0;
    }

    private static int GetIntValue(List<int>? values, int index)
    {
        if (values == null || values.Count == 0)
            return 0;

        if (index < 0 || index >= values.Count)
            return values[0];

        return values[index];
    }

    private static double GetDoubleValue(List<double>? values, int index)
    {
        if (values == null || values.Count == 0)
            return 0;

        if (index < 0 || index >= values.Count)
            return values[0];

        return values[index];
    }

    private static List<HourlyWeatherInfo> BuildHourlyForecasts(OpenMeteoResponse data)
    {
        var result = new List<HourlyWeatherInfo>();

        if (data.Hourly?.Time == null ||
            data.Hourly.Temperature == null ||
            data.Hourly.WeatherCode == null)
        {
            return result;
        }

        var now = DateTime.Now;

        for (int i = 0; i < data.Hourly.Time.Count; i++)
        {
            if (i >= data.Hourly.Temperature.Count || i >= data.Hourly.WeatherCode.Count)
                break;

            if (!DateTime.TryParse(data.Hourly.Time[i], out DateTime forecastTime))
                continue;

            if (forecastTime < now.AddMinutes(-30))
                continue;

            int code = data.Hourly.WeatherCode[i];

            int precipitation = GetIntValue(data.Hourly.PrecipitationProbability, i);

            result.Add(new HourlyWeatherInfo
            {
                TimeText = forecastTime.ToString("HH:mm"),
                Temperature = Math.Round(data.Hourly.Temperature[i], 0),
                WeatherCode = code,
                Icon = GetIcon(code),
                PrecipitationProbability = precipitation,
                PrecipitationText = $"%{precipitation}"
            });

            if (result.Count >= 12)
                break;
        }

        return result;
    }

    private static List<DailyWeatherInfo> BuildDailyForecasts(OpenMeteoResponse data)
    {
        var result = new List<DailyWeatherInfo>();

        if (data.Daily?.Time == null ||
            data.Daily.MaxTemperature == null ||
            data.Daily.MinTemperature == null ||
            data.Daily.WeatherCode == null)
        {
            return result;
        }

        var tr = new CultureInfo("tr-TR");

        for (int i = 0; i < data.Daily.Time.Count; i++)
        {
            if (i >= data.Daily.MaxTemperature.Count ||
                i >= data.Daily.MinTemperature.Count ||
                i >= data.Daily.WeatherCode.Count)
            {
                break;
            }

            if (!DateTime.TryParse(data.Daily.Time[i], out DateTime date))
                continue;

            int code = data.Daily.WeatherCode[i];

            string dayText = date.Date == DateTime.Today
                ? "Bugün"
                : tr.DateTimeFormat.GetDayName(date.DayOfWeek);

            result.Add(new DailyWeatherInfo
            {
                DayText = dayText,
                MaxTemperature = Math.Round(data.Daily.MaxTemperature[i], 0),
                MinTemperature = Math.Round(data.Daily.MinTemperature[i], 0),
                WeatherCode = code,
                Icon = GetIcon(code)
            });
        }

        return result;
    }

    private static void ApplyTheme(WeatherInfo weather)
    {
        int code = weather.WeatherCode;

        if (code == 0 || code == 1)
        {
            weather.BackgroundStartColor = Color.FromArgb("#0EA5E9");
            weather.BackgroundMiddleColor = Color.FromArgb("#1E3A8A");
            weather.BackgroundEndColor = Color.FromArgb("#020617");

            weather.CardStartColor = Color.FromArgb("#2563EB");
            weather.CardEndColor = Color.FromArgb("#0F172A");

            weather.AccentColor = Color.FromArgb("#FBBF24");
        }
        else if (code == 2 || code == 3)
        {
            weather.BackgroundStartColor = Color.FromArgb("#334155");
            weather.BackgroundMiddleColor = Color.FromArgb("#1E293B");
            weather.BackgroundEndColor = Color.FromArgb("#020617");

            weather.CardStartColor = Color.FromArgb("#475569");
            weather.CardEndColor = Color.FromArgb("#0F172A");

            weather.AccentColor = Color.FromArgb("#93C5FD");
        }
        else if (code is 61 or 63 or 65 or 80 or 81 or 82 or 51 or 53 or 55)
        {
            weather.BackgroundStartColor = Color.FromArgb("#1E40AF");
            weather.BackgroundMiddleColor = Color.FromArgb("#172554");
            weather.BackgroundEndColor = Color.FromArgb("#020617");

            weather.CardStartColor = Color.FromArgb("#1D4ED8");
            weather.CardEndColor = Color.FromArgb("#0F172A");

            weather.AccentColor = Color.FromArgb("#38BDF8");
        }
        else if (code is 71 or 73 or 75 or 77 or 85 or 86)
        {
            weather.BackgroundStartColor = Color.FromArgb("#BAE6FD");
            weather.BackgroundMiddleColor = Color.FromArgb("#2563EB");
            weather.BackgroundEndColor = Color.FromArgb("#0F172A");

            weather.CardStartColor = Color.FromArgb("#38BDF8");
            weather.CardEndColor = Color.FromArgb("#0F172A");

            weather.AccentColor = Color.FromArgb("#E0F2FE");
        }
        else if (code is 95 or 96 or 99)
        {
            weather.BackgroundStartColor = Color.FromArgb("#581C87");
            weather.BackgroundMiddleColor = Color.FromArgb("#1E1B4B");
            weather.BackgroundEndColor = Color.FromArgb("#020617");

            weather.CardStartColor = Color.FromArgb("#6D28D9");
            weather.CardEndColor = Color.FromArgb("#020617");

            weather.AccentColor = Color.FromArgb("#C084FC");
        }
        else if (code is 45 or 48)
        {
            weather.BackgroundStartColor = Color.FromArgb("#64748B");
            weather.BackgroundMiddleColor = Color.FromArgb("#334155");
            weather.BackgroundEndColor = Color.FromArgb("#020617");

            weather.CardStartColor = Color.FromArgb("#475569");
            weather.CardEndColor = Color.FromArgb("#0F172A");

            weather.AccentColor = Color.FromArgb("#CBD5E1");
        }
        else
        {
            weather.BackgroundStartColor = Color.FromArgb("#1E3A8A");
            weather.BackgroundMiddleColor = Color.FromArgb("#0F172A");
            weather.BackgroundEndColor = Color.FromArgb("#020617");

            weather.CardStartColor = Color.FromArgb("#1E3A8A");
            weather.CardEndColor = Color.FromArgb("#020617");

            weather.AccentColor = Color.FromArgb("#60A5FA");
        }
    }

    private static string GetMoodText(int code, double temperature, double windSpeed)
    {
        if (temperature >= 35)
            return "Bugün hava oldukça sıcak. Dışarı çıkarken su bulundurmak iyi olur.";

        if (windSpeed >= 35)
            return "Rüzgâr bugün belirgin şekilde etkili olabilir.";

        return code switch
        {
            0 => "Gökyüzü açık. Dışarı çıkmak için güzel bir gün.",
            1 => "Hava genel olarak açık ve sakin görünüyor.",
            2 => "Bulutlar var ama hava dengeli görünüyor.",
            3 => "Kapalı bir hava var, gün biraz sakin geçebilir.",
            45 or 48 => "Sis görüşü azaltabilir, dikkatli olmakta fayda var.",
            51 or 53 or 55 => "Hafif yağış olabilir. Şemsiye almak iyi fikir.",
            61 or 63 or 65 => "Yağmur bekleniyor. Dışarı çıkarken hazırlıklı ol.",
            80 or 81 or 82 => "Sağanak geçişleri olabilir. Şemsiyeni unutma.",
            71 or 73 or 75 or 77 => "Kar etkili olabilir. Soğuğa karşı hazırlıklı ol.",
            85 or 86 => "Kar sağanağı ihtimali var. Dışarıda dikkatli ol.",
            95 or 96 or 99 => "Fırtına ve gök gürültüsü olabilir. Açık alanda dikkatli ol.",
            _ => "Hava durumunu kontrol ettim. Gününe hazırlıklı başlayabilirsin."
        };
    }

    private static string GetDescription(int code)
    {
        return code switch
        {
            0 => "Açık",
            1 => "Çoğunlukla açık",
            2 => "Parçalı bulutlu",
            3 => "Kapalı",
            45 or 48 => "Sisli",
            51 or 53 or 55 => "Çisenti",
            61 or 63 or 65 => "Yağmurlu",
            66 or 67 => "Donan yağmur",
            71 or 73 or 75 => "Karlı",
            77 => "Kar taneleri",
            80 or 81 or 82 => "Sağanak yağış",
            85 or 86 => "Kar sağanağı",
            95 => "Gök gürültülü",
            96 or 99 => "Dolu ve fırtına",
            _ => "Bilinmiyor"
        };
    }

    private static string GetIcon(int code)
    {
        return code switch
        {
            0 => "☀️",
            1 => "🌤️",
            2 => "⛅",
            3 => "☁️",
            45 or 48 => "🌫️",
            51 or 53 or 55 => "🌦️",
            61 or 63 or 65 => "🌧️",
            66 or 67 => "🌧️",
            71 or 73 or 75 => "❄️",
            77 => "❄️",
            80 or 81 or 82 => "🌧️",
            85 or 86 => "🌨️",
            95 => "⛈️",
            96 or 99 => "⛈️",
            _ => "☁️"
        };
    }
}

public class OpenMeteoResponse
{
    [JsonPropertyName("current")]
    public CurrentWeather? Current { get; set; }

    [JsonPropertyName("hourly")]
    public HourlyWeather? Hourly { get; set; }

    [JsonPropertyName("daily")]
    public DailyWeather? Daily { get; set; }
}

public class CurrentWeather
{
    [JsonPropertyName("temperature_2m")]
    public double Temperature { get; set; }

    [JsonPropertyName("relative_humidity_2m")]
    public int Humidity { get; set; }

    [JsonPropertyName("apparent_temperature")]
    public double ApparentTemperature { get; set; }

    [JsonPropertyName("weather_code")]
    public int WeatherCode { get; set; }

    [JsonPropertyName("wind_speed_10m")]
    public double WindSpeed { get; set; }
}

public class HourlyWeather
{
    [JsonPropertyName("time")]
    public List<string> Time { get; set; } = new();

    [JsonPropertyName("temperature_2m")]
    public List<double> Temperature { get; set; } = new();

    [JsonPropertyName("weather_code")]
    public List<int> WeatherCode { get; set; } = new();

    [JsonPropertyName("precipitation_probability")]
    public List<int> PrecipitationProbability { get; set; } = new();

    [JsonPropertyName("uv_index")]
    public List<double> UvIndex { get; set; } = new();

    [JsonPropertyName("pressure_msl")]
    public List<double> Pressure { get; set; } = new();

    [JsonPropertyName("visibility")]
    public List<double> Visibility { get; set; } = new();
}

public class DailyWeather
{
    [JsonPropertyName("time")]
    public List<string> Time { get; set; } = new();

    [JsonPropertyName("weather_code")]
    public List<int> WeatherCode { get; set; } = new();

    [JsonPropertyName("temperature_2m_max")]
    public List<double> MaxTemperature { get; set; } = new();

    [JsonPropertyName("temperature_2m_min")]
    public List<double> MinTemperature { get; set; } = new();
}
