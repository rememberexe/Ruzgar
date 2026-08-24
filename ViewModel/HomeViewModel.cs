using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Graphics;
using Ruzgar.Models;
using Ruzgar.Services;

namespace Ruzgar.ViewModels;

public partial class HomeViewModel : ObservableObject
{
    private readonly WeatherService _weatherService = new();
    private readonly LocationService _locationService = new();
    private readonly CitySearchService _citySearchService = new();
    private readonly FavoriteCityService _favoriteCityService = new();
    private readonly SettingsService _settingsService = new();
    private readonly WeatherAlertService _weatherAlertService = new();
    private readonly SearchHistoryService _searchHistoryService = new();

    private AppSettings _settings = new();
    private CancellationTokenSource? _searchCancellation;

    private double _currentLatitude = 37.0000;
    private double _currentLongitude = 35.3213;
    private string _currentCity = "Adana";
    private string _currentCountry = "Türkiye";
    private string _currentAdminArea = "Adana";

    public AsyncRelayCommand RefreshCommand { get; }
    public AsyncRelayCommand SearchCommand { get; }
    public AsyncRelayCommand UseMyLocationCommand { get; }
    public AsyncRelayCommand<CitySearchResult> SelectCityCommand { get; }
    public AsyncRelayCommand<FavoriteCity> SelectFavoriteCityCommand { get; }

    public RelayCommand ToggleFavoriteCommand { get; }
    public RelayCommand ClearSearchHistoryCommand { get; }
    public RelayCommand<FavoriteCity> RemoveFavoriteCityCommand { get; }

    public ObservableCollection<CitySearchResult> CityResults { get; } = new();

    public ObservableCollection<FavoriteCity> FavoriteCities { get; } = new();
    public ObservableCollection<CitySearchResult> SearchHistoryCities { get; } = new();

    [ObservableProperty]
    private WeatherInfo weather = new()
    {
        City = "Yükleniyor",
        Temperature = 0,
        TemperatureText = "0°C",
        FeelsLike = 0,
        FeelsLikeText = "Hissedilen 0°C",
        Humidity = 0,
        WindSpeed = 0,
        Description = "Hazırlanıyor",
        Icon = "☁️",
        UpdatedText = "",
        MoodText = "Hava durumu bilgileri hazırlanıyor."
    };

    [ObservableProperty]
    private bool isLoading;

    [ObservableProperty]
    private bool isSearching;

    [ObservableProperty]
    private string searchText = "";

    [ObservableProperty]
    private string errorMessage = "";

    [ObservableProperty]
    private bool hasCityResults;

    [ObservableProperty]
    private bool hasFavoriteCities;

    [ObservableProperty]
    private bool isCurrentCityFavorite;

    [ObservableProperty]
    private string favoriteButtonText = "☆";

    [ObservableProperty]
    private string favoriteActionText = "Favoriye ekle";

    [ObservableProperty]
    private bool hasSearchHistory;

    [ObservableProperty]
    private bool showSearchHistory;

    public HomeViewModel()
    {
        _settings = _settingsService.LoadSettings();

        RefreshCommand = new AsyncRelayCommand(RefreshWeatherAsync, CanRunMainAction);
        SearchCommand = new AsyncRelayCommand(SearchCitiesAsync, CanSearch);
        UseMyLocationCommand = new AsyncRelayCommand(LoadWeatherFromCurrentLocationAsync, CanRunMainAction);
        SelectCityCommand = new AsyncRelayCommand<CitySearchResult>(SelectCityAsync);
        SelectFavoriteCityCommand = new AsyncRelayCommand<FavoriteCity>(SelectFavoriteCityAsync);

        ToggleFavoriteCommand = new RelayCommand(ToggleFavorite);
        RemoveFavoriteCityCommand = new RelayCommand<FavoriteCity>(RemoveFavoriteCity);
        ClearSearchHistoryCommand = new RelayCommand(ClearSearchHistory);

        LoadFavoritesFromStorage();
        LoadSearchHistoryFromStorage();

        if (_settings.UseCurrentLocationOnStartup)
            _ = LoadWeatherFromCurrentLocationAsync();
        else
            _ = LoadDefaultWeatherAsync();
    }

    private bool CanRunMainAction()
    {
        return !IsLoading && !IsSearching;
    }

    private bool CanSearch()
    {
        return !IsLoading &&
               !IsSearching &&
               !string.IsNullOrWhiteSpace(SearchText) &&
               SearchText.Trim().Length >= 2;
    }

    partial void OnIsLoadingChanged(bool value)
    {
        RefreshCommand.NotifyCanExecuteChanged();
        SearchCommand.NotifyCanExecuteChanged();
        UseMyLocationCommand.NotifyCanExecuteChanged();
    }

    partial void OnIsSearchingChanged(bool value)
    {
        RefreshCommand.NotifyCanExecuteChanged();
        SearchCommand.NotifyCanExecuteChanged();
        UseMyLocationCommand.NotifyCanExecuteChanged();
    }

    partial void OnSearchTextChanged(string value)
    {
        SearchCommand.NotifyCanExecuteChanged();

        if (string.IsNullOrWhiteSpace(value))
        {
            CityResults.Clear();
            HasCityResults = false;
            ShowSearchHistory = HasSearchHistory;
            return;
        }

        ShowSearchHistory = false;
    }

    public async Task ReloadAfterSettingsAsync()
    {
        try
        {
            _settings = _settingsService.LoadSettings();

            LoadFavoritesFromStorage();

            if (_settings.UseCurrentLocationOnStartup)
            {
                await RefreshWeatherAsync();
            }
            else
            {
                await LoadDefaultWeatherAsync();
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex);
        }
    }

    private void LoadFavoritesFromStorage()
    {
        FavoriteCities.Clear();

        var favorites = _favoriteCityService.LoadFavorites();

        foreach (var city in favorites)
            FavoriteCities.Add(city);

        UpdateFavoriteState();

        _ = LoadFavoriteWeatherSnapshotsAsync();
    }
    private void ToggleFavorite()
    {
        var existing = FavoriteCities.FirstOrDefault(IsSameCurrentCity);

        if (existing != null)
        {
            FavoriteCities.Remove(existing);
            SaveFavorites();
            return;
        }

        var favorite = new FavoriteCity
        {
            Name = _currentCity,
            Country = _currentCountry,
            AdminArea = _currentAdminArea,
            Latitude = _currentLatitude,
            Longitude = _currentLongitude,
            MiniIcon = Weather.Icon,
            MiniTemperatureText = Weather.TemperatureText,
            MiniDescription = Weather.Description,
            MiniUpdatedText = DateTime.Now.ToString("HH:mm"),
            HasMiniWeather = true
        };

        FavoriteCities.Add(favorite);
        SaveFavorites();

        _ = LoadFavoriteWeatherSnapshotAsync(favorite);
    }

    private async Task LoadFavoriteWeatherSnapshotsAsync()
    {
        try
        {
            if (FavoriteCities.Count == 0)
                return;

            var favorites = FavoriteCities.ToList();
            using var throttle = new SemaphoreSlim(3);

            var tasks = favorites.Select(async favorite =>
            {
                await throttle.WaitAsync();

                try
                {
                    await LoadFavoriteWeatherSnapshotAsync(favorite);
                }
                finally
                {
                    throttle.Release();
                }
            });

            await Task.WhenAll(tasks);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex);
        }
    }

    private async Task LoadFavoriteWeatherSnapshotAsync(FavoriteCity city)
    {
        try
        {
            city.IsMiniWeatherLoading = true;

            if (!city.HasMiniWeather)
            {
                city.MiniIcon = "⌁";
                city.MiniTemperatureText = "--°";
                city.MiniDescription = "Yükleniyor";
                city.MiniUpdatedText = "";
            }

            var result = await _weatherService.GetWeatherAsync(
                city.Latitude,
                city.Longitude,
                city.Name);

            result = PrepareWeatherForDisplay(result);

            city.MiniIcon = result.Icon;
            city.MiniTemperatureText = result.TemperatureText;
            city.MiniDescription = result.Description;
            city.MiniUpdatedText = DateTime.Now.ToString("HH:mm");
            city.HasMiniWeather = true;
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex);

            if (!city.HasMiniWeather)
            {
                city.MiniIcon = "⚠";
                city.MiniTemperatureText = "--";
                city.MiniDescription = "Alınamadı";
                city.MiniUpdatedText = "";
            }
        }
        finally
        {
            city.IsMiniWeatherLoading = false;
        }
    }
    private void SaveFavorites()
    {
        _favoriteCityService.SaveFavorites(FavoriteCities);
        UpdateFavoriteState();
    }

    private async Task LoadDefaultWeatherAsync()
    {
        try
        {
            IsLoading = true;
            ErrorMessage = "";

            CityResults.Clear();
            HasCityResults = false;
            ShowSearchHistory = false;
            SearchText = "";

            if (_settings.HasDefaultCity)
            {
                _currentLatitude = _settings.DefaultCityLatitude;
                _currentLongitude = _settings.DefaultCityLongitude;
                _currentCity = _settings.DefaultCityName;
                _currentCountry = _settings.DefaultCityCountry;
                _currentAdminArea = _settings.DefaultCityAdminArea;
            }
            else
            {
                _currentLatitude = 37.0000;
                _currentLongitude = 35.3213;
                _currentCity = "Adana";
                _currentCountry = "Türkiye";
                _currentAdminArea = "Adana";
            }

            var result = await _weatherService.GetWeatherAsync(
                _currentLatitude,
                _currentLongitude,
                _currentCity);

            Weather = PrepareWeatherForDisplay(result);

           // await CheckWeatherNotificationAsync();

            UpdateFavoriteState();
        }
        catch (Exception ex)
        {
            ErrorMessage = "Varsayılan şehir için hava durumu alınamadı.";
            System.Diagnostics.Debug.WriteLine(ex);
        }
        finally
        {
            IsLoading = false;
        }
    }

    public void ShowSearchHistoryIfAvailable()
    {
        if (HasCityResults)
            return;

        ShowSearchHistory = HasSearchHistory && string.IsNullOrWhiteSpace(SearchText);
    }

    private void LoadSearchHistoryFromStorage()
    {
        SearchHistoryCities.Clear();

        var history = _searchHistoryService.LoadHistory();

        foreach (var city in history)
            SearchHistoryCities.Add(city);

        HasSearchHistory = SearchHistoryCities.Count > 0;
        ShowSearchHistory = false;
    }

    private void AddSearchHistory(CitySearchResult city)
    {
        var existing = SearchHistoryCities.FirstOrDefault(x =>
            string.Equals(x.Name, city.Name, StringComparison.OrdinalIgnoreCase) &&
            Math.Abs(x.Latitude - city.Latitude) < 0.01 &&
            Math.Abs(x.Longitude - city.Longitude) < 0.01);

        if (existing != null)
            SearchHistoryCities.Remove(existing);

        var historyCity = new CitySearchResult
        {
            Name = city.Name,
            Country = city.Country,
            AdminArea = city.AdminArea,
            Latitude = city.Latitude,
            Longitude = city.Longitude
        };

        SearchHistoryCities.Insert(0, historyCity);

        while (SearchHistoryCities.Count > 8)
            SearchHistoryCities.RemoveAt(SearchHistoryCities.Count - 1);

        HasSearchHistory = SearchHistoryCities.Count > 0;
        ShowSearchHistory = false;

        _searchHistoryService.SaveHistory(SearchHistoryCities);
    }

    private void ClearSearchHistory()
    {
        SearchHistoryCities.Clear();

        HasSearchHistory = false;
        ShowSearchHistory = false;

        _searchHistoryService.ClearHistory();
    }
    private async Task LoadWeatherFromCurrentLocationAsync()
    {
        try
        {
            IsLoading = true;
            ErrorMessage = "";

            CityResults.Clear();
            HasCityResults = false;
            SearchText = "";

            var location = await _locationService.GetCurrentLocationAsync();

            _currentLatitude = location.Latitude;
            _currentLongitude = location.Longitude;
            _currentCity = location.City;
            _currentCountry = location.Country;
            _currentAdminArea = location.AdminArea;

            var result = await _weatherService.GetWeatherAsync(
                _currentLatitude,
                _currentLongitude,
                _currentCity);

            Weather = PrepareWeatherForDisplay(result);

            //await CheckWeatherNotificationAsync();

            UpdateFavoriteState();
        }
        catch (Exception ex)
        {
            ErrorMessage = "Konumdan hava durumu alınamadı.";
            System.Diagnostics.Debug.WriteLine(ex);
        }
        finally
        {
            IsLoading = false;
        }
    }

    private async Task RefreshWeatherAsync()
    {
        try
        {
            IsLoading = true;
            ErrorMessage = "";

            var result = await _weatherService.GetWeatherAsync(
                _currentLatitude,
                _currentLongitude,
                _currentCity);

            Weather = PrepareWeatherForDisplay(result);

//            await CheckWeatherNotificationAsync();

            UpdateFavoriteState();
        }
        catch (Exception ex)
        {
            ErrorMessage = "Hava durumu alınamadı. Tekrar deneyin.";
            System.Diagnostics.Debug.WriteLine(ex);
        }
        finally
        {
            IsLoading = false;
        }
    }

    private async Task SearchCitiesAsync()
    {
        string query = SearchText.Trim();

        _searchCancellation?.Cancel();
        _searchCancellation?.Dispose();
        _searchCancellation = new CancellationTokenSource();
        var token = _searchCancellation.Token;

        try
        {
            IsSearching = true;
            ErrorMessage = "";

            CityResults.Clear();
            HasCityResults = false;

            var results = await _citySearchService.SearchCitiesAsync(query, token);

            if (token.IsCancellationRequested || !string.Equals(SearchText.Trim(), query, StringComparison.Ordinal))
                return;

            foreach (var city in results)
                CityResults.Add(city);

            HasCityResults = CityResults.Count > 0;

            if (!HasCityResults)
                ErrorMessage = "Şehir bulunamadı.";
        }
        catch (Exception ex)
        {
            if (ex is OperationCanceledException)
                return;

            ErrorMessage = "Şehir araması yapılamadı.";
            System.Diagnostics.Debug.WriteLine(ex);
        }
        finally
        {
            if (!token.IsCancellationRequested)
                IsSearching = false;
        }
    }

    private async Task SelectCityAsync(CitySearchResult? city)
    {
        if (city == null)
            return;

        try
        {
            IsLoading = true;
            ErrorMessage = "";

            _currentLatitude = city.Latitude;
            _currentLongitude = city.Longitude;
            _currentCity = city.Name;
            _currentCountry = city.Country;
            _currentAdminArea = city.AdminArea;

            SearchText = city.DisplayName;

            CityResults.Clear();
            HasCityResults = false;

            var result = await _weatherService.GetWeatherAsync(
                _currentLatitude,
                _currentLongitude,
                _currentCity);

            Weather = PrepareWeatherForDisplay(result);
            AddSearchHistory(city);
            //await CheckWeatherNotificationAsync();

            UpdateFavoriteState();
        }
        catch (Exception ex)
        {
            ErrorMessage = "Seçilen şehir için hava durumu alınamadı.";
            System.Diagnostics.Debug.WriteLine(ex);
        }
        finally
        {
            IsLoading = false;
        }
    }

    private async Task SelectFavoriteCityAsync(FavoriteCity? city)
    {
        if (city == null)
            return;

        try
        {
            IsLoading = true;
            ErrorMessage = "";

            _currentLatitude = city.Latitude;
            _currentLongitude = city.Longitude;
            _currentCity = city.Name;
            _currentCountry = city.Country;
            _currentAdminArea = city.AdminArea;

            SearchText = city.DisplayName;

            CityResults.Clear();
            HasCityResults = false;

            var result = await _weatherService.GetWeatherAsync(
                _currentLatitude,
                _currentLongitude,
                _currentCity);

            Weather = PrepareWeatherForDisplay(result);

            //await CheckWeatherNotificationAsync();

            UpdateFavoriteState();
        }
        catch (Exception ex)
        {
            ErrorMessage = "Favori şehir için hava durumu alınamadı.";
            System.Diagnostics.Debug.WriteLine(ex);
        }
        finally
        {
            IsLoading = false;
        }
    }

   

    private void RemoveFavoriteCity(FavoriteCity? city)
    {
        if (city == null)
            return;

        FavoriteCities.Remove(city);
        SaveFavorites();
    }

    private WeatherInfo PrepareWeatherForDisplay(WeatherInfo weather)
    {
        if (_settings.UseFahrenheit)
        {
            weather.Temperature = ConvertCelsiusToFahrenheit(weather.Temperature);
            weather.FeelsLike = ConvertCelsiusToFahrenheit(weather.FeelsLike);

            weather.TemperatureText = $"{weather.Temperature:0}°F";
            weather.FeelsLikeText = $"Hissedilen {weather.FeelsLike:0}°F";

            foreach (var hour in weather.HourlyForecasts)
            {
                hour.Temperature = ConvertCelsiusToFahrenheit(hour.Temperature);
                hour.TemperatureText = $"{hour.Temperature:0}°F";
            }

            foreach (var day in weather.DailyForecasts)
            {
                day.MaxTemperature = ConvertCelsiusToFahrenheit(day.MaxTemperature);
                day.MinTemperature = ConvertCelsiusToFahrenheit(day.MinTemperature);

                day.MaxTemperatureText = $"{day.MaxTemperature:0}°F";
                day.MinTemperatureText = $"{day.MinTemperature:0}°F";
            }
        }
        else
        {
            weather.Temperature = Math.Round(weather.Temperature, 0);
            weather.FeelsLike = Math.Round(weather.FeelsLike, 0);

            weather.TemperatureText = $"{weather.Temperature:0}°C";
            weather.FeelsLikeText = $"Hissedilen {weather.FeelsLike:0}°C";

            foreach (var hour in weather.HourlyForecasts)
            {
                hour.Temperature = Math.Round(hour.Temperature, 0);
                hour.TemperatureText = $"{hour.Temperature:0}°C";
            }

            foreach (var day in weather.DailyForecasts)
            {
                day.MaxTemperature = Math.Round(day.MaxTemperature, 0);
                day.MinTemperature = Math.Round(day.MinTemperature, 0);

                day.MaxTemperatureText = $"{day.MaxTemperature:0}°C";
                day.MinTemperatureText = $"{day.MinTemperature:0}°C";
            }
        }

        if (!_settings.UseDynamicTheme)
        {
            ApplyStaticTheme(weather);
        }

        return weather;
    }

    private async Task CheckWeatherNotificationAsync()
    {
        try
        {
            if (!_settings.EnableWeatherNotifications)
                return;

            var alert = _weatherAlertService.CreateAlert(Weather);

            if (alert == null)
                return;

            if (!_weatherAlertService.CanSendAlert(alert, Weather.City))
                return;

            var service = Microsoft.Maui.Controls.Application.Current?
                .Handler?
                .MauiContext?
                .Services
                .GetService<INotificationManagerService>();

            if (service == null)
                return;

            bool allowed = await service.RequestPermissionAsync();

            if (!allowed)
                return;

            service.SendNotification(alert.Title, alert.Message);

            _weatherAlertService.MarkAlertAsSent(alert, Weather.City);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex);
        }
    }

    private static double ConvertCelsiusToFahrenheit(double celsius)
    {
        return Math.Round((celsius * 9 / 5) + 32, 0);
    }

    private static void ApplyStaticTheme(WeatherInfo weather)
    {
        weather.BackgroundStartColor = Color.FromArgb("#0F172A");
        weather.BackgroundMiddleColor = Color.FromArgb("#111827");
        weather.BackgroundEndColor = Color.FromArgb("#020617");

        weather.CardStartColor = Color.FromArgb("#1E293B");
        weather.CardEndColor = Color.FromArgb("#020617");

        weather.AccentColor = Color.FromArgb("#60A5FA");
    }

    private void UpdateFavoriteState()
    {
        HasFavoriteCities = FavoriteCities.Count > 0;

        IsCurrentCityFavorite = FavoriteCities.Any(IsSameCurrentCity);

        FavoriteButtonText = IsCurrentCityFavorite ? "★" : "☆";
        FavoriteActionText = IsCurrentCityFavorite ? "Favoriden çıkar" : "Favoriye ekle";
    }

    private bool IsSameCurrentCity(FavoriteCity city)
    {
        const double tolerance = 0.01;

        bool sameCoordinates =
            Math.Abs(city.Latitude - _currentLatitude) < tolerance &&
            Math.Abs(city.Longitude - _currentLongitude) < tolerance;

        bool sameName =
            string.Equals(city.Name, _currentCity, StringComparison.OrdinalIgnoreCase);

        return sameCoordinates || sameName;
    }
}
