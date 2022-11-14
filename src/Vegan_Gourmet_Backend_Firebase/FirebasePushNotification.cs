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
            Credential = GoogleCredential.FromJson("{   \"type\": \"service_account\",   \"project_id\": \"vegan-gourmet\",   \"private_key_id\": \"33af74c141fc3f681ba5443bb2f89132f4b7c97d\",   \"private_key\": \"-----BEGIN PRIVATE KEY-----\nMIIEvwIBADANBgkqhkiG9w0BAQEFAASCBKkwggSlAgEAAoIBAQCeX/mo9mq6yWyJ\nceBGnprrZ+dVZlhnfBh5djlgyyEYosuUfJaMFwHfxVCKd5MfD1ArWjDmTJ5JYfxG\nicUmtjsnQwjztdEbAHbml82QT/eiTOCd3HHR55SfLUJN6wyPn2Qmk7uSM80dapWw\n8lwhsYJf4hpai6EB5+2hwJraoVBpVH7ZrEq5ow+FGSkPCOzXLxFVF7iYqnGrIzs8\n2kekFhSWYjojXRDyUqHIRBHJ2X68m+CZgzz7HDY3qJywJ1Dy5fnoDgK0bTxv3XCE\n506uHOOxNrbazIrrdd752PxOHJQyQcRHfGH14RH3aEA17rh9srhkhwfD2M1nrFVa\nwXda0me5AgMBAAECggEABgGi0M8jphjchmvssxDx1Cq5IcqDYM1aikS7EVoy06Hc\n8bE17nMy7X8ouk+lo0Br7HD7uMhAGo1eSXiRIxI3NRp8PO3w08LVP5KTR71YqW2b\n+TCymmDbiJvpT1YyQEItxK7GptlTFqIDslXGu7plNOi40iVIgm9+2isZVGBY0d3E\nuMKM7nAdmpNJ357Rejp1gx3Zr20Ko3J7PYknBGnNk25PUS64B0E7L/cEsDo7PvMA\nrqOA2+cjmb6FPgEx5+ueBF5rhLOB75xb1Jjolzh1uD05p+KaTD7sWPSnaE8C/Nkz\nanqCM0t1IFKCKDvtLZwkyKaE2S1POHVYmDjKhDlvuQKBgQDOSuJfborcuuHA6Qe4\n9lHMGCHYYB27pmst8gXqwRBP+2j9rgjh4EbXO/tLNp1U+19DcCgfP5UkfyVWWiyA\n3Yx2zJ1/5n45Tb+pcRPFFOWhvP+IJtc/7zuYclRi9tdRo0l7UeUd7L37ijsi+uxl\npOtt73SZh63FlqkYEou8WcWLbQKBgQDEiU1Fxxk5XLCWqUFO9j4qjdPbCuYAy7KS\n4M4F5hRX3haQm6Ph0z4PVH1xbCfgF9T8KX3GZoDjlwazaFHa1bHj7RjfLjvIXG8Z\nombN7IkYX8Ag1qREQSlf0+Pv6f+nnQJ0WrDKaoE8P8rA+KuOrzzFMyyKYneEQt6R\nHW0eV+7x/QKBgQDCEeTAzqfIW++BojhnoyL0lEdS3albHYZ7JNK4NIR6GhR9grpM\ndMdwOLeB3JFKn2jRcrPsIc7XFN41TIPNf59jK7+H0Xkxw5jpeL2WjMAy1jC3D4M0\nXIV+NyB4MawC21CHuVWIP23DNBnKILFANlRdigXxYZjy53eQc/INcY7MSQKBgQC8\nt+LdR+suq5RddzTg746OKhXuVS66QN6+LuNlwqJyJS2hufHJnKAQ9F5oFSTNB9Va\nNTUy16aX46Npjpha+6uPY1HorGp3YFrGUK1KuwCByR+h6LlfWPqzq7FJ5HW6qwd6\nVsM/+rkR82drmNyTbC18ZkE0uIxvEg7JZWosIt+suQKBgQCMpHCh4l9O8aVxwCCr\nspDeYjPZ+FnBUdOOXSR2JQGDc8vfFM/RK19jbazjcJXBtcLn6yCJQQEoUBfbYi+W\nmkeSYUqQO7CIBwzhIBwbNj4MzFFqIBgOOkHWvKlhQktfRNdAiwZf4ao3kHuGNqf3\nj/76zDKw8k1NLk0IswNPwwpb5Q==\n-----END PRIVATE KEY-----\n\",   \"client_email\": \"firebase-adminsdk-6tty9@vegan-gourmet.iam.gserviceaccount.com\",   \"client_id\": \"107777581813095720430\",   \"auth_uri\": \"https://accounts.google.com/o/oauth2/auth\",   \"token_uri\": \"https://oauth2.googleapis.com/token\",   \"auth_provider_x509_cert_url\": \"https://www.googleapis.com/oauth2/v1/certs\",   \"client_x509_cert_url\": \"https://www.googleapis.com/robot/v1/metadata/x509/firebase-adminsdk-6tty9%40vegan-gourmet.iam.gserviceaccount.com\" }"),
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
                    Badge = 1,
                    Sound = "default"
                }
            }
        };

        await fcm.SendAsync(message);
    }
}

