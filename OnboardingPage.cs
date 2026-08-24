using Microsoft.Maui.Storage;

namespace Ruzgar;

public partial class OnboardingPage : ContentPage
{
    private const string OnboardingSeenKey = "Ruzgar_OnboardingSeen";

    private int _index;
    private bool _isAnimating;

    private readonly int[] _weatherCodes =
    {
        2,
        1,
        95,
        61
    };

    private readonly Color[] _accentColors =
    {
        Color.FromArgb("#60A5FA"),
        Color.FromArgb("#FBBF24"),
        Color.FromArgb("#C084FC"),
        Color.FromArgb("#38BDF8")
    };

    private readonly string[] _titles =
    {
        "Canlı hava durumu",
        "Favori şehirler",
        "Günlük analiz",
        "Saatlik ve haftalık tahmin"
    };

    private readonly string[] _descriptions =
    {
        "Seçtiğin şehir için anlık hava durumunu, saatlik akışı ve haftalık tahmini tek ekranda gör.",
        "Favori şehirlerini mini hava kartlarıyla takip et. Sıcaklık, ikon ve durum bilgisi hızlıca yanında olsun.",
        "Detay sayfasında şemsiye, kıyafet, UV, rüzgar ve gün planı önerilerini sade şekilde gör.",
        "12 saatlik akışı ve 7 günlük görünümü takip ederek gününü daha rahat planla."
    };

    public OnboardingPage()
    {
        InitializeComponent();

        UpdateSlide(false);
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        try
        {
            OnboardingContent.Opacity = 0;
            OnboardingContent.TranslationY = 24;
            OnboardingContent.Scale = 0.96;

            await Task.Delay(100);

            await Task.WhenAll(
                OnboardingContent.FadeToAsync(1, 360, Easing.CubicOut),
                OnboardingContent.TranslateToAsync(0, 0, 360, Easing.CubicOut),
                OnboardingContent.ScaleToAsync(1, 360, Easing.SpringOut)
            );
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex);
        }
    }

    private async void NextButton_Tapped(object? sender, TappedEventArgs e)
    {
        if (_isAnimating)
            return;

        try
        {
            _isAnimating = true;

            await Task.WhenAll(
                NextButton.ScaleToAsync(0.96, 80, Easing.CubicOut),
                NextButton.FadeToAsync(0.84, 80, Easing.CubicOut)
            );

            await Task.WhenAll(
                NextButton.ScaleToAsync(1, 150, Easing.SpringOut),
                NextButton.FadeToAsync(1, 120, Easing.CubicOut)
            );

            if (_index >= _titles.Length - 1)
            {
                await FinishOnboardingAsync();
                return;
            }

            _index++;
            await ChangeSlideAsync();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex);
        }
        finally
        {
            NextButton.Scale = 1;
            NextButton.Opacity = 1;
            _isAnimating = false;
        }
    }

    private async void SkipButton_Tapped(object? sender, TappedEventArgs e)
    {
        if (_isAnimating)
            return;

        await FinishOnboardingAsync();
    }

    private async Task ChangeSlideAsync()
    {
        try
        {
            await Task.WhenAll(
                OnboardingContent.FadeToAsync(0, 160, Easing.CubicIn),
                OnboardingContent.TranslateToAsync(-18, 0, 160, Easing.CubicIn),
                OnboardingContent.ScaleToAsync(0.98, 160, Easing.CubicIn)
            );

            OnboardingContent.TranslationX = 22;

            UpdateSlide(true);

            await Task.WhenAll(
                OnboardingContent.FadeToAsync(1, 260, Easing.CubicOut),
                OnboardingContent.TranslateToAsync(0, 0, 260, Easing.CubicOut),
                OnboardingContent.ScaleToAsync(1, 260, Easing.SpringOut)
            );
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex);
            UpdateSlide(false);
        }
    }

    private void UpdateSlide(bool animateDots)
    {
        IconBadge.WeatherCode = _weatherCodes[_index];
        IconBadge.AccentColor = _accentColors[_index];
        TitleLabel.Text = _titles[_index];
        DescriptionLabel.Text = _descriptions[_index];

        NextButtonText.Text = _index == _titles.Length - 1
            ? "Rüzgar'ı kullanmaya başla"
            : "Devam";

        SetDot(Dot1, _index == 0);
        SetDot(Dot2, _index == 1);
        SetDot(Dot3, _index == 2);
        SetDot(Dot4, _index == 3);
    }

    private static void SetDot(Border dot, bool active)
    {
        dot.WidthRequest = active ? 24 : 7;
        dot.BackgroundColor = active
            ? Colors.White
            : Color.FromArgb("#55FFFFFF");
    }

    private async Task FinishOnboardingAsync()
    {
        try
        {
            Preferences.Default.Set(OnboardingSeenKey, true);

            await Task.WhenAll(
                OnboardingContent.FadeToAsync(0, 220, Easing.CubicIn),
                OnboardingContent.TranslateToAsync(0, -18, 220, Easing.CubicIn),
                OnboardingContent.ScaleToAsync(0.98, 220, Easing.CubicIn)
            );

            await Shell.Current.GoToAsync("//MainPage", false);
        }
        catch
        {
            try
            {
                Microsoft.Maui.Controls.Application.Current!.Windows[0].Page = new MainPage();
            }
            catch
            {
            }
        }
    }

    protected override bool OnBackButtonPressed()
    {
        return true;
    }
}
