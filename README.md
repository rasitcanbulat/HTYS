HTYS - Hukuk Takip Yönetim Sistemi
Bu proje, bir bankanın hukuk departmanı için geliştirilmiş olan ASP.NET Core MVC tabanlı bir Hukuk Takip Yönetim Sistemi'dir. Sistem, bankacı ve avukat rollerine sahip kullanıcıların müşteri, ürün, ihtar ve icra takiplerini yönetmesini sağlar.

Proje Hakkında
HTYS, bankanın borçlu müşterilerine ait yasal süreçlerin dijital ortamda verimli bir şekilde takip edilmesi amacıyla oluşturulmuştur. Sistem, N-Tier (Çok Katmanlı) mimari prensiplerine uygun olarak geliştirilmiştir.

Kullanılan Teknolojiler
Backend: C#, ASP.NET Core MVC, Entity Framework Core

Frontend: HTML5, CSS3, JavaScript

Veritabanı: Microsoft SQL Server

Mimari: N-Tier (Katmanlı Mimari)

Özellikler
Çift Rol Sistemi:

Bankacı Paneli: Müşteri, avukat, ürün, ihtar ve icra takibi için tam CRUD (Oluşturma, Okuma, Güncelleme, Silme) işlemleri.

Avukat Paneli: Kendisine atanmış olan müşteri, ihtar ve icra dosyalarını görüntüleme.

Kullanıcı Yönetimi: Güvenli kullanıcı girişi ve bankacılar için kayıt olma özelliği.

Dinamik Formlar: Birbiriyle ilişkili verilerin (İl -> İlçe, Müşteri -> Ürün) dinamik olarak yüklendiği kullanıcı dostu formlar.

Anlık Doğrulama: Kullanıcıların formları doldururken yaptığı hataları anında gösteren JavaScript tabanlı istemci tarafı doğrulama.

Veritabanı Yönetimi: Code-First yaklaşımı ve Entity Framework Core Migrations ile veritabanı yönetimi.

Güvenlik: Şifrelerin veritabanında güvenli bir şekilde hash'lenerek saklanması.

Kurulum
Projeyi yerel makinenizde çalıştırmak için aşağıdaki adımları izleyin:

Depoyu Klonlayın:

git clone https://github.com/kullanici-adiniz/proje-adiniz.git

Veritabanı Bağlantısı:

HTYS.WebUI projesi içindeki appsettings.json dosyasını açın.

ConnectionStrings bölümündeki "DefaultConnection" değerini kendi SQL Server bağlantı bilgilerinizle güncelleyin.

Veritabanı Migrasyonları:

Visual Studio'da Package Manager Console'u açın.

Default project olarak HTYS.DataAccessLayer projesini seçin.

Aşağıdaki komutu çalıştırarak veritabanını oluşturun ve tabloları yükleyin:

Update-Database

Projeyi Çalıştırın:

HTYS.WebUI projesini başlangıç projesi olarak ayarlayın ve çalıştırın.

Veritabanı Yapısı
Proje, Entity Framework Core Code-First yaklaşımı ile aşağıdaki ana varlıkları (entities) yönetir:

Musteri

Avukat

Urun

Ihtar

IcraTakip

LoginAccount

Proje Mimarisi
Proje, sorumlulukların ayrılması prensibine dayalı olarak 4 ana katmandan oluşmaktadır:

HTYS.Entities: Projenin veritabanı tablolarına karşılık gelen POCO (Plain Old CLR Object) sınıflarını içerir.

HTYS.DataAccessLayer: Entity Framework Core kullanarak veritabanı işlemlerini (CRUD) gerçekleştiren katmandır.

HTYS.BusinessLayer: İş mantığı, veri doğrulama ve DataAccessLayer ile UI arasındaki koordinasyonu sağlayan katmandır.

HTYS.WebUI: Kullanıcı arayüzünü (Views), Controller'ları ve diğer web varlıklarını içeren ASP.NET Core MVC projesidir.
