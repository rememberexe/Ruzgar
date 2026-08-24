using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Devices;
using Microsoft.Maui.Storage;

namespace Ruzgar;

public partial class AboutPage : ContentPage
{
    private bool _animationPlayed;
    private bool _isShowOnboardingAnimating;

    public AboutPage()
    {
        InitializeComponent();

        BindingContext = new AboutPageInfo();
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
                AboutRoot.FadeToAsync(1, 360, Easing.CubicOut),
                AboutRoot.TranslateToAsync(0, 0, 360, Easing.CubicOut)
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
                    AboutRoot.FadeToAsync(0, 180, Easing.CubicIn),
                    AboutRoot.TranslateToAsync(0, 18, 180, Easing.CubicIn)
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

    private async void ShowOnboardingButton_Tapped(object? sender, TappedEventArgs e)
    {
        if (_isShowOnboardingAnimating)
            return;

        try
        {
            _isShowOnboardingAnimating = true;

            await Task.WhenAll(
                ShowOnboardingButton.ScaleToAsync(0.96, 90, Easing.CubicOut),
                ShowOnboardingButton.FadeToAsync(0.82, 90, Easing.CubicOut)
            );

            await Task.WhenAll(
                ShowOnboardingButton.ScaleToAsync(1.02, 160, Easing.SpringOut),
                ShowOnboardingButton.FadeToAsync(1, 130, Easing.CubicOut)
            );

            await ShowOnboardingButton.ScaleToAsync(1, 80, Easing.CubicOut);

            Preferences.Default.Set("Ruzgar_OnboardingSeen", false);

            await Shell.Current.GoToAsync("//OnboardingPage", true);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex);
        }
        finally
        {
            ShowOnboardingButton.Scale = 1;
            ShowOnboardingButton.Opacity = 1;
            _isShowOnboardingAnimating = false;
        }
    }

    protected override bool OnBackButtonPressed()
    {
        _ = Shell.Current.GoToAsync("//MainPage", true);
        return true;
    }
}

public class AboutPageInfo
{
    public string AppName => AppInfo.Current.Name;

    public string VersionText => $"Sürüm {AppInfo.Current.VersionString}";

    public string PlatformText => $"{DeviceInfo.Platform} {DeviceInfo.VersionString}";
}
