using Microsoft.Azure.Functions.Worker;
using Vegan_Gourmet_Backend_UseCases.TimerPush;

namespace Vegan_Gourmet_Backend
{
    public class LunchTimePushNotificationHandler
    {
        private readonly ITimerPushNotificationUseCase _timerPushNotificationUseCase;

        public LunchTimePushNotificationHandler(ITimerPushNotificationUseCase timerPushNotificationUseCase)
        => _timerPushNotificationUseCase = timerPushNotificationUseCase;

        [Function("LunchTimePushNotificationHandler")]
        public async Task Run([TimerTrigger("%LunchTime%")] Timer _)
        {
            await _timerPushNotificationUseCase.ExecuteAsync();
        }
    }
}

