using System.Text.Json;
using Microsoft.Maui.Storage;
using Ruzgar.Models;

namespace Ruzgar.Services;

public class FavoriteCityService
{
    private const string FavoritesKey = "ruzgar_favorite_cities";

    public List<FavoriteCity> LoadFavorites()
    {
        try
        {
            string json = Preferences.Default.Get(FavoritesKey, "");

            if (string.IsNullOrWhiteSpace(json))
                return new List<FavoriteCity>();

            return JsonSerializer.Deserialize<List<FavoriteCity>>(json) ?? new List<FavoriteCity>();
        }
        catch
        {
            return new List<FavoriteCity>();
        }
    }

    public void SaveFavorites(IEnumerable<FavoriteCity> favorites)
    {
        try
        {
            string json = JsonSerializer.Serialize(favorites);
            Preferences.Default.Set(FavoritesKey, json);
        }
        catch
        {
            // Kayıt sırasında hata olursa uygulamayı çökertme.
        }
    }

    public void ClearFavorites()
    {
        try
        {
            Preferences.Default.Remove(FavoritesKey);
        }
        catch
        {
            // Temizleme sırasında hata olursa uygulamayı çökertme.
        }
    }
}