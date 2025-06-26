# BOOK STORE API
Bu proje, .net 9 ile geliştirilmiş, CQRS ve Onion mimarisi kullanılmış, kitap mağazı projesidir

# Tablolar
- Book
- Category
- BookCategory (Junction Tablo - Many to Many)
- AppUser
- AppRole

# Controller'lar & EndPoint'ler
- BooksController (GetAll, Create, GetById, Update, Delete, ThrowError)
- CategoriesController (GetAll, Create, GetById, Update, Delete)
- AppUsersController (Register, Login)


- WebApi'i çalıştırın
- https://localhost:5201/swagger/index.html ile swagger'ı açın
- Register endpoint'i ile kayıt olun
- Book tablosuna öge eklemek için önce Register endpoint'i ile kayıt olun (Sadece bu endpoint için authorize uygulanmıştır, diğer endpoint'leri kayıt olmadan kullanabilirsiniz)
- Login endpoint'i ile token'ı kopyalayın
- Swagger arayüzünde sağ üstte bulunan Authorize butonuna basarak token'ı girerek giriş yapın.
- Book ile Category tablolarının ilişkisi, junction tablo ile kurulmuştur.
- Book eklerken, ekleyeceğiniz CategoryId ögesinin, Category tablosunda varolduğuna dikkat edin.
- CategoryId liste olarak göndererek birden fazla many to many kurabilirsiniz.

# Diğer Teknik Bilgiler
- .net 9 yazıldı ve CQRS ile Onion mimari kullanıldı
- JWT tabanlı kimlik doğrulama yapıldı
- Read / Write Repository dizayn edildi
- DTO ve entity dönüşümlerinde automapper kullanıldı
- Solid prensiplerine uygun tasarlandı
- Swagger aktif edildi ve endpointler listelendi
- Örnek unit test çalışması
