# Kitap Yönetim Projesi - Üyelik ve Rol Yönetimi Entegrasyonu

## Proje Özeti
Bu hafta, Kitap Yönetim Projemize **Üyelik ve Rol Yönetim Sistemi** entegrasyonu ekledik. Bu entegrasyon, kullanıcı ve rol yönetimini kolaylaştırırken güçlü bir erişim kontrolü sağlar.

### Ana Özellikler
- Üyelik yönetimi için `IdentityDbContext` entegrasyonu.
- Veritabanında üyelikle ilgili tabloların otomatik oluşturulması.
- Kullanıcı ve Rol yönetimi için RESTful API'lerin uygulanması.

## API Dokümantasyonu
`/api/doc` URL'si üzerinden Stoplight.io entegrasyonu ile API dokümantasyonuna erişebilirsiniz. Bu dokümantasyon, kullanıcı ve rol yönetimi uç noktalarını detaylı bir şekilde açıklar ve test etmenizi sağlar.

## Teknoloji ve Araçlar
- **ASP.NET Core Identity:** Kullanıcı ve rol yönetimi.
- **Entity Framework Core:** Veritabanı işlemleri.
- **Stoplight.io:** API dokümantasyonu için kullanıcı dostu arayüz.

## Proje Durumu
Bu entegrasyon ile proje daha kullanıcı dostu hale getirilmiş, kullanıcı ve rol yönetimi süreçleri güvenli ve kolay bir şekilde uygulanmıştır.

## Kurulum Talimatları
### Gereksinimler
- **Admin Giriş Bilgileri** (Test için):
  - **Kullanıcı Adı**: `ssttek`
  - **Şifre**: `Ssttek123`

## Kullanıcı Yönetimi
Kullanıcılarla ilgili işlemler, `UserController` sınıfı aracılığıyla yönetilir. Sağlanan API uç noktaları şunlardır:

- **➕ Kullanıcı Ekleme (Create):** Yeni bir kullanıcı oluşturur.
- **📄 Kullanıcı Bilgilerini Görüntüleme (Read):** Mevcut bir kullanıcının bilgilerini listeler.
- **✏️ Kullanıcı Bilgilerini Güncelleme (Update):** Kullanıcı bilgilerini düzenler.
- **🗑️ Kullanıcı Silme (Delete):** Bir kullanıcıyı sistemden kaldırır.

## Rol Yönetimi
Rollerle ilgili işlemler, `RoleController` sınıfı aracılığıyla yönetilir. Sağlanan API uç noktaları şunlardır:

- **➕ Rol Ekleme (Create Role):** Yeni bir rol oluşturur.
- **📄 Rolleri Listeleme (List Roles):** Tüm rolleri görüntüler.
- **✏️ Rol Güncelleme (Update Role):** Mevcut bir rolü düzenler.
- **🗑️ Rol Silme (Delete Role):** Bir rolü sistemden kaldırır.
- **🎭 Kullanıcıya Rol Atama ve Silme (Assign/Remove Role for User):** Bir kullanıcıya rol atar veya kullanıcıdan rolü kaldırır.



---
