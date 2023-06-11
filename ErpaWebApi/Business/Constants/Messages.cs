using Infrastructure.Model.Concrete;

namespace Business.Constants
{
    public static class Messages
    {
        public static string Success = "İşlem Başarılı";
        public static string Error = "Hata Oluştu!";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";
        public static string LoginBlocked = "Girişiniz 10 dakika bloke olmuştur";
    }
}
