using Microsoft.Maui.Graphics;
using Ruzgar.Models;

namespace Ruzgar.ViewModels;

public class WeatherDetailViewModel
{
    public WeatherInfo Weather { get; }

    public WeatherDetailViewModel(WeatherInfo weather)
    {
        Weather = weather;
    }

    public Color BackgroundStartColor => Weather.BackgroundStartColor;
    public Color BackgroundMiddleColor => Weather.BackgroundMiddleColor;
    public Color BackgroundEndColor => Weather.BackgroundEndColor;
    public Color CardStartColor => Weather.CardStartColor;
    public Color CardEndColor => Weather.CardEndColor;
    public Color AccentColor => Weather.AccentColor;

    public string City => Weather.City;
    public string Icon => Weather.Icon;
    public string TemperatureText => Weather.TemperatureText;
    public string Description => Weather.Description;
    public string UpdatedText => Weather.UpdatedText;
    public int WeatherCode => Weather.WeatherCode;

    public List<HourlyWeatherInfo> HourlyForecasts => Weather.HourlyForecasts;
    public List<DailyWeatherInfo> DailyForecasts => Weather.DailyForecasts;

    public string TodayRangeText
    {
        get
        {
            var today = Weather.DailyForecasts.FirstOrDefault();

            if (today == null)
                return "Bugün için aralık yok";

            return $"{today.MinTemperatureText} / {today.MaxTemperatureText}";
        }
    }

    public string WarmestHourText
    {
        get
        {
            var hour = Weather.HourlyForecasts
                .OrderByDescending(x => x.Temperature)
                .FirstOrDefault();

            if (hour == null)
                return "--";

            return $"{hour.TimeText} • {hour.TemperatureText}";
        }
    }

    public string ColdestHourText
    {
        get
        {
            var hour = Weather.HourlyForecasts
                .OrderBy(x => x.Temperature)
                .FirstOrDefault();

            if (hour == null)
                return "--";

            return $"{hour.TimeText} • {hour.TemperatureText}";
        }
    }

    public string ComfortScoreText
    {
        get
        {
            int score = 100;

            if (Weather.Temperature >= 35)
                score -= 28;
            else if (Weather.Temperature >= 30)
                score -= 15;
            else if (Weather.Temperature <= 3)
                score -= 22;
            else if (Weather.Temperature <= 8)
                score -= 12;

            if (Weather.WindSpeed >= 35)
                score -= 20;
            else if (Weather.WindSpeed >= 22)
                score -= 10;

            if (Weather.PrecipitationProbability >= 70)
                score -= 25;
            else if (Weather.PrecipitationProbability >= 40)
                score -= 12;

            if (Weather.Visibility > 0 && Weather.Visibility <= 2)
                score -= 18;

            score = Math.Clamp(score, 0, 100);

            return $"{score}/100";
        }
    }

    public string ComfortComment
    {
        get
        {
            int score = ExtractComfortScore();

            if (score >= 85)
                return "Bugün dışarı çıkmak için oldukça rahat görünüyor.";

            if (score >= 65)
                return "Genel olarak uygun, ama gün içinde hava değişebilir.";

            if (score >= 45)
                return "Dışarı çıkarken biraz hazırlıklı olmak iyi olur.";

            return "Bugün hava koşulları yorucu olabilir, dikkatli plan yapmak iyi olur.";
        }
    }

    public string RainAdvice
    {
        get
        {
            if (Weather.PrecipitationProbability >= 70)
                return "Şemsiye kesin iyi fikir. Yağış ihtimali yüksek.";

            if (Weather.PrecipitationProbability >= 40)
                return "Yağış ihtimali orta seviyede. Dışarı çıkacaksan şemsiye almak mantıklı.";

            if (Weather.PrecipitationProbability >= 20)
                return "Düşük de olsa yağış ihtimali var. Kısa süreli geçişler olabilir.";

            return "Yağış ihtimali düşük. Şemsiye şart görünmüyor.";
        }
    }

    public string UvAdvice
    {
        get
        {
            if (Weather.UvIndex >= 8)
                return "UV yüksek. Güneş kremi, şapka ve gölge önemli.";

            if (Weather.UvIndex >= 6)
                return "UV belirgin. Uzun süre dışarıda kalacaksan korunmak iyi olur.";

            if (Weather.UvIndex >= 3)
                return "UV orta seviyede. Öğlen saatlerinde dikkat etmek yeterli.";

            return "UV düşük. Güneş açısından rahat bir gün.";
        }
    }

    public string WindAdvice
    {
        get
        {
            if (Weather.WindSpeed >= 40)
                return "Rüzgar güçlü. Açık alanda dikkatli olmak iyi olur.";

            if (Weather.WindSpeed >= 25)
                return "Rüzgar hissedilir seviyede. İnce kıyafetler rahatsız edebilir.";

            if (Weather.WindSpeed >= 12)
                return "Hafif rüzgar var, hava daha serin hissedilebilir.";

            return "Rüzgar sakin görünüyor.";
        }
    }

    public string VisibilityAdvice
    {
        get
        {
            if (Weather.Visibility <= 0)
                return "Görüş bilgisi alınamadı.";

            if (Weather.Visibility <= 1.5)
                return "Görüş düşük. Araç kullanırken dikkatli olmak gerekir.";

            if (Weather.Visibility <= 5)
                return "Görüş orta seviyede. Sis veya pus etkili olabilir.";

            return "Görüş iyi görünüyor.";
        }
    }

    public string OutfitSuggestion
    {
        get
        {
            if (Weather.Temperature >= 32)
                return "Hafif kıyafetler, su ve güneşten korunma iyi olur.";

            if (Weather.Temperature >= 24)
                return "İnce ve rahat kıyafetler uygun görünüyor.";

            if (Weather.Temperature >= 15)
                return "Hafif bir üst almak iyi olabilir.";

            if (Weather.Temperature >= 8)
                return "Mont veya kalın bir üst iyi olur.";

            return "Soğuk olabilir. Kalın giyinmek mantıklı.";
        }
    }

    public string DayPlanSuggestion
    {
        get
        {
            if (Weather.PrecipitationProbability >= 60)
                return "Açık hava planlarını kısa tutmak daha iyi olabilir.";

            if (Weather.WindSpeed >= 35)
                return "Rüzgarlı alanlarda uzun süre kalmamaya dikkat et.";

            if (Weather.UvIndex >= 7)
                return "Öğlen saatlerinde gölge veya kapalı alan daha iyi olur.";

            if (Weather.Temperature >= 30)
                return "Dışarı planlarını sabah veya akşam saatlerine almak daha rahat olur.";

            return "Günlük planlar için hava genel olarak uygun görünüyor.";
        }
    }

    public string WeeklyHighlightText
    {
        get
        {
            var hottest = Weather.DailyForecasts
                .OrderByDescending(x => x.MaxTemperature)
                .FirstOrDefault();

            if (hottest == null)
                return "Haftalık veri bulunamadı.";

            return $"Haftanın en sıcak günü: {hottest.DayText}, {hottest.MaxTemperatureText}.";
        }
    }

    public string WeeklyColdText
    {
        get
        {
            var coldest = Weather.DailyForecasts
                .OrderBy(x => x.MinTemperature)
                .FirstOrDefault();

            if (coldest == null)
                return "Haftalık veri bulunamadı.";

            return $"En serin zaman: {coldest.DayText}, {coldest.MinTemperatureText}.";
        }
    }

    private int ExtractComfortScore()
    {
        string value = ComfortScoreText.Replace("/100", "").Trim();

        return int.TryParse(value, out int score)
            ? score
            : 0;
    }
}
