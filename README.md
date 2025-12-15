# Tren Bileti Sistemi - SQLite Kurulum Talimatlarý

## SQLite Kurulumu

### Yöntem 1: NuGet Package Manager ile (Önerilen)

1. Visual Studio'da projeye sað týklayýn
2. "Manage NuGet Packages" seçin
3. "Browse" sekmesine týklayýn
4. Arama kutusuna "System.Data.SQLite" yazýn
5. "System.Data.SQLite.Core" paketini bulun (Version 1.0.118)
6. "Install" butonuna týklayýn

### Yöntem 2: Package Manager Console ile

Visual Studio'da Tools > NuGet Package Manager > Package Manager Console açýn ve þu komutu çalýþtýrýn:

```
Install-Package System.Data.SQLite.Core -Version 1.0.118
```

### Yöntem 3: Manuel Kurulum

1. https://system.data.sqlite.org/index.html/doc/trunk/www/downloads.wiki adresinden indirin
2. "Precompiled Binaries for .NET Framework 4.7.2" bölümünden uygun paketi indirin
3. System.Data.SQLite.dll dosyasýný projeye referans olarak ekleyin

## Giriþ Bilgileri

**Kullanýcý Giriþi:**
- Kullanýcý Adý: kullanici
- Þifre: 123

**Admin Giriþi:**
- Kullanýcý Adý: admin
- Þifre: admin123

## Özellikler

- Tren sefer arama ve listeleme
- Bilet satýn alma
- Bilet iptal etme
- Admin panelinde tren ekleme
- Satýþ istatistikleri
- SQLite veritabaný entegrasyonu

## Veritabaný

Proje ilk çalýþtýrýldýðýnda otomatik olarak "TrenBileti.db" dosyasý oluþturulur.
Veritabanýnda 2 tablo bulunur:
- Trenler (Tren bilgileri)
- Biletler (Satýlan biletler)
