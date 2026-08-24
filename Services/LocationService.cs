using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Devices.Sensors;

namespace Ruzgar.Services;

public class LocationService
{
    public async Task<(double Latitude, double Longitude, string City, string Country, string AdminArea)> GetCurrentLocationAsync()
    {
        try
        {
            var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

            if (status != PermissionStatus.Granted)
            {
                status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            }

            if (status != PermissionStatus.Granted)
            {
                return GetDefaultLocation();
            }

            var request = new GeolocationRequest(
                GeolocationAccuracy.Medium,
                TimeSpan.FromSeconds(10));

            var location = await Geolocation.Default.GetLocationAsync(request);

            if (location == null)
            {
                return GetDefaultLocation();
            }

            string city = "Konumum";
            string country = "";
            string adminArea = "";

            try
            {
                var placemarks = await Geocoding.Default.GetPlacemarksAsync(
                    location.Latitude,
                    location.Longitude);

                var placemark = placemarks?.FirstOrDefault();

                city =
                    placemark?.Locality ??
                    placemark?.SubAdminArea ??
                    placemark?.AdminArea ??
                    "Konumum";

                country = placemark?.CountryName ?? "";
                adminArea = placemark?.AdminArea ?? "";
            }
            catch
            {
                city = "Konumum";
                country = "";
                adminArea = "";
            }

            return (
                location.Latitude,
                location.Longitude,
                city,
                country,
                adminArea);
        }
        catch
        {
            return GetDefaultLocation();
        }
    }

    private static (double Latitude, double Longitude, string City, string Country, string AdminArea) GetDefaultLocation()
    {
        return (37.0000, 35.3213, "Adana", "Türkiye", "Adana");
    }
}