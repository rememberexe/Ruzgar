using System.Text.Json;
using Microsoft.Maui.Storage;
using Ruzgar.Models;

namespace Ruzgar.Services;

public class SettingsService
{
    private const string SettingsKey = "ruzgar_app_settings";

    public AppSettings LoadSettings()
    {
        try
        {
            string json = Preferences.Default.Get(SettingsKey, "");

            if (string.IsNullOrWhiteSpace(json))
                return new AppSettings();

            return JsonSerializer.Deserialize<AppSettings>(json) ?? new AppSettings();
        }
        catch
        {
            return new AppSettings();
        }
    }

    public void SaveSettings(AppSettings settings)
    {
        try
        {
            string json = JsonSerializer.Serialize(settings);
            Preferences.Default.Set(SettingsKey, json);
        }
        catch
        {
            // Ayar kaydedilemezse uygulamayı çökertme.
        }
    }

    public void ResetSettings()
    {
        try
        {
            Preferences.Default.Remove(SettingsKey);
        }
        catch
        {
            // Sıfırlama sırasında hata olursa uygulamayı çökertme.
        }
    }
}