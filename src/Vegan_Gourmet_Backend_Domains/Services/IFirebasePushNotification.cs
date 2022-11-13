using System;
namespace Vegan_Gourmet_Backend_Domains.Services;

public interface IFirebasePushNotification
{
    Task PushAsync();
}

