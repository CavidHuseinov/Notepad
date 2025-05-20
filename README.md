Əlbəttə, aşağıdakı ingiliscə versiyasıdır. GitHub `README.md` üçün tam uyğundur:

---

# 📝 Notepad API

This project is an ASP.NET Core Web API application designed for creating, viewing, deleting, and encrypting personal notes.

## 🏗 Layers

The project is structured using a 5-layer architecture:

| Layer                      | Description                                                    |
| -------------------------- | -------------------------------------------------------------- |
| **Notepad.Core**           | Entity models and configuration classes                        |
| **Notepad.DAL**            | DbContext, Repository pattern, and Unit of Work implementation |
| **Notepad.Business**       | Business logic and DTOs                                        |
| **Notepad.Infrastructure** | Background jobs and additional infrastructure components       |
| **Notepad.WebAPI**         | API endpoints, Swagger, and the application’s entry point      |

---

## 🚀 Technologies

* **.NET 8.0**
* **Entity Framework Core**
* **AutoMapper**
* **FluentValidation**
* **Hangfire** – for background jobs
* **Swagger (Swashbuckle)** – for API documentation

---

## ⚙️ Core Features

* ✅ Create a note (`POST /api/note/create`)
* 🔒 View encrypted note (`GET /api/note/secure/{id}?password=xyz`)
* 📋 View all notes (`GET /api/note`)
* 🗑 Delete a note (`DELETE /api/note/delete/{id}`)
* 🔁 Automatically delete old notes (older than 1 month) via background job

---

## 🧠 Architecture & Design

* **Repository Pattern** – to abstract data access logic
* **Unit of Work** – to manage database transactions
* **AutoMapper** – to map between entities and DTOs
* **FluentValidation** – to validate models
* **Hangfire** – runs `DeleteOldNotes()` daily in the background
* **Options Pattern** – used for `Link` configuration

---

## 🔐 Note Encryption System

* Uses `PasswordHasher<T>` to hash passwords when creating secure notes
* Password is validated when accessing secure notes
* If `Note.SecureStatus == true`, access requires a valid password

---

## 🔄 Hangfire Dashboard

You can access the Hangfire dashboard at:

👉 [https://notepadbackend.cavidhuseynov.me/hangfire/notepad/secret](https://notepadbackend.cavidhuseynov.me/hangfire/notepad/secret)

> The dashboard is publicly accessible, but protected by `AllowAllUserDashboard` middleware.

---

## 🧪 Swagger

Swagger UI is enabled and can be accessed via `/swagger`.

---

## 📦 NuGet Packages

Some key NuGet packages used:

* `AutoMapper`
* `Microsoft.AspNetCore.Identity`
* `FluentValidation`
* `Hangfire`
* `Microsoft.EntityFrameworkCore`
* `Swashbuckle.AspNetCore`

---

## 🧑‍💻 Getting Started

```bash
git clone <repo-link>
cd Notepad.WebAPI
dotnet run
```

> Don't forget to configure `Link` and `ConnectionString` inside your `appsettings.json`.

---

Hazır README'dir, birbaşa GitHub-a yükləyə bilərsən. İstəyirsənsə badge, deploy və ya Docker bölmələri də əlavə edə bilərəm. Devam! 💪
