# BOOK STORE API
Bu proje, .net 9 ile geliştirilmiş, CQRS ve Onion mimarisi kullanılmış, kitap mağazı projesidir

# Tablolar
1- Book
2- Category
3- BookCategory (Junction Tablo - Many to Many)
4- AppUser
5- AppRole

# Controller'lar & EndPoint'ler
1- BooksController (GetAll, Create, GetById, Update, Delete, ThrowError)
2- CategoriesController (GetAll, Create, GetById, Update, Delete)
3- AppUsersController (Register, Login)


1- WebApi'i çalıştırın
2- https://localhost:5201/swagger/index.html ile swagger'ı açın
3- Register endpoint'i ile kayıt olun
3- Book tablosuna öge eklemek için önce Register endpoint'i ile kayıt olun (Sadece bu endpoint için authorize uygulanmıştır, diğer endpoint'leri kayıt olmadan kullanabilirsiniz)
4- Login endpoint'i ile token'ı kopyalayın
5- Swagger arayüzünde sağ üstte bulunan Authorize butonuna basarak token'ı girerek giriş yapın.
6- Book ile Category tablolarının ilişkisi, junction tablo ile kurulmuştur.
7- Book eklerken, ekleyeceğiniz CategoryId ögesinin, Category tablosunda varolduğuna dikkat edin.
8- CategoryId liste olarak göndererek birden fazla many to many kurabilirsiniz.

# Diğer Teknik Bilgiler
- .net 9 yazıldı ve CQRS ile Onion mimari kullanıldı
- JWT tabanlı kimlik doğrulama yapıldı
- Read / Write Repository dizayn edildi
- DTO ve entity dönüşümlerinde automapper kullanıldı
- Solid prensiplerine uygun tasarlandı
- Swagger aktif edildi ve endpointler listelendi
- Örnek unit test çalışması
