using Microsoft.Maui.Storage;


namespace Ruzgar;

public partial class SplashIntroPage : ContentPage
{
    private bool _started;

    public SplashIntroPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (_started)
            return;

        _started = true;

        await PlayIntroAsync();
    }

    private async Task PlayIntroAsync()
    {
        try
        {
            SplashContent.Opacity = 0;
            SplashContent.TranslationY = 34;
            SplashContent.Scale = 0.94;

            LogoCard.Scale = 0.82;
            LogoGlow.Scale = 0.76;
            LogoIcon.Opacity = 0;

            ProgressFill.WidthRequest = 0;

            await Task.Delay(180);

            await Task.WhenAll(
                SplashContent.FadeToAsync(1, 480, Easing.CubicOut),
                SplashContent.TranslateToAsync(0, 0, 480, Easing.CubicOut),
                SplashContent.ScaleToAsync(1, 480, Easing.SpringOut),
                LogoGlow.ScaleToAsync(1.08, 620, Easing.SpringOut),
                LogoCard.ScaleToAsync(1, 620, Easing.SpringOut)
            );

            await Task.WhenAll(
                LogoIcon.FadeToAsync(1, 260, Easing.CubicOut),
                LogoIcon.RotateToAsync(8, 220, Easing.CubicOut)
            );

            await LogoIcon.RotateToAsync(0, 160, Easing.CubicOut);

            await Task.WhenAll(
                AnimateWidthAsync(ProgressFill, 210, 850, Easing.CubicInOut),
                LogoGlow.ScaleToAsync(1.18, 850, Easing.CubicInOut)
            );

            await Task.Delay(250);

            await Task.WhenAll(
                SplashContent.FadeToAsync(0, 280, Easing.CubicIn),
                SplashContent.TranslateToAsync(0, -22, 280, Easing.CubicIn),
                SplashContent.ScaleToAsync(0.98, 280, Easing.CubicIn)
            );

            await GoToMainPageSafeAsync();
        }
        catch
        {
            await GoToMainPageSafeAsync();
        }
    }
    private static async Task GoNextAfterSplashAsync()
    {
        try
        {
            bool onboardingSeen = Preferences.Default.Get("Ruzgar_OnboardingSeen", false);

            string targetRoute = onboardingSeen
                ? "//MainPage"
                : "//OnboardingPage";

            await Shell.Current.GoToAsync(targetRoute, false);
        }
        catch
        {
            try
            {
                bool onboardingSeen = Preferences.Default.Get("Ruzgar_OnboardingSeen", false);

                var app = Microsoft.Maui.Controls.Application.Current;

                if (app?.Windows.Count > 0)
                {
                    app.Windows[0].Page = onboardingSeen
                        ? new MainPage()
                        : new OnboardingPage();
                }
            }
            catch
            {
            }
        }
    }
    private static async Task GoToMainPageSafeAsync()
    {
        try
        {
            if (Shell.Current is not null)
            {
                await GoNextAfterSplashAsync();
                return;
            }
        }
        catch
        {
        }

        try
        {
            var app = Microsoft.Maui.Controls.Application.Current;

            if (app?.Windows.Count > 0)
            {
                app.Windows[0].Page = new MainPage();
            }
        }
        catch
        {
        }
    }

    private static Task<bool> AnimateWidthAsync(
        VisualElement view,
        double targetWidth,
        uint length,
        Easing easing)
    {
        var taskCompletionSource = new TaskCompletionSource<bool>();

        double startWidth = view.WidthRequest;

        var animation = new Animation(
            callback: value => view.WidthRequest = value,
            start: startWidth,
            end: targetWidth,
            easing: easing);

        animation.Commit(
            owner: view,
            name: "WidthAnimation",
            rate: 16,
            length: length,
            finished: (_, cancelled) =>
            {
                taskCompletionSource.SetResult(!cancelled);
            });

        return taskCompletionSource.Task;
    }

    protected override bool OnBackButtonPressed()
    {
        return true;
    }
}