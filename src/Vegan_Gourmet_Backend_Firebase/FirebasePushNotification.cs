using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using Microsoft.Extensions.Configuration;
using Vegan_Gourmet_Backend_Domains.Services;

namespace Vegan_Gourmet_Backend_Firebase;

public class FirebasePushNotification : IFirebasePushNotification
{
    private readonly FirebaseApp _firebaseApp;

    private readonly IConfiguration _configuration;

    public FirebasePushNotification(IConfiguration configuration)
    {
        _configuration = configuration;

        _firebaseApp = FirebaseApp.Create(new AppOptions()
        {
            Credential = GoogleCredential.FromJson(configuration["FirebaseCredential"]),
        });
    }

    public async Task PushAsync()
    {
        var fcm = FirebaseMessaging.GetMessaging(_firebaseApp);
        var message = new Message()
        {
            Notification = new Notification
            {
                Title = _configuration["TimerPushTitle"],
                Body = _configuration["TimerPushBody"],
                ImageUrl = _configuration["TimerPushImage"]
            },
            Topic = _configuration["TimerPushTopic"],
            Apns = new ApnsConfig()
            {
                Aps = new Aps()
                {
                    Badge = 1
                }
            }
        };

        await fcm.SendAsync(message);
    }
}

