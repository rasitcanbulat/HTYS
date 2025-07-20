
# ⚖️ HTYS - Hukuk Takip Yönetim Sistemi

**HTYS (Hukuk Takip Yönetim Sistemi)**, bir bankanın hukuk departmanında kullanılmak üzere geliştirilmiş, ASP.NET Core MVC tabanlı bir web uygulamasıdır. Sistem, **bankacı** ve **avukat** rollerine sahip kullanıcıların müşteri, ürün, ihtar ve icra takip süreçlerini etkin şekilde yönetmesine olanak sağlar.

## 📌 Proje Hakkında

HTYS, bankaların borçlu müşterilerine ait **hukuki takip süreçlerini dijital ortamda merkezi ve güvenli şekilde yönetmek** amacıyla geliştirilmiştir.

> 🏢 Bu proje, **Halkbank – Temel Bankacılık Uygulama Geliştirme Daire Başkanlığı**'nda **stajyerlik sürecim** boyunca geliştirdiğim **ilk profesyonel yazılım projesidir**.

Uygulama, modern web teknolojileriyle oluşturulmuş olup, **N-Tier (Katmanlı Mimari)** prensiplerine uygun olarak yapılandırılmıştır.

## 🛠️ Kullanılan Teknolojiler

| Katman       | Teknoloji                          |
|--------------|------------------------------------|
| Backend      | C#, ASP.NET Core MVC, EF Core      |
| Frontend     | HTML5, CSS3, JavaScript            |
| Veritabanı   | Microsoft SQL Server               |
| Mimari       | N-Tier Architecture                |

## 🚀 Özellikler

### 👥 Rol Tabanlı Yetkilendirme
- **Bankacı Paneli**: Müşteri, avukat, ürün, ihtar ve icra takibi için **tam CRUD** işlemleri.
- **Avukat Paneli**: Sadece **kendi atandığı dosya ve müşterileri** görüntüleyebilir.

### 🔐 Kullanıcı Yönetimi
- Bankacılar için **kayıt olma**, güvenli **giriş işlemleri** ve roller arası geçiş yönetimi.

### 🧠 Dinamik Formlar & Doğrulama
- **İl → İlçe**, **Müşteri → Ürün** gibi ilişkili verilerin dinamik yüklenmesi.
- **Gerçek zamanlı form doğrulama** ile kullanıcı dostu veri giriş deneyimi.

### 📦 Veritabanı Yönetimi
- **Code-First** yaklaşımı ile geliştirilen veritabanı.
- **EF Core Migrations** ile sürüm kontrollü yapılar.

### 🔒 Güvenlik
- Kullanıcı şifreleri **hash’lenerek** saklanır.
- Yetkisiz erişimlere karşı **role-based authorization** mekanizması uygulanır.

## ⚙️ Kurulum Adımları

### 1. Depoyu Klonlayın
```bash
git clone https://github.com/rasitcanbulat/HTYS.git
```

### 2. Veritabanı Bağlantısı
`HTYS.WebUI/appsettings.json` dosyasındaki `DefaultConnection` kısmını kendi SQL Server bilgilerinizle güncelleyin:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=HTYS;Trusted_Connection=True;"
}
```

### 3. Veritabanı Migrasyonu
Visual Studio'da `Package Manager Console` açın:

- Default Project: `HTYS.DataAccessLayer` olarak seçin.
- Komutu çalıştırın:
```bash
Update-Database
```

### 4. Projeyi Başlatın
`HTYS.WebUI` projesini **Startup Project** olarak ayarlayın ve uygulamayı çalıştırın.

## 🧱 Veritabanı Varlıkları (Entities)

- `Musteri`
- `Avukat`
- `Urun`
- `Ihtar`
- `IcraTakip`
- `LoginAccount`

## 🏗️ Proje Mimarisi

**Katmanlı mimari** yapısıyla modüler, okunabilir ve sürdürülebilir bir geliştirme ortamı sunar:

```
HTYS.WebUI         → Kullanıcı Arayüzü (ASP.NET Core MVC)
HTYS.BusinessLayer → İş Mantığı ve Validasyon
HTYS.DataAccess    → Veritabanı Erişim Katmanı (EF Core)
HTYS.Entities      → POCO Sınıflar (Entity Tanımları)
```

## 📬 Katkı Sağlamak

Projeye katkıda bulunmak isterseniz, lütfen bir `fork` oluşturun, değişikliklerinizi ayrı bir dalda yapın ve ardından `pull request` gönderin. Her türlü geri bildiriminiz memnuniyetle karşılanır!

## 📄 Lisans

Bu proje [MIT Lisansı](LICENSE) ile lisanslanmıştır.
