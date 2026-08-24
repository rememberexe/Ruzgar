# 🌤️ Rüzgar

**Rüzgar**, modern, sade ve premium bir kullanıcı deneyimi sunmayı amaçlayan hava durumu uygulamasıdır.

Anlık hava durumunu, saatlik ve günlük tahminleri, favori şehirleri ve hava koşullarına göre değişen görsel arayüzü tek bir uygulamada bir araya getirir.

> 🌬️ **Havayı önceden hisset.**

---

## ✨ Özellikler

* 🌡️ **Anlık hava durumu**

  * Sıcaklık
  * Hissedilen sıcaklık
  * Nem
  * Rüzgar
  * Hava durumu açıklaması

* 🕐 **Saatlik hava tahmini**

  * 12 saate kadar tahmin
  * Sıcaklık
  * Hava durumu ikonu
  * Yağış ihtimali

* 📅 **Günlük hava tahmini**

  * 7 günlük tahmin
  * Günlük sıcaklık aralığı
  * Hava durumu bilgileri

* ⭐ **Favori şehirler**

  * Şehirleri favorilere ekleme
  * Favori şehirlerde mini hava durumu
  * Favoriler arasında hızlı geçiş
  * Favori şehirleri kaldırma

* 🔎 **Şehir arama**

  * Şehir adına göre arama
  * Ülke ve bölge bilgileri
  * Arama sonuçlarından doğrudan hava durumuna geçiş

* 🕘 **Şehir arama geçmişi**

  * Son aranan şehirleri saklama
  * Geçmiş şehirlerden hızlıca hava durumuna geçme
  * Arama geçmişini temizleme

* 📍 **Varsayılan şehir**

  * Uygulama açılışında kullanılacak şehir
  * Ayarlardan değiştirilebilir

* 🎨 **Dinamik hava durumu arayüzü**

  * Hava durumuna göre değişen arka plan efektleri
  * Güneş
  * Bulut
  * Yağmur
  * Kar
  * Sis
  * Fırtına efektleri

* 📊 **Detaylı hava durumu**

  * Günlük analiz
  * UV bilgisi
  * Görüş mesafesi
  * Basınç
  * Rüzgar yönü
  * Gün doğumu / gün batımı
  * Hissedilen sıcaklık analizi

* 👕 **Günlük öneriler**

  * Kıyafet önerisi
  * Şemsiye önerisi
  * Dışarı çıkma önerisi
  * UV ve hava koşullarına göre kısa yorumlar

* 🚀 **Premium giriş deneyimi**

  * Splash screen
  * Uygulama tanıtımı
  * Açılış animasyonları
  * Tanıtımı tekrar görüntüleme

* ⚙️ **Ayarlar**

  * Fahrenheit / Celsius
  * Varsayılan şehir
  * Konum kullanımı
  * Dinamik tema
  * Favorileri yönetme

* ℹ️ **Hakkında sayfası**

  * Uygulama bilgileri
  * Sürüm bilgisi
  * Özellikler
  * Tanıtımı tekrar başlatma

---

## 🛠️ Teknolojiler

Rüzgar aşağıdaki teknolojiler kullanılarak geliştirilmektedir:

* **C#**
* **.NET 10**
* **.NET MAUI**
* **XAML**
* **MVVM**
* **CommunityToolkit.Mvvm**
* **Newtonsoft.Json**
* **Android**
* **Windows**

---

## 📱 Platformlar

| Platform | Durum |
| -------- | ----- |
| Android  | ✅     |
| Windows  | ✅     |
| iOS      | 🚧    |
| macOS    | 🚧    |

Android tarafında uygulama **APK** olarak derlenebilir.

---

## 🎨 Tasarım

Rüzgar'ın tasarımında:

* Koyu arayüz
* Glassmorphism
* Gradient efektleri
* Yuvarlatılmış kartlar
* Akıcı animasyonlar
* Minimal ikon kullanımı
* Hava durumuna göre dinamik görseller

ön planda tutulmuştur.

Amaç yalnızca çalışan bir hava durumu uygulaması değil, **kullanırken keyif veren modern bir mobil uygulama deneyimi** oluşturmaktır.

---

## 🧩 Proje Yapısı

```text
Ruzgar/
│
├── Models/
│   ├── AppSettings.cs
│   ├── FavoriteCity.cs
│   ├── CitySearchResult.cs
│   └── ...
│
├── Services/
│   ├── WeatherService.cs
│   ├── SettingsService.cs
│   ├── FavoriteCityService.cs
│   ├── CitySearchService.cs
│   ├── SearchHistoryService.cs
│   └── ...
│
├── ViewModels/
│   └── HomeViewModel.cs
│
├── Platforms/
│   ├── Android/
│   └── Windows/
│
├── Resources/
│   ├── AppIcon/
│   ├── Splash/
│   ├── Images/
│   ├── Fonts/
│   └── Raw/
│
├── MainPage.xaml
├── SettingsPage.xaml
├── AboutPage.xaml
├── SplashIntroPage.xaml
└── Ruzgar.csproj
```

---

## 🚀 Kurulum

### Gereksinimler

Projeyi geliştirmek için:

* .NET 10 SDK
* Visual Studio 2026
* .NET MAUI workload
* Android SDK

gereklidir.

### Projeyi klonlama

```bash
git clone https://github.com/yusufarday83/Ruzgar.git
cd Ruzgar
```

### Android için derleme

```bash
dotnet build -f net10.0-android
```

### Windows için derleme

```bash
dotnet build -f net10.0-windows10.0.19041.0
```

---

## 📦 APK Oluşturma

Release APK oluşturmak için:

```bash
dotnet publish Ruzgar.csproj ^
    -f net10.0-android ^
    -c Release ^
    -p:AndroidPackageFormat=apk ^
    -p:RuntimeIdentifier=android-arm64
```

Oluşturulan APK, projenin `bin/Release` klasörü altında bulunabilir.

> Release dağıtımı için kendi Android keystore'unuzu kullanmanız önerilir.

---

## 🔐 Gizlilik

Rüzgar'ın temel amacı hava durumu verilerini kullanıcıya sade bir şekilde sunmaktır.

Kullanıcı ayarları ve yerel tercihler cihaz üzerinde saklanır.

Konum özelliği kullanıldığında cihazın konum izinleri Android tarafından yönetilir.

---

## 🗺️ Yol Haritası

* [x] Anlık hava durumu
* [x] Saatlik tahmin
* [x] Yağış ihtimali
* [x] 7 günlük tahmin
* [x] Favori şehirler
* [x] Varsayılan şehir
* [x] Şehir arama
* [x] Şehir arama geçmişi
* [x] Hava durumuna göre arka plan efektleri
* [x] Detaylı hava durumu sayfası
* [x] Splash / onboarding
* [x] Hakkında sayfası
* [x] Dinamik tema
* [ ] Gelişmiş hava durumu uyarıları
* [ ] Daha gelişmiş animasyonlar
* [ ] Widget desteği
* [ ] Bildirim sistemi
* [ ] Daha gelişmiş konum özellikleri
* [ ] iOS desteği
* [ ] macOS desteği

---

## 📸 Ekran Görüntüleri

<img width="1220" height="2712" alt="Screenshot_2026-08-24-14-30-15-110_com yusufarday83 ruzgar" src="https://github.com/user-attachments/assets/5e1eb2cb-69f1-4540-8214-7e408836e127" />
<img width="1220" height="2712" alt="Screenshot_2026-08-24-14-30-18-099_com yusufarday83 ruzgar" src="https://github.com/user-attachments/assets/80236a7e-97ea-471a-a3f4-16c77e50b616" />
<img width="1220" height="2712" alt="Screenshot_2026-08-24-14-30-20-426_com yusufarday83 ruzgar" src="https://github.com/user-attachments/assets/796e97e6-fc0d-489c-8588-b13b72c3e6ff" />
<img width="1220" height="2712" alt="Screenshot_2026-08-24-14-30-24-891_com yusufarday83 ruzgar" src="https://github.com/user-attachments/assets/a42cb437-1209-4a14-9412-ee931a95148c" />
<img width="1220" height="2712" alt="Screenshot_2026-08-24-14-30-27-250_com yusufarday83 ruzgar" src="https://github.com/user-attachments/assets/35226e47-824c-43f1-b661-eca59bbbf699" />
<img width="1220" height="2712" alt="Screenshot_2026-08-24-14-30-28-989_com yusufarday83 ruzgar" src="https://github.com/user-attachments/assets/a8f88ae3-41f0-4bf7-b6e5-80e995b5d8cd" />
<img width="1220" height="2712" alt="Screenshot_2026-08-24-14-30-35-846_com yusufarday83 ruzgar" src="https://github.com/user-attachments/assets/6f43ac18-2614-4d47-82ab-b80c6682b734" />
<img width="1220" height="2712" alt="Screenshot_2026-08-24-14-30-37-410_com yusufarday83 ruzgar" src="https://github.com/user-attachments/assets/0f8a0a8a-99e9-48ec-b921-e03564af42e4" />
<img width="1220" height="2712" alt="Screenshot_2026-08-24-14-30-42-099_com yusufarday83 ruzgar" src="https://github.com/user-attachments/assets/327b5d7b-732f-46b0-9344-bd15b0f5e70f" />
<img width="1220" height="2712" alt="Screenshot_2026-08-24-14-31-09-412_com yusufarday83 ruzgar" src="https://github.com/user-attachments/assets/f5d850fb-44ed-457c-9e28-3c4849635210" />

---

## 👨‍💻 Geliştirici

**Yusuf Arda Yılmaz**

Rüzgar, modern mobil uygulama geliştirme, .NET MAUI ve C# teknolojilerini öğrenmek ve gerçek bir proje üzerinde geliştirmek amacıyla oluşturulmaktadır.

---

## 📄 Lisans

Bu proje şu anda kişisel geliştirme ve öğrenme amacıyla kullanılmaktadır.

Lisanslama durumu ilerleyen süreçte belirlenecektir.

---

⭐ Projeyi beğendiyseniz GitHub'da yıldız bırakabilirsiniz.

**Rüzgar — Havayı önceden hisset.**
