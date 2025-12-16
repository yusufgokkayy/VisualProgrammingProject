# Ýstatistik Sistemi Eklendi - Tren Bileti Sistemi

## ?? Yeni Özellikler

Admin paneline **Ýstatistikler** butonu ve sayfasý eklendi. Bu sayede admin kullanýcýlarý sistem istatistiklerini görsel pie chart'lar ile görebilir.

### ?? Ýstatistik Grafikleri

1. **Varýþ Þehrine Göre Satýþlar**
   - En çok bilet satýlan 5 þehri gösterir
   - Pie chart formatýnda görselleþtirilir
   - Her þehir için bilet sayýsý ve yüzdesi gösterilir

2. **Günlük Bilet Satýþ Daðýlýmý**
   - Hangi günlerde kaç bilet satýldýðýný gösterir
   - Tarih bazlý daðýlým sunar
   - Pie chart ile görselleþtirilir

3. **Trenlere Göre Gelir Daðýlýmý**
   - En çok gelir getiren 6 treni gösterir
   - Her tren için toplam gelir (?) gösterilir
   - Pie chart ile görselleþtirilir

### ?? Genel Ýstatistikler

Ýstatistik sayfasýnda aþaðýdaki özet bilgiler de gösterilir:
- ?? **Toplam Bilet Sayýsý**
- ?? **Toplam Gelir (?)**
- ?? **Ortalama Bilet Fiyatý (?)**

## ?? Eriþim

Bu özellik **yalnýzca admin** kullanýcýlarý tarafýndan görülebilir ve kullanýlabilir.

### Admin Giriþi
- **Kullanýcý Adý:** `admin`
- **Þifre:** `admin123`

## ?? Özellikler

- ? Renkli pie chart grafikleri
- ? Otomatik yüzde hesaplamalarý
- ? Legend (açýklama) panelleri
- ? Responsive görünüm
- ? Profesyonel renk paleti
- ? Kullanýcý dostu arayüz

## ?? Kullaným

1. Admin olarak giriþ yapýn (`admin` / `admin123`)
2. Admin Paneli'nde alttaki **"?? Ýstatistikler"** butonuna týklayýn
3. Tüm istatistikleri göreceksiniz
4. "Kapat" butonu ile paneli kapatabilirsiniz

## ?? Teknik Detaylar

- Manuel pie chart çizimi (GDI+ kullanýlarak)
- .NET Framework 4.7.2 uyumlu
- Harici kütüphane gerektirmez
- Performanslý ve hafif
- SQLite veritabaný entegrasyonu

## ?? Ýstatistik Kriterleri

- **Þehir grafiði:** Top 5 varýþ noktasý
- **Günlük grafik:** Tüm günler
- **Tren grafiði:** Top 6 gelir getiren tren
- Tüm veriler veritabanýndan gerçek zamanlý çekilir

---

**Not:** Ýstatistiklerin görülebilmesi için sistemde bilet satýþý olmasý gerekir. Test için normal kullanýcý hesabýyla (`kullanici` / `123`) bilet satýn alabilirsiniz.
