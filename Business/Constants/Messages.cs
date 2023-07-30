using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün Eklendi";
        public static string ProductNameInvalid = "Ürün İsmi Geçersiz";
        public static string MaintananceTime = "Zaman Dilimi İşleminize Uygun Değil";
        public static string ProductsListed = "Ürünler Listelendi";
        public static string ProductCountOfCategoryError = "Bir Kategoride En Fazla 10 Ürün Olmalı";
        public static string ProductNameAlreadyExists = "Böyle Bir Ürün Zaten Var";
        public static string CategoryLimitExceded = "Kategori Limiti Aşıldı";
        public static string? AuthorizationDenied = "Yetkiniz Yok";

        public static string UserRegistered = "Kayıt Olundu";
        public static string UserNotFound = "Kullanıcı Bulunamadı";
        public static string PasswordError = "Şifre Hatası";
        public static string SuccessfulLogin = "Başarılı Giriş";
        public static string UserAlreadyExists = "Kullanıcı Mevcut";
        public static string AccessTokenCreated = "Token Oluşturuldu";
    }
}
