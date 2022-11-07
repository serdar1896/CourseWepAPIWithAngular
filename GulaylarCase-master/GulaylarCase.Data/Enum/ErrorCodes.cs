namespace GulaylarCase.Data.Enum
{
    public class ErrorCodes
    {
        public static ErrorModel BilinmeyenHata { get { return new ErrorModel { Code = 1, Text = "Bilinmeyen Bir Hata Oluştu Lütfen Bizimle İletişime Geçiniz." }; } }
        public static ErrorModel AyniMailUyelikMevcut { get { return new ErrorModel { Code = 2, Text = "Aynı Mail Adresi İle Mevcut Üyelik Bulunmaktadır." }; } }
        public static ErrorModel MailVeyaSifreHatali { get { return new ErrorModel { Code = 1, Text = "Mail veya Şifre Hatalı" }; } }
        public static ErrorModel KayitYok { get { return new ErrorModel { Code = 1, Text = "Kayıt Bulunamadı" }; } }
    }

    public class ErrorModel
    {
        public int Code { get; set; }
        public string Text { get; set; }
    }
}
