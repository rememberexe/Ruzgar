namespace Ruzgar.Services;

public interface INotificationManagerService
{
    event EventHandler<NotificationEventArgs>? NotificationReceived;

    Task<bool> RequestPermissionAsync();

    void SendNotification(string title, string message);
}

public class NotificationEventArgs : EventArgs
{
    public string Title { get; set; } = "";

    public string Message { get; set; } = "";
}