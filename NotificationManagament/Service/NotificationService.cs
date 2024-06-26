namespace NotificationManagament.Service;

public class NotificationService
{

    public void SendNotification(string message)
    {
        Console.WriteLine("Notification sent to {USER}: Your package from {SUPPLIERNAME} will be deliverd in the coming 24 hours :)");
    }
}
