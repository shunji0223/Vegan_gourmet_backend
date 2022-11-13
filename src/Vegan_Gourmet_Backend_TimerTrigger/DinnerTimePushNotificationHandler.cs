using Microsoft.Azure.Functions.Worker;
using Vegan_Gourmet_Backend_UseCases.TimerPush;

namespace Vegan_Gourmet_Backend
{
    public class DinnerTimePushNotificationHandler
    {
        private readonly ITimerPushNotificationUseCase _timerPushNotificationUseCase;

        public DinnerTimePushNotificationHandler(ITimerPushNotificationUseCase timerPushNotificationUseCase)
        => _timerPushNotificationUseCase = timerPushNotificationUseCase;

        [Function("DinnerTimePushNotificationHandler")]
        public async Task Run([TimerTrigger("%DinnerTime%")] Timer _)
        {
            await _timerPushNotificationUseCase.ExecuteAsync();
        }
    }
}

