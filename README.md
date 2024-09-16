# CarBook - Araç Kiralama Sitesi

CarBook is a car rental system that allows users to view and book available vehicles based on their location. This project leverages modern technologies and architectural patterns to provide a robust and scalable solution.

## Proje Tanımı

Kullanıcılar, alacakları lokasyona göre uygun araçları listeleyebilir ve istedikleri araca ön kayıt oluşturarak aracı kiralayabilirler.

**Teknolojiler:**
- **ASP.NET Core 8.0**: Web API ve MVC kullanılarak geliştirilmiştir.
- **Entity Framework Code First**: Dinamik veritabanı yönetimi için kullanılmıştır.
- **Onion Architecture**: Projenin modüler ve sürdürülebilir olmasını sağlar.
- **CQRS, Mediator, Repository Design Patterns**: Kodun organizasyonunu ve sürdürülebilirliğini artırmak için uygulanmıştır.

## Kullanılan Teknolojiler

### Frontend
- **HTML**
- **CSS**
- **Bootstrap**
- **JavaScript**

### Backend
- **C#**
- **ASP.NET Core 8.0**
- **ASP.NET Web API**
- **Entity Framework Code First**
- **MSSQL**
- **SignalR**
- **Json Web Token (JWT)**
- **MailKit**
- **FluentValidation**

## Özellikler

- **Araç Listeleme ve Kiralama**: Uygun lokasyona göre müsait araçları listeleme ve kiralama imkanı.
- **Araç Detayları**: Araçların detaylarını görüntüleme.
- **Araç Özellikleri**: Araçlara özellik atama.
- **Admin Panel**: Yöneticiler için özel bir panel.
- **Canlı Veri Takibi**: SignalR ile canlı veri güncellemeleri.
- **Güvenlik**: Json Web Token ile güvenli kimlik doğrulama.
- **İstatistikler**: Araç ve kullanıcı istatistikleri.
- **Mail Gönderme**: MailKit kullanarak kullanıcılarla iletişim.
- **Validation Kontrolleri**: FluentValidation ile form doğrulama.

## Teknik Özellikler

- **MSSQL Veritabanı**: Veritabanı yönetimi için kullanılmıştır.
- **Onion Mimari**: Projenin modülerliğini sağlar.
- **CQRS, Mediator, Repository Design Patterns**: Kodun yönetimini ve sürdürülebilirliğini artırır.
- **SignalR**: Canlı veri akışı sağlar.
- **LINQ**: Entity Framework Code First ile veritabanı sorguları.

## Kurulum

1. **Projeyi Klonlayın:**

   ```bash
   git clone https://github.com/username/carbook.git
