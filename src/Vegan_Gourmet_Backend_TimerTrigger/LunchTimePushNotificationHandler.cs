using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.WebJobs;
using Vegan_Gourmet_Backend_UseCases.TimerPush;

namespace Vegan_Gourmet_Backend
{
    public class LunchTimePushNotificationHandler
    {
        private readonly ITimerPushNotificationUseCase _timerPushNotificationUseCase;

        public LunchTimePushNotificationHandler(ITimerPushNotificationUseCase timerPushNotificationUseCase)
        => _timerPushNotificationUseCase = timerPushNotificationUseCase;

        [Function("LunchTimePushNotificationHandler")]
        public async Task Run([Microsoft.Azure.Functions.Worker.TimerTrigger("%LunchTime%")] TimerInfo timer)
        {
            await _timerPushNotificationUseCase.ExecuteAsync();
        }
    }
}

