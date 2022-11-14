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
        public async Task Run([TimerTrigger("%DinnerTime%")] MyInfo timer)
        {
            await _timerPushNotificationUseCase.ExecuteAsync();
        }

        public class MyInfo
        {
            public MyScheduleStatus ScheduleStatus { get; set; }

            public bool IsPastDue { get; set; }
        }

        public class MyScheduleStatus
        {
            public DateTime Last { get; set; }

            public DateTime Next { get; set; }

            public DateTime LastUpdated { get; set; }
        }
    }
}

