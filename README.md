# 🏭 SmartInventory API

## Akıllı Cihaz ve Sensör Takip Sistemi

SmartInventory API, IoT cihazlarının envanter takibini yapan ve simüle
edilmiş sensör verilerini **gerçek zamanlı (real-time)** olarak
istemcilere ileten, **.NET 8** tabanlı bir backend API projesidir.

Sistem, cihaz yönetimi, canlı sensör verisi akışı ve otomatik alarm
üretimi gibi özellikleri tek bir servis altında sunar.

------------------------------------------------------------------------

## 🚀 Özellikler

### ✅ Cihaz Yönetimi (CRUD)

-   Cihaz ekleme
-   Cihaz güncelleme
-   Cihaz silme
-   Cihaz listeleme

### 📡 Anlık Veri Akışı (SignalR)

-   WebSocket üzerinden istemcilere canlı sıcaklık verisi gönderimi
-   Frontend uygulamalar gerçek zamanlı veri alabilir

### ⚙️ Arka Plan Sensör Servisi

-   `SensorBackgroundService` her **5 saniyede bir** sensör verisi
    üretir
-   Sensör verisi simüle edilerek sistemde dolaştırılır

### 🚨 Otomatik Alarm Sistemi

-   Sıcaklık **80°C üzerine çıktığında**
-   Otomatik olarak veritabanına alarm kaydı oluşturulur

### 🐳 Dockerize Mimari

-   API ve PostgreSQL Docker konteynerleri içinde çalışır
-   Ortam kurulumu minimum gereksinimle yapılır

------------------------------------------------------------------------

## 🛠 Kullanılan Teknolojiler

-   .NET 8 Web API
-   Entity Framework Core
-   PostgreSQL
-   SignalR
-   Docker
-   Docker Compose

------------------------------------------------------------------------

## ⚙️ Kurulum ve Çalıştırma

Projeyi çalıştırmak için yalnızca **Docker** kurulu olması yeterlidir.

.NET SDK veya PostgreSQL kurmanız gerekmez.

------------------------------------------------------------------------

### 1️⃣ Projeyi Klonlayın

Terminal veya komut satırında:

``` bash
git clone https://github.com/KULLANICI_ADIN/SmartInventoryAPI.git
cd SmartInventoryAPI
```

### 2️⃣ Docker ile Projeyi Ayağa Kaldırın

Terminal veya komut satırında:

``` bash
docker-compose up -d --build
```

### 3️⃣ API'yi Test Edin

Servisler ayağa kalktıktan sonra tarayıcıdan aşağıdaki adresleri
kullanarak API'yi test edebilirsiniz:

  Servis                         Adres
  ------------------------------ -----------------------------------
  Swagger (API Dokümantasyonu)   http://localhost:5113/swagger
  Cihaz API                      http://localhost:5113/api/devices
  SignalR Hub                    http://localhost:5113/sensorHub

Swagger arayüzü üzerinden tüm endpointleri doğrudan test edebilirsiniz.

------------------------------------------------------------------------

## 📝 API Endpointleri

  Metot    Endpoint            Açıklama
  -------- ------------------- -----------------------------
  GET      /api/devices        Tüm cihazları listeler
  GET      /api/devices/{id}   Tek cihaz getirir
  POST     /api/devices        Yeni cihaz ekler
  PUT      /api/devices/{id}   Cihaz bilgilerini günceller
  DELETE   /api/devices/{id}   Cihazı siler

------------------------------------------------------------------------

## ⚠️ Geliştirici Notları

### Veritabanı Bağlantısı

Docker ortamında PostgreSQL servisi `db` adıyla çalışmaktadır.

Connection string Docker içinde şu şekilde ayarlanmıştır:

    Host=db

------------------------------------------------------------------------

### Sensör Simülasyonu

Arka plan servisi çalıştığı sürece:

-   Her 5 saniyede bir sıcaklık verisi üretilir
-   Üretilen veri SignalR üzerinden istemcilere gönderilir
-   Sıcaklık 80°C üstüne çıkarsa `AlarmLogs` tablosuna otomatik kayıt
    eklenir

------------------------------------------------------------------------

## 📁 Proje Klasör Yapısı (Özet)

    SmartInventoryAPI
    │
    ├── Controllers
    ├── Models
    ├── Data
    ├── Hubs
    ├── Services
    ├── BackgroundServices
    ├── docker-compose.yml
    └── Dockerfile

------------------------------------------------------------------------

## 📌 Katkı Sağlama

Projeye katkıda bulunmak isteyenler pull request gönderebilir veya issue
açabilir.
