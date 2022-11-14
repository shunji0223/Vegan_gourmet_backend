using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Vegan_Gourmet_Backend_Domains.Services;
using Vegan_Gourmet_Backend_Firebase;
using Vegan_Gourmet_Backend_UseCases;
using Vegan_Gourmet_Backend_UseCases.TimerPush;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(services =>
    {
        services.AddSingleton<ITimerPushNotificationUseCase, TimerPushNotificationUseCase>();
        services.AddSingleton<IFirebasePushNotification, FirebasePushNotification>();
    })
    .Build();

host.Run();

