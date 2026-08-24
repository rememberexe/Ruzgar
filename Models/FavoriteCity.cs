using CommunityToolkit.Mvvm.ComponentModel;

namespace Ruzgar.Models;

public class FavoriteCity : ObservableObject
{
    private string _name = "";
    private string _country = "";
    private string _adminArea = "";
    private double _latitude;
    private double _longitude;

    private string _miniIcon = "⌁";
    private string _miniTemperatureText = "--°";
    private string _miniDescription = "Yükleniyor";
    private string _miniUpdatedText = "";
    private bool _isMiniWeatherLoading;
    private bool _hasMiniWeather;

    public string Name
    {
        get => _name;
        set
        {
            if (SetProperty(ref _name, value))
            {
                OnPropertyChanged(nameof(DisplayName));
                OnPropertyChanged(nameof(SubText));
            }
        }
    }

    public string Country
    {
        get => _country;
        set
        {
            if (SetProperty(ref _country, value))
            {
                OnPropertyChanged(nameof(DisplayName));
                OnPropertyChanged(nameof(SubText));
            }
        }
    }

    public string AdminArea
    {
        get => _adminArea;
        set
        {
            if (SetProperty(ref _adminArea, value))
            {
                OnPropertyChanged(nameof(DisplayName));
                OnPropertyChanged(nameof(SubText));
            }
        }
    }

    public double Latitude
    {
        get => _latitude;
        set => SetProperty(ref _latitude, value);
    }

    public double Longitude
    {
        get => _longitude;
        set => SetProperty(ref _longitude, value);
    }

    public string MiniIcon
    {
        get => _miniIcon;
        set => SetProperty(ref _miniIcon, value);
    }

    public string MiniTemperatureText
    {
        get => _miniTemperatureText;
        set => SetProperty(ref _miniTemperatureText, value);
    }

    public string MiniDescription
    {
        get => _miniDescription;
        set => SetProperty(ref _miniDescription, value);
    }

    public string MiniUpdatedText
    {
        get => _miniUpdatedText;
        set => SetProperty(ref _miniUpdatedText, value);
    }

    public bool IsMiniWeatherLoading
    {
        get => _isMiniWeatherLoading;
        set => SetProperty(ref _isMiniWeatherLoading, value);
    }

    public bool HasMiniWeather
    {
        get => _hasMiniWeather;
        set => SetProperty(ref _hasMiniWeather, value);
    }

    public string DisplayName
    {
        get
        {
            if (!string.IsNullOrWhiteSpace(AdminArea) &&
                !string.IsNullOrWhiteSpace(Country) &&
                !string.Equals(AdminArea, Name, StringComparison.OrdinalIgnoreCase))
            {
                return $"{Name}, {AdminArea}, {Country}";
            }

            if (!string.IsNullOrWhiteSpace(Country))
                return $"{Name}, {Country}";

            return Name;
        }
    }

    public string SubText
    {
        get
        {
            if (!string.IsNullOrWhiteSpace(AdminArea) &&
                !string.IsNullOrWhiteSpace(Country) &&
                !string.Equals(AdminArea, Name, StringComparison.OrdinalIgnoreCase))
            {
                return $"{AdminArea}, {Country}";
            }

            if (!string.IsNullOrWhiteSpace(Country))
                return Country;

            return "Favori şehir";
        }
    }
}