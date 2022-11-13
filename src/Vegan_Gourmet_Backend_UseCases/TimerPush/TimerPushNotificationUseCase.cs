using Vegan_Gourmet_Backend_Domains.Services;
using Vegan_Gourmet_Backend_UseCases.TimerPush;

namespace Vegan_Gourmet_Backend_UseCases;
public class TimerPushNotificationUseCase : ITimerPushNotificationUseCase
{
    private readonly IFirebasePushNotification _firebasePushNotification;

    public TimerPushNotificationUseCase(IFirebasePushNotification firebasePushNotification)
        => _firebasePushNotification = firebasePushNotification;

    public async Task ExecuteAsync()
    {
        await _firebasePushNotification.PushAsync();
    }
}

