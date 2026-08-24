using Ruzgar.ViewModels;
using Ruzgar.Models;

namespace Ruzgar;

public partial class MainPage : ContentPage
{
    private bool _shouldReloadAfterSettings;
    private bool _animationPlayed;
    private bool _isRefreshAnimating;
    private bool _isFavoriteAnimating;
    private bool _isSettingsAnimating;
    private bool _isDetailAnimating;
    private bool _isFavoriteCardAnimating;
    private bool _isAboutAnimating;
    private bool _isCityResultAnimating;
    private bool _isSearchHistoryAnimating;
    public MainPage()
    {
        InitializeComponent();
        BindingContext = new HomeViewModel();
    }
    private void SearchEntry_Focused(object? sender, FocusEventArgs e)
    {
        if (BindingContext is HomeViewModel vm)
            vm.ShowSearchHistoryIfAvailable();
    }
    private async void SearchHistoryCard_Tapped(object? sender, TappedEventArgs e)
    {
        if (_isSearchHistoryAnimating)
            return;

        if (BindingContext is not HomeViewModel vm)
            return;

        if (e.Parameter is not CitySearchResult city)
            return;

        VisualElement? card = null;

        if (sender is Element element && element.Parent is VisualElement parent)
            card = parent;

        try
        {
            _isSearchHistoryAnimating = true;

            if (card != null)
            {
                await Task.WhenAll(
                    card.ScaleToAsync(0.965, 80, Easing.CubicOut),
                    card.FadeToAsync(0.82, 80, Easing.CubicOut)
                );

                await Task.WhenAll(
                    card.ScaleToAsync(1.02, 130, Easing.SpringOut),
                    card.FadeToAsync(1, 110, Easing.CubicOut)
                );

                await card.ScaleToAsync(1, 70, Easing.CubicOut);
            }

            if (vm.SelectCityCommand.CanExecute(city))
                await vm.SelectCityCommand.ExecuteAsync(city);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex);
        }
        finally
        {
            if (card != null)
            {
                card.Scale = 1;
                card.Opacity = 1;
            }

            _isSearchHistoryAnimating = false;
        }
    }
    private async void CityResultCard_Tapped(object? sender, TappedEventArgs e)
    {
        if (_isCityResultAnimating)
            return;

        if (BindingContext is not HomeViewModel vm)
            return;

        if (e.Parameter is not CitySearchResult city)
            return;

        VisualElement? card = null;

        if (sender is Element element && element.Parent is VisualElement parent)
            card = parent;

        try
        {
            _isCityResultAnimating = true;

            if (card != null)
            {
                await Task.WhenAll(
                    card.ScaleToAsync(0.965, 80, Easing.CubicOut),
                    card.FadeToAsync(0.82, 80, Easing.CubicOut)
                );

                await Task.WhenAll(
                    card.ScaleToAsync(1.02, 130, Easing.SpringOut),
                    card.FadeToAsync(1, 110, Easing.CubicOut)
                );

                await card.ScaleToAsync(1, 70, Easing.CubicOut);
            }

            if (vm.SelectCityCommand.CanExecute(city))
                await vm.SelectCityCommand.ExecuteAsync(city);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex);
        }
        finally
        {
            if (card != null)
            {
                card.Scale = 1;
                card.Opacity = 1;
            }

            _isCityResultAnimating = false;
        }
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (_animationPlayed)
        {
            if (_shouldReloadAfterSettings)
            {
                _shouldReloadAfterSettings = false;

                if (BindingContext is HomeViewModel vm)
                    await vm.ReloadAfterSettingsAsync();
            }

            return;
        }

        _animationPlayed = true;

        try
        {
            await Task.Delay(120);

            await Task.WhenAll(
                TopBar.FadeToAsync(1, 360, Easing.CubicOut),
                TopBar.TranslateToAsync(0, 0, 360, Easing.CubicOut)
            );

            await Task.WhenAll(
                SearchArea.FadeToAsync(1, 360, Easing.CubicOut),
                SearchArea.TranslateToAsync(0, 0, 360, Easing.CubicOut)
            );

            await Task.WhenAll(
                MainWeatherCard.FadeToAsync(1, 480, Easing.CubicOut),
                MainWeatherCard.TranslateToAsync(0, 0, 480, Easing.CubicOut),
                MainWeatherCard.ScaleToAsync(1, 480, Easing.SpringOut)
            );

            await Task.WhenAll(
                HourlyTitle.FadeToAsync(1, 320, Easing.CubicOut),
                HourlyTitle.TranslateToAsync(0, 0, 320, Easing.CubicOut),
                HourlyList.FadeToAsync(1, 360, Easing.CubicOut),
                HourlyList.TranslateToAsync(0, 0, 360, Easing.CubicOut)
            );

            await Task.WhenAll(
                DetailsTitle.FadeToAsync(1, 320, Easing.CubicOut),
                DetailsTitle.TranslateToAsync(0, 0, 320, Easing.CubicOut),
                MiniCards.FadeToAsync(1, 380, Easing.CubicOut),
                MiniCards.TranslateToAsync(0, 0, 380, Easing.CubicOut)
            );

            await Task.WhenAll(
                DailyTitle.FadeToAsync(1, 360, Easing.CubicOut),
                DailyTitle.TranslateToAsync(0, 0, 360, Easing.CubicOut),
                DailyCard.FadeToAsync(1, 420, Easing.CubicOut),
                DailyCard.TranslateToAsync(0, 0, 420, Easing.CubicOut)
            );
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex);
        }
    }

    private async void AboutButton_Tapped(object? sender, TappedEventArgs e)
    {
        if (_isAboutAnimating)
            return;

        try
        {
            _isAboutAnimating = true;

            await Task.WhenAll(
                AboutButton.ScaleToAsync(0.86, 90, Easing.CubicOut),
                AboutButton.FadeToAsync(0.76, 90, Easing.CubicOut)
            );

            await Task.WhenAll(
                AboutButton.ScaleToAsync(1.04, 180, Easing.SpringOut),
                AboutButton.FadeToAsync(1, 160, Easing.CubicOut),
                AboutIcon.ScaleToAsync(1.18, 180, Easing.SpringOut)
            );

            await Task.WhenAll(
                AboutButton.ScaleToAsync(1, 90, Easing.CubicOut),
                AboutIcon.ScaleToAsync(1, 90, Easing.CubicOut)
            );

            await Shell.Current.GoToAsync(nameof(AboutPage), true);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex);
        }
        finally
        {
            AboutButton.Scale = 1;
            AboutButton.Opacity = 1;
            AboutIcon.Scale = 1;
            _isAboutAnimating = false;
        }
    }
    private async void FavoriteCityCard_Tapped(object? sender, TappedEventArgs e)
    {
        if (_isFavoriteCardAnimating)
            return;

        if (BindingContext is not HomeViewModel vm)
            return;

        if (e.Parameter is not FavoriteCity favoriteCity)
            return;

        VisualElement? card = null;

        if (sender is Element element && element.Parent is VisualElement parent)
            card = parent;

        try
        {
            _isFavoriteCardAnimating = true;

            if (card != null)
            {
                await Task.WhenAll(
                    card.ScaleToAsync(0.965, 85, Easing.CubicOut),
                    card.FadeToAsync(0.82, 85, Easing.CubicOut)
                );

                await Task.WhenAll(
                    card.ScaleToAsync(1.025, 140, Easing.SpringOut),
                    card.FadeToAsync(1, 120, Easing.CubicOut)
                );

                await card.ScaleToAsync(1, 80, Easing.CubicOut);
            }

            if (vm.SelectFavoriteCityCommand.CanExecute(favoriteCity))
                await vm.SelectFavoriteCityCommand.ExecuteAsync(favoriteCity);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex);
        }
        finally
        {
            if (card != null)
            {
                card.Scale = 1;
                card.Opacity = 1;
            }

            _isFavoriteCardAnimating = false;
        }
    }

    private async void MainWeatherCard_Tapped(object? sender, TappedEventArgs e)
    {
        if (_isDetailAnimating)
            return;

        if (BindingContext is not HomeViewModel vm)
            return;

        try
        {
            _isDetailAnimating = true;

            await MainWeatherCard.ScaleToAsync(0.985, 90, Easing.CubicOut);
            await MainWeatherCard.ScaleToAsync(1, 140, Easing.SpringOut);

            await Shell.Current.Navigation.PushAsync(
                new WeatherDetailPage(vm.Weather),
                true);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex);
        }
        finally
        {
            MainWeatherCard.Scale = 1;
            _isDetailAnimating = false;
        }
    }
    private async void RefreshButton_Tapped(object? sender, TappedEventArgs e)
    {
        if (_isRefreshAnimating)
            return;

        if (BindingContext is not HomeViewModel vm)
            return;

        if (!vm.RefreshCommand.CanExecute(null))
            return;

        try
        {
            _isRefreshAnimating = true;

            await Task.WhenAll(
                RefreshButton.ScaleToAsync(0.86, 90, Easing.CubicOut),
                RefreshButton.FadeToAsync(0.76, 90, Easing.CubicOut)
            );

            var refreshTask = vm.RefreshCommand.ExecuteAsync(null);

            await Task.WhenAll(
                RefreshButton.ScaleToAsync(1, 230, Easing.SpringOut),
                RefreshButton.FadeToAsync(1, 180, Easing.CubicOut),
                RefreshIcon.RotateToAsync(360, 540, Easing.CubicOut)
            );

            RefreshIcon.Rotation = 0;

            await refreshTask;
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex);
        }
        finally
        {
            RefreshButton.Scale = 1;
            RefreshButton.Opacity = 1;
            RefreshIcon.Rotation = 0;
            _isRefreshAnimating = false;
        }
    }

    private async void FavoriteActionButton_Tapped(object? sender, TappedEventArgs e)
    {
        if (_isFavoriteAnimating)
            return;

        if (BindingContext is not HomeViewModel vm)
            return;

        try
        {
            _isFavoriteAnimating = true;

            await FavoriteActionButton.ScaleToAsync(0.94, 80, Easing.CubicOut);

            if (vm.ToggleFavoriteCommand.CanExecute(null))
                vm.ToggleFavoriteCommand.Execute(null);

            await FavoriteActionButton.ScaleToAsync(1.04, 120, Easing.SpringOut);
            await FavoriteActionButton.ScaleToAsync(1, 90, Easing.CubicOut);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex);
        }
        finally
        {
            FavoriteActionButton.Scale = 1;
            _isFavoriteAnimating = false;
        }
    }

    private async void SettingsButton_Tapped(object? sender, TappedEventArgs e)
    {
        if (_isSettingsAnimating)
            return;

        try
        {
            _isSettingsAnimating = true;

            await Task.WhenAll(
                SettingsButton.ScaleToAsync(0.86, 90, Easing.CubicOut),
                SettingsButton.FadeToAsync(0.76, 90, Easing.CubicOut)
            );

            await Task.WhenAll(
                SettingsButton.ScaleToAsync(1.04, 180, Easing.SpringOut),
                SettingsButton.FadeToAsync(1, 160, Easing.CubicOut),
                SettingsIcon.RotateToAsync(120, 260, Easing.CubicOut)
            );

            await SettingsButton.ScaleToAsync(1, 90, Easing.CubicOut);

            SettingsIcon.Rotation = 0;
            _shouldReloadAfterSettings = true;
            await Shell.Current.GoToAsync(nameof(SettingsPage), true);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex);
        }
        finally
        {
            SettingsButton.Scale = 1;
            SettingsButton.Opacity = 1;
            SettingsIcon.Rotation = 0;
            _isSettingsAnimating = false;
        }
    }
}