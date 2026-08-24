#if ANDROID

using Android.App;
using Android.Content.PM;
using Android.Content.Res;
using Android.OS;
using Android.Views;

namespace Ruzgar;

[Activity(
    Theme = "@style/Maui.SplashTheme",
    MainLauncher = true,
    LaunchMode = LaunchMode.SingleTop,
    ConfigurationChanges =
        ConfigChanges.ScreenSize |
        ConfigChanges.Orientation |
        ConfigChanges.UiMode |
        ConfigChanges.ScreenLayout |
        ConfigChanges.SmallestScreenSize |
        ConfigChanges.Density)]
public class MainActivity : Microsoft.Maui.MauiAppCompatActivity
{
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        SetSystemBarsByPhoneTheme();
    }

    protected override void OnResume()
    {
        base.OnResume();

        SetSystemBarsByPhoneTheme();
    }

    public override void OnConfigurationChanged(Configuration newConfig)
    {
        base.OnConfigurationChanged(newConfig);

        SetSystemBarsByPhoneTheme();
    }

    private void SetSystemBarsByPhoneTheme()
    {
        try
        {
            if (Window is null)
                return;

            bool isDarkMode = IsPhoneDarkMode();

            string statusColor = isDarkMode ? "#020617" : "#F8FAFC";
            string navigationColor = isDarkMode ? "#020617" : "#F8FAFC";

            if (!OperatingSystem.IsAndroidVersionAtLeast(35))
            {
                Window.SetStatusBarColor(Android.Graphics.Color.ParseColor(statusColor));
                Window.SetNavigationBarColor(Android.Graphics.Color.ParseColor(navigationColor));
            }

            if (OperatingSystem.IsAndroidVersionAtLeast(30))
            {
                var appearance = isDarkMode
                    ? 0
                    : (int)(WindowInsetsControllerAppearance.LightStatusBars |
                            WindowInsetsControllerAppearance.LightNavigationBars);

                Window.InsetsController?.SetSystemBarsAppearance(
                    appearance,
                    (int)(WindowInsetsControllerAppearance.LightStatusBars |
                          WindowInsetsControllerAppearance.LightNavigationBars));

                return;
            }

            var flags = (SystemUiFlags)0;

            if (!isDarkMode && Build.VERSION.SdkInt >= BuildVersionCodes.M)
                flags |= SystemUiFlags.LightStatusBar;

            if (!isDarkMode && OperatingSystem.IsAndroidVersionAtLeast(26))
                flags |= SystemUiFlags.LightNavigationBar;

            Window.DecorView.SystemUiFlags = flags;
        }
        catch
        {
            // Sistem bar rengi yüzünden uygulama çökmesin.
        }
    }

    private bool IsPhoneDarkMode()
    {
        try
        {
            var uiMode = Resources?.Configuration?.UiMode ?? UiMode.TypeUndefined;

            return (uiMode & UiMode.NightMask) == UiMode.NightYes;
        }
        catch
        {
            return true;
        }
    }
}

#endif
