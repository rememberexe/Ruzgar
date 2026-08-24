using System.Collections.ObjectModel;
using Microsoft.Extensions.DependencyInjection;
using Ruzgar.Models;
using Ruzgar.Services;

namespace Ruzgar;

public partial class SettingsPage : ContentPage
{
    private readonly SettingsService _settingsService = new();
    private readonly FavoriteCityService _favoriteCityService = new();
    private readonly CitySearchService _citySearchService = new();

    private AppSettings _settings = new();
    private bool _isBackAnimating;
    private bool _isLoadingSettings;

    public ObservableCollection<CitySearchResult> DefaultCityResults { get; } = new();

    public SettingsPage()
    {
        InitializeComponent();

        BindingContext = this;

        LoadSettingsToUi();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        try
        {
            SettingsScroll.Opacity = 0;
            SettingsScroll.TranslationY = 34;
            SettingsScroll.Scale = 0.98;

            await Task.Delay(80);

            await Task.WhenAll(
                SettingsScroll.FadeToAsync(1, 360, Easing.CubicOut),
                SettingsScroll.TranslateToAsync(0, 0, 420, Easing.CubicOut),
                SettingsScroll.ScaleToAsync(1, 420, Easing.SpringOut)
            );
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex);
        }
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        SaveSettings();
    }

    private void LoadSettingsToUi()
    {
        try
        {
            _isLoadingSettings = true;

            _settings = _settingsService.LoadSettings();

            FahrenheitSwitch.IsToggled = _settings.UseFahrenheit;
            UseLocationSwitch.IsToggled = _settings.UseCurrentLocationOnStartup;
            DynamicThemeSwitch.IsToggled = _settings.UseDynamicTheme;
           // NotificationSwitch.IsToggled = _settings.EnableWeatherNotifications;

            DefaultCityLabel.Text = _settings.DefaultCityDisplayName;

            DefaultCityResults.Clear();
            DefaultCityResultsPanel.IsVisible = false;
            DefaultCityStatusLabel.Text = "";
        }
        finally
        {
            _isLoadingSettings = false;
        }
    }

    private void SaveSettings()
    {
        _settingsService.SaveSettings(_settings);
    }

    private async void BackButton_Tapped(object? sender, TappedEventArgs e)
    {
        if (_isBackAnimating)
            return;

        try
        {
            _isBackAnimating = true;

            SaveSettings();

            await Task.WhenAll(
                SettingsScroll.FadeToAsync(0, 220, Easing.CubicIn),
                SettingsScroll.TranslateToAsync(0, 28, 220, Easing.CubicIn),
                SettingsScroll.ScaleToAsync(0.98, 220, Easing.CubicIn)
            );

            await Shell.Current.GoToAsync("..", true);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex);
        }
        finally
        {
            _isBackAnimating = false;
        }
    }

    private void FahrenheitSwitch_Toggled(object? sender, ToggledEventArgs e)
    {
        if (_isLoadingSettings)
            return;

        _settings.UseFahrenheit = e.Value;
        SaveSettings();
    }

    private void UseLocationSwitch_Toggled(object? sender, ToggledEventArgs e)
    {
        if (_isLoadingSettings)
            return;

        _settings.UseCurrentLocationOnStartup = e.Value;
        SaveSettings();
    }

    private void DynamicThemeSwitch_Toggled(object? sender, ToggledEventArgs e)
    {
        if (_isLoadingSettings)
            return;

        _settings.UseDynamicTheme = e.Value;
        SaveSettings();
    }

    private async void NotificationSwitch_Toggled(object? sender, ToggledEventArgs e)
    {
        if (_isLoadingSettings)
            return;

        _settings.EnableWeatherNotifications = e.Value;
        SaveSettings();

        if (!e.Value)
            return;

        var service = Microsoft.Maui.Controls.Application.Current?
            .Handler?
            .MauiContext?
            .Services
            .GetService<INotificationManagerService>();

        
    }

    private async void DefaultCitySearchEntry_Completed(object? sender, EventArgs e)
    {
        await SearchDefaultCityAsync();
    }

    private async void SearchDefaultCity_Tapped(object? sender, TappedEventArgs e)
    {
        await SearchDefaultCityAsync();
    }

    private async Task SearchDefaultCityAsync()
    {
        try
        {
            string query = DefaultCitySearchEntry.Text?.Trim() ?? "";

            DefaultCityResults.Clear();
            DefaultCityResultsPanel.IsVisible = false;
            DefaultCityStatusLabel.Text = "";

            if (query.Length < 2)
            {
                DefaultCityStatusLabel.Text = "Şehir aramak için en az 2 harf yaz.";
                return;
            }

            DefaultCityStatusLabel.Text = "Şehirler aranıyor...";

            var results = await _citySearchService.SearchCitiesAsync(query);

            foreach (var city in results)
                DefaultCityResults.Add(city);

            DefaultCityResultsPanel.IsVisible = DefaultCityResults.Count > 0;

            DefaultCityStatusLabel.Text = DefaultCityResults.Count > 0
                ? "Varsayılan yapmak istediğin şehri seç."
                : "Şehir bulunamadı.";
        }
        catch (Exception ex)
        {
            DefaultCityStatusLabel.Text = "Şehir araması yapılamadı.";
            System.Diagnostics.Debug.WriteLine(ex);
        }
    }

    private async void DefaultCityResult_Tapped(object? sender, TappedEventArgs e)
    {
        if (sender is not Element element)
            return;

        if (element.BindingContext is not CitySearchResult city)
            return;

        _settings.HasDefaultCity = true;
        _settings.DefaultCityName = city.Name;
        _settings.DefaultCityCountry = city.Country;
        _settings.DefaultCityAdminArea = city.AdminArea;
        _settings.DefaultCityLatitude = city.Latitude;
        _settings.DefaultCityLongitude = city.Longitude;

        SaveSettings();

        DefaultCityLabel.Text = _settings.DefaultCityDisplayName;

        DefaultCitySearchEntry.Text = "";
        DefaultCityResults.Clear();
        DefaultCityResultsPanel.IsVisible = false;

        DefaultCityStatusLabel.Text = $"{city.DisplayName} varsayılan şehir yapıldı.";

        await DefaultCityLabel.ScaleToAsync(1.06, 120, Easing.SpringOut);
        await DefaultCityLabel.ScaleToAsync(1, 100, Easing.CubicOut);
    }

    private async void ClearFavorites_Tapped(object? sender, TappedEventArgs e)
    {
        bool confirm = await DisplayAlertAsync(
            "Favorileri temizle",
            "Tüm favori şehirler silinsin mi?",
            "Evet, temizle",
            "Vazgeç");

        if (!confirm)
            return;

        _favoriteCityService.ClearFavorites();

        await DisplayAlertAsync(
            "Tamamlandı",
            "Favori şehirler temizlendi. Ana ekrana döndüğünde liste yenilenecek.",
            "Tamam");
    }
}
