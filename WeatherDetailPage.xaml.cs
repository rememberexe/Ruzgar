using Microsoft.Maui.Graphics;
using Ruzgar.Models;
using Ruzgar.ViewModels;

namespace Ruzgar;

public partial class WeatherDetailPage : ContentPage
{
    private bool _animationPlayed;

    public WeatherDetailPage()
        : this(null)
    {
    }

    public WeatherDetailPage(WeatherInfo? weather)
    {
        InitializeComponent();

        BindingContext = new WeatherDetailViewModel(weather ?? CreateFallbackWeather());
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (_animationPlayed)
            return;

        _animationPlayed = true;

        try
        {
            await Task.Delay(80);

            await Task.WhenAll(
                DetailRoot.FadeToAsync(1, 360, Easing.CubicOut),
                DetailRoot.TranslateToAsync(0, 0, 360, Easing.CubicOut)
            );
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex);
        }
    }

    private async void BackButton_Tapped(object? sender, TappedEventArgs e)
    {
        try
        {
            await BackButton.ScaleToAsync(0.86, 80, Easing.CubicOut);
            await BackButton.ScaleToAsync(1, 140, Easing.SpringOut);

            if (Shell.Current?.Navigation?.NavigationStack?.Count > 1)
            {
                await Task.WhenAll(
                    DetailRoot.FadeToAsync(0, 180, Easing.CubicIn),
                    DetailRoot.TranslateToAsync(0, 18, 180, Easing.CubicIn)
                );

                await Shell.Current.Navigation.PopAsync(true);
                return;
            }

            if (Shell.Current != null)
                await Shell.Current.GoToAsync("//MainPage", true);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex);
        }
    }

    private static WeatherInfo CreateFallbackWeather()
    {
        return new WeatherInfo
        {
            City = "Rüzgar",
            TemperatureText = "--°",
            FeelsLikeText = "Hissedilen --°",
            Description = "Bilgi yok",
            Icon = "☁️",
            UpdatedText = "",
            MoodText = "Hava detayı bulunamadı.",
            BackgroundStartColor = Color.FromArgb("#0F172A"),
            BackgroundMiddleColor = Color.FromArgb("#111827"),
            BackgroundEndColor = Color.FromArgb("#020617"),
            CardStartColor = Color.FromArgb("#1E293B"),
            CardEndColor = Color.FromArgb("#020617"),
            AccentColor = Color.FromArgb("#60A5FA")
        };
    }
}
