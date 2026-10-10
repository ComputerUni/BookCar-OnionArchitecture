# 🚗 CarBook - Araç Kiralama Platformu

CarBook, modern teknolojiler kullanılarak geliştirilen, **Onion Architecture** mimarisine dayanan eksiksiz bir araç kiralama ve yönetim platformudur. .NET 8 ve Razor Pages teknolojileri ile inşa edilmiş, güçlü API'si ve kullanıcı dostu arayüzü ile araba kiralama işlemlerini kolaylaştıran bir uygulamadır.

---

## 🌟 Proje Özellikleri

### 📋 Temel Özellikler
- **Araç Yönetimi**: Araçların eklenmesi, düzenlenmesi, silinmesi
- **Dinamik Fiyatlandırma**: Araçlar için farklı fiyatlandırma seçenekleri
- **Kiralama Sistemi**: Araç kiralaması ve rezervasyon işlemleri
- **Blog Sistemi**: Araç ve kiralama hakkında yazılar yayınlama
- **Yorum ve Değerlendirme**: Müşteriler tarafından araçlara yorum ve puan verme
- **Müşteri Yönetimi**: Müşteri bilgileri ve kiralama geçmişi
- **İletişim Formu**: Ziyaretçiler tarafından mesaj gönderme

### 🛡️ Güvenlik Özellikleri
- **JWT Tabanlı Kimlik Doğrulama**: Güvenli kullanıcı oturumu
- **Rol Tabanlı Erişim Kontrolü (RBAC)**: Admin ve kullanıcı seviyeleri
- **Şifreli Veri Depolama**: Güvenli veri yönetimi
- **Cookie Güvenliği**: HttpOnly, Secure ve SameSite ayarları

### 🎨 Kullanıcı Arayüzü
- **Responsive Tasarım**: Tüm cihazlarda uyumlu görünüm
- **Admin Panel**: Tüm verileri yönetim arayüzü
- **Blog Detay Sayfası**: Yazılar için ayrıntılı görüntüleme
- **Real-time Güncellemeler**: SignalR ile canlı veri güncelleme

### 🔌 API Özellikleri
- **RESTful API**: Standart REST prensiplerine uygun
- **CQRS Deseni**: Komut ve Sorgu ayrışmasını içeren mimari
- **MediaR Deseni**: İstek işleme için bağımsız handler'lar
- **Repository Pattern**: Veri erişim katmanı abstraksiyon

---

## 🏗️ Proje Mimarisi (Onion Architecture)

```
CarBook/
├── Core/
│   ├── CarBook.Domain/              # İş alanı modelleri ve interface'ler
│   └── CarBook.Application/         # İş kuralları ve CQRS/MediaR handler'ları
│
├── Frontends/
│   ├── CarBook.WebUI/               # Razor Pages ön yüz
│   └── CarBook.Dto/                 # Veri Transfer Object'leri
│
├── Infrastructure/
│   └── CarBook.Persistence/         # Veri tabanı, Repository'ler ve Context
│
└── Presentation/
	└── CarBook.WebApi/              # REST API ve Controller'lar
```

### Katmanların Sorumlulukları

#### 📦 **Domain Katmanı** (CarBook.Domain)
- İş alanı varlıkları (Entities)
- Enum ve değer nesneleri
- Interface'ler ve soyut konseptler
- **Varlıklar:**
  - `Car`: Araç bilgileri
  - `Brand`: Araç markaları
  - `Category`: Araç kategorileri
  - `Pricing`: Fiyatlandırma modları
  - `RentACar`: Kiralama işlemleri
  - `Reservation`: Rezervasyonlar
  - `Blog`: Blog yazıları
  - `Author`: Blog yazarları
  - `Comment`: Yazılara yapılan yorumlar
  - `Review`: Araç değerlendirmeleri
  - `Customer`: Müşteri bilgileri
  - `Feature`: Araç özellikleri
  - Ve daha fazlası...

#### 🔧 **Application Katmanı** (CarBook.Application)
- İş kuralları ve iş mantığı
- **CQRS Handlers**: Komutlar ve sorgular için handler'lar
  - Read Handler'ları (Veri okuma)
  - Write Handler'ları (Veri yazma/güncelleme)
- **MediaR Handlers**: MediaR pattern'ı ile istek işleme
- Service'ler ve tool'lar
- DTO'lar (Veri Transfer Object'ler)
- AutoMapper konfigürasyonları

#### 💾 **Persistence Katmanı** (CarBook.Persistence)
- Entity Framework Core DbContext
- Repository ve Generic Repository implementasyonları
- Veri tabanı tabloları ve ilişkilendirmeler
- Veri tabanı migration'ları
- Seed data'lar

#### 🌐 **WebUI Katmanı** (CarBook.WebUI - Razor Pages)
- Razor Pages ve Views
- Controllers
- Areas (Admin paneli gibi)
- Static dosyalar (CSS, JavaScript, resimler)
- **Sayfalar:**
  - Anasayfa (Home)
  - Araç Listeleri (Car)
  - Kiralama (RentACar, Reservation)
  - Blog (Blog, BlogDetail)
  - Hizmetler (Service)
  - İletişim (Contact)
  - Hakkında (About)
  - Admin Alanı (AdminCar, AdminBrand, AdminFeature, vb.)

#### 📡 **WebApi Katmanı** (CarBook.WebApi)
- REST API Endpoints
- Controller'lar
- Veri doğrulama
- Hata yönetimi
- JWT token işlemleri

---

## 💻 Teknoloji Stack'i

### Backend Technologies
| Teknoloji | Versiyon | Amaç |
|-----------|---------|------|
| **.NET** | 8.0 | Framework |
| **ASP.NET Core** | 8.0 | Web framework |
| **Entity Framework Core** | 8.x | ORM |
| **MediatR** | Latest | Command/Query handler'ları |
| **AutoMapper** | Latest | DTO mapping |
| **JWT** | Latest | Kimlik doğrulama |
| **SignalR** | 8.x | Real-time iletişim |

### Frontend Technologies
| Teknoloji | Amaç |
|-----------|------|
| **Razor Pages** | Sayfa şablonları |
| **HTML5** | Yapı |
| **CSS3** | Stil |
| **Bootstrap** | Responsive tasarım |
| **JavaScript** | Etkileşim |

### Database
- **SQL Server** / **PostgreSQL** (yapılandırılabilir)
- Entity Framework Core ile yönetilir

---

## 🚀 Başlangıç

### Prerequisites
- .NET 8 SDK yüklü
- Visual Studio 2026 Community veya daha yeni
- SQL Server Express veya PostgreSQL
- Git

### Kurulum Adımları

1. **Repository'yi klonlayın:**
   ```bash
   git clone https://github.com/ComputerUni/BookCar-OnionArchitecture.git
   cd CarBook
   ```

2. **Solution'u açın:**
   ```bash
   Visual Studio 2026'da CarBook.slnx dosyasını açın
   ```

3. **Bağımlılıkları yükleyin:**
   ```bash
   NuGet Package Manager Console'dan tüm paketleri restore edin
   veya
   dotnet restore komutunu çalıştırın
   ```

4. **Veritabanını yapılandırın:**
   - `appsettings.json` dosyasında connection string'i düzenleyin
   - Package Manager Console'dan migration'ları uygulayın:
   ```bash
   Update-Database
   ```

5. **Projeyi çalıştırın:**
   ```bash
   WebUI ve WebApi proyelerını başlat (F5)
   ```

6. **Tarayıcıda açın:**
   - WebUI: `https://localhost:7001`
   - WebApi: `https://localhost:7002`

---

## 📸 Ekran Görüntüleri

### 🏠 Anasayfa
![Anasayfa](./screenshots/Ekran%20görüntüsü%202026-10-10%20192446.png)

### 🚗 Müşteriler
![Müşteriler](./screenshots/Ekran%20görüntüsü%202026-10-10%20192508.png)

### 📋 Araç Detayları
![Araç Detayları](./screenshots/Ekran%20görüntüsü%202026-10-10%20192536.png)

### 🎯 Kiralama İşlemi
![Kiralama İşlemi](./screenshots/Ekran%20görüntüsü%202026-10-10%20192552.png)

### 💳 Blog Detay
![Blog Detay](./screenshots/Ekran%20görüntüsü%202026-10-10%20192759.png)

### 👨‍💼 Blog Yorumlar
![Blog Yorumlar](./screenshots/Ekran%20görüntüsü%202026-10-10%20192823.png)

### 🏷️ Rezervasyon
![Rezervasyon](./screenshots/Ekran%20görüntüsü%202026-10-10%20192956.png)

### ✍️ Dashboard
![Dashboard](./screenshots/Ekran%20görüntüsü%202026-10-10%20193011.png)

### 📝 Arabalar
![Arabalar](./screenshots/Ekran%20görüntüsü%202026-10-10%20193046.png)

### 💬 Yazarlar
![Yazarlar](./screenshots/Ekran%20görüntüsü%202026-10-10%20193101.png)

### ⭐ Bloglar
![Bloglar](./screenshots/Ekran%20görüntüsü%202026-10-10%20193113.png)

### 📞 Referanslar
![Referanslar](./screenshots/Ekran%20görüntüsü%202026-10-10%20193148.png)

---

## 🔐 Kimlik Doğrulama ve Yetkilendirme

### Kullanıcı Rolleri
- **Admin**: Tüm sistem yönetimi
- **User**: Araç kiralama ve yorum yapma

### JWT Token Flow
1. Kullanıcı giriş yapar
2. Server JWT token oluşturur
3. Token cookie'ye kaydedilir
4. İsteklerde otomatik olarak gönderilir
5. Servertoken'ı doğrular

### Güvenlik Ayarları
```csharp
opt.LoginPath = "/Login/Index";
opt.LogoutPath = "/Login/Logout";
opt.AccessDeniedPath = "/Pages/AccessDenied";
opt.Cookie.SameSite = SameSiteMode.Strict;
opt.Cookie.HttpOnly = true;
opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
opt.Cookie.Name = "CarBookJwt";
```

---

## 📊 Veri Tabanı Şeması

### Ana Tablolar

**Cars** (Araçlar)
- CarID, Brand, Model, CoverImageUrl, Km, Transmission, FuelType, ModelYear, DailyPrice

**Brands** (Markalar)
- BrandID, BrandName

**Pricing** (Fiyatlandırma)
- PricingID, Name, Description

**Reservations** (Rezervasyonlar)
- ReservationID, CarID, CustomerID, StartDate, EndDate, Status

**Blogs** (Blog Yazıları)
- BlogID, Title, Content, AuthorID, CreatedDate, CoverImageUrl

**Comments** (Yorumlar)
- CommentID, BlogID, UserID, Text, CreatedDate

**Reviews** (Değerlendirmeler)
- ReviewID, CarID, UserID, Rating, Comment, CreatedDate

**AppUsers** (Kullanıcılar)
- UserID, FirstName, LastName, Email, PhoneNumber, Password

Ve daha fazlası...

---

## 🔄 İş Akışları

### Araç Kiralama Akışı
```
1. Araç Seçilir → 2. Tarih Belirlenir → 3. Müşteri Bilgileri → 
4. Fiyat Hesaplanır → 5. Ödeme → 6. Rezervasyon Doğrulanır → 
7. Kiralama Başlar
```

### Admin Yönetimi Akışı
```
1. Admin Paneline Giriş → 2. İçerik Yönetimi → 
3. Değişiklikleri Kaydet → 4. Sistem Güncellenir
```

---

## 🛠️ Geliştirme Rehberi

### Yeni Feature Ekleme Adımları

1. **Entity Oluştur** (`CarBook.Domain/Entities/`)
   ```csharp
   public class YeniVarlik
   {
	   public int Id { get; set; }
	   public string Ad { get; set; }
	   // Özellikler...
   }
   ```

2. **DbContext'e Ekle** (`CarBook.Persistence/Context/CarBookContext.cs`)
   ```csharp
   public DbSet<YeniVarlik> YeniVarliklar { get; set; }
   ```

3. **Repository Arabirimi Oluştur** (`CarBook.Application/Interfaces/`)
   ```csharp
   public interface IYeniVarlikRepository : IRepository<YeniVarlik>
   {
	   // Custom methodlar...
   }
   ```

4. **Repository Implementasyonu** (`CarBook.Persistence/Repositories/`)
   ```csharp
   public class YeniVarlikRepository : IRepository<YeniVarlik>, IYeniVarlikRepository
   {
	   // Implementasyon...
   }
   ```

5. **CQRS Handler'ları Yaz** (`CarBook.Application/Features/`)
   - Create Command & Handler
   - Update Command & Handler
   - Delete Command & Handler
   - Get Query & Handler

6. **API Controller Oluştur** (`CarBook.WebApi/Controllers/`)
   ```csharp
   [ApiController]
   [Route("api/[controller]")]
   public class YeniVarlikController : ControllerBase
   {
	   // Endpoint'ler...
   }
   ```

7. **UI Sayfaları Oluştur** (`CarBook.WebUI/Areas/Admin/Views/`)
   - Index (List)
   - Create
   - Edit
   - Delete

8. **Test Et** ve Veritabanına Migration'ı çalıştır

---
---

## 📖 API Endpoints Örnekleri

### Araçlar
```
GET    /api/cars              - Tüm araçları listele
GET    /api/cars/{id}         - Araç detaylarını al
POST   /api/cars              - Yeni araç ekle
PUT    /api/cars/{id}         - Araç güncelle
DELETE /api/cars/{id}         - Araç sil
```

### Markalar
```
GET    /api/brands            - Tüm markaları listele
POST   /api/brands            - Yeni marka ekle
PUT    /api/brands/{id}       - Marka güncelle
DELETE /api/brands/{id}       - Marka sil
```

### Değerlendirmeler
```
GET    /api/reviews               - Tüm yorumları listele
GET    /api/reviews/car/{carId}   - Araçın yorumlarını al
POST   /api/reviews               - Yeni yorum ekle
```

### Blog
```
GET    /api/blogs             - Blog yazılarını listele
GET    /api/blogs/{id}        - Blog detayını al
POST   /api/blogs             - Yeni blog yazı ekle
DELETE /api/blogs/{id}        - Blog yazısını sil
```

---

## 🔗 Proje Bağımlılıkları

### NuGet Paketleri (Ana Paketler)
- `Microsoft.EntityFrameworkCore`
- `Microsoft.EntityFrameworkCore.SqlServer`
- `MediatR`
- `Microsoft.AspNetCore.Authentication.JwtBearer`
- `System.IdentityModel.Tokens.Jwt`
- `Microsoft.AspNetCore.SignalR`

Tüm paketler `appsettings.json` ve proje dosyaları içinde yapılandırılmıştır.


## 📋 Kullanılan Design Pattern'lar

| Pattern | Kullanım Alanı |
|---------|-----------------|
| **Onion Architecture** | Genel proje mimarisi |
| **Repository Pattern** | Veri erişim katmanı |
| **CQRS** | İş kuralları ve handler'lar |
| **Dependency Injection** | Bağımlılık yönetimi |
| **Mediator Pattern** | İstek işleme (MediatR) |
| **DTO Pattern** | Katmanlar arası veri transferi |
| **Factory Pattern** | Nesne oluşturma |
| **Adapter Pattern** | Farklı sistemlerin entegrasyonu |

---



